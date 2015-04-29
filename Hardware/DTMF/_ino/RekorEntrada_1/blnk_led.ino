void blnk_led()
{
  //Esta rutina parpadea rápidamente el led led_lst durante 1 seg
  for(int i = 0; i < 15; i++)
  {
    digitalWrite(led_lst, LOW);
    delay(50);
    digitalWrite(led_lst, HIGH);
    delay(50);
   }
}
