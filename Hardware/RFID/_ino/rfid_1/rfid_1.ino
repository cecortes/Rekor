/*Programa que incluye el módulo RFID MF522 para el software REKOR, 
esta es la primera versión BETA que integra el módulo en el Arduino, sirve para porobar la
lectura de una tarjeta RFID después de que se presione cualquier tecla en el monitor USB.
Las conexiones entre el módulo y Arduino se muestran a continuación.
 
 Conexiones Arduino UNO + MF522
 Pin 10   - MF522 (Pin 8) - SS
 Pin 13   - MF522 (Pin 7) - SCK
 Pin 11   - MF522 (Pin 6) - MOSI
 Pin 12   - MF522 (Pin 5) - MISO
 GND      - MF522 (Pin 3) - GND
 Pin 05   - MF522 (Pin 2) - RST
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
 #define rstPD 5    //Pin 5 Arduino conectado al Reset del módulo
 
 //MF522 Command word
 #define PCD_IDLE              0x00               //NO action; Cancel the current command
 #define PCD_AUTHENT           0x0E               //Authentication Key
 #define PCD_RECEIVE           0x08               //Receive Data
 #define PCD_TRANSMIT          0x04               //Transmit data
 #define PCD_TRANSCEIVE        0x0C               //Transmit and receive data,
 #define PCD_RESETPHASE        0x0F               //Reset
 #define PCD_CALCCRC           0x03               //CRC Calculate

  // Mifare_One card command word
  # define PICC_REQIDL          0x26               // find the antenna area does not enter hibernation
  # define PICC_REQALL          0x52               // find all the cards antenna area
  # define PICC_ANTICOLL        0x93               // anti-collision
  # define PICC_SElECTTAG       0x93               // election card
  # define PICC_AUTHENT1A       0x60               // authentication key A
  # define PICC_AUTHENT1B       0x61               // authentication key B
  # define PICC_READ            0x30               // Read Block
  # define PICC_WRITE           0xA0               // write block
  # define PICC_DECREMENT       0xC0               // debit
  # define PICC_INCREMENT       0xC1               // recharge
  # define PICC_RESTORE         0xC2               // transfer block data to the buffer
  # define PICC_TRANSFER        0xB0               // save the data in the buffer
  # define PICC_HALT            0x50               // Sleep


  //And MF522 The error code is returned when communication
  #define MI_OK                 0
  #define MI_NOTAGERR           1
  #define MI_ERR                2
  
  //------------------MFRC522 Register---------------
  //Page 0:Command and Status
  #define     Reserved00            0x00    
  #define     CommandReg            0x01    
  #define     CommIEnReg            0x02    
  #define     DivlEnReg             0x03    
  #define     CommIrqReg            0x04    
  #define     DivIrqReg             0x05
  #define     ErrorReg              0x06    
  #define     Status1Reg            0x07    
  #define     Status2Reg            0x08    
  #define     FIFODataReg           0x09
  #define     FIFOLevelReg          0x0A
  #define     WaterLevelReg         0x0B
  #define     ControlReg            0x0C
  #define     BitFramingReg         0x0D
  #define     CollReg               0x0E
  #define     Reserved01            0x0F
  //Page 1:Command     
  #define     Reserved10            0x10
  #define     ModeReg               0x11
  #define     TxModeReg             0x12
  #define     RxModeReg             0x13
  #define     TxControlReg          0x14
  #define     TxAutoReg             0x15
  #define     TxSelReg              0x16
  #define     RxSelReg              0x17
  #define     RxThresholdReg        0x18
  #define     DemodReg              0x19
  #define     Reserved11            0x1A
  #define     Reserved12            0x1B
  #define     MifareReg             0x1C
  #define     Reserved13            0x1D
  #define     Reserved14            0x1E
  #define     SerialSpeedReg        0x1F
  //Page 2:CFG    
  #define     Reserved20            0x20  
  #define     CRCResultRegM         0x21
  #define     CRCResultRegL         0x22
  #define     Reserved21            0x23
  #define     ModWidthReg           0x24
  #define     Reserved22            0x25
  #define     RFCfgReg              0x26
  #define     GsNReg                0x27
  #define     CWGsPReg	            0x28
  #define     ModGsPReg             0x29
  #define     TModeReg              0x2A
  #define     TPrescalerReg         0x2B
  #define     TReloadRegH           0x2C
  #define     TReloadRegL           0x2D
  #define     TCounterValueRegH     0x2E
  #define     TCounterValueRegL     0x2F
  //Page 3:TestRegister     
  #define     Reserved30            0x30
  #define     TestSel1Reg           0x31
  #define     TestSel2Reg           0x32
  #define     TestPinEnReg          0x33
  #define     TestPinValueReg       0x34
  #define     TestBusReg            0x35
  #define     AutoTestReg           0x36
  #define     VersionReg            0x37
  #define     AnalogTestReg         0x38
  #define     TestDAC1Reg           0x39  
  #define     TestDAC2Reg           0x3A   
  #define     TestADCReg            0x3B   
  #define     Reserved31            0x3C   
  #define     Reserved32            0x3D   
  #define     Reserved33            0x3E   
  #define     Reserved34            0x3F
  //-----------------------------------------------
  
  #define uchar	unsigned char
  #define uint	unsigned int
  //Maximum length of the array
  #define MAX_LEN 16
 
 //4 bytes card serial number, the first 5 bytes for the checksum byte
uchar serNum[5];

uchar  writeData[16]={0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100};  //Initialization 100 dollars
uchar  moneyConsume = 18 ;  //Consumption of 18 yuan
uchar  moneyAdd = 10 ;  //Recharge 10 yuan
//Sector A password, 16 sectors, each sector password 6Byte
 uchar sectorKeyA[16][16] = {{0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF},
                             {0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF},
                             //{0x19, 0x84, 0x07, 0x15, 0x76, 0x14},
                             {0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF},
                            };
 uchar sectorNewKeyA[16][16] = {{0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF},
                                {0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xff,0x07,0x80,0x69, 0x19,0x84,0x07,0x15,0x76,0x14},
                                 //you can set another ket , such as  " 0x19, 0x84, 0x07, 0x15, 0x76, 0x14 "
                                 //{0x19, 0x84, 0x07, 0x15, 0x76, 0x14, 0xff,0x07,0x80,0x69, 0x19,0x84,0x07,0x15,0x76,0x14},
                                 // but when loop, please set the  sectorKeyA, the same key, so that RFID module can read the card
                                {0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xff,0x07,0x80,0x69, 0x19,0x33,0x07,0x15,0x34,0x14},
                               };
  
 void setup()
 {
   //Iniciamos las comunicaciones seriales
   Serial.begin(9600);
   //Iniciamos la comunicación SPI
   SPI.begin();
   
   //Iniciamos el MF522
   pinMode(chipSS, OUTPUT);
   digitalWrite(chipSS, LOW);
   pinMode(rstPD, HIGH);
   digitalWrite(rstPD, HIGH);
   
   //Iniciamos la configuración del MF522
   MFRC522_Init();
   
   Serial.println("> MFRC522 Ok"); //Debug
 }
 void loop()
 {
   uchar i,tmp, checksum1;
   uchar status;
   uchar str[MAX_LEN];
   uchar RC_size;
   uchar blockAddr;	//Selection operation block address 0 to 63
   String mynum = "";
   
   //Find cards, return card type
   status = MFRC522_Request(PICC_REQIDL, str);	
   if (status == MI_OK)
   {
//     Serial.println("Card detected");
//     Serial.print(str[0],BIN);
//     Serial.print(" , ");
//     Serial.print(str[1],BIN);
//     Serial.println(" ");
   }
   
   //Anti-collision, return card serial number 4 bytes
   status = MFRC522_Anticoll(str);
   memcpy(serNum, str, 5);
   if(status == MI_OK)
   {
     checksum1 = serNum[0] ^ serNum[1] ^ serNum[2] ^ serNum[3];
     //Serial.println("The card's number is  : ");
     Serial.print("S");
     Serial.print(serNum[0],HEX);
     Serial.print(" , ");
     Serial.print(serNum[1],HEX);
     Serial.print(" , ");
     Serial.print(serNum[2],HEX);
     Serial.print(" , ");
     Serial.print(serNum[3],HEX);
     Serial.print(" , ");
     Serial.print(serNum[4],HEX);
     Serial.print(checksum1);
     Serial.print("E");
     Serial.println(" <-");
     
     // Should really check all pairs, but for now we'll just use the first
     if(serNum[0] == 88)
     {
       Serial.println("Hello Grant");
     }
     else if(serNum[0] == 173)
     {
       Serial.println("Hello David");
     }
     delay(1000);
   }
   //MFRC522_Halt();  //Command card into hibernation 
 }
