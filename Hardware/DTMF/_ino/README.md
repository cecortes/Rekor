# _ino

Esta carpeta contiene los programas de Arduino, según se han completado en las diferentes etapas.

	dtmf_0 - Este programa (BETA) integra el módulo con el CMD8870 y Arduino en un sólo shield, el programa recibe los tonos y los decodifica en su valor decimal, también los muestra en el puerto USB.
        RekorEntrada_1 - Programa que junta el RFID y el DTMF sirve para Entrada y Salida.
	(NOTA - ambos programas tienen que ir en la misma carpeta y crear la pestaña dentro del dtmf_0.ino con el nonmbre de la(s) funciones que son ocupadas por este. ejemplo nombre pestaña, read_dtmf).