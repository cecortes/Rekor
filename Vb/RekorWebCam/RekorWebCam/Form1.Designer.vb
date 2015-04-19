<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.pbxImagen = New System.Windows.Forms.PictureBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lbUsbCam = New System.Windows.Forms.ListBox()
        CType(Me.pbxImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbxImagen
        '
        Me.pbxImagen.BackColor = System.Drawing.Color.White
        Me.pbxImagen.Location = New System.Drawing.Point(674, 40)
        Me.pbxImagen.Name = "pbxImagen"
        Me.pbxImagen.Size = New System.Drawing.Size(320, 240)
        Me.pbxImagen.TabIndex = 0
        Me.pbxImagen.TabStop = False
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(12, 576)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(98, 49)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "Iniciar"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(211, 576)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(98, 49)
        Me.btnStop.TabIndex = 2
        Me.btnStop.Text = "Detener"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(795, 286)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(98, 49)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Guardar"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lbUsbCam
        '
        Me.lbUsbCam.BackColor = System.Drawing.Color.LightGreen
        Me.lbUsbCam.FormattingEnabled = True
        Me.lbUsbCam.ItemHeight = 18
        Me.lbUsbCam.Location = New System.Drawing.Point(12, 30)
        Me.lbUsbCam.Name = "lbUsbCam"
        Me.lbUsbCam.Size = New System.Drawing.Size(418, 76)
        Me.lbUsbCam.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1013, 637)
        Me.Controls.Add(Me.lbUsbCam)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.pbxImagen)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "Rekor WebCam Prueba2"
        CType(Me.pbxImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbxImagen As System.Windows.Forms.PictureBox
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lbUsbCam As System.Windows.Forms.ListBox

End Class
