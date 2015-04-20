uchar MFRC522_Anticoll(uchar *serNum)
{
  /*
   * Description: Anti-collision detection, reading selected card serial number card
   * Input parameters: serNum - returns 4 bytes card serial number, the first 5 bytes for the checksum byte
   * Return value: the successful return MI_OK
  */
  uchar status;
  uchar i;
  uchar serNumCheck=0;
  uint unLen;
  
  //ClearBitMask(Status2Reg, 0x08);		//TempSensclear
  //ClearBitMask(CollReg,0x80);			//ValuesAfterColl
  Write_MFRC522(BitFramingReg, 0x00);		//TxLastBists = BitFramingReg[2..0]

  serNum[0] = PICC_ANTICOLL;
  serNum[1] = 0x20;
  status = MFRC522_ToCard(PCD_TRANSCEIVE, serNum, 2, serNum, &unLen);

  if (status == MI_OK)
  {
    //Check card serial number
    for (i=0; i<4; i++)
    {   
      serNumCheck ^= serNum[i];
    }
    if (serNumCheck != serNum[i])
    {   
      status = MI_ERR;    
    }
  }
  //SetBitMask(CollReg, 0x80);	//ValuesAfterColl=1
  return status;
}
