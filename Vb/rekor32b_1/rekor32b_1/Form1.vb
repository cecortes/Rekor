'********************************************************************************************************
'rekor32b_1         Programa de Control de visitas, este programa permite dar de alta a visitantes de un
'                   fraccionamiento, capturando su Nombre completo, el número de casa al que visitan,
'                   permite elegir el tipo de identificación que presentan (Ife, Licencia, Otro), toma una
'                   foto de la identificación, toma una foto del visitante, captura la fecha y la hora del
'                   registro, manda una confirmación vía GSM o Línea convenccional del teléfono y captura
'                   la persona que autoriza, ésta confirmación la logra hacer mediante ARDUINO, graba los
'                   datos en las tablas correspondientes de MySQL (rekor y usuarios), también graba la info
'                   en una tarjeta RFID que se le entrega al visitante y se le pide a la salida para poder
'                   obtener el tiempo total de la visita.
'                   Este programa es el módulo de entrada y también tiene la capacidad de dar de alta a los
'                   usuarios (Información de las casas), borrar usuarios y modificarlos.
'
'Autor:             César López Cortés  02/03/2015
'Uso:               Instalar la aplicación, correr los comandos del menú
'Licencia:          Producto con (C) César López Cortés.
'
'Notas:             Esta versión SOLAMENTE CORRE EN CPU DE 32 BITS WINDOWS XP - WINDOWS 7.
'********************************************************************************************************

Public Class scrPrincipal


    Private Sub AltaDeUsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AltaDeUsuariosToolStripMenuItem.Click
        scrAltaUsuarios.Show()
    End Sub

    Private Sub BaseDeDatosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BaseDeDatosToolStripMenuItem.Click
        'Llamamos al  formulario de parámetros de conexión
        mysqlSettings.Show()
    End Sub

    Private Sub scrPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Mostramos el panel de parámetros de conexión para capturar los settings por default
        mysqlSettings.Show()
        'Cerramos imediatamente
        mysqlSettings.Close()
    End Sub
End Class