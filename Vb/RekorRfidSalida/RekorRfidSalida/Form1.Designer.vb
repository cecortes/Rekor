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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.menu = New System.Windows.Forms.MenuStrip()
        Me.ConfiguraciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BaseDeDatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConexiónSerialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConectarAlRFIDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SoporteTécnicoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pbxRostro = New System.Windows.Forms.PictureBox()
        Me.pbxId = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblNombreVisita = New System.Windows.Forms.Label()
        Me.lblId = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblHoraEntrada = New System.Windows.Forms.Label()
        Me.lblHoraSalida = New System.Windows.Forms.Label()
        Me.lblCasa = New System.Windows.Forms.Label()
        Me.spPuerto = New System.IO.Ports.SerialPort(Me.components)
        Me.tmrTimer = New System.Windows.Forms.Timer(Me.components)
        Me.tmrTimer2 = New System.Windows.Forms.Timer(Me.components)
        Me.menu.SuspendLayout()
        CType(Me.pbxRostro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxId, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'menu
        '
        Me.menu.BackColor = System.Drawing.Color.SlateBlue
        Me.menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguraciónToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.menu.Location = New System.Drawing.Point(0, 0)
        Me.menu.Name = "menu"
        Me.menu.Size = New System.Drawing.Size(1006, 28)
        Me.menu.TabIndex = 0
        Me.menu.Text = "MenuStrip1"
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
        Me.BaseDeDatosToolStripMenuItem.BackColor = System.Drawing.Color.SlateBlue
        Me.BaseDeDatosToolStripMenuItem.Image = CType(resources.GetObject("BaseDeDatosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BaseDeDatosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BaseDeDatosToolStripMenuItem.Name = "BaseDeDatosToolStripMenuItem"
        Me.BaseDeDatosToolStripMenuItem.Size = New System.Drawing.Size(197, 38)
        Me.BaseDeDatosToolStripMenuItem.Text = "&Base de Datos"
        '
        'ConexiónSerialToolStripMenuItem
        '
        Me.ConexiónSerialToolStripMenuItem.BackColor = System.Drawing.Color.SlateBlue
        Me.ConexiónSerialToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConectarAlRFIDToolStripMenuItem})
        Me.ConexiónSerialToolStripMenuItem.Image = CType(resources.GetObject("ConexiónSerialToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ConexiónSerialToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ConexiónSerialToolStripMenuItem.Name = "ConexiónSerialToolStripMenuItem"
        Me.ConexiónSerialToolStripMenuItem.Size = New System.Drawing.Size(197, 38)
        Me.ConexiónSerialToolStripMenuItem.Text = "&Conexión Serial"
        '
        'ConectarAlRFIDToolStripMenuItem
        '
        Me.ConectarAlRFIDToolStripMenuItem.BackColor = System.Drawing.Color.SlateBlue
        Me.ConectarAlRFIDToolStripMenuItem.Image = CType(resources.GetObject("ConectarAlRFIDToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ConectarAlRFIDToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ConectarAlRFIDToolStripMenuItem.Name = "ConectarAlRFIDToolStripMenuItem"
        Me.ConectarAlRFIDToolStripMenuItem.Size = New System.Drawing.Size(204, 38)
        Me.ConectarAlRFIDToolStripMenuItem.Text = "C&onectar al RFID"
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
        Me.SoporteTécnicoToolStripMenuItem.BackColor = System.Drawing.Color.SlateBlue
        Me.SoporteTécnicoToolStripMenuItem.Image = CType(resources.GetObject("SoporteTécnicoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SoporteTécnicoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SoporteTécnicoToolStripMenuItem.Name = "SoporteTécnicoToolStripMenuItem"
        Me.SoporteTécnicoToolStripMenuItem.Size = New System.Drawing.Size(202, 38)
        Me.SoporteTécnicoToolStripMenuItem.Text = "&Soporte Técnico"
        '
        'AcercaDeToolStripMenuItem
        '
        Me.AcercaDeToolStripMenuItem.BackColor = System.Drawing.Color.SlateBlue
        Me.AcercaDeToolStripMenuItem.Image = CType(resources.GetObject("AcercaDeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AcercaDeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
        Me.AcercaDeToolStripMenuItem.Size = New System.Drawing.Size(202, 38)
        Me.AcercaDeToolStripMenuItem.Text = "&Acerca de"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nombre del visitante:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(202, 25)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Tipo de Identificación:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 196)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(143, 25)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Fecha Ingreso:"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(401, 196)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 25)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Hora Ingreso:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(705, 196)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 25)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Hora Salida:"
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 278)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(237, 25)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Número de Casa visitada:"
        '
        'pbxRostro
        '
        Me.pbxRostro.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbxRostro.BackColor = System.Drawing.Color.White
        Me.pbxRostro.Location = New System.Drawing.Point(17, 447)
        Me.pbxRostro.Name = "pbxRostro"
        Me.pbxRostro.Size = New System.Drawing.Size(320, 240)
        Me.pbxRostro.TabIndex = 15
        Me.pbxRostro.TabStop = False
        '
        'pbxId
        '
        Me.pbxId.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxId.BackColor = System.Drawing.Color.White
        Me.pbxId.Location = New System.Drawing.Point(674, 447)
        Me.pbxId.Name = "pbxId"
        Me.pbxId.Size = New System.Drawing.Size(320, 240)
        Me.pbxId.TabIndex = 16
        Me.pbxId.TabStop = False
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 419)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 25)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Rostro:"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(669, 419)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(131, 25)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Identificación:"
        '
        'lblNombreVisita
        '
        Me.lblNombreVisita.AutoSize = True
        Me.lblNombreVisita.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.lblNombreVisita.Location = New System.Drawing.Point(212, 72)
        Me.lblNombreVisita.Name = "lblNombreVisita"
        Me.lblNombreVisita.Size = New System.Drawing.Size(87, 25)
        Me.lblNombreVisita.TabIndex = 19
        Me.lblNombreVisita.Text = "Visitante"
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.lblId.Location = New System.Drawing.Point(220, 137)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(125, 25)
        Me.lblId.TabIndex = 20
        Me.lblId.Text = "Identificación"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.lblFecha.Location = New System.Drawing.Point(161, 196)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(127, 25)
        Me.lblFecha.TabIndex = 21
        Me.lblFecha.Text = "Día/Mes/Año"
        '
        'lblHoraEntrada
        '
        Me.lblHoraEntrada.AutoSize = True
        Me.lblHoraEntrada.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.lblHoraEntrada.Location = New System.Drawing.Point(537, 196)
        Me.lblHoraEntrada.Name = "lblHoraEntrada"
        Me.lblHoraEntrada.Size = New System.Drawing.Size(112, 25)
        Me.lblHoraEntrada.TabIndex = 22
        Me.lblHoraEntrada.Text = "Hr:Min:Seg"
        '
        'lblHoraSalida
        '
        Me.lblHoraSalida.AutoSize = True
        Me.lblHoraSalida.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.lblHoraSalida.Location = New System.Drawing.Point(831, 196)
        Me.lblHoraSalida.Name = "lblHoraSalida"
        Me.lblHoraSalida.Size = New System.Drawing.Size(112, 25)
        Me.lblHoraSalida.TabIndex = 23
        Me.lblHoraSalida.Text = "Hr:Min:Seg"
        '
        'lblCasa
        '
        Me.lblCasa.AutoSize = True
        Me.lblCasa.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.lblCasa.Location = New System.Drawing.Point(254, 278)
        Me.lblCasa.Name = "lblCasa"
        Me.lblCasa.Size = New System.Drawing.Size(34, 25)
        Me.lblCasa.TabIndex = 24
        Me.lblCasa.Text = "##"
        '
        'spPuerto
        '
        Me.spPuerto.BaudRate = 115200
        '
        'tmrTimer
        '
        Me.tmrTimer.Interval = 1500
        '
        'tmrTimer2
        '
        Me.tmrTimer2.Interval = 10000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1006, 723)
        Me.Controls.Add(Me.lblCasa)
        Me.Controls.Add(Me.lblHoraSalida)
        Me.Controls.Add(Me.lblHoraEntrada)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.lblNombreVisita)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.pbxId)
        Me.Controls.Add(Me.pbxRostro)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.menu)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menu
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "Rékor 32b     Módulo de Salida                 WAB Ingeniería (C) 2015"
        Me.menu.ResumeLayout(False)
        Me.menu.PerformLayout()
        CType(Me.pbxRostro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxId, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents menu As System.Windows.Forms.MenuStrip
    Friend WithEvents ConfiguraciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pbxRostro As System.Windows.Forms.PictureBox
    Friend WithEvents pbxId As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblNombreVisita As System.Windows.Forms.Label
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents lblHoraEntrada As System.Windows.Forms.Label
    Friend WithEvents lblHoraSalida As System.Windows.Forms.Label
    Friend WithEvents lblCasa As System.Windows.Forms.Label
    Friend WithEvents BaseDeDatosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConexiónSerialToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SoporteTécnicoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents spPuerto As System.IO.Ports.SerialPort
    Friend WithEvents tmrTimer As System.Windows.Forms.Timer
    Friend WithEvents ConectarAlRFIDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrTimer2 As System.Windows.Forms.Timer

End Class
