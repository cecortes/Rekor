void Write_MFRC522(uchar addr, uchar val)
{
  /*
   * Function Description: To a certain MFRC522 register to write a byte of data
   * Input Parametersï¼šaddr - register address; val - the value to be written
   * Return value: None
  */
  digitalWrite(chipSS, LOW);
  
  //Address Format 0XXXXXX0
  SPI.transfer((addr<<1)&0x7E);	
  SPI.transfer(val);
  digitalWrite(chipSS, HIGH);
}
