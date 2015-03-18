uchar Read_MFRC522(uchar addr)
{
  /*
   * Description: From a certain MFRC522 read a byte of data register
   * Input Parameters: addr - register address
   * Returns: a byte of data read from the
  */
  uchar val;
  digitalWrite(chipSS, LOW);
  
  //Address Format 1XXXXXX0
  SPI.transfer(((addr<<1)&0x7E) | 0x80);	
  val =SPI.transfer(0x00);	
  digitalWrite(chipSS, HIGH);
  
  return val;	
}
