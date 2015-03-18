void ClearBitMask(uchar reg, uchar mask)  
{
  /*
   * Description: clear RC522 register bit
   * Input parameters: reg - register address; mask - clear bit value
   * Return value: None
  */
  uchar tmp;
  tmp = Read_MFRC522(reg);
  Write_MFRC522(reg, tmp & (~mask));  // clear bit mask
}
