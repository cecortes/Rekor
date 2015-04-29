<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class scrSerial
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(scrSerial))
        Me.btnDterminarPuertos = New System.Windows.Forms.Button()
        Me.cmbPorts = New System.Windows.Forms.ComboBox()
        Me.btnGuardarPto = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnDterminarPuertos
        '
        Me.btnDterminarPuertos.Image = CType(resources.GetObject("btnDterminarPuertos.Image"), System.Drawing.Image)
        Me.btnDterminarPuertos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDterminarPuertos.Location = New System.Drawing.Point(12, 33)
        Me.btnDterminarPuertos.Name = "btnDterminarPuertos"
        Me.btnDterminarPuertos.Size = New System.Drawing.Size(239, 52)
        Me.btnDterminarPuertos.TabIndex = 0
        Me.btnDterminarPuertos.Text = "&Determinar Puertos"
        Me.btnDterminarPuertos.UseVisualStyleBackColor = True
        '
        'cmbPorts
        '
        Me.cmbPorts.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.cmbPorts.FormattingEnabled = True
        Me.cmbPorts.Location = New System.Drawing.Point(286, 44)
        Me.cmbPorts.Name = "cmbPorts"
        Me.cmbPorts.Size = New System.Drawing.Size(201, 33)
        Me.cmbPorts.TabIndex = 1
        '
        'btnGuardarPto
        '
        Me.btnGuardarPto.Image = CType(resources.GetObject("btnGuardarPto.Image"), System.Drawing.Image)
        Me.btnGuardarPto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardarPto.Location = New System.Drawing.Point(144, 204)
        Me.btnGuardarPto.Name = "btnGuardarPto"
        Me.btnGuardarPto.Size = New System.Drawing.Size(189, 54)
        Me.btnGuardarPto.TabIndex = 2
        Me.btnGuardarPto.Text = "&Guardar"
        Me.btnGuardarPto.UseVisualStyleBackColor = True
        '
        'scrSerial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 311)
        Me.Controls.Add(Me.btnGuardarPto)
        Me.Controls.Add(Me.cmbPorts)
        Me.Controls.Add(Me.btnDterminarPuertos)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "scrSerial"
        Me.Text = "Parámetros de conexión Serial Rekor 32 bits."
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnDterminarPuertos As System.Windows.Forms.Button
    Friend WithEvents cmbPorts As System.Windows.Forms.ComboBox
    Friend WithEvents btnGuardarPto As System.Windows.Forms.Button
End Class
