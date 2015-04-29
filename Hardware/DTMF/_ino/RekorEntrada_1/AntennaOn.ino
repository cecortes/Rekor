void AntennaOn(void)
{
  /*
   * Description: Open antennas, each time you start or shut down the natural barrier between the transmitter should be at least 1ms interval
   * Input: None
   * Return value: None
  */
  uchar temp;
  
  temp = Read_MFRC522(TxControlReg);
  if (!(temp & 0x03))
  {
    SetBitMask(TxControlReg, 0x03);
  }
}
