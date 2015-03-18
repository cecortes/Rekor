void MFRC522_Init(void)
{
  /* Esta función configura al módulo con los parámetros necesarios
     No recibe ni devuelve ningún valor.
  */
  
  digitalWrite(rstPD, HIGH);
  //Hacemos un Reset del módulo
  MFRC522_Reset();
  
  Write_MFRC522(TModeReg, 0x8D);
  Write_MFRC522(TPrescalerReg, 0x3E);
  Write_MFRC522(TReloadRegL, 30);           
  Write_MFRC522(TReloadRegH, 0);
  Write_MFRC522(TxAutoReg, 0x40);
  Write_MFRC522(ModeReg, 0x3D);
  
  //Encendemos la Antena
  AntennaOn();
}
