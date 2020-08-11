<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmVerifyInfile
    Inherits Telerik.WinControls.UI.RadForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVerifyInfile))
        Me.grdVerify = New Telerik.WinControls.UI.RadGridView()
        Me.waitingAddData = New Telerik.WinControls.UI.RadWaitingBar()
        Me.LineRingWaitingBarIndicatorElement1 = New Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement()
        Me.chlAllColumns = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.grpboxRecords = New Telerik.WinControls.UI.RadGroupBox()
        Me.cmdCreateRecords = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.txtNewRecords = New Telerik.WinControls.UI.RadTextBox()
        CType(Me.grdVerify, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVerify.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grdVerify.SuspendLayout()
        CType(Me.waitingAddData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chlAllColumns, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpboxRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpboxRecords.SuspendLayout()
        CType(Me.cmdCreateRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNewRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdVerify
        '
        Me.grdVerify.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdVerify.Controls.Add(Me.waitingAddData)
        Me.grdVerify.Location = New System.Drawing.Point(13, 13)
        '
        '
        '
        Me.grdVerify.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.grdVerify.Name = "grdVerify"
        Me.grdVerify.Size = New System.Drawing.Size(867, 584)
        Me.grdVerify.TabIndex = 0
        '
        'waitingAddData
        '
        Me.waitingAddData.Location = New System.Drawing.Point(738, 553)
        Me.waitingAddData.Name = "waitingAddData"
        Me.waitingAddData.Size = New System.Drawing.Size(70, 70)
        Me.waitingAddData.TabIndex = 4
        Me.waitingAddData.Text = "Läser..."
        Me.waitingAddData.WaitingIndicators.Add(Me.LineRingWaitingBarIndicatorElement1)
        Me.waitingAddData.WaitingSpeed = 50
        Me.waitingAddData.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing
        '
        'LineRingWaitingBarIndicatorElement1
        '
        Me.LineRingWaitingBarIndicatorElement1.Name = "LineRingWaitingBarIndicatorElement1"
        '
        'chlAllColumns
        '
        Me.chlAllColumns.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chlAllColumns.Location = New System.Drawing.Point(13, 615)
        Me.chlAllColumns.Name = "chlAllColumns"
        Me.chlAllColumns.Size = New System.Drawing.Size(136, 18)
        Me.chlAllColumns.TabIndex = 1
        Me.chlAllColumns.Text = "Visa samtliga kolumner"
        '
        'RadLabel1
        '
        Me.RadLabel1.Location = New System.Drawing.Point(5, 17)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(64, 18)
        Me.RadLabel1.TabIndex = 2
        Me.RadLabel1.Text = "Fyll på med"
        '
        'grpboxRecords
        '
        Me.grpboxRecords.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.grpboxRecords.Controls.Add(Me.cmdCreateRecords)
        Me.grpboxRecords.Controls.Add(Me.RadLabel2)
        Me.grpboxRecords.Controls.Add(Me.txtNewRecords)
        Me.grpboxRecords.Controls.Add(Me.RadLabel1)
        Me.grpboxRecords.HeaderText = ""
        Me.grpboxRecords.Location = New System.Drawing.Point(171, 598)
        Me.grpboxRecords.Name = "grpboxRecords"
        Me.grpboxRecords.Size = New System.Drawing.Size(477, 42)
        Me.grpboxRecords.TabIndex = 3
        '
        'cmdCreateRecords
        '
        Me.cmdCreateRecords.Location = New System.Drawing.Point(217, 11)
        Me.cmdCreateRecords.Name = "cmdCreateRecords"
        Me.cmdCreateRecords.Size = New System.Drawing.Size(110, 24)
        Me.cmdCreateRecords.TabIndex = 5
        Me.cmdCreateRecords.Text = "Fyll på"
        '
        'RadLabel2
        '
        Me.RadLabel2.Location = New System.Drawing.Point(140, 17)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(59, 18)
        Me.RadLabel2.TabIndex = 4
        Me.RadLabel2.Text = "nya poster"
        '
        'txtNewRecords
        '
        Me.txtNewRecords.Location = New System.Drawing.Point(77, 16)
        Me.txtNewRecords.Name = "txtNewRecords"
        Me.txtNewRecords.Size = New System.Drawing.Size(57, 20)
        Me.txtNewRecords.TabIndex = 3
        '
        'FrmVerifyInfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 642)
        Me.Controls.Add(Me.grpboxRecords)
        Me.Controls.Add(Me.chlAllColumns)
        Me.Controls.Add(Me.grdVerify)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmVerifyInfile"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "FrmVerifyInfile"
        CType(Me.grdVerify.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVerify, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grdVerify.ResumeLayout(False)
        Me.grdVerify.PerformLayout()
        CType(Me.waitingAddData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chlAllColumns, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpboxRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpboxRecords.ResumeLayout(False)
        Me.grpboxRecords.PerformLayout()
        CType(Me.cmdCreateRecords, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNewRecords, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grdVerify As Telerik.WinControls.UI.RadGridView
    Friend WithEvents chlAllColumns As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents grpboxRecords As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents cmdCreateRecords As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtNewRecords As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents waitingAddData As Telerik.WinControls.UI.RadWaitingBar
    Friend WithEvents LineRingWaitingBarIndicatorElement1 As Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement
End Class

