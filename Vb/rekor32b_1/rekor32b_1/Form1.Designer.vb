<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class scrPrincipal
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(scrPrincipal))
        Me.mnuPrincipal = New System.Windows.Forms.MenuStrip()
        Me.ConfiguraciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BaseDeDatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConexiónSerialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConectarAlDTMFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesconectarDelFTMFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AltaDeUsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BajadeUsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarUsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SoporteTécnicoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombreVisita = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbIdVisita = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFechaVisita = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtHoraVisita = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbIdcasaVisita = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblNombreUsuario = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.spPuerto = New System.IO.Ports.SerialPort(Me.components)
        Me.mnuPrincipal.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuPrincipal
        '
        Me.mnuPrincipal.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.mnuPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguraciónToolStripMenuItem, Me.UsuariosToolStripMenuItem, Me.RegistrosToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.mnuPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.mnuPrincipal.Name = "mnuPrincipal"
        Me.mnuPrincipal.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.mnuPrincipal.Size = New System.Drawing.Size(1006, 30)
        Me.mnuPrincipal.TabIndex = 0
        Me.mnuPrincipal.Text = "MenuStrip1"
        '
        'ConfiguraciónToolStripMenuItem
        '
        Me.ConfiguraciónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BaseDeDatosToolStripMenuItem, Me.ConexiónSerialToolStripMenuItem})
        Me.ConfiguraciónToolStripMenuItem.Name = "ConfiguraciónToolStripMenuItem"
        Me.ConfiguraciónToolStripMenuItem.Size = New System.Drawing.Size(114, 24)
        Me.ConfiguraciónToolStripMenuItem.Text = "&Configuración"
        '
        'BaseDeDatosToolStripMenuItem
        '
        Me.BaseDeDatosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.BaseDeDatosToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BaseDeDatosToolStripMenuItem.Image = CType(resources.GetObject("BaseDeDatosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BaseDeDatosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BaseDeDatosToolStripMenuItem.Name = "BaseDeDatosToolStripMenuItem"
        Me.BaseDeDatosToolStripMenuItem.Size = New System.Drawing.Size(197, 38)
        Me.BaseDeDatosToolStripMenuItem.Text = "&Base de Datos"
        '
        'ConexiónSerialToolStripMenuItem
        '
        Me.ConexiónSerialToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.ConexiónSerialToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConectarAlDTMFToolStripMenuItem, Me.DesconectarDelFTMFToolStripMenuItem})
        Me.ConexiónSerialToolStripMenuItem.Image = CType(resources.GetObject("ConexiónSerialToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ConexiónSerialToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ConexiónSerialToolStripMenuItem.Name = "ConexiónSerialToolStripMenuItem"
        Me.ConexiónSerialToolStripMenuItem.Size = New System.Drawing.Size(197, 38)
        Me.ConexiónSerialToolStripMenuItem.Text = "C&onexión Serial"
        '
        'ConectarAlDTMFToolStripMenuItem
        '
        Me.ConectarAlDTMFToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.ConectarAlDTMFToolStripMenuItem.Name = "ConectarAlDTMFToolStripMenuItem"
        Me.ConectarAlDTMFToolStripMenuItem.Size = New System.Drawing.Size(228, 24)
        Me.ConectarAlDTMFToolStripMenuItem.Text = "Con&ectar al DTMF"
        '
        'DesconectarDelFTMFToolStripMenuItem
        '
        Me.DesconectarDelFTMFToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.DesconectarDelFTMFToolStripMenuItem.Name = "DesconectarDelFTMFToolStripMenuItem"
        Me.DesconectarDelFTMFToolStripMenuItem.Size = New System.Drawing.Size(228, 24)
        Me.DesconectarDelFTMFToolStripMenuItem.Text = "Desconectar del &DTMF"
        '
        'UsuariosToolStripMenuItem
        '
        Me.UsuariosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AltaDeUsuariosToolStripMenuItem, Me.BajadeUsuariosToolStripMenuItem, Me.ModificarUsuariosToolStripMenuItem})
        Me.UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem"
        Me.UsuariosToolStripMenuItem.Size = New System.Drawing.Size(77, 24)
        Me.UsuariosToolStripMenuItem.Text = "&Usuarios"
        '
        'AltaDeUsuariosToolStripMenuItem
        '
        Me.AltaDeUsuariosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.AltaDeUsuariosToolStripMenuItem.Image = CType(resources.GetObject("AltaDeUsuariosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AltaDeUsuariosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AltaDeUsuariosToolStripMenuItem.Name = "AltaDeUsuariosToolStripMenuItem"
        Me.AltaDeUsuariosToolStripMenuItem.Size = New System.Drawing.Size(218, 38)
        Me.AltaDeUsuariosToolStripMenuItem.Text = "A&lta de Usuarios"
        '
        'BajadeUsuariosToolStripMenuItem
        '
        Me.BajadeUsuariosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.BajadeUsuariosToolStripMenuItem.Image = CType(resources.GetObject("BajadeUsuariosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BajadeUsuariosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BajadeUsuariosToolStripMenuItem.Name = "BajadeUsuariosToolStripMenuItem"
        Me.BajadeUsuariosToolStripMenuItem.Size = New System.Drawing.Size(218, 38)
        Me.BajadeUsuariosToolStripMenuItem.Text = "Baja &de Usuarios"
        '
        'ModificarUsuariosToolStripMenuItem
        '
        Me.ModificarUsuariosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.ModificarUsuariosToolStripMenuItem.Image = CType(resources.GetObject("ModificarUsuariosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ModificarUsuariosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ModificarUsuariosToolStripMenuItem.Name = "ModificarUsuariosToolStripMenuItem"
        Me.ModificarUsuariosToolStripMenuItem.Size = New System.Drawing.Size(218, 38)
        Me.ModificarUsuariosToolStripMenuItem.Text = "&Modificar Usuarios"
        '
        'RegistrosToolStripMenuItem
        '
        Me.RegistrosToolStripMenuItem.Name = "RegistrosToolStripMenuItem"
        Me.RegistrosToolStripMenuItem.Size = New System.Drawing.Size(82, 24)
        Me.RegistrosToolStripMenuItem.Text = "&Registros"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SoporteTécnicoToolStripMenuItem, Me.AcercaDeToolStripMenuItem})
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(63, 24)
        Me.AyudaToolStripMenuItem.Text = "&Ayuda"
        '
        'SoporteTécnicoToolStripMenuItem
        '
        Me.SoporteTécnicoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.SoporteTécnicoToolStripMenuItem.Image = CType(resources.GetObject("SoporteTécnicoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SoporteTécnicoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SoporteTécnicoToolStripMenuItem.Name = "SoporteTécnicoToolStripMenuItem"
        Me.SoporteTécnicoToolStripMenuItem.Size = New System.Drawing.Size(202, 38)
        Me.SoporteTécnicoToolStripMenuItem.Text = "&Soporte Técnico"
        '
        'AcercaDeToolStripMenuItem
        '
        Me.AcercaDeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.AcercaDeToolStripMenuItem.Image = CType(resources.GetObject("AcercaDeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AcercaDeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
        Me.AcercaDeToolStripMenuItem.Size = New System.Drawing.Size(202, 38)
        Me.AcercaDeToolStripMenuItem.Text = "&Acerca de"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nombre del visitante:"
        '
        'txtNombreVisita
        '
        Me.txtNombreVisita.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombreVisita.Location = New System.Drawing.Point(249, 97)
        Me.txtNombreVisita.MaxLength = 200
        Me.txtNombreVisita.Name = "txtNombreVisita"
        Me.txtNombreVisita.Size = New System.Drawing.Size(300, 30)
        Me.txtNombreVisita.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.PictureBox1.Location = New System.Drawing.Point(785, 100)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(180, 180)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(780, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 25)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Rostro:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(49, 167)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(202, 25)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Tipo de Identificación:"
        '
        'cmbIdVisita
        '
        Me.cmbIdVisita.FormattingEnabled = True
        Me.cmbIdVisita.Items.AddRange(New Object() {"IFE", "Licencia", "Otro"})
        Me.cmbIdVisita.Location = New System.Drawing.Point(249, 167)
        Me.cmbIdVisita.Name = "cmbIdVisita"
        Me.cmbIdVisita.Size = New System.Drawing.Size(121, 33)
        Me.cmbIdVisita.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(49, 237)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(143, 25)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Fecha Ingreso:"
        '
        'txtFechaVisita
        '
        Me.txtFechaVisita.Location = New System.Drawing.Point(249, 237)
        Me.txtFechaVisita.Name = "txtFechaVisita"
        Me.txtFechaVisita.Size = New System.Drawing.Size(300, 30)
        Me.txtFechaVisita.TabIndex = 8
        Me.txtFechaVisita.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(49, 307)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 25)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Hora Ingreso:"
        '
        'txtHoraVisita
        '
        Me.txtHoraVisita.Location = New System.Drawing.Point(249, 304)
        Me.txtHoraVisita.Name = "txtHoraVisita"
        Me.txtHoraVisita.Size = New System.Drawing.Size(300, 30)
        Me.txtHoraVisita.TabIndex = 10
        Me.txtHoraVisita.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(49, 385)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(166, 25)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Número de Casa:"
        '
        'cmbIdcasaVisita
        '
        Me.cmbIdcasaVisita.FormattingEnabled = True
        Me.cmbIdcasaVisita.Location = New System.Drawing.Point(249, 382)
        Me.cmbIdcasaVisita.Name = "cmbIdcasaVisita"
        Me.cmbIdcasaVisita.Size = New System.Drawing.Size(80, 33)
        Me.cmbIdcasaVisita.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(362, 385)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(187, 25)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Nombre del usuario:"
        '
        'lblNombreUsuario
        '
        Me.lblNombreUsuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNombreUsuario.AutoSize = True
        Me.lblNombreUsuario.Location = New System.Drawing.Point(578, 385)
        Me.lblNombreUsuario.Name = "lblNombreUsuario"
        Me.lblNombreUsuario.Size = New System.Drawing.Size(0, 25)
        Me.lblNombreUsuario.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(780, 473)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(131, 25)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Identificación:"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.PictureBox2.Location = New System.Drawing.Point(785, 501)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(180, 180)
        Me.PictureBox2.TabIndex = 16
        Me.PictureBox2.TabStop = False
        '
        'btnGrabar
        '
        Me.btnGrabar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(54, 617)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(180, 64)
        Me.btnGrabar.TabIndex = 17
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'spPuerto
        '
        Me.spPuerto.BaudRate = 115200
        '
        'scrPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1006, 723)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblNombreUsuario)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmbIdcasaVisita)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtHoraVisita)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtFechaVisita)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbIdVisita)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtNombreVisita)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mnuPrincipal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnuPrincipal
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "scrPrincipal"
        Me.Text = "Rekór 32bits...             Módulo de Entrada                  WAB Ingeniería (C)" & _
            " 2015"
        Me.mnuPrincipal.ResumeLayout(False)
        Me.mnuPrincipal.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuPrincipal As System.Windows.Forms.MenuStrip
    Friend WithEvents ConfiguraciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsuariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BaseDeDatosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SoporteTécnicoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AltaDeUsuariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BajadeUsuariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarUsuariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNombreVisita As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbIdVisita As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFechaVisita As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtHoraVisita As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbIdcasaVisita As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblNombreUsuario As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents ConexiónSerialToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents spPuerto As System.IO.Ports.SerialPort
    Friend WithEvents ConectarAlDTMFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DesconectarDelFTMFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
