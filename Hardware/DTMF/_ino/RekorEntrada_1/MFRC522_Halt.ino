void MFRC522_Halt(void)
{
  /*
   * Description: Command card into hibernation
   * Input: None
   * Return value: None
  */
  uchar status;
  uint unLen;
  uchar buff[4]; 

  buff[0] = PICC_HALT;
  buff[1] = 0;
  CalulateCRC(buff, 2, &buff[2]);

  status = MFRC522_ToCard(PCD_TRANSCEIVE, buff, 4, buff,&unLen);
}
