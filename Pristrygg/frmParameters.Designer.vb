<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmParameters
    Inherits Telerik.WinControls.UI.RadForm

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
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.txtAS400Dir = New Telerik.WinControls.UI.RadTextBox()
        Me.txtOutputDir = New Telerik.WinControls.UI.RadTextBox()
        Me.txtInputDir = New Telerik.WinControls.UI.RadTextBox()
        Me.txtMallDir = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.cmdSave = New Telerik.WinControls.UI.RadButton()
        Me.cmdCancel = New Telerik.WinControls.UI.RadButton()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.txtAS400Dir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOutputDir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInputDir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMallDir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox1.Controls.Add(Me.txtAS400Dir)
        Me.RadGroupBox1.Controls.Add(Me.txtOutputDir)
        Me.RadGroupBox1.Controls.Add(Me.txtInputDir)
        Me.RadGroupBox1.Controls.Add(Me.txtMallDir)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel4)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel3)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel2)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel1)
        Me.RadGroupBox1.HeaderText = "Sökvägar"
        Me.RadGroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(593, 146)
        Me.RadGroupBox1.TabIndex = 0
        Me.RadGroupBox1.Text = "Sökvägar"
        '
        'txtAS400Dir
        '
        Me.txtAS400Dir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAS400Dir.Location = New System.Drawing.Point(126, 100)
        Me.txtAS400Dir.Name = "txtAS400Dir"
        Me.txtAS400Dir.Size = New System.Drawing.Size(449, 20)
        Me.txtAS400Dir.TabIndex = 7
        '
        'txtOutputDir
        '
        Me.txtOutputDir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOutputDir.Location = New System.Drawing.Point(126, 74)
        Me.txtOutputDir.Name = "txtOutputDir"
        Me.txtOutputDir.Size = New System.Drawing.Size(449, 20)
        Me.txtOutputDir.TabIndex = 6
        '
        'txtInputDir
        '
        Me.txtInputDir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInputDir.Location = New System.Drawing.Point(126, 48)
        Me.txtInputDir.Name = "txtInputDir"
        Me.txtInputDir.Size = New System.Drawing.Size(449, 20)
        Me.txtInputDir.TabIndex = 5
        '
        'txtMallDir
        '
        Me.txtMallDir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMallDir.Location = New System.Drawing.Point(126, 22)
        Me.txtMallDir.Name = "txtMallDir"
        Me.txtMallDir.Size = New System.Drawing.Size(449, 20)
        Me.txtMallDir.TabIndex = 4
        '
        'RadLabel4
        '
        Me.RadLabel4.Location = New System.Drawing.Point(6, 94)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(35, 18)
        Me.RadLabel4.TabIndex = 3
        Me.RadLabel4.Text = "Trygg"
        '
        'RadLabel3
        '
        Me.RadLabel3.Location = New System.Drawing.Point(5, 70)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(40, 18)
        Me.RadLabel3.TabIndex = 2
        Me.RadLabel3.Text = "Utdata"
        '
        'RadLabel2
        '
        Me.RadLabel2.Location = New System.Drawing.Point(6, 46)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(38, 18)
        Me.RadLabel2.TabIndex = 1
        Me.RadLabel2.Text = "Indata"
        '
        'RadLabel1
        '
        Me.RadLabel1.Location = New System.Drawing.Point(6, 22)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(95, 18)
        Me.RadLabel1.TabIndex = 0
        Me.RadLabel1.Text = "Leverantörsmallar"
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(367, 181)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(110, 24)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "&Spara"
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(496, 181)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(110, 24)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "&Avbryt"
        '
        'FrmParameters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(618, 228)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Name = "FrmParameters"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "FrmParameters"
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.txtAS400Dir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOutputDir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInputDir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMallDir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents txtAS400Dir As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtOutputDir As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtInputDir As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtMallDir As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmdSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdCancel As Telerik.WinControls.UI.RadButton
End Class

