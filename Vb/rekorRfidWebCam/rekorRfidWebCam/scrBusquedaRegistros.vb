'Importamos las referencias necesarias para trabajar con mysql
Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient

Public Class scrBusquedaRegistros
    '****************************************************************************************************
    'Variables Globales:
    'Se declaran las variables que se ocupan dentro de este formulario
    '****************************************************************************************************
    Dim rostroPath As String    'Variable para guardar el directorio de la foto del rostro
    Dim idPath As String        'Variable para guardar el directorio de la foto del id

    Public Sub deshabilitar()
        'Esta función se encarga de borrar los textos de las etiquetas del formulario
        lblUsuario.Text = ""
        lblTelCasa.Text = ""
        lblTelCel.Text = ""
    End Sub

    Public Sub cmbUpdate()
        'Esta función se encarga de llenar los campos del id de casas en el combo box
        'Re iniciamos los datos en caso de ser actualizados
        _dtscbx.Reset()

        'Llamamos a la consulta de los datos
        consulta_datos()
        'Cargamos los datos de la tabla usuarios
        cmbCasaVisita.DataSource = _dtscbx.Tables("usuarios")
        'Cargamos los datos de la columna idcasas
        cmbCasaVisita.DisplayMember = "idcasas"
    End Sub

    Public Sub datagrid_formato()
        'Esta función cambia el formato del data grid
        dgvVisitas.Columns(0).HeaderText = "DB"
        dgvVisitas.Columns(1).HeaderText = "Nombre de la Visita"
        dgvVisitas.Columns(2).HeaderText = "Id"
        dgvVisitas.Columns(3).HeaderText = "Fecha"
        dgvVisitas.Columns(4).HeaderText = "Entrada"
        dgvVisitas.Columns(5).HeaderText = "Salida"

        dgvVisitas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvVisitas.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvVisitas.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvVisitas.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvVisitas.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvVisitas.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgvVisitas.Columns(0).Width = 65
        dgvVisitas.Columns(1).Width = 280
        dgvVisitas.Columns(2).Width = 120
        dgvVisitas.Columns(3).Width = 150
        dgvVisitas.Columns(4).Width = 150
        dgvVisitas.Columns(5).Width = 150
    End Sub

    Private Sub scrBusquedaRegistros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Borramos los textos iniciales
        deshabilitar()
        'Actualizamos los datos del combo box
        cmbUpdate()
        'Capturamos la fecha seleccionada y la guardamos en la variable global FechaInicio para evitar un error en la consulta
        _varglobal.FechaInicio = dtpInicio.Text
        'Capturamos la fecha seleccionada y la guardamos en la variable global FechaFinal para evitar un error en la consulta
        _varglobal.FechaFinal = dtpFinal.Text
    End Sub

    Private Sub cmbCasaVisita_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCasaVisita.SelectedValueChanged
        'Esta función se dispara cuando cambia el valor del combo box y busca en la tabla de usuarios los datos del
        'número de casa seleccionada para mostrarlos en sus respectivas etiquetas.
        Dim comandoSql As MySqlCommand
        Dim resultado As MySqlDataReader
        'Conectamos a la base de datos dentro de un TRY
        Try
            conexion_Global()
            _conexion.Open()
            comandoSql = New MySqlCommand("select * from usuarios where idcasas='" & cmbCasaVisita.Text & "'", _conexion)
            resultado = comandoSql.ExecuteReader
            'Dentro de un ciclo leemos los resultados
            While resultado.Read
                lblUsuario.Text = resultado.GetString("nombrecontacto")
                lblTelCasa.Text = resultado.GetString("telcasa")
                lblTelCel.Text = resultado.GetString("telcel")
            End While
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Rekor 32bits", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cerrar()
        End Try

        'Guardamos el valor seleccionado del combo box en la variable global ncasas
        _varglobal.ncasas = cmbCasaVisita.Text
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        'Esta función es llamada para consultar la table visitas3 que contiene todos los registros de visitantes una vez
        'que ya salieron y fueron tomados sus datos de salida
        'Re iniciamos el indice de los datos
        _dtsdatos.Reset()

        'Llamamos a la consulta para llenar los datos en el DataGrid
        consulta_visitas()
        dgvVisitas.DataSource = _dtvdatos
        'Llamamos a la función que le da formato al datagrid
        datagrid_formato()
    End Sub

    Private Sub dtpInicio_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpInicio.ValueChanged
        'Capturamos la fecha seleccionada y la guardamos en la variable global FechaInicio
        _varglobal.FechaInicio = dtpInicio.Text
    End Sub

    Private Sub dtpFinal_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFinal.ValueChanged
        'Capturamos la fecha seleccionada y la guardamos en la variable global FechaInicio
        _varglobal.FechaFinal = dtpFinal.Text
    End Sub

    Private Sub dgvVisitas_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvVisitas.CellMouseClick
        'Esta función se dispara cuando se hace click en los valores de la tabla, de esta manera se mostrarán las fotos
        'en sus respectivos picture box
        'Capturamos en una variable la fila seleccionada
        Dim db As Integer
        db = dgvVisitas.Rows(dgvVisitas.CurrentRow.Index).Cells(0).Value

        'Función para consultar la tabla de visitas3 y extraer los datos del path
        Dim comandoSql As MySqlCommand
        Dim resultado As MySqlDataReader

        'Conectamos a la base de datos dentro de un TRY
        Try
            conexion_Global()
            _conexion.Open()
            comandoSql = New MySqlCommand("select PicRostro, PicId from visitas3 where idvisita='" & db & "'", _conexion)
            resultado = comandoSql.ExecuteReader
            'Dentro de un ciclo leemos los resultados
            While resultado.Read
                rostroPath = resultado.GetString("PicRostro")
                idPath = resultado.GetString("PicId")
            End While
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Rekor 32bits RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cerrar()
        End Try

        'Mostramos las fotos en los picture box
        'Hacemos que la imágen se ajuste al tamaño del picture box del rostro y de la credencial
        pbxRostro.SizeMode = PictureBoxSizeMode.StretchImage
        pbxId.SizeMode = PictureBoxSizeMode.StretchImage

        Try
            pbxRostro.Image = System.Drawing.Image.FromFile(rostroPath)
            pbxId.Image = System.Drawing.Image.FromFile(idPath)
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & vbCrLf & "Error al cargar la imágen, verifique que el equipo se encuentre conectado a la red.", "Rekor 32bits RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class