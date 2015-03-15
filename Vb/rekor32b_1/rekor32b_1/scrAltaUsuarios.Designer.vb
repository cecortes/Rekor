<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class scrAltaUsuarios
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(scrAltaUsuarios))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombreContacto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIdCasas = New System.Windows.Forms.TextBox()
        Me.txtTelCasa = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTelCel = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSaveClose = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 171)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(290, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre del usuario (Completo):"
        '
        'txtNombreContacto
        '
        Me.txtNombreContacto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombreContacto.BackColor = System.Drawing.Color.Honeydew
        Me.txtNombreContacto.Location = New System.Drawing.Point(338, 168)
        Me.txtNombreContacto.MaxLength = 200
        Me.txtNombreContacto.Name = "txtNombreContacto"
        Me.txtNombreContacto.Size = New System.Drawing.Size(600, 30)
        Me.txtNombreContacto.TabIndex = 1
        Me.txtNombreContacto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 250)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(166, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Número de Casa:"
        '
        'txtIdCasas
        '
        Me.txtIdCasas.BackColor = System.Drawing.Color.Honeydew
        Me.txtIdCasas.Location = New System.Drawing.Point(338, 247)
        Me.txtIdCasas.MaxLength = 6
        Me.txtIdCasas.Name = "txtIdCasas"
        Me.txtIdCasas.Size = New System.Drawing.Size(120, 30)
        Me.txtIdCasas.TabIndex = 3
        Me.txtIdCasas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTelCasa
        '
        Me.txtTelCasa.BackColor = System.Drawing.Color.Honeydew
        Me.txtTelCasa.Location = New System.Drawing.Point(338, 327)
        Me.txtTelCasa.MaxLength = 10
        Me.txtTelCasa.Name = "txtTelCasa"
        Me.txtTelCasa.Size = New System.Drawing.Size(120, 30)
        Me.txtTelCasa.TabIndex = 5
        Me.txtTelCasa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(42, 330)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(174, 25)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Teléfono de Casa:"
        '
        'txtTelCel
        '
        Me.txtTelCel.BackColor = System.Drawing.Color.Honeydew
        Me.txtTelCel.Location = New System.Drawing.Point(338, 409)
        Me.txtTelCel.MaxLength = 11
        Me.txtTelCel.Name = "txtTelCel"
        Me.txtTelCel.Size = New System.Drawing.Size(120, 30)
        Me.txtTelCel.TabIndex = 7
        Me.txtTelCel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(42, 412)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(162, 25)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Teléfono Celular:"
        '
        'btnSaveClose
        '
        Me.btnSaveClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSaveClose.Image = CType(resources.GetObject("btnSaveClose.Image"), System.Drawing.Image)
        Me.btnSaveClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveClose.Location = New System.Drawing.Point(124, 599)
        Me.btnSaveClose.Name = "btnSaveClose"
        Me.btnSaveClose.Size = New System.Drawing.Size(278, 64)
        Me.btnSaveClose.TabIndex = 8
        Me.btnSaveClose.Text = "&Guardar y Cerrar"
        Me.btnSaveClose.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.Location = New System.Drawing.Point(612, 599)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(278, 64)
        Me.btnLimpiar.TabIndex = 9
        Me.btnLimpiar.Text = "&Limpiar campos"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'scrAltaUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1006, 723)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnSaveClose)
        Me.Controls.Add(Me.txtTelCel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTelCasa)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtIdCasas)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNombreContacto)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "scrAltaUsuarios"
        Me.Text = "Rekór 32bits...             Alta de Usuarios                  WAB Ingeniería (C)2" & _
            "015 "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNombreContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIdCasas As System.Windows.Forms.TextBox
    Friend WithEvents txtTelCasa As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTelCel As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSaveClose As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
End Class
