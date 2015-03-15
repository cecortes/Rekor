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

        'DEBUG
        'habilitar()
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
End Class