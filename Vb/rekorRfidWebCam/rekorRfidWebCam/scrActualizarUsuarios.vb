Public Class scrActualizarUsuarios

    Private Sub scrActualizarUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Re iniciamos el indice de los datos
        _dtsdatos.Reset()
        'Llamamos a la consulta para llenar los datos en el DataGrid
        consulta_datos()
        dgvUsuarios.DataSource = _dtvdatos
        'Llamamos a la función que le da formato al datagrid
        datagrid_formato()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        'Creamos las variables de las clases insert_datos y datos
        Dim conexion As New class_insert_datos
        Dim datos As New class_datos
        'Re iniciamos el indice de los datos
        _dtsdatos.Reset()

        'Cargamos la información de la llave primaria y se la pasamos a datos para actualizar los datos de la tabla
        datos.idusuario = _varglobal.usuario_index
        'Cargamos toda la informacion en los textbox, el indice que se ocupa para actualizar es txtIdCasas
        datos.nombrecontacto = txtNombreContacto.Text
        datos.idcasas = txtIdCasas.Text
        datos.telcasa = txtTelCasa.Text
        datos.telcel = txtTelCel.Text

        'Dentro de un if verificamos que los datos sean eliminados
        If conexion.actualizarUsuario(datos) Then
            MessageBox.Show("Usuario actualizado correctamente !!!", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Actualizamos los datos que se muestran en el data grid view y limpiamos los text box
            limpiar_actualizar()
        Else
            MessageBox.Show("El usuario no pudo actualizarse en la base de datos", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub dgvUsuarios_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvUsuarios.CellMouseClick
        'Esta función es llamada cada vez que se hace click en alguno de los campos del datagridview
        Try
            'Obtenemos la llave primaria de la fila seleccionada y la guardamos en la variable global
            _varglobal.usuario_index = dgvUsuarios.Rows(dgvUsuarios.CurrentRow.Index).Cells(0).Value
            'Llenamos los campos de los text box con el valor que le corresponde del datagridview
            txtNombreContacto.Text = dgvUsuarios.Rows(dgvUsuarios.CurrentRow.Index).Cells(1).Value
            txtIdCasas.Text = dgvUsuarios.Rows(dgvUsuarios.CurrentRow.Index).Cells(2).Value
            txtTelCasa.Text = dgvUsuarios.Rows(dgvUsuarios.CurrentRow.Index).Cells(3).Value
            txtTelCel.Text = dgvUsuarios.Rows(dgvUsuarios.CurrentRow.Index).Cells(4).Value
        Catch ex As NullReferenceException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub limpiar_actualizar()
        'Esta función limpia los datos de los texbox y actualiza la información del data grid view
        txtNombreContacto.Text = ""
        txtIdCasas.Text = ""
        txtTelCasa.Text = ""
        txtTelCel.Text = ""

        consulta_datos()
        dgvUsuarios.DataSource = _dtvdatos
    End Sub

    Public Sub datagrid_formato()
        'Esta función cambia el formato del data grid
        dgvUsuarios.Columns(0).HeaderText = "Id DB"
        dgvUsuarios.Columns(1).HeaderText = "Nombre del Usuario"
        dgvUsuarios.Columns(2).HeaderText = "Número de Casa"
        dgvUsuarios.Columns(3).HeaderText = "Teléfono de Casa"
        dgvUsuarios.Columns(4).HeaderText = "Teléfono Celular"

        dgvUsuarios.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvUsuarios.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvUsuarios.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvUsuarios.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvUsuarios.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgvUsuarios.Columns(0).Width = 85
        dgvUsuarios.Columns(1).Width = 210
        dgvUsuarios.Columns(2).Width = 200
        dgvUsuarios.Columns(3).Width = 200
        dgvUsuarios.Columns(4).Width = 200
    End Sub
End Class