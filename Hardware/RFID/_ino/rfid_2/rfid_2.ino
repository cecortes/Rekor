/*Programa que incluye el módulo RFID MF522 para el software REKOR, 
esta es la primera versión BETA que integra el módulo en el Arduino, sirve para probar la
lectura de una tarjeta RFID después de que esta se detecte por la antena. También se busca
simplificar la programación del mismo eliminando funciones o definiciones del mismo.
Las conexiones entre el módulo y Arduino se muestran a continuación.
 
 Conexiones Arduino UNO + MF522
 Pin 10   - MF522 (Pin 8) - SS
 Pin 13   - MF522 (Pin 7) - SCK
 Pin 11   - MF522 (Pin 6) - MOSI
 Pin 12   - MF522 (Pin 5) - MISO
 GND      - MF522 (Pin 3) - GND
 Pin 09   - MF522 (Pin 2) - RST
 3.3V     - MF522 (Pin 1) - 3.3V
 
 *MF522 PIN 4 NO CONECTADO
 
 Una vez probado el programa comentar las líneas Debug.
 
 Realizado por: César López Cortés <cesarlopezcortes@me.com> (Marzo / 2015)
 
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
 //4 bytes card serial number, the first 5 bytes for the checksum byte
 uchar serNum[5];
 String code ="35";  //Código ASCII para el #
 String rekorCmd ="";
 
 void setup()
 {
   //Iniciamos las comunicaciones seriales
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
   }
   //Reiniciamos la variable del dato en caso de recibir un dato no válido
   rekorCmd = "";
 }
