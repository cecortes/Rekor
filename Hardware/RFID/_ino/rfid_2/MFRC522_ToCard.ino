uchar MFRC522_ToCard(uchar command, uchar *sendData, uchar sendLen, uchar *backData, uint *backLen)
{
  /*
   * Description: RC522 and ISO14443 card communication
   * Input Parameters: command - MF522 command word,
   *		       sendData--RC522 sent to the card by the data
   *		       sendLen--Length of data sent	 
   *		       backData--Received the card returns data,
   *		        backLen--Return data bit length
   * Return value: the successful return MI_OK
  */
  uchar status = MI_ERR;
  uchar irqEn = 0x00;
  uchar waitIRq = 0x00;
  uchar lastBits;
  uchar n;
  uint i;

  switch (command)
  {
  case PCD_AUTHENT:		//Certification cards close
    {
      irqEn = 0x12;
      waitIRq = 0x10;
      break;
    }
  case PCD_TRANSCEIVE:	//Transmit FIFO data
    {
      irqEn = 0x77;
      waitIRq = 0x30;
      break;
    }
  default:
    break;
  }

  Write_MFRC522(CommIEnReg, irqEn|0x80);	//Interrupt request
  ClearBitMask(CommIrqReg, 0x80);			//Clear all interrupt request bit
  SetBitMask(FIFOLevelReg, 0x80);			//FlushBuffer=1, FIFO Initialization

  Write_MFRC522(CommandReg, PCD_IDLE);	//NO action; Cancel the current command???

  //Writing data to the FIFO
  for (i=0; i<sendLen; i++)
  {   
    Write_MFRC522(FIFODataReg, sendData[i]);    
  }

  //Execute the command
  Write_MFRC522(CommandReg, command);
  if (command == PCD_TRANSCEIVE)
  {    
    SetBitMask(BitFramingReg, 0x80);		//StartSend=1,transmission of data starts  
  }   

  //Waiting to receive data to complete
  i = 2000;	//i according to the clock frequency adjustment, the operator M1 card maximum waiting time 25ms???
  do 
  {
    //CommIrqReg[7..0]
    //Set1 TxIRq RxIRq IdleIRq HiAlerIRq LoAlertIRq ErrIRq TimerIRq
    n = Read_MFRC522(CommIrqReg);
    i--;
  }
  while ((i!=0) && !(n&0x01) && !(n&waitIRq));

  ClearBitMask(BitFramingReg, 0x80);			//StartSend=0

    if (i != 0)
  {    
    if(!(Read_MFRC522(ErrorReg) & 0x1B))	//BufferOvfl Collerr CRCErr ProtecolErr
    {
      status = MI_OK;
      if (n & irqEn & 0x01)
      {   
        status = MI_NOTAGERR;			//??   
      }

      if (command == PCD_TRANSCEIVE)
      {
        n = Read_MFRC522(FIFOLevelReg);
        lastBits = Read_MFRC522(ControlReg) & 0x07;
        if (lastBits)
        {   
          *backLen = (n-1)*8 + lastBits;   
        }
        else
        {   
          *backLen = n*8;   
        }

        if (n == 0)
        {   
          n = 1;    
        }
        if (n > MAX_LEN)
        {   
          n = MAX_LEN;   
        }

        //Reading the received data in FIFO
        for (i=0; i<n; i++)
        {   
          backData[i] = Read_MFRC522(FIFODataReg);    
        }
      }
    }
    else
    {   
      status = MI_ERR;  
    }

  }

  //SetBitMask(ControlReg,0x80);           //timer stops
  //Write_MFRC522(CommandReg, PCD_IDLE); 

  return status;
}
