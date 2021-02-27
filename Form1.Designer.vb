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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.NUDCallname, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        resources.ApplyResources(Me.DataGridView1, "DataGridView1")
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column1, Me.Column2})
        Me.DataGridView1.Name = "DataGridView1"
        '
        'Column3
        '
        resources.ApplyResources(Me.Column3, "Column3")
        Me.Column3.Name = "Column3"
        '
        'Column1
        '
        Me.Column1.FillWeight = 200.0!
        resources.ApplyResources(Me.Column1, "Column1")
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        resources.ApplyResources(Me.Column2, "Column2")
        Me.Column2.Name = "Column2"
        '
        'OFD
        '
        resources.ApplyResources(Me.OFD, "OFD")
        '
        'SFD
        '
        resources.ApplyResources(Me.SFD, "SFD")
        '
        'BtnBorrar
        '
        resources.ApplyResources(Me.BtnBorrar, "BtnBorrar")
        Me.BtnBorrar.Name = "BtnBorrar"
        Me.BtnBorrar.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbrirToolStripMenuItem, Me.GuardarToolStripMenuItem, Me.GuardarComoToolStripMenuItem, Me.LanguageToolStripMenuItem})
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'AbrirToolStripMenuItem
        '
        resources.ApplyResources(Me.AbrirToolStripMenuItem, "AbrirToolStripMenuItem")
        Me.AbrirToolStripMenuItem.Name = "AbrirToolStripMenuItem"
        '
        'GuardarToolStripMenuItem
        '
        resources.ApplyResources(Me.GuardarToolStripMenuItem, "GuardarToolStripMenuItem")
        Me.GuardarToolStripMenuItem.Name = "GuardarToolStripMenuItem"
        '
        'GuardarComoToolStripMenuItem
        '
        resources.ApplyResources(Me.GuardarComoToolStripMenuItem, "GuardarComoToolStripMenuItem")
        Me.GuardarComoToolStripMenuItem.Name = "GuardarComoToolStripMenuItem"
        '
        'LanguageToolStripMenuItem
        '
        resources.ApplyResources(Me.LanguageToolStripMenuItem, "LanguageToolStripMenuItem")
        Me.LanguageToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LanguageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EspañolToolStripMenuItem, Me.EnglishToolStripMenuItem})
        Me.LanguageToolStripMenuItem.Name = "LanguageToolStripMenuItem"
        '
        'EspañolToolStripMenuItem
        '
        resources.ApplyResources(Me.EspañolToolStripMenuItem, "EspañolToolStripMenuItem")
        Me.EspañolToolStripMenuItem.Checked = True
        Me.EspañolToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.EspañolToolStripMenuItem.Name = "EspañolToolStripMenuItem"
        '
        'EnglishToolStripMenuItem
        '
        resources.ApplyResources(Me.EnglishToolStripMenuItem, "EnglishToolStripMenuItem")
        Me.EnglishToolStripMenuItem.Name = "EnglishToolStripMenuItem"
        '
        'BtnAgregar
        '
        resources.ApplyResources(Me.BtnAgregar, "BtnAgregar")
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.UseVisualStyleBackColor = True
        '
        'NUDCallname
        '
        resources.ApplyResources(Me.NUDCallname, "NUDCallname")
        Me.NUDCallname.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NUDCallname.Name = "NUDCallname"
        '
        'TBNombre
        '
        resources.ApplyResources(Me.TBNombre, "TBNombre")
        Me.TBNombre.Name = "TBNombre"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.BtnAgregar)
        Me.GroupBox1.Controls.Add(Me.TBNombre)
        Me.GroupBox1.Controls.Add(Me.NUDCallname)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'BtnBorrartodo
        '
        resources.ApplyResources(Me.BtnBorrartodo, "BtnBorrartodo")
        Me.BtnBorrartodo.Name = "BtnBorrartodo"
        Me.BtnBorrartodo.UseVisualStyleBackColor = True
        '
        'TextBoxBuscar
        '
        resources.ApplyResources(Me.TextBoxBuscar, "TextBoxBuscar")
        Me.TextBoxBuscar.Name = "TextBoxBuscar"
        '
        'GroupBox3
        '
        resources.ApplyResources(Me.GroupBox3, "GroupBox3")
        Me.GroupBox3.Controls.Add(Me.TextBoxBuscar)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.TabStop = False
        '
        'BtnxSound
        '
        resources.ApplyResources(Me.BtnxSound, "BtnxSound")
        Me.BtnxSound.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BtnxSound.FlatAppearance.BorderSize = 0
        Me.BtnxSound.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.BtnxSound.ForeColor = System.Drawing.Color.White
        Me.BtnxSound.Name = "BtnxSound"
        Me.BtnxSound.UseVisualStyleBackColor = False
        '
        'Btnplay
        '
        resources.ApplyResources(Me.Btnplay, "Btnplay")
        Me.Btnplay.FlatAppearance.BorderSize = 0
        Me.Btnplay.Name = "Btnplay"
        Me.Btnplay.UseVisualStyleBackColor = True
        '
        'Btnstop
        '
        resources.ApplyResources(Me.Btnstop, "Btnstop")
        Me.Btnstop.FlatAppearance.BorderSize = 0
        Me.Btnstop.Name = "Btnstop"
        Me.Btnstop.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        resources.ApplyResources(Me.GroupBox5, "GroupBox5")
        Me.GroupBox5.Controls.Add(Me.BtnADX)
        Me.GroupBox5.Controls.Add(Me.Btnplay2)
        Me.GroupBox5.Controls.Add(Me.BtnStop2)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.TabStop = False
        '
        'BtnADX
        '
        resources.ApplyResources(Me.BtnADX, "BtnADX")
        Me.BtnADX.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BtnADX.FlatAppearance.BorderSize = 0
        Me.BtnADX.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.BtnADX.ForeColor = System.Drawing.Color.White
        Me.BtnADX.Name = "BtnADX"
        Me.BtnADX.UseVisualStyleBackColor = False
        '
        'Btnplay2
        '
        resources.ApplyResources(Me.Btnplay2, "Btnplay2")
        Me.Btnplay2.FlatAppearance.BorderSize = 0
        Me.Btnplay2.Name = "Btnplay2"
        Me.Btnplay2.UseVisualStyleBackColor = True
        '
        'BtnStop2
        '
        resources.ApplyResources(Me.BtnStop2, "BtnStop2")
        Me.BtnStop2.FlatAppearance.BorderSize = 0
        Me.BtnStop2.Name = "BtnStop2"
        Me.BtnStop2.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        resources.ApplyResources(Me.GroupBox4, "GroupBox4")
        Me.GroupBox4.Controls.Add(Me.BtnxSound)
        Me.GroupBox4.Controls.Add(Me.BtnBorrar)
        Me.GroupBox4.Controls.Add(Me.BtnBorrartodo)
        Me.GroupBox4.Controls.Add(Me.Btnplay)
        Me.GroupBox4.Controls.Add(Me.Btnstop)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.TabStop = False
        '
        'OFDs_sound
        '
        resources.ApplyResources(Me.OFDs_sound, "OFDs_sound")
        '
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'Button2
        '
        resources.ApplyResources(Me.Button2, "Button2")
        Me.Button2.Name = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        resources.ApplyResources(Me.Button3, "Button3")
        Me.Button3.Name = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
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
        Me.GroupBox2.ResumeLayout(False)
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
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
End Class
