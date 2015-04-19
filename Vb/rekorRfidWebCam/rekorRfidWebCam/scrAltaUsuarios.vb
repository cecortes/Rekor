Public Class scrAltaUsuarios

    Private Sub btnSaveClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveClose.Click
        Dim conexion As New class_insert_datos
        Dim datos As New class_datos

        'Revisamos si el cuadro de texto de la IP o el del Usuario o el Pass están vacíos, de ser así desplegamos un mensaje al usuario
        'para que ponga los datos necesarios o reinicie la aplicación.
        If _varglobal.ip = "" Or _varglobal.pass = "" Or _varglobal.user = "" Then
            MessageBox.Show("Por favor revise los parámetros de conexión y de click en Guardar." & vbNewLine & "" & vbNewLine & "Dirección IP (default): 192.168.1.92" & vbNewLine & "Usuario (default): root" & vbNewLine & "Contraseña (default): ZMalqp10", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            'Mostramos el panel de conexión
            mysqlSettings.Show()
            Return
        End If

        'Checamos que los datos no esten vacíos
        If txtNombreContacto.Text = "" Then
            MessageBox.Show("El campo de Nombre no puede estar vacío", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If txtIdCasas.Text = "" Then
            MessageBox.Show("El campo de Casa no puede estar vacío", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If txtTelCasa.Text = "" Then
            MessageBox.Show("El campo de Teléfono Casa no puede estar vacío", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If txtTelCel.Text = "" Then
            MessageBox.Show("El campo de Teléfono Celular no puede estar vacío", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        datos.nombrecontacto = txtNombreContacto.Text
        datos.idcasas = txtIdCasas.Text
        datos.telcasa = txtTelCasa.Text
        datos.telcel = txtTelCel.Text

        If conexion.insertarDatos(datos) Then
            MessageBox.Show("Datos Guardados", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Datos no guardados", "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        'Limpiamos los campos de los cuadros de texto
        txtIdCasas.Text = ""
        txtNombreContacto.Text = ""
        txtTelCasa.Text = ""
        txtTelCel.Text = ""
    End Sub
End Class