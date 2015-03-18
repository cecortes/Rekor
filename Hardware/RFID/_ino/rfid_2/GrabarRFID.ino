void GrabarRFID()
{
  /*
  Esta función se encarga de llamar a las funciones para leer el número de serie
  de la tarjeta RFID, una vez leída la tarjeta se reciben los datos en Hexadecimal
  y se guardan en un arreglo, por último se construye un arreglo de datos y estos
  son mandados por el puerto serial como una cadena de datos.
  */
  
  //Variables locales
  uchar i,tmp, checksum1;
  uchar status;
  uchar str[MAX_LEN];
  String rfidDat = "";    //Variable para construir el dato que se envía por el puerto serial.
  
  //Esta función busca la tarjeta que esta dentro del área de la antena
  status = MFRC522_Request(PICC_REQIDL, str);
  //Esta función lee la tarjeta y regresa el Número Serial.
  status = MFRC522_Anticoll(str);
  memcpy(serNum, str, 5);
  if(status == MI_OK)
  {
    //Si no hay error leemos el número serial
    checksum1 = serNum[0] ^ serNum[1] ^ serNum[2] ^ serNum[3];
//    Serial.print("* ");            //Only debug
//    Serial.print(serNum[0],HEX);   //Only debug
//    Serial.print(",");             //Only debug
//    Serial.print(serNum[1],HEX);   //Only debug
//    Serial.print(",");             //Only debug
//    Serial.print(serNum[2],HEX);   //Only debug
//    Serial.print(",");             //Only debug
//    Serial.print(serNum[3],HEX);   //Only debug
//    Serial.print(",");             //Only debug
//    Serial.print(serNum[4],HEX);   //Only debug
//    Serial.print(checksum1);       //Only debug
//    Serial.print(" *");            //Only debug
//    Serial.println("");            //Only debug
    
    //Creamos el dato que se mandará a Rekor
    String temp0 = String(serNum[0], HEX);
    String temp1 = String(serNum[1], HEX);
    String temp2 = String(serNum[2], HEX);
    String temp3 = String(serNum[3], HEX);
    String temp4 = String(serNum[4], HEX);
    rfidDat = temp0 + temp1 + temp2 + temp3 + temp4;
    Serial.println(rfidDat);
  }	
}
