/*Programa que incluye el módulo DTMF 8870 para el software REKOR y el RFID para el módulo de entrada,
esta es la primera versión BETA que integra el shield para el módulo y el RFID, 
monitorea a través de una interrupción el Std del circuito que se dipara cuando recibe un tono válido del teléfono,
al activarse la interrupción manda a llamar a una función que se encarga de recibir los estados Q4, Q3, Q2, Q1 
del módulo y traducirlos a dígitos decimales para después mandárlos por el puerto serial en forma de cadena; 
Para indicar que el módulo está funcionando se cuenta con dos leds, uno para el Std del CMD8870, 
el cual se activa cada vez que recibe un tono válido y otro que es un led que se mantiene parpadeando indicando 
así que el Arduino está en escucha.

En la parte del RFID, el programa original espera hasta recibir el caracter en ASCII "#" para poder leer cualquier
TAG que se encuentre dentro del área de la antena, al leerlo manda através del puerto serial el número de serie del 
TAG encontrado. Para esta versión del programa eperaremos hasta que se cumpla la rutina del DTMF, después de mandar
el caracter recibido por el teléfono entraremos en una rutina que esperará hasta recibir el código del bóton "GRABAR" 
del software Rekor, que en este caso es "#" en ASCII, después de recibirlo entonces leeremos el número serial del 
TAG y lo mandarémos por el puerto Serial.

 Conexiones Arduino UNO + Módulo 8870
 Pin 08 - Led Ready and Listen
 Pin 02 - CMD8870 Std (Pin 15) - Int.0 Arduino Uno
 Pin 03 - CMD8870 Q4  (Pin 14)
 Pin 04 - CMD8870 Q3  (Pin 13)
 Pin 05 - CMD8870 Q2  (Pin 12)
 Pin 06 - CMD8870 Q1  (Pin 11)
 
 ////// Una vez probado el programa comentar las líneas Debug. ////////
 
 Conexiones Arduino UNO + MF522
 Pin 10   - MF522 (Pin 8) - SS
 Pin 13   - MF522 (Pin 7) - SCK
 Pin 11   - MF522 (Pin 6) - MOSI
 Pin 12   - MF522 (Pin 5) - MISO
 GND      - MF522 (Pin 3) - GND
 Pin 09   - MF522 (Pin 2) - RST
 3.3V     - MF522 (Pin 1) - 3.3V
 
 *MF522 PIN 4 NO CONECTADO
 
 Realizado por: César López Cortés <cesarlopezcortes@me.com> (Abril / 2015)
 
 Copyright (C) <2015>  <César López Cortés>
 
   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.
 
   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.
 
 You should have received a copy of the GNU General Public License
 along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

 #include <SPI.h>

 //---------------------------------------------- DTMF -------------------------
 #define led_lst 8     //Led Ready and Listen
 #define std 0         //CMD8870 Std (Pin 15) - Int.0 Arduino Uno Pin 2 Arduino
 #define q4  3         //Pin 03 - CMD8870 Q4  (Pin 14)
 #define q3  4         //Pin 04 - CMD8870 Q3  (Pin 13)
 #define q2  5         //Pin 05 - CMD8870 Q2  (Pin 12)
 #define q1  6         //Pin 06 - CMD8870 Q1  (Pin 11)
 //---------------------------------------------- DTMF -------------------------
 
 //---------------------------------------------- RFID ---------------------------------------------
 #define chipSS 10  //Chip Select Pin
 #define rstPD 9    //Pin 5 Arduino conectado al Reset del módulo
 
 //MF522 Command word
 #define PCD_IDLE              0x00               //NO action; Cancel the current command
 #define PCD_AUTHENT           0x0E               //Authentication Key
 #define PCD_TRANSCEIVE        0x0C               //Transmit and receive data,
 #define PCD_RESETPHASE        0x0F               //Reset
 #define PCD_CALCCRC           0x03               //CRC Calculate

 // Mifare_One card command word
 # define PICC_REQIDL          0x26               // find the antenna area does not enter hibernation
 # define PICC_ANTICOLL        0x93               // anti-collision
 # define PICC_HALT            0x50               // Sleep
 
 //And MF522 The error code is returned when communication
 #define MI_OK                 0
 #define MI_NOTAGERR           1
 #define MI_ERR                2
  
 //------------------MFRC522 Register---------------
 //Page 0:Command and Status
 #define     CommandReg            0x01    
 #define     CommIEnReg            0x02    
 #define     CommIrqReg            0x04    
 #define     DivIrqReg             0x05
 #define     ErrorReg              0x06    
 #define     FIFODataReg           0x09
 #define     FIFOLevelReg          0x0A
 #define     ControlReg            0x0C
 #define     BitFramingReg         0x0D
 //Page 1:Command     
 #define     ModeReg               0x11
 #define     TxControlReg          0x14
 #define     TxAutoReg             0x15
 //Page 2:CFG    
 #define     CRCResultRegM         0x21
 #define     CRCResultRegL         0x22
 #define     TModeReg              0x2A
 #define     TPrescalerReg         0x2B
 #define     TReloadRegH           0x2C
 #define     TReloadRegL           0x2D
 //-----------------------------------------------
 #define uchar	unsigned char
 #define uint	unsigned int
 //Maximum length of the array
 #define MAX_LEN 16
 //---------------------------------------------- RFID ---------------------------------------------
 
 //Variables Globales
 volatile byte dtmf_tmp;    //Variable para leer el dato bit por bit del CMD8870, volatile para usarla dentro de la interrupción.
 volatile byte dtmf_dat;    //Variable para convertir el dato DTMF a decimal, volatile para usarla dentro de la interrupción.
 volatile boolean btnGrabarRkr;  //Variable tipo bandera se activa después de enviar el DTMF, volatile para usarla dentro de la interrupción
 
 //4 bytes card serial number, the first 5 bytes for the checksum byte
 uchar serNum[5];
 String code ="61"; //Código ASCII para el =  //"35";  //Código ASCII para el #
 String rekorCmd ="";
 
void setup()
{
  //Configuración E/S DTMF
   pinMode(led_lst, OUTPUT);
   pinMode(q4, INPUT);
   pinMode(q3, INPUT);
   pinMode(q2, INPUT);
   pinMode(q1, INPUT);
   //Interrupción
   attachInterrupt(std, read_dtmf, RISING);    //Int.0 llama a la función read_dtmf cuando va de LOW a HIGH
   
   //Iniciamos comunicación Serial
   Serial.begin(115200);
   //Iniciamos la comunicación SPI
   SPI.begin();
   
   //Iniciamos el MF522
   pinMode(chipSS, OUTPUT);
   digitalWrite(chipSS, LOW);
   pinMode(rstPD, HIGH);
   digitalWrite(rstPD, HIGH);
   
   //Iniciamos la configuración del MF522
   MFRC522_Init();
}

void loop()
{
  //Parpadeo led_lst
   digitalWrite(led_lst, HIGH);
//   delay(150);
//   digitalWrite(led_lst, LOW);
//   delay(150);
   
   //Dentro de un ciclo leemos el puerto serial en espera de recibir el comando para leer la tarjeta
   while(Serial.available() > 0)
   {
     //Guardamos los datos en la variable rekorCmd
     rekorCmd+=Serial.read();
   }
   //Comparamos la cadena recibida con el código pre establecido, true si son iguales.
   if(code == rekorCmd)
   {
     //Reiniciamos la variable del dato recibido para salir de la rutina.
     rekorCmd = "";
     //Llamamos a la rutina para obtener el Número Serial de la tarjeta y mandarlo por Serial.
     GrabarRFID();
     //Mostramos al usuario que el Serial del TAG ha sido enviado al Serial, parpadeando led_lst
     blnk_led();
   }
   //Reiniciamos la variable del dato en caso de recibir un dato no válido
   rekorCmd = "";
}
