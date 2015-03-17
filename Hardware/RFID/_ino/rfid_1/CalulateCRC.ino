void CalulateCRC(uchar *pIndata, uchar len, uchar *pOutData)
{
  /*
   * Description: CRC calculation with MF522
   * Input parameters: pIndata - To read the CRC data, len - the data length, pOutData - CRC calculation results
   * Return value: None
  */
  uchar i, n;

  ClearBitMask(DivIrqReg, 0x04);    //CRCIrq = 0
  SetBitMask(FIFOLevelReg, 0x80);  //Clear the FIFO pointer
  //Write_MFRC522(CommandReg, PCD_IDLE);

  //Writing data to the FIFO	
  for (i=0; i<len; i++)
  {   
    Write_MFRC522(FIFODataReg, *(pIndata+i));   
  }
  Write_MFRC522(CommandReg, PCD_CALCCRC);

  //Wait CRC calculation is complete
  i = 0xFF;
  do 
  {
    n = Read_MFRC522(DivIrqReg);
    i--;
  }
  while ((i!=0) && !(n&0x04));  //CRCIrq = 1

  //Read CRC calculation result
  pOutData[0] = Read_MFRC522(CRCResultRegL);
  pOutData[1] = Read_MFRC522(CRCResultRegM);
}

