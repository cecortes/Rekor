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
Public Class scrPrincipal
    '****************************************************************************************************
    'Variables Globales:
    'Se declaran las variables que se ocupan dentro de este formulario
    '****************************************************************************************************
    Dim strBufferIn As String   'Variable para recibir el dato del puerto Serial
    Dim strTmp As String        'Variable temporal para construir el código recibido por el DTMF
    Dim rfidEstado As Boolean = False 'Variable para saber si se va a recibir el número serial de la tarjeta
    Dim rfidSN As String        'Variable para guardar el número serial del RFID

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
        'Deshabilitamos los elementos del formulario hasta que recibamos el código del usuario vía telefónica
        deshabilitar()

        'Si la variable del puerto serial está vacía, llamamos al formulario para configurar el puerto
        If _varglobal.puertoSerial = "" Then
            scrSerial.Show()
        End If
        'DEBUG
        'habilitar()
        'scrSerial.Show()
        'tmrTimer.Enabled = False
        'btnGrabar.Enabled = True
    End Sub

    Private Sub BajadeUsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BajadeUsuariosToolStripMenuItem.Click
        'Mostramos la pantalla para borrar usuarios
        scrBajaUsuarios.Show()
    End Sub

    Private Sub ModificarUsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarUsuariosToolStripMenuItem.Click
        'Llamamos al formulario para actualizar datos del usuario
        scrActualizarUsuarios.Show()
    End Sub

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

        PictureBox1.Enabled = False
        PictureBox2.Enabled = False

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

        PictureBox1.Enabled = True
        PictureBox2.Enabled = True

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
            MessageBox.Show("El campo de Nombre no puede estar vacío", "Rekor 32bits", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If cmbIdVisita.Text = "" Then
            MessageBox.Show("El tipo de identificación no puede estar vacío", "Rekor 32bits", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If txtFechaVisita.Text = "" Then
            MessageBox.Show("El campo de Fecha de ingreso no puede estar vacío", "Rekor 32bits", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If txtHoraVisita.Text = "" Then
            MessageBox.Show("El campo de Hora de ingreso no puede estar vacío", "Rekor 32bits", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If cmbIdcasaVisita.Text = "" Then
            MessageBox.Show("El número de casa no puede estar vacío", "Rekor 32bits", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            MessageBox.Show("Los datos del visitante han sido guardados correctamente" & vbNewLine & "" & vbNewLine & "La tarjeta RFID ya puede ser entregada al visitante, Gracias", "Rekors CPU 32bits", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Actualizamos los campos de Fecha y Hora
            fecha_hora()
            'Llamamos a la función para limpiar los datos
            limpiarFormulario()
            'Des habilitamos el panel para recibir otro visitante
            deshabilitar()
        Else
            MessageBox.Show("Datos del visitante no guardados", "Rekor 32bits", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub ConexiónSerialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConexiónSerialToolStripMenuItem.Click
        scrSerial.Show()
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
            MessageBox.Show("Conexión USB exitosa." & vbNewLine & _varglobal.puertoSerial, "Rekors CPU 32bits", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            'Si el edoConexión es falso entonces llamamos a configurar los parámetros de conexión
            MessageBox.Show("No se ha iniciado la comunicación USB, configure los parámetros." & vbNewLine & "" & vbNewLine & "Puerto Serial (común): COM3" & vbNewLine & "" & vbNewLine & "Puede revisar en el administrador de dispositivos para saber el nombre del puerto serial.", "Rekors CPU 32bits", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            scrSerial.Show()
        End If
    End Sub

    Private Sub DesconectarDelFTMFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesconectarDelFTMFToolStripMenuItem.Click
        'Esta función cierra el puerto serial y termina la comunicación USB
        spPuerto.Close()
        _varglobal.edoConexion = False
        _varglobal.puertoSerial = ""
        MessageBox.Show("La conexión USB ha sido terminada." & vbNewLine & _varglobal.puertoSerial, "Rekors CPU 32bits", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            MessageBox.Show("Acceso habilitado desde el número telefónico." & vbNewLine & _varglobal.puertoSerial, "Rekors CPU 32bits", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            MessageBox.Show("Los datos del visitante serán guardados en la tarjeta RFID: " & vbNewLine & "" & vbNewLine & rfidSN & vbNewLine & "" & vbNewLine & "Por el momento no mueva la tarjeta RFID del lector.", "Rekors CPU 32bits", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        'Función para mandar un dato por el puerto serial y pedirle al módulo RFID regrese el SN de la tarjeta RFID
        If spPuerto.IsOpen Then
            'Envíamos el comando al Arduino para leer el RFID, si es que el puerto está abierto
            spPuerto.Write("#")
        Else
            'Mostramos un mensaje al usuario y lo mandamos al panel de conexión
            MessageBox.Show("Puerto COM se encuentra desconectado." & vbNewLine & "Favor de revisar la configuración", "Rekors CPU 32bits", MessageBoxButtons.OK, MessageBoxIcon.Information)
            scrSerial.Show()
        End If
    End Sub
End Class