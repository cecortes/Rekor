void read_dtmf()
{
  /*Rutina que es llamada cuando la interrupción INT.0 sucede
    esta rutina se encarga de leer los bits del CMD8870 y convertirlos
    en valores decimales para ser mostrados en el monitor serial.
  */
  
  dtmf_dat = 0;    //Limpiamos el valor de la variable
  dtmf_tmp = 0;    //Limpiamos el valor de la variable
  
  //Leemos Q4
  dtmf_tmp = digitalRead(q4);
  //Left_Shift hasta su posición según la tabla CMD8870
  dtmf_dat += dtmf_tmp << 3;
  
  //Leemos Q3
  dtmf_tmp = digitalRead(q3);
  //Left_Shift hasta su posición según la tabla CMD8870
  dtmf_dat += dtmf_tmp << 2;
  
  //Leemos Q2
  dtmf_tmp = digitalRead(q2);
  //Left_Shift hasta su posición según la tabla CMD8870
  dtmf_dat += dtmf_tmp << 1;
  
  //Leemos Q1
  dtmf_tmp = digitalRead(q1);
  //Left_Shift hasta su posición según la tabla CMD8870
  dtmf_dat += dtmf_tmp << 0;
  
  //Enviamos el dato convertido al USB
  Serial.print("> DTMF: "); 
  Serial.println(dtmf_dat, DEC);    //Dato en su valor decimal
}
