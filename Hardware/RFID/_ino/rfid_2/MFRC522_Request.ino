uchar MFRC522_Request(uchar reqMode, uchar *TagType)
{
  /*
   * Description: Find cards, read the card type number
   * Input parameters: reqMode - find cards way
   *		       TagType - Return Card Type
   *		       0x4400 = Mifare_UltraLight
   *		       0x0400 = Mifare_One(S50)
   *		       0x0200 = Mifare_One(S70)
   *		       0x0800 = Mifare_Pro(X)
   *		       0x4403 = Mifare_DESFire
   * Return value: the successful return MI_OK
  */
  uchar status;  
  uint backBits;  //The received data bits
  
  Write_MFRC522(BitFramingReg, 0x07);	//TxLastBists = BitFramingReg[2..0]	???
  
  TagType[0] = reqMode;
  status = MFRC522_ToCard(PCD_TRANSCEIVE, TagType, 1, TagType, &backBits);
  
  if ((status != MI_OK) || (backBits != 0x10))
  {    
    status = MI_ERR;
  } 
  return status;
}
