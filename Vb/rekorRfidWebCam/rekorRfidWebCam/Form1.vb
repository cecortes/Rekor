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
'Importamos las referencias necesarias para trabajar con mysql
Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient

'Importamos la librería necesaria para trabajar con las cámaras Usb
Imports System.Runtime.InteropServices

Public Class scrPrincipal
    'Los nombres y valores de estas constantes están definidas directamente por la API en este caso por user32.dll y por avicap32.dll
    'Se recomienda mantener los nombres y los valores no pueden ser modificados.
    Const WM_CAP As Short = &H400S
    Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
    Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
    Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30
    Const WM_CAP_SET_PREVIEW As Integer = WM_CAP + 50
    Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP + 52
    Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53
    Const WS_CHILD As Integer = &H40000000
    Const WS_VISIBLE As Integer = &H10000000
    Const SWP_NOMOVE As Short = &H2S
    Const SWP_NOSIZE As Short = 1
    Const SWP_NOZORDER As Short = &H4S
    Const HWND_BOTTOM As Short = 1

    Dim iDevice As Integer = 0      'Variable para el manejo del dispositivo
    Dim hHwnd As Integer            'Variable para el manejo del Preview Capture

    '*************************************************************************************
    'Declaración de funciones que se encuentran dentro de la API user32.dll y avicap32.dll
    '*************************************************************************************
    'Función para obtener la lista de los dispositivos USB de video dentro del API avicap32.dll
    Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short, ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, ByVal cbVer As Integer) As Boolean
    'Función para la captura de video dentro del API avicap32.dll
    Declare Function capCreateCaptureWindowA Lib "avicap32.dll" (ByVal lpszWindowName As String, ByVal dwStyle As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Short, ByVal hWndParent As Integer, ByVal nID As Integer) As Integer
    'Función para mandar comandos a la cámara Usb
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer      'Funciona en Windows 7 pero es necesario importar System.Runtime.InteropServices
    'Función para el tamaño de la ventana dentro del API user32.dll
    Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    'Función para destruir la ventana dentro del API user32.dll
    Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean

    '****************************************************************************************************
    'Variables Globales:
    'Se declaran las variables que se ocupan dentro de este formulario
    '****************************************************************************************************
    Dim strBufferIn As String   'Variable para recibir el dato del puerto Serial
    Dim strTmp As String        'Variable temporal para construir el código recibido por el DTMF
    Dim rfidEstado As Boolean = False 'Variable para saber si se va a recibir el número serial de la tarjeta
    Dim rfidSN As String        'Variable para guardar el número serial del RFID

    Public Sub fecha_hora()
        'Esta función sirve para obtener la fecha y la hora, además de guardarlas en los campos que corresponden
        txtFechaVisita.Text = Date.Now.Date
        txtHoraVisita.Text = Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second
    End Sub

    Public Sub actualizar_cbox()
        'Esta función sirve para llenar los datos en el combo box cmbIdcasaVisita
        'Re iniciamos los datos en caso de ser actualizados
        _dtscbx.Reset()

        'Llamamos a la consulta de los datos
        consulta_datos()
        'Cargamos los datos de la tabla usuarios
        cmbIdcasaVisita.DataSource = _dtscbx.Tables("usuarios")
        'Cargamos los datos de la columna idcasas
        cmbIdcasaVisita.DisplayMember = "idcasas"
    End Sub

    Private Sub deshabilitar()
        'Esta función deshabilita los elementos de la pantalla inicial
        Label1.Enabled = False
        Label2.Enabled = False
        Label3.Enabled = False
        Label4.Enabled = False
        Label5.Enabled = False
        Label6.Enabled = False
        Label7.Enabled = False
        Label8.Enabled = False
        lblNombreUsuario.Enabled = False

        txtNombreVisita.Enabled = False
        txtFechaVisita.Enabled = False
        txtHoraVisita.Enabled = False

        cmbIdcasaVisita.Enabled = False
        cmbIdVisita.Enabled = False

        pbxRostro.Enabled = False
        pbxCredencial.Enabled = False

        btnGrabar.Enabled = False
    End Sub

    Private Sub habilitar()
        'Esta función habilita los elementos del formulario
        Label1.Enabled = True
        Label2.Enabled = True
        Label3.Enabled = True
        Label4.Enabled = True
        Label5.Enabled = True
        Label6.Enabled = True
        Label7.Enabled = True
        Label8.Enabled = True
        lblNombreUsuario.Enabled = True

        txtNombreVisita.Enabled = True
        txtFechaVisita.Enabled = True
        txtHoraVisita.Enabled = True

        cmbIdcasaVisita.Enabled = True
        cmbIdVisita.Enabled = True

        pbxRostro.Enabled = True
        pbxCredencial.Enabled = True

        btnGrabar.Enabled = True

        fecha_hora()
        actualizar_cbox()
    End Sub

    Private Sub guardarVisitante()
        'Esta función se encarga de capturar los datos del visitante y guardarlos en la tabla visitas
        Dim conexion As New class_insert_datos
        Dim datos As New class_datos

        'Checamos que los datos no esten vacíos
        If txtNombreVisita.Text = "" Then
            MessageBox.Show("El campo de Nombre no puede estar vacío", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If cmbIdVisita.Text = "" Then
            MessageBox.Show("El tipo de identificación no puede estar vacío", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If txtFechaVisita.Text = "" Then
            MessageBox.Show("El campo de Fecha de ingreso no puede estar vacío", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If txtHoraVisita.Text = "" Then
            MessageBox.Show("El campo de Hora de ingreso no puede estar vacío", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If cmbIdcasaVisita.Text = "" Then
            MessageBox.Show("El número de casa no puede estar vacío", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        'Capturamos los datos del visitante en las variables de la clase class_datos
        datos.nombrevisita = txtNombreVisita.Text
        datos.tipoid = cmbIdVisita.Text
        datos.fechaingreso = txtFechaVisita.Text
        datos.horaingreso = txtHoraVisita.Text
        datos.ncasas = cmbIdcasaVisita.Text
        datos.snrfid = rfidSN

        ''Dentro de un IF insertamos los datos en la tabla de visitas
        If conexion.insertarVisitas(datos) Then
            MessageBox.Show("Los datos del visitante han sido guardados correctamente" & vbNewLine & "" & vbNewLine & "La tarjeta RFID ya puede ser entregada al visitante, Gracias", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Actualizamos los campos de Fecha y Hora
            fecha_hora()
            'Llamamos a la función para limpiar los datos
            limpiarFormulario()
            'Des habilitamos el panel para recibir otro visitante
            deshabilitar()
        Else
            MessageBox.Show("Datos del visitante no guardados", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Actualizamos los campos de Fecha y Hora
            fecha_hora()
        End If
    End Sub

    Private Sub limpiarFormulario()
        txtNombreVisita.Text = ""
        cmbIdVisita.Text = ""
        txtFechaVisita.Text = ""
        txtHoraVisita.Text = ""
        actualizar_cbox()
        lblNombreUsuario.Text = ""
        fecha_hora()
    End Sub

    Public Sub obtnerUsbCam()
        'Función para obtener la lista de cámaras usb conectadas al sistema
        listUsbCam()

        'Verificamos si existen dispositivos encontrados
        If lbUsbCam.Items.Count > 0 Then
            'Mostramos mensaje al usuario
            MessageBox.Show("Existen: " & vbNewLine & vbNewLine & lbUsbCam.Items.Count.ToString & " WebCams encontradas", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Seleccionamos la primer cámara encontrada
            lbUsbCam.SelectedIndex = 0
        Else
            'Mostramos mensaje al usuario que no se encontró ningún dispositivo
            MessageBox.Show("WebCam no encontradas")
            'Añadimos el mensaje en el listbox
            lbUsbCam.Items.Add("Ninguna WebCam encontrada")
        End If

        'Hacemos que la imágen se ajuste al tamaño del picture box del rostro y de la credencial
        pbxRostro.SizeMode = PictureBoxSizeMode.StretchImage
        pbxCredencial.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Public Sub listUsbCam()
        'Función para obtener en forma de lista las cámaras Usb conectadas al sistema
        Dim strName As String = Space(100)      'Variable para guardar el nombre del dispositivo
        Dim strVer As String = Space(100)       'Variable para guardar la versión del dispositivo
        Dim bReturn As Boolean                  'Variable para guardar el resultado de la función

        Dim x As Integer = 0                    'Contador de dispositivos encontrados
        'Ciclo para cargar la lista de dispositivos
        Do
            'Obtiene el nombre del driver y la versión
            bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)

            If bReturn Then
                'Si encuentra un dispositivo lo agrega a la lista del lbUsbCam
                lbUsbCam.Items.Add(strName.Trim)
                'Incrementamos el contador de dispositivos
                x += 1
            End If
            'Finaliza el ciclo cuando no encuentra más dispositivos
        Loop Until bReturn = False
    End Sub

    Public Sub iniciarWebCam()
        'Función que inicia la cámara Web que este seleccionada

        'Obtenemos el indice del dispositivo seleccionado en la lista de lbUsbCam
        iDevice = lbUsbCam.SelectedIndex

        'Iniciamos la captura y la mostramos en el picture box pbxImagen
        hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640, 480, pbxRostro.Handle.ToInt32, 0)

        'Dentro de un If intentamos conectarnos al dispòsitivo Usb
        If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) Then
            'Configura la escala del Preview
            SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)
            'Configura el Preview Rate en milisegundos
            SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)
            'Inicia el Preview de la cámara Usb
            SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)
            'Re dimensiona la ventana al tamaño del picture box pbxImagen
            SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, pbxRostro.Width, pbxRostro.Height, SWP_NOMOVE Or SWP_NOZORDER)
        Else
            'Si existe algún error destruimos el Handler de la ventana
            DestroyWindow(hHwnd)
        End If
    End Sub

    Public Sub guardarWebCam()
        'Función para guardar la captura de la cámara Usb Seleccionada en formato .jpg y dentro de un directorio predefinido
        Dim dataClipBoard As IDataObject    'Variable para manejar los datos del Porta Papeles o ClipBoard
        Dim bmpData As Image                'Variable para guardar los datos como Imágen Bmp
        Dim path As String = "C:\Users\N30\Documents\test\"                  'Variable para guardar la dirección del directorio donde se guarda la imágen

        'Copiamos la imágen de la cámara al ClipBoard
        SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)

        'Obtenemos la imágen del ClipBoard y la guardamos como Imágen BMP
        dataClipBoard = Clipboard.GetDataObject()

        'Dentro de un If verificamos que se guardo la variable como Imágen BMP
        If dataClipBoard.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
            'Realizamos la copia del ClipBoard y cambiamos de tipo a BMP dentro de la variable bmpData que es un Image
            bmpData = CType(dataClipBoard.GetData(GetType(System.Drawing.Bitmap)), Image)
            'Mostramos la imágen BMP dentro del picture box
            pbxRostro.Image = bmpData
            'Cerramos la vista previa de la cámara
            detenerWebCam()
            'Guardamos el archivo como .jpg dentro del directorio pre establecido
            bmpData.Save(path & "tst" & ".jpeg", Imaging.ImageFormat.Jpeg)
        End If
    End Sub

    Public Sub detenerWebCam()
        'Función para detener la cámara USB y su Preview

        'Detenemos la cámara Usb enviando el comando necesario
        SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0)

        'Destruimos el Handler de la ventana Preview
        DestroyWindow(hHwnd)
    End Sub

    Private Sub scrPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Mostramos el panel de parámetros de conexión para capturar los settings por default
        mysqlSettings.Show()
        'Cerramos imediatamente
        mysqlSettings.Close()
        'Deshabilitamos los elementos del formulario hasta que recibamos el código del usuario vía telefónica
        'deshabilitar()

        'Si la variable del puerto serial está vacía, llamamos al formulario para configurar el puerto
        If _varglobal.puertoSerial = "" Then
            scrSerial.Show()
        End If

        'Debug ***************************************************************************************************
        'Cargamos la lista de las cámaras Usb conectadas al sistema
        'Función para obtener la lista de cámaras usb conectadas al sistema
        obtnerUsbCam()

        'Función para iniciar la cámara Usb
        iniciarWebCam()
    End Sub

    Private Sub MySQLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MySQLToolStripMenuItem.Click
        'Llamamos al  formulario de parámetros de conexión
        mysqlSettings.Show()
    End Sub

    Private Sub ConexiónSerialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConexiónSerialToolStripMenuItem.Click
        'Llamamos a la pantalla de la conexión serial
        scrSerial.Show()
    End Sub

    Private Sub AltaDeUsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AltaDeUsuariosToolStripMenuItem.Click
        'Llamamos a la pantalla para dar de alta al ususario
        scrAltaUsuarios.Show()
    End Sub

    Private Sub BajadeUsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BajadeUsuariosToolStripMenuItem.Click
        'Llamamos a la pantalla para dar de baja a un usuario
        scrBajaUsuarios.Show()
    End Sub

    Private Sub ModificarUsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarUsuariosToolStripMenuItem.Click
        'Llamamos al formulario para actualizar datos del usuario
        scrActualizarUsuarios.Show()
    End Sub

    Private Sub ConectarAlDTMFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConectarAlDTMFToolStripMenuItem.Click
        'Esta función se ocupa para abrir el puerto serial e iniciar la comunicación USB
        'Si el estado de la conexión está listo abrimos el puerto serial e iniciamos la comunicación USB
        If _varglobal.edoConexion = True Then
            spPuerto.Close()
            'Le pasamos el nombre del puerto por medio de la variable de la clase _varglobal
            spPuerto.PortName = _varglobal.puertoSerial
            'Abrimos el puerto serial
            spPuerto.Open()
            'Mostramos el mensaje para el usuario indicando que la comunicación USB está lista
            MessageBox.Show("Conexión USB exitosa." & vbNewLine & _varglobal.puertoSerial, "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            'Si el edoConexión es falso entonces llamamos a configurar los parámetros de conexión
            MessageBox.Show("No se ha iniciado la comunicación USB, configure los parámetros." & vbNewLine & "" & vbNewLine & "Puerto Serial (Por defecto): COM3" & vbNewLine & "" & vbNewLine & "Puede revisar en el administrador de dispositivos para saber el nombre del puerto serial.", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            scrSerial.Show()
        End If
    End Sub

    Private Sub DesconectarDTMFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesconectarDTMFToolStripMenuItem.Click
        'Esta función cierra el puerto serial y termina la comunicación USB
        spPuerto.Close()
        _varglobal.edoConexion = False
        _varglobal.puertoSerial = ""
        MessageBox.Show("La conexión USB ha sido terminada." & vbNewLine & _varglobal.puertoSerial, "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub cmbIdcasaVisita_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbIdcasaVisita.SelectedValueChanged
        'Esta función actualiza los datos del nombre de usuario cuando se selecciona el número de la casa
        Dim comandoSql As MySqlCommand
        Dim resultado As MySqlDataReader
        'Conectamos a la base de datos dentro de un TRY
        Try
            conexion_Global()
            _conexion.Open()
            comandoSql = New MySqlCommand("select nombrecontacto from usuarios where idcasas='" & cmbIdcasaVisita.Text & "'", _conexion)
            resultado = comandoSql.ExecuteReader
            'Dentro de un ciclo leemos los resultados
            While resultado.Read
                lblNombreUsuario.Text = resultado.GetString("nombrecontacto")
            End While
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Rekor 32bits", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cerrar()
        End Try
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        'DEBUG ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'Llamamos a la función para guardar la captura de la cámar USB seleccionada
        guardarWebCam()

        'Función para mandar un dato por el puerto serial y pedirle al módulo RFID regrese el SN de la tarjeta RFID
        If spPuerto.IsOpen Then
            'Envíamos el comando al Arduino para leer el RFID, si es que el puerto está abierto
            spPuerto.Write("#")
        Else
            'Mostramos un mensaje al usuario y lo mandamos al panel de conexión
            MessageBox.Show("Puerto COM se encuentra desconectado." & vbNewLine & "Favor de revisar la configuración", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        'Rutina para recibir el asterisco del DTMF = 11*
        If strTmp = "11*" Then
            'Llamamos a la función habilitar desde un método seguro
            Me.Invoke(New EventHandler(AddressOf habilitar))
            'Mensaje de usuario
            MessageBox.Show("Acceso habilitado desde el número telefónico." & vbNewLine & _varglobal.puertoSerial, "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf strTmp = "$*" Then
            'rfidEstado es True lo que signfica que el siguiente dato USB es el número serial de la tarjeta RFID
            rfidEstado = True
            'Debug-------------------------------------------------------------------------------------------
            'MessageBox.Show("true")
            '------------------------------------------------------------------------------------------------
        ElseIf rfidEstado = True Then
            'strTmp contiene el número serial de la RFID, guardamos todos los datos y el RFID en la tabla visitas
            'Capturamos el número serial del RFID y lo guardamos en la variable que le corresponde
            rfidSN = strTmp
            'Mensaje para el usuario que le muestra el número de serie de la tarjeta
            MessageBox.Show("Los datos del visitante serán guardados en la tarjeta RFID: " & vbNewLine & "" & vbNewLine & rfidSN & vbNewLine & "" & vbNewLine & "Por el momento no mueva la tarjeta RFID del lector.", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Debug-------------------------------------------------------------------------------------------
            'MessageBox.Show(rfidSN)
            '------------------------------------------------------------------------------------------------
            'Llamamos a la función que se encarga de guardar los datos en la tabla visitas2
            Me.Invoke(New EventHandler(AddressOf guardarVisitante))
        Else
            'Limpiamos la variable temporal
            strTmp = ""
            'Des habilitamos los elementos del formulario desde un método seguro
            Me.Invoke(New EventHandler(AddressOf deshabilitar))
            'Re iniciamos rfidEstado a su estado inicial false
            rfidEstado = False
        End If
    End Sub
End Class
