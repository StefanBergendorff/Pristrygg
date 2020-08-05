<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSupplierTemplate
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
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.fraPost = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdFields = New Telerik.WinControls.UI.RadGridView()
        Me.cmdCancel = New Telerik.WinControls.UI.RadButton()
        Me.cmdSave = New Telerik.WinControls.UI.RadButton()
        Me.RadGroupBox3 = New Telerik.WinControls.UI.RadGroupBox()
        Me.cmdHelp = New Telerik.WinControls.UI.RadButton()
        Me.lblPostTyp = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.txtDivider = New Telerik.WinControls.UI.RadTextBox()
        Me.lblDivider = New Telerik.WinControls.UI.RadLabel()
        Me.txtPostLen = New Telerik.WinControls.UI.RadTextBox()
        Me.txtStartPos = New Telerik.WinControls.UI.RadTextBox()
        Me.lblPostLen = New Telerik.WinControls.UI.RadLabel()
        Me.lblStartPos = New Telerik.WinControls.UI.RadLabel()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.cmbFilTyp = New Telerik.WinControls.UI.RadDropDownList()
        Me.txtHeader = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.Filtyp = New Telerik.WinControls.UI.RadLabel()
        Me.txtLevNr = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.txtLevNamn = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        CType(Me.fraPost, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraPost.SuspendLayout()
        CType(Me.grdFields, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdFields.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox3.SuspendLayout()
        CType(Me.cmdHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPostTyp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDivider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDivider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPostLen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStartPos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPostLen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblStartPos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.cmbFilTyp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Filtyp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLevNr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLevNamn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraPost
        '
        Me.fraPost.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.fraPost.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraPost.Controls.Add(Me.grdFields)
        Me.fraPost.Controls.Add(Me.cmdCancel)
        Me.fraPost.Controls.Add(Me.cmdSave)
        Me.fraPost.Controls.Add(Me.RadGroupBox3)
        Me.fraPost.HeaderText = "Koppla samman infilen med uppgifter i Trygg"
        Me.fraPost.Location = New System.Drawing.Point(12, 154)
        Me.fraPost.Name = "fraPost"
        Me.fraPost.Size = New System.Drawing.Size(871, 445)
        Me.fraPost.TabIndex = 3
        Me.fraPost.Text = "Koppla samman infilen med uppgifter i Trygg"
        '
        'grdFields
        '
        Me.grdFields.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdFields.Location = New System.Drawing.Point(6, 22)
        '
        '
        '
        Me.grdFields.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.grdFields.Name = "grdFields"
        Me.grdFields.Size = New System.Drawing.Size(654, 407)
        Me.grdFields.TabIndex = 5
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(773, 405)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(93, 24)
        Me.cmdCancel.TabIndex = 11
        Me.cmdCancel.Text = "&Avbryt"
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(674, 405)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(93, 24)
        Me.cmdSave.TabIndex = 10
        Me.cmdSave.Text = "&Spara"
        '
        'RadGroupBox3
        '
        Me.RadGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox3.Controls.Add(Me.cmdHelp)
        Me.RadGroupBox3.Controls.Add(Me.lblPostTyp)
        Me.RadGroupBox3.Controls.Add(Me.RadLabel4)
        Me.RadGroupBox3.Controls.Add(Me.txtDivider)
        Me.RadGroupBox3.Controls.Add(Me.lblDivider)
        Me.RadGroupBox3.Controls.Add(Me.txtPostLen)
        Me.RadGroupBox3.Controls.Add(Me.txtStartPos)
        Me.RadGroupBox3.Controls.Add(Me.lblPostLen)
        Me.RadGroupBox3.Controls.Add(Me.lblStartPos)
        Me.RadGroupBox3.HeaderText = "Fältuppgifter"
        Me.RadGroupBox3.Location = New System.Drawing.Point(666, 21)
        Me.RadGroupBox3.Name = "RadGroupBox3"
        Me.RadGroupBox3.Size = New System.Drawing.Size(200, 128)
        Me.RadGroupBox3.TabIndex = 2
        Me.RadGroupBox3.Text = "Fältuppgifter"
        '
        'cmdHelp
        '
        Me.cmdHelp.Location = New System.Drawing.Point(179, 91)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(18, 20)
        Me.cmdHelp.TabIndex = 9
        Me.cmdHelp.Text = "?"
        '
        'lblPostTyp
        '
        Me.lblPostTyp.Location = New System.Drawing.Point(60, 21)
        Me.lblPostTyp.Name = "lblPostTyp"
        Me.lblPostTyp.Size = New System.Drawing.Size(27, 18)
        Me.lblPostTyp.TabIndex = 18
        Me.lblPostTyp.Text = "Text"
        '
        'RadLabel4
        '
        Me.RadLabel4.Location = New System.Drawing.Point(12, 21)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(46, 18)
        Me.RadLabel4.TabIndex = 17
        Me.RadLabel4.Text = "Posttyp:"
        '
        'txtDivider
        '
        Me.txtDivider.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDivider.Location = New System.Drawing.Point(117, 91)
        Me.txtDivider.Name = "txtDivider"
        Me.txtDivider.Size = New System.Drawing.Size(64, 20)
        Me.txtDivider.TabIndex = 8
        '
        'lblDivider
        '
        Me.lblDivider.Location = New System.Drawing.Point(12, 93)
        Me.lblDivider.Name = "lblDivider"
        Me.lblDivider.Size = New System.Drawing.Size(79, 18)
        Me.lblDivider.TabIndex = 15
        Me.lblDivider.Text = "Omräkningstal"
        '
        'txtPostLen
        '
        Me.txtPostLen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPostLen.Location = New System.Drawing.Point(148, 68)
        Me.txtPostLen.Name = "txtPostLen"
        Me.txtPostLen.Size = New System.Drawing.Size(47, 20)
        Me.txtPostLen.TabIndex = 7
        '
        'txtStartPos
        '
        Me.txtStartPos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStartPos.Location = New System.Drawing.Point(148, 42)
        Me.txtStartPos.Name = "txtStartPos"
        Me.txtStartPos.Size = New System.Drawing.Size(47, 20)
        Me.txtStartPos.TabIndex = 6
        '
        'lblPostLen
        '
        Me.lblPostLen.Location = New System.Drawing.Point(12, 69)
        Me.lblPostLen.Name = "lblPostLen"
        Me.lblPostLen.Size = New System.Drawing.Size(37, 18)
        Me.lblPostLen.TabIndex = 7
        Me.lblPostLen.Text = "Längd"
        '
        'lblStartPos
        '
        Me.lblStartPos.Location = New System.Drawing.Point(12, 43)
        Me.lblStartPos.Name = "lblStartPos"
        Me.lblStartPos.Size = New System.Drawing.Size(70, 18)
        Me.lblStartPos.TabIndex = 6
        Me.lblStartPos.Text = "Startposition"
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox1.Controls.Add(Me.cmbFilTyp)
        Me.RadGroupBox1.Controls.Add(Me.txtHeader)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel3)
        Me.RadGroupBox1.Controls.Add(Me.Filtyp)
        Me.RadGroupBox1.Controls.Add(Me.txtLevNr)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel2)
        Me.RadGroupBox1.Controls.Add(Me.txtLevNamn)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel1)
        Me.RadGroupBox1.HeaderText = "Uppgifter om infilen"
        Me.RadGroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(871, 127)
        Me.RadGroupBox1.TabIndex = 2
        Me.RadGroupBox1.Text = "Uppgifter om infilen"
        '
        'cmbFilTyp
        '
        Me.cmbFilTyp.Location = New System.Drawing.Point(151, 69)
        Me.cmbFilTyp.Name = "cmbFilTyp"
        Me.cmbFilTyp.Size = New System.Drawing.Size(125, 20)
        Me.cmbFilTyp.TabIndex = 3
        Me.cmbFilTyp.Text = "RadDropDownList1"
        '
        'txtHeader
        '
        Me.txtHeader.Location = New System.Drawing.Point(151, 93)
        Me.txtHeader.Name = "txtHeader"
        Me.txtHeader.Size = New System.Drawing.Size(31, 20)
        Me.txtHeader.TabIndex = 4
        '
        'RadLabel3
        '
        Me.RadLabel3.Location = New System.Drawing.Point(5, 93)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(130, 18)
        Me.RadLabel3.TabIndex = 11
        Me.RadLabel3.Text = "Antal rubrikrader i infilen"
        '
        'Filtyp
        '
        Me.Filtyp.Location = New System.Drawing.Point(5, 69)
        Me.Filtyp.Name = "Filtyp"
        Me.Filtyp.Size = New System.Drawing.Size(33, 18)
        Me.Filtyp.TabIndex = 9
        Me.Filtyp.Text = "Filtyp"
        '
        'txtLevNr
        '
        Me.txtLevNr.Location = New System.Drawing.Point(151, 45)
        Me.txtLevNr.Name = "txtLevNr"
        Me.txtLevNr.Size = New System.Drawing.Size(100, 20)
        Me.txtLevNr.TabIndex = 2
        '
        'RadLabel2
        '
        Me.RadLabel2.Location = New System.Drawing.Point(5, 45)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(106, 18)
        Me.RadLabel2.TabIndex = 7
        Me.RadLabel2.Text = "Leverantörsnummer"
        '
        'txtLevNamn
        '
        Me.txtLevNamn.Location = New System.Drawing.Point(151, 21)
        Me.txtLevNamn.Name = "txtLevNamn"
        Me.txtLevNamn.Size = New System.Drawing.Size(314, 20)
        Me.txtLevNamn.TabIndex = 1
        '
        'RadLabel1
        '
        Me.RadLabel1.Location = New System.Drawing.Point(5, 21)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(89, 18)
        Me.RadLabel1.TabIndex = 5
        Me.RadLabel1.Text = "Namn på mallen"
        '
        'FrmSupplierTemplate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 618)
        Me.Controls.Add(Me.fraPost)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Name = "FrmSupplierTemplate"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "FrmSupplierTemplate"
        CType(Me.fraPost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraPost.ResumeLayout(False)
        CType(Me.grdFields.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdFields, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox3.ResumeLayout(False)
        Me.RadGroupBox3.PerformLayout()
        CType(Me.cmdHelp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPostTyp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDivider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDivider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPostLen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStartPos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPostLen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblStartPos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.cmbFilTyp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Filtyp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLevNr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLevNamn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fraPost As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents grdFields As Telerik.WinControls.UI.RadGridView
    Friend WithEvents cmdCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadGroupBox3 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents txtPostLen As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtStartPos As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lblPostLen As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblStartPos As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents cmbFilTyp As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents txtHeader As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents Filtyp As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtLevNr As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtLevNamn As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtDivider As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lblDivider As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblPostTyp As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmdHelp As Telerik.WinControls.UI.RadButton
End Class

