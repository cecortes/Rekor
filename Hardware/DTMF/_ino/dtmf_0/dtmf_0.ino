/*Programa que incluye el módulo DTMF 8870 para el software REKOR, esta es una primera versión BETA que
integra el shield para el módulo, monitorea a través de una interrupción el Std del circuito que se 
dipara cuando recibe un tono válido del teléfono, al activarse la interrupción manda a llamar a una 
función que se encarga de recibir los estados Q4, Q3, Q2, Q1 del módulo y traducirlos a dígitos decimales
para después mandárlos por el puerto serial en forma de cadena; Para indicar que el módulo está funcionando
se cuenta con des leds, uno para el Std del CMD8870, el cual se activa cada vez que recibe un tono válido
y otro que es un led que se mantiene parpadeando indicando así que el Arduino está en escucha.
 
 Conexiones Arduino UNO + Módulo 8870
 Pin 13 - Led Ready and Listen
 Pin 02 - CMD8870 Std (Pin 15) - Int.0 Arduino Uno
 Pin 03 - CMD8870 Q4  (Pin 14)
 Pin 04 - CMD8870 Q3  (Pin 13)
 Pin 05 - CMD8870 Q2  (Pin 12)
 Pin 06 - CMD8870 Q1  (Pin 11)
 
 Una vez probado el programa comentar las líneas Debug.
 
 Realizado por: César López Cortés <cesarlopezcortes@me.com> (Marzo / 2015)
 
 Copyright (C) <2015>  <César López Cortés>
 
   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.
 
   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.
 
 You should have received a copy of the GNU General Public License
 along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
 
 #define led_lst 13    //Led Ready and Listen
 #define std 0         //CMD8870 Std (Pin 15) - Int.0 Arduino Uno
 #define q4  3         //Pin 03 - CMD8870 Q4  (Pin 14)
 #define q3  4         //Pin 04 - CMD8870 Q3  (Pin 13)
 #define q2  5         //Pin 05 - CMD8870 Q2  (Pin 12)
 #define q1  6         //Pin 06 - CMD8870 Q1  (Pin 11)
 
 //Variables Globales
 volatile byte dtmf_tmp;    //Variable para leer el dato bit por bit del CMD8870, volatile para usarla dentro de la interrupción.
 volatile byte dtmf_dat;    //Variable para convertir el dato DTMF a decimal, volatile para usarla dentro de la interrupción.
 void setup()
 {
   //Configuración E/S
   pinMode(led_lst, OUTPUT);
   pinMode(q4, INPUT);
   pinMode(q3, INPUT);
   pinMode(q2, INPUT);
   pinMode(q1, INPUT);
   //Interrupción
   attachInterrupt(std, read_dtmf, RISING);    //Int.0 llama a la función read_dtmf cuando va de LOW a HIGH
   
   //Iniciamos comunicación Serial
   Serial.begin(115200);
   Serial.println("> DTMF: Listo y en escucha !!!");    //Only debug purpose
 }
 
 void loop()
 {
   //Parpadeo led_lst
   digitalWrite(led_lst, HIGH);
   delay(250);
   digitalWrite(led_lst, LOW);
   delay(250);
 }
