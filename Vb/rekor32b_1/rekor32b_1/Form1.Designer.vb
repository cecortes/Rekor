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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(scrPrincipal))
        Me.mnuPrincipal = New System.Windows.Forms.MenuStrip()
        Me.ConfiguraciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BaseDeDatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AltaDeUsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BajadeUsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarUsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SoporteTécnicoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuPrincipal
        '
        Me.mnuPrincipal.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.mnuPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguraciónToolStripMenuItem, Me.UsuariosToolStripMenuItem, Me.AyudaToolStripMenuItem, Me.RegistrosToolStripMenuItem})
        Me.mnuPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.mnuPrincipal.Name = "mnuPrincipal"
        Me.mnuPrincipal.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.mnuPrincipal.Size = New System.Drawing.Size(1006, 30)
        Me.mnuPrincipal.TabIndex = 0
        Me.mnuPrincipal.Text = "MenuStrip1"
        '
        'ConfiguraciónToolStripMenuItem
        '
        Me.ConfiguraciónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BaseDeDatosToolStripMenuItem})
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
        Me.BaseDeDatosToolStripMenuItem.Size = New System.Drawing.Size(189, 38)
        Me.BaseDeDatosToolStripMenuItem.Text = "&Base de Datos"
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
        'RegistrosToolStripMenuItem
        '
        Me.RegistrosToolStripMenuItem.Name = "RegistrosToolStripMenuItem"
        Me.RegistrosToolStripMenuItem.Size = New System.Drawing.Size(82, 24)
        Me.RegistrosToolStripMenuItem.Text = "&Registros"
        '
        'scrPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1006, 723)
        Me.Controls.Add(Me.mnuPrincipal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnuPrincipal
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "scrPrincipal"
        Me.Text = "Rekór 32bits...             Módulo de Entrada                  César López (C)201" & _
            "5 "
        Me.mnuPrincipal.ResumeLayout(False)
        Me.mnuPrincipal.PerformLayout()
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

End Class
