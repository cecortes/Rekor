'********************************************************************************************************
'RekorRfidSalida    Programa de Control de visitas, este programa lee automáticamente el código RFID de una
'                   tarjeta para despúes consultar la base de datos para recibir los datos con los que se
'                   dió de alta la tarjeta en el módulo de Entrada.
'                   Se muestran las fotos del Rostro y de la Identificación depués de realizar la consulta
'                   por último se captura la hora de salida, de acuerdo al sistema y se guarda en la base
'                   de datos.
'
'Autor:             César López Cortés  27/04/2015
'Uso:               Instalar la aplicación, correr los comandos del menú
'Licencia:          Producto con (C) César López Cortés.
'
'Notas:             Esta versión SOLAMENTE CORRE EN CPU DE 32 BITS WINDOWS XP - WINDOWS 7.
'********************************************************************************************************

'Importamos las referencias necesarias para trabajar con mysql
Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient

Public Class Form1
    'Variables Globales------------------------------------------------------------------------------------------------------------
    Dim consultaOk As Boolean = False 'Variable que cambia a true cuando la consulta MySql es exitosa
    Dim strBufferIn As String   'Variable para recibir el dato del puerto Serial
    Dim strTmp As String        'Variable temporal para construir el código recibido por el DTMF
    Dim strFechaTmp As String   'Variable temporal para remover los caracteres basura de la consulta MySql
    Dim rfidEstado As Boolean = False 'Variable para saber si se va a recibir el número serial de la tarjeta
    Dim rfidSN As String        'Variable para guardar el número serial del RFID
    Dim pathRostro As String    'Variable para guardar la dirección de la foto del rostro
    Dim pathId As String        'Variable para guardar la dirección de la foto de la Id
    '------------------------------------------------------------------------------------------------------------------------------
    Public Sub deshabilitar()
        'Esta función deshabilita los elementos de la pantalla principal
        lblCasa.Text = ""
        lblFecha.Text = ""
        lblHoraEntrada.Text = ""
        lblHoraSalida.Text = ""
        lblId.Text = ""
        lblNombreVisita.Text = ""
    End Sub

    Public Sub consultarVisitante()
        'Función para consultar la tabla de visitas2 y extraer sus datos
        Dim comandoSql As MySqlCommand
        Dim resultado As MySqlDataReader

        'Conectamos a la base de datos dentro de un TRY
        Try
            conexion_Global()
            _conexion.Open()
            comandoSql = New MySqlCommand("select * from visitas2 where snrfid='" & rfidSN & "'", _conexion)
            resultado = comandoSql.ExecuteReader
            'Dentro de un ciclo leemos los resultados
            While resultado.Read
                lblNombreVisita.Text = resultado.GetString("nombrevisita")
                lblCasa.Text = resultado.GetString("ncasas")
                strFechaTmp = resultado.GetString("fechaingreso")
                'Removemos los caracteres finales de la consulta de MySQL que contienen " 12:00 a.m."
                lblFecha.Text = strFechaTmp.Remove(10, 14)
                lblHoraEntrada.Text = resultado.GetString("horaingreso")
                lblId.Text = resultado.GetString("tipoid")
                'Obtenemos las direcciones de las fotos asociadas y las guardamos en sus variables
                pathRostro = resultado.GetString("PicRostro")
                pathId = resultado.GetString("PicId")
                'Cambiamos la variable de consulta a ok
                consultaOk = True
            End While
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Rekor 32bits Módulo de Salida", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cerrar()
        End Try

        'Dentro de un If mostramos la hora y las fotos
        If consultaOk = True Then
            'Llamamos a la función que se encarga de obtener la hora de salida
            obtenerHora()
            'Llamamos a la función que se encarga de mostrar las Pics
            mostrarPic()
            'Borramos al visitante de la tabla de visitas2 para liberar el RFID
            borrarVisitas()
            'Guardamos los datos del visitante en la tabla visitas3
            guardarVisitas()
            'Regresamos la variable consulta a su estado original
            consultaOk = False
            'Iniciamos al segundo contador para mostrar los campos 10 segundos
            tmrTimer2.Enabled = True
        End If
    End Sub

    Public Sub obtenerHora()
        'Esta función sirve para obtener la hora, además de guardarla en el campo que corresponde
        lblHoraSalida.Text = Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second
    End Sub

    Public Sub mostrarPic()
        'Hacemos que la imágen se ajuste al tamaño del picture box del rostro y de la credencial
        pbxRostro.SizeMode = PictureBoxSizeMode.StretchImage
        pbxId.SizeMode = PictureBoxSizeMode.StretchImage

        pbxRostro.Image = System.Drawing.Image.FromFile(pathRostro)
        pbxId.Image = System.Drawing.Image.FromFile(pathId)
    End Sub

    Public Sub borrarVisitas()
        '* Esta función se utiliza para borrar al visitante de la tabla visitas2 y así liberar el número de serie del RFID
        '* que haya sido utilizado, posteriormente y en otra función se guardarán los datos del visitante junto con su hora
        '* de salida para que pueda ser consultado por los registros.
        'Creamos las variables de las clases insert_datos y datos
        Dim conexion As New class_insert_datos
        Dim datos As New class_datos

        'Cargamos el número de serie del RFID
        datos.snrfid = rfidSN

        'Dentro de un if verificamos que los datos sean eliminados
        If conexion.eliminarDatos(datos) Then
            MessageBox.Show("Datos Eliminados correctamente !!!", "Rekór 32 bits Módulo de Salida", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Actualizamos los datos que se muestran en el data grid view y limpiamos los text box
            'limpiar_actualizar()
        Else
            MessageBox.Show("Los datos no pudieron eliminarse de la base de datos", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub guardarVisitas()
        '* Esta función se encarga de guardar los datos del visitante presentados en pantalla dentro de la tabla
        '* visitas3 para que después puedan ser consultadas por el usuario
        Dim conexion As New class_insert_datos
        Dim datos As New class_datos

        'Capturamos los datos que se van a guardar en la tabla de visitas3
        datos.nombrevisita = lblNombreVisita.Text
        datos.tipoid = lblId.Text
        datos.fechaingreso = lblFecha.Text
        datos.horaingreso = lblHoraEntrada.Text
        datos.horasalida = lblHoraSalida.Text
        datos.ncasas = lblCasa.Text
        datos.snrfid = rfidSN
        datos.PicRostro = pathRostro
        datos.PicId = pathId

        ''Dentro de un IF insertamos los datos en la tabla de visitas
        If conexion.insertarVisitas(datos) Then
            MessageBox.Show("Los datos del visitante han sido guardados correctamente" & vbNewLine & "" & vbNewLine & "La tarjeta RFID ya puede ser entregada al visitante, Gracias", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Des habilitamos el panel para recibir otro visitante
            'deshabilitar()
        Else
            MessageBox.Show("Datos del visitante no guardados", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Mostramos el panel de parámetros de conexión para capturar los settings por default
        mysqlSettings.Show()
        'Cerramos imediatamente
        mysqlSettings.Close()
        'Llamamos a la función para deshabilitar los elementos de inicio
        deshabilitar()

        'Des habilitamos los timer
        tmrTimer.Enabled = False    'Timer de comunicación para mandar el comando RFID
        tmrTimer2.Enabled = False   'Timer para mostrar campos por 10 segundos

        'Si la variable del puerto serial está vacía, llamamos al formulario para configurar el puerto
        If _varglobal.puertoSerial = "" Then
            scrSerial.Show()
        End If
    End Sub

    Private Sub ConexiónSerialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConexiónSerialToolStripMenuItem.Click
        'Llamamos a la pantalla de la conexión serial
        scrSerial.Show()
    End Sub

    Private Sub BaseDeDatosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BaseDeDatosToolStripMenuItem.Click
        'Llamamos al  formulario de parámetros de conexión con el servidor MySql
        mysqlSettings.Show()
    End Sub

    Private Sub ConectarAlRFIDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConectarAlRFIDToolStripMenuItem.Click
        'Esta función se ocupa para abrir el puerto serial e iniciar la comunicación USB para el lector RFID
        'Si el estado de la conexión está listo abrimos el puerto serial e iniciamos la comunicación USB
        If _varglobal.edoConexion = True Then
            spPuerto.Close()
            'Le pasamos el nombre del puerto por medio de la variable de la clase _varglobal
            spPuerto.PortName = _varglobal.puertoSerial
            'Abrimos el puerto serial
            spPuerto.Open()
            'Mostramos el mensaje para el usuario indicando que la comunicación USB está lista
            MessageBox.Show("Conexión USB exitosa." & vbNewLine & _varglobal.puertoSerial, "Rekór RFID Módulo Salida", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Habilitamos el Timer que se encargará de mandar el comando de lectura al RFID
            tmrTimer.Enabled = True
        Else
            'Si el edoConexión es falso entonces llamamos a configurar los parámetros de conexión
            MessageBox.Show("No se ha iniciado la comunicación USB, configure los parámetros." & vbNewLine & "" & vbNewLine & "Puerto Serial (Por defecto): COM3" & vbNewLine & "" & vbNewLine & "Puede revisar en el administrador de dispositivos para saber el nombre del puerto serial.", "Rekór RFID Módulo Salida", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            scrSerial.Show()
        End If
    End Sub

    Private Sub tmrTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrTimer.Tick
        'Esta función se encarga de enviar el comando de lectura al RFID cada vez que el timer completa un ciclo
        If spPuerto.IsOpen Then
            'Envíamos el comando al Arduino para leer el RFID, si es que el puerto está abierto
            spPuerto.Write("=")
        Else
            'Mostramos un mensaje al usuario y lo mandamos al panel de conexión
            MessageBox.Show("Puerto COM se encuentra desconectado." & vbNewLine & "Favor de revisar la configuración", "Rekór RFID Módulo de Salida", MessageBoxButtons.OK, MessageBoxIcon.Information)
            scrSerial.Show()
        End If
    End Sub

    Private Sub spPuerto_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles spPuerto.DataReceived
        'Esta función es llamada cada vez que se recibe un dato
        'Cargamos el dato recibido en su variable
        strBufferIn = spPuerto.ReadLine
        'Si el dato es diferente de cero, guardamos el dato en una variable temporal
        If strBufferIn <> "" Then
            'Removemos los saltos de línea y guardamos en una variable temporal
            strTmp = Replace(Replace(strBufferIn, vbCr, "*"), vbLf, "b")
        End If
        'Limpiamos el puerto serial para recibir el siguiente dato
        spPuerto.DiscardInBuffer()
        'Debug-------------------------------------------------------------------------------------------
        'MessageBox.Show(strTmp)
        '------------------------------------------------------------------------------------------------
        If strTmp = "$*" Then
            'rfidEstado es True lo que signfica que el siguiente dato USB es el número serial de la tarjeta RFID
            rfidEstado = True
            'Des habilitamos el timer para no seguir mandando el comando de lectura de RFID
            tmrTimer.Enabled = False
            'Debug-------------------------------------------------------------------------------------------
            'MessageBox.Show("true")
            '------------------------------------------------------------------------------------------------
        ElseIf rfidEstado = True Then
            'strTmp contiene el número serial de la RFID.
            'Capturamos el número serial del RFID y lo guardamos en la variable que le corresponde
            rfidSN = strTmp
            'Mensaje para el usuario mostrando el número de serie de la tarjeta
            MessageBox.Show("Se detecto el RFID: " & vbNewLine & "" & vbNewLine & rfidSN & vbNewLine & "" & vbNewLine & "Por el momento no mueva la tarjeta RFID del lector.", "Rekór RFID Módulo de Salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Debug-------------------------------------------------------------------------------------------
            'MessageBox.Show(rfidSN)
            '------------------------------------------------------------------------------------------------
            'Llamamos a la función que se encarga de consultar la tabla de visitas2 de acuerdo al serial del RFID
            Me.Invoke(New EventHandler(AddressOf consultarVisitante))
        Else
            'Limpiamos la variable temporal
            strTmp = ""
            'Des habilitamos los elementos del formulario desde un método seguro
            Me.Invoke(New EventHandler(AddressOf deshabilitar))
            'Re iniciamos rfidEstado a su estado inicial false
            rfidEstado = False
        End If
    End Sub

    Private Sub tmrTimer2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrTimer2.Tick
        'Este timer se activa dentro de la función consultarVisitante y sirve para mostrar las Pics por 10 segundos
        'Terminado el tiempo, el timer se des habilita, limpia los campos de la pantalla y arranca el timer del RFID
        tmrTimer2.Enabled = False
        deshabilitar()
        'Limpiamos Pics
        pbxRostro.Image = Nothing
        pbxId.Image = Nothing
        'Arrancamos el timer RFID
        tmrTimer.Enabled = True
    End Sub
End Class
