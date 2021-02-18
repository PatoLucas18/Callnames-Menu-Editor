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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OFD = New System.Windows.Forms.OpenFileDialog()
        Me.SFD = New System.Windows.Forms.SaveFileDialog()
        Me.BtnBorrar = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AbrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarComoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LanguageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EspañolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnglishToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnAgregar = New System.Windows.Forms.Button()
        Me.NUDCallname = New System.Windows.Forms.NumericUpDown()
        Me.TBNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnBorrartodo = New System.Windows.Forms.Button()
        Me.TextBoxBuscar = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BtnxSound = New System.Windows.Forms.Button()
        Me.Btnplay = New System.Windows.Forms.Button()
        Me.Btnstop = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.BtnADX = New System.Windows.Forms.Button()
        Me.Btnplay2 = New System.Windows.Forms.Button()
        Me.BtnStop2 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.OFDs_sound = New System.Windows.Forms.OpenFileDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.NUDCallname, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column1, Me.Column2})
        Me.DataGridView1.Enabled = False
        Me.DataGridView1.Location = New System.Drawing.Point(7, 27)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 30
        Me.DataGridView1.Size = New System.Drawing.Size(397, 540)
        Me.DataGridView1.TabIndex = 8
        '
        'Column3
        '
        Me.Column3.HeaderText = "ID"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 50
        '
        'Column1
        '
        Me.Column1.FillWeight = 200.0!
        Me.Column1.HeaderText = "Nombres"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 200
        '
        'Column2
        '
        Me.Column2.HeaderText = "unknow"
        Me.Column2.Name = "Column2"
        '
        'OFD
        '
        Me.OFD.Filter = "Bin Files|*.bin"
        '
        'SFD
        '
        Me.SFD.Filter = "Bin Files|*.bin"
        '
        'BtnBorrar
        '
        Me.BtnBorrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBorrar.Enabled = False
        Me.BtnBorrar.Location = New System.Drawing.Point(7, 60)
        Me.BtnBorrar.Name = "BtnBorrar"
        Me.BtnBorrar.Size = New System.Drawing.Size(141, 27)
        Me.BtnBorrar.TabIndex = 4
        Me.BtnBorrar.Text = "Borrar Seleccionado"
        Me.BtnBorrar.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbrirToolStripMenuItem, Me.GuardarToolStripMenuItem, Me.GuardarComoToolStripMenuItem, Me.LanguageToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(688, 24)
        Me.MenuStrip1.TabIndex = 70
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AbrirToolStripMenuItem
        '
        Me.AbrirToolStripMenuItem.Name = "AbrirToolStripMenuItem"
        Me.AbrirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.AbrirToolStripMenuItem.Size = New System.Drawing.Size(42, 20)
        Me.AbrirToolStripMenuItem.Text = "Abrir"
        '
        'GuardarToolStripMenuItem
        '
        Me.GuardarToolStripMenuItem.Enabled = False
        Me.GuardarToolStripMenuItem.Name = "GuardarToolStripMenuItem"
        Me.GuardarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.GuardarToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.GuardarToolStripMenuItem.Text = "Guardar"
        '
        'GuardarComoToolStripMenuItem
        '
        Me.GuardarComoToolStripMenuItem.Enabled = False
        Me.GuardarComoToolStripMenuItem.Name = "GuardarComoToolStripMenuItem"
        Me.GuardarComoToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.GuardarComoToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.GuardarComoToolStripMenuItem.Text = "Guardar Como"
        '
        'LanguageToolStripMenuItem
        '
        Me.LanguageToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LanguageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EspañolToolStripMenuItem, Me.EnglishToolStripMenuItem})
        Me.LanguageToolStripMenuItem.Name = "LanguageToolStripMenuItem"
        Me.LanguageToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.LanguageToolStripMenuItem.Text = "Language"
        '
        'EspañolToolStripMenuItem
        '
        Me.EspañolToolStripMenuItem.Checked = True
        Me.EspañolToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.EspañolToolStripMenuItem.Name = "EspañolToolStripMenuItem"
        Me.EspañolToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.EspañolToolStripMenuItem.Text = "Español"
        '
        'EnglishToolStripMenuItem
        '
        Me.EnglishToolStripMenuItem.Name = "EnglishToolStripMenuItem"
        Me.EnglishToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.EnglishToolStripMenuItem.Text = "English"
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Location = New System.Drawing.Point(205, 53)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(43, 23)
        Me.BtnAgregar.TabIndex = 71
        Me.BtnAgregar.Text = "Ok"
        Me.BtnAgregar.UseVisualStyleBackColor = True
        '
        'NUDCallname
        '
        Me.NUDCallname.Location = New System.Drawing.Point(142, 53)
        Me.NUDCallname.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NUDCallname.Name = "NUDCallname"
        Me.NUDCallname.Size = New System.Drawing.Size(59, 23)
        Me.NUDCallname.TabIndex = 72
        '
        'TBNombre
        '
        Me.TBNombre.Location = New System.Drawing.Point(7, 52)
        Me.TBNombre.MaxLength = 40
        Me.TBNombre.Name = "TBNombre"
        Me.TBNombre.Size = New System.Drawing.Size(128, 23)
        Me.TBNombre.TabIndex = 73
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 30)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Nombre                 unknow"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.BtnAgregar)
        Me.GroupBox1.Controls.Add(Me.TBNombre)
        Me.GroupBox1.Controls.Add(Me.NUDCallname)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(413, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(266, 93)
        Me.GroupBox1.TabIndex = 75
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Agregar Callnames"
        '
        'BtnBorrartodo
        '
        Me.BtnBorrartodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBorrartodo.Enabled = False
        Me.BtnBorrartodo.Location = New System.Drawing.Point(159, 60)
        Me.BtnBorrartodo.Name = "BtnBorrartodo"
        Me.BtnBorrartodo.Size = New System.Drawing.Size(90, 27)
        Me.BtnBorrartodo.TabIndex = 77
        Me.BtnBorrartodo.Text = "Borrar todo"
        Me.BtnBorrartodo.UseVisualStyleBackColor = True
        '
        'TextBoxBuscar
        '
        Me.TextBoxBuscar.Location = New System.Drawing.Point(14, 24)
        Me.TextBoxBuscar.MaxLength = 40
        Me.TextBoxBuscar.Name = "TextBoxBuscar"
        Me.TextBoxBuscar.Size = New System.Drawing.Size(234, 23)
        Me.TextBoxBuscar.TabIndex = 75
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBoxBuscar)
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(413, 264)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(266, 66)
        Me.GroupBox3.TabIndex = 79
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Buscar"
        '
        'BtnxSound
        '
        Me.BtnxSound.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BtnxSound.FlatAppearance.BorderSize = 0
        Me.BtnxSound.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.BtnxSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnxSound.ForeColor = System.Drawing.Color.White
        Me.BtnxSound.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnxSound.Location = New System.Drawing.Point(10, 22)
        Me.BtnxSound.Name = "BtnxSound"
        Me.BtnxSound.Size = New System.Drawing.Size(121, 23)
        Me.BtnxSound.TabIndex = 82
        Me.BtnxSound.Text = "Sel. X_sound.afs"
        Me.BtnxSound.UseVisualStyleBackColor = False
        '
        'Btnplay
        '
        Me.Btnplay.BackgroundImage = CType(resources.GetObject("Btnplay.BackgroundImage"), System.Drawing.Image)
        Me.Btnplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btnplay.Enabled = False
        Me.Btnplay.FlatAppearance.BorderSize = 0
        Me.Btnplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnplay.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Btnplay.Location = New System.Drawing.Point(152, 16)
        Me.Btnplay.Name = "Btnplay"
        Me.Btnplay.Size = New System.Drawing.Size(35, 35)
        Me.Btnplay.TabIndex = 84
        Me.Btnplay.UseVisualStyleBackColor = True
        '
        'Btnstop
        '
        Me.Btnstop.BackgroundImage = CType(resources.GetObject("Btnstop.BackgroundImage"), System.Drawing.Image)
        Me.Btnstop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btnstop.Enabled = False
        Me.Btnstop.FlatAppearance.BorderSize = 0
        Me.Btnstop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnstop.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Btnstop.Location = New System.Drawing.Point(195, 16)
        Me.Btnstop.Name = "Btnstop"
        Me.Btnstop.Size = New System.Drawing.Size(35, 35)
        Me.Btnstop.TabIndex = 83
        Me.Btnstop.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.BtnADX)
        Me.GroupBox5.Controls.Add(Me.Btnplay2)
        Me.GroupBox5.Controls.Add(Me.BtnStop2)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(413, 393)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(266, 60)
        Me.GroupBox5.TabIndex = 81
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Reproducir ADX (Archivo externo)"
        '
        'BtnADX
        '
        Me.BtnADX.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BtnADX.FlatAppearance.BorderSize = 0
        Me.BtnADX.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.BtnADX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnADX.ForeColor = System.Drawing.Color.White
        Me.BtnADX.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnADX.Location = New System.Drawing.Point(10, 22)
        Me.BtnADX.Name = "BtnADX"
        Me.BtnADX.Size = New System.Drawing.Size(125, 27)
        Me.BtnADX.TabIndex = 22
        Me.BtnADX.Text = "Sel. adx..."
        Me.BtnADX.UseVisualStyleBackColor = False
        '
        'Btnplay2
        '
        Me.Btnplay2.BackgroundImage = CType(resources.GetObject("Btnplay2.BackgroundImage"), System.Drawing.Image)
        Me.Btnplay2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btnplay2.FlatAppearance.BorderSize = 0
        Me.Btnplay2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnplay2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Btnplay2.Location = New System.Drawing.Point(163, 22)
        Me.Btnplay2.Name = "Btnplay2"
        Me.Btnplay2.Size = New System.Drawing.Size(27, 27)
        Me.Btnplay2.TabIndex = 24
        Me.Btnplay2.UseVisualStyleBackColor = True
        '
        'BtnStop2
        '
        Me.BtnStop2.BackgroundImage = CType(resources.GetObject("BtnStop2.BackgroundImage"), System.Drawing.Image)
        Me.BtnStop2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnStop2.FlatAppearance.BorderSize = 0
        Me.BtnStop2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnStop2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnStop2.Location = New System.Drawing.Point(198, 22)
        Me.BtnStop2.Name = "BtnStop2"
        Me.BtnStop2.Size = New System.Drawing.Size(27, 27)
        Me.BtnStop2.TabIndex = 23
        Me.BtnStop2.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.BtnxSound)
        Me.GroupBox4.Controls.Add(Me.BtnBorrar)
        Me.GroupBox4.Controls.Add(Me.BtnBorrartodo)
        Me.GroupBox4.Controls.Add(Me.Btnplay)
        Me.GroupBox4.Controls.Add(Me.Btnstop)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(413, 145)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(266, 93)
        Me.GroupBox4.TabIndex = 80
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Callname Seleccionado"
        '
        'OFDs_sound
        '
        Me.OFDs_sound.Filter = "Afs files|*.afs"
        Me.OFDs_sound.Title = "Seleccionar Ejecutabel PES6 o WE9"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 572)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Callnames Menú editor"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.NUDCallname, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SFD As System.Windows.Forms.SaveFileDialog
    Friend WithEvents BtnBorrar As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AbrirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnAgregar As System.Windows.Forms.Button
    Friend WithEvents NUDCallname As System.Windows.Forms.NumericUpDown
    Friend WithEvents TBNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GuardarComoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnBorrartodo As System.Windows.Forms.Button
    Friend WithEvents TextBoxBuscar As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LanguageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EspañolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnglishToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnxSound As System.Windows.Forms.Button
    Friend WithEvents Btnstop As System.Windows.Forms.Button
    Friend WithEvents Btnplay As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnADX As System.Windows.Forms.Button
    Friend WithEvents Btnplay2 As System.Windows.Forms.Button
    Friend WithEvents BtnStop2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents OFDs_sound As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
