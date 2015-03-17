void SetBitMask(uchar reg, uchar mask)  
{
  /*
   * Description: Set RC522 register bit
   * Input parameters: reg - register address; mask - set value
   * Return value: None
  */
  uchar tmp;
  tmp = Read_MFRC522(reg);
  Write_MFRC522(reg, tmp | mask);  // set bit mask
}
