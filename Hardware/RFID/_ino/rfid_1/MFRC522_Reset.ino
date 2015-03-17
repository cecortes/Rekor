void MFRC522_Reset(void)
{
  //Esta función hace Reset al MFRC522, no recibe ni devuelve nada
  Write_MFRC522(CommandReg, PCD_RESETPHASE);
}
