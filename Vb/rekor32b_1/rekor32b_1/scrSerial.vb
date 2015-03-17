Public Class scrSerial

    Private Sub scrSerial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Iniciamos el formulario con el botón de guardar y el combo box deshabilitados
        cmbPorts.Enabled = False
        btnGuardarPto.Enabled = False
        'Deshabilitamos la conexión serial
        _varglobal.edoConexion = False
    End Sub

    Private Sub btnDeterminarPuertos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeterminarPuertos.Click
        'Iniciamos el contenido del cboPuertos
        cmbPorts.Items.Clear()

        'Cargamos el contenido de todos los puertos detectados en el combo box
        For Each PuertosDisponibles As String In My.Computer.Ports.SerialPortNames
            cmbPorts.Items.Add(PuertosDisponibles)
        Next

        'Si exiten puertos disponibles los cargamos como texto
        If cmbPorts.Items.Count > 0 Then
            cmbPorts.Text = cmbPorts.Items(0)
            'Mostramos el mensaje de ayuda al usuario
            MessageBox.Show("Por favor seleccione el puerto serial y de click en Guardar." & vbNewLine & "" & vbNewLine & "Puerto Serial (común): COM3" & vbNewLine & "" & vbNewLine & "Puede revisar en el administrador de dispositivos para saber el nombre del puerto serial.", "Rekors CPU 32bits", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Habilitamos el combo box
            cmbPorts.Enabled = True
            'Habilitamos el botón de Guardar
            btnGuardarPto.Enabled = True

        Else
            'Si no existen los puertos mostramos el mensaje de ayuda y deshabilitamos el botón de guardar y el combo box
            MessageBox.Show("No se encontró ningún puerto disponible." & vbNewLine & "" & vbNewLine & "Verifique que el dispositivo está conectado y consulte al soporte técnico.", "Rekor 32bits", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbPorts.Enabled = False
            btnGuardarPto.Enabled = False

            cmbPorts.Items.Clear()
            cmbPorts.Text = ("                  ")
        End If
    End Sub

    Private Sub btnGuardarPto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarPto.Click
        'Esta función se encarga de guardar el nombre del puerto serial en su variable global que le corresponde
        'Creamos una variable para recibir el resultado del mensaje para el usuario
        Dim resultado As DialogResult

        'Mostramos al usuario los parámetros de conexión en un mensaje y cerramos el formulario
        resultado = MessageBox.Show("Se iniciará la conexión serial en el puerto: " & vbNewLine & _varglobal.puertoSerial & vbNewLine & "Oprima Si para continuar, para conectarse al DTMF vaya al menú de Configuración -> Conexión Serial -> Conectar al DTMF" & vbNewLine & "" & vbNewLine & "Oprima No si quiere seleccionar otro puerto.", "Rekors CPU 32bits", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If resultado = DialogResult.Yes Then
            'Guardamos el puerto serial en la variable global
            _varglobal.puertoSerial = cmbPorts.Text
            'Habilitamos la conexión serial para conectarse
            _varglobal.edoConexion = True
            'Cerramos el formulario
            Me.Close()
        Else
            Return
        End If
    End Sub
End Class