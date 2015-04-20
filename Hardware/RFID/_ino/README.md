# _ino

Esta carpeta contiene los programas de Arduino, según se han completado en las diferentes etapas.

   - rfid_1 - Este programa (BETA) integra el módulo MF522 RFID y Arduino, el programa Lee el Número Serial de Tarjetas o Tag RFID 13.56Mhz y los muestra en el monitor Serial.
   * (NOTA - todos los programas tienen que ir en la misma carpeta y crear las pestañas dentro del rfid_1.ino con el nonmbre de la(s) funciones que son ocupadas por este. ejemplo nombre pestaña, AntennaOn)

   - rfid_2 - Este programa (BETA) espera a recibir el código "#" (ASCII 35) de manera serial para poder leer el número serial de la tarjeta de 13.56Mhz.
   * Este programa ya tiene la compatibilidad de los pines para integrarse al Shield del DTMF y puede interactuar con Rekor.
   * (NOTA - todos los programas tienen que ir en la misma carpeta y crear las pestañas dentro del rfid_2.ino con el nonmbre de la(s) funciones que son ocupadas por este. ejemplo nombre pestaña, AntennaOn)

   - RekorEntrada_1 - Este Programa tiene la función DTMF y RFID juntas