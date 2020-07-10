<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.RadMenu1 = New Telerik.WinControls.UI.RadMenu()
        Me.RadMenuItem4 = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuSettings = New Telerik.WinControls.UI.RadMenuItem()
        Me.RadMenuSeparatorItem1 = New Telerik.WinControls.UI.RadMenuSeparatorItem()
        Me.mnuExit = New Telerik.WinControls.UI.RadMenuItem()
        Me.RadMenuItem5 = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuNewSupplier = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuUpdateSupplier = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuDeleteSupplier = New Telerik.WinControls.UI.RadMenuItem()
        Me.RadMenuItem1 = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuHelp = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuAbout = New Telerik.WinControls.UI.RadMenuItem()
        Me.AquaTheme1 = New Telerik.WinControls.Themes.AquaTheme()
        Me.BreezeTheme1 = New Telerik.WinControls.Themes.BreezeTheme()
        Me.CrystalTheme1 = New Telerik.WinControls.Themes.CrystalTheme()
        Me.CrystalDarkTheme1 = New Telerik.WinControls.Themes.CrystalDarkTheme()
        Me.DesertTheme1 = New Telerik.WinControls.Themes.DesertTheme()
        Me.FluentTheme1 = New Telerik.WinControls.Themes.FluentTheme()
        Me.FluentDarkTheme1 = New Telerik.WinControls.Themes.FluentDarkTheme()
        Me.Office2010BlackTheme1 = New Telerik.WinControls.Themes.Office2010BlackTheme()
        Me.Office2010BlueTheme1 = New Telerik.WinControls.Themes.Office2010BlueTheme()
        Me.Office2010SilverTheme1 = New Telerik.WinControls.Themes.Office2010SilverTheme()
        Me.Office2013DarkTheme1 = New Telerik.WinControls.Themes.Office2013DarkTheme()
        Me.Office2013LightTheme1 = New Telerik.WinControls.Themes.Office2013LightTheme()
        Me.Windows8Theme1 = New Telerik.WinControls.Themes.Windows8Theme()
        Me.lstLev = New Telerik.WinControls.UI.RadListControl()
        Me.chkVerifiering = New Telerik.WinControls.UI.RadCheckBox()
        Me.cmdTransfer = New Telerik.WinControls.UI.RadButton()
        Me.lstFiles = New Telerik.WinControls.UI.RadListControl()
        Me.statusStrip = New Telerik.WinControls.UI.RadStatusStrip()
        Me.txtProgressBar = New Telerik.WinControls.UI.RadLabelElement()
        Me.CommandBarSeparator1 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.progressBarElement = New Telerik.WinControls.UI.RadProgressBarElement()
        Me.CommandBarSeparator2 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.labelStatus = New Telerik.WinControls.UI.RadLabelElement()
        Me.CommandBarSeparator3 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.labelDateTime = New Telerik.WinControls.UI.RadLabelElement()
        Me.FrameLevfiler = New Telerik.WinControls.UI.RadGroupBox()
        Me.frameLev = New Telerik.WinControls.UI.RadGroupBox()
        Me.frameCmd = New Telerik.WinControls.UI.RadGroupBox()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstLev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkVerifiering, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdTransfer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.statusStrip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FrameLevfiler, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FrameLevfiler.SuspendLayout()
        CType(Me.frameLev, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frameLev.SuspendLayout()
        CType(Me.frameCmd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frameCmd.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadMenu1
        '
        Me.RadMenu1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadMenuItem4, Me.RadMenuItem5, Me.RadMenuItem1})
        Me.RadMenu1.Location = New System.Drawing.Point(0, 0)
        Me.RadMenu1.Name = "RadMenu1"
        Me.RadMenu1.Size = New System.Drawing.Size(671, 20)
        Me.RadMenu1.TabIndex = 0
        '
        'RadMenuItem4
        '
        Me.RadMenuItem4.Items.AddRange(New Telerik.WinControls.RadItem() {Me.mnuSettings, Me.RadMenuSeparatorItem1, Me.mnuExit})
        Me.RadMenuItem4.Name = "RadMenuItem4"
        Me.RadMenuItem4.Text = "&Arkiv"
        '
        'mnuSettings
        '
        Me.mnuSettings.Name = "mnuSettings"
        Me.mnuSettings.Text = "&Inställningar"
        '
        'RadMenuSeparatorItem1
        '
        Me.RadMenuSeparatorItem1.Name = "RadMenuSeparatorItem1"
        Me.RadMenuSeparatorItem1.Text = "RadMenuSeparatorItem1"
        Me.RadMenuSeparatorItem1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Text = "&Avsluta"
        '
        'RadMenuItem5
        '
        Me.RadMenuItem5.Items.AddRange(New Telerik.WinControls.RadItem() {Me.mnuNewSupplier, Me.mnuUpdateSupplier, Me.mnuDeleteSupplier})
        Me.RadMenuItem5.Name = "RadMenuItem5"
        Me.RadMenuItem5.Text = "&Leverantör"
        '
        'mnuNewSupplier
        '
        Me.mnuNewSupplier.Name = "mnuNewSupplier"
        Me.mnuNewSupplier.Text = "&Lägg upp ny leverantör"
        '
        'mnuUpdateSupplier
        '
        Me.mnuUpdateSupplier.Name = "mnuUpdateSupplier"
        Me.mnuUpdateSupplier.Text = "&Redigera markerad leverantör"
        '
        'mnuDeleteSupplier
        '
        Me.mnuDeleteSupplier.Name = "mnuDeleteSupplier"
        Me.mnuDeleteSupplier.Text = "&Ta bort markerad leverantör"
        '
        'RadMenuItem1
        '
        Me.RadMenuItem1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.mnuHelp, Me.mnuAbout})
        Me.RadMenuItem1.Name = "RadMenuItem1"
        Me.RadMenuItem1.Text = "&Hjälp"
        '
        'mnuHelp
        '
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Text = "&Hjälp"
        '
        'mnuAbout
        '
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Text = "&Om Pristrygg"
        '
        'lstLev
        '
        Me.lstLev.Location = New System.Drawing.Point(15, 21)
        Me.lstLev.Name = "lstLev"
        Me.lstLev.Size = New System.Drawing.Size(371, 137)
        Me.lstLev.TabIndex = 1
        '
        'chkVerifiering
        '
        Me.chkVerifiering.Location = New System.Drawing.Point(5, 49)
        Me.chkVerifiering.Name = "chkVerifiering"
        Me.chkVerifiering.Size = New System.Drawing.Size(107, 18)
        Me.chkVerifiering.TabIndex = 3
        Me.chkVerifiering.Text = "Endast verifiering"
        '
        'cmdTransfer
        '
        Me.cmdTransfer.Location = New System.Drawing.Point(5, 10)
        Me.cmdTransfer.Name = "cmdTransfer"
        Me.cmdTransfer.Size = New System.Drawing.Size(110, 24)
        Me.cmdTransfer.TabIndex = 4
        Me.cmdTransfer.Text = "Skapa fil till Trygg"
        '
        'lstFiles
        '
        Me.lstFiles.Location = New System.Drawing.Point(15, 21)
        Me.lstFiles.Name = "lstFiles"
        Me.lstFiles.Size = New System.Drawing.Size(421, 225)
        Me.lstFiles.TabIndex = 5
        '
        'statusStrip
        '
        Me.statusStrip.Items.AddRange(New Telerik.WinControls.RadItem() {Me.txtProgressBar, Me.CommandBarSeparator1, Me.progressBarElement, Me.CommandBarSeparator2, Me.labelStatus, Me.CommandBarSeparator3, Me.labelDateTime})
        Me.statusStrip.Location = New System.Drawing.Point(0, 471)
        Me.statusStrip.Name = "statusStrip"
        Me.statusStrip.Size = New System.Drawing.Size(671, 30)
        Me.statusStrip.TabIndex = 7
        '
        'txtProgressBar
        '
        Me.txtProgressBar.Name = "txtProgressBar"
        Me.statusStrip.SetSpring(Me.txtProgressBar, False)
        Me.txtProgressBar.Text = "1/1"
        Me.txtProgressBar.TextWrap = True
        '
        'CommandBarSeparator1
        '
        Me.CommandBarSeparator1.Name = "CommandBarSeparator1"
        Me.statusStrip.SetSpring(Me.CommandBarSeparator1, False)
        Me.CommandBarSeparator1.VisibleInOverflowMenu = False
        '
        'progressBarElement
        '
        Me.progressBarElement.AutoSize = True
        Me.progressBarElement.DefaultSize = New System.Drawing.Size(300, 20)
        Me.progressBarElement.Name = "progressBarElement"
        Me.progressBarElement.SeparatorColor1 = System.Drawing.Color.White
        Me.progressBarElement.SeparatorColor2 = System.Drawing.Color.White
        Me.progressBarElement.SeparatorColor3 = System.Drawing.Color.White
        Me.progressBarElement.SeparatorColor4 = System.Drawing.Color.White
        Me.progressBarElement.SeparatorGradientAngle = 0
        Me.progressBarElement.SeparatorGradientPercentage1 = 0.4!
        Me.progressBarElement.SeparatorGradientPercentage2 = 0.6!
        Me.progressBarElement.SeparatorNumberOfColors = 2
        Me.progressBarElement.ShowProgressIndicators = True
        Me.statusStrip.SetSpring(Me.progressBarElement, False)
        Me.progressBarElement.StepWidth = 14
        Me.progressBarElement.SweepAngle = 90
        Me.progressBarElement.Text = "0 %"
        '
        'CommandBarSeparator2
        '
        Me.CommandBarSeparator2.Name = "CommandBarSeparator2"
        Me.statusStrip.SetSpring(Me.CommandBarSeparator2, False)
        Me.CommandBarSeparator2.VisibleInOverflowMenu = False
        '
        'labelStatus
        '
        Me.labelStatus.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        Me.labelStatus.Name = "labelStatus"
        Me.statusStrip.SetSpring(Me.labelStatus, False)
        Me.labelStatus.Text = "RadLabelElement1"
        Me.labelStatus.TextWrap = True
        '
        'CommandBarSeparator3
        '
        Me.CommandBarSeparator3.Name = "CommandBarSeparator3"
        Me.statusStrip.SetSpring(Me.CommandBarSeparator3, False)
        Me.CommandBarSeparator3.VisibleInOverflowMenu = False
        '
        'labelDateTime
        '
        Me.labelDateTime.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        Me.labelDateTime.Name = "labelDateTime"
        Me.statusStrip.SetSpring(Me.labelDateTime, False)
        Me.labelDateTime.Text = "RadLabelElement1"
        Me.labelDateTime.TextWrap = True
        '
        'FrameLevfiler
        '
        Me.FrameLevfiler.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.FrameLevfiler.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.FrameLevfiler.Controls.Add(Me.lstFiles)
        Me.FrameLevfiler.HeaderText = "Leverantörsfiler"
        Me.FrameLevfiler.Location = New System.Drawing.Point(158, 200)
        Me.FrameLevfiler.Name = "FrameLevfiler"
        Me.FrameLevfiler.Size = New System.Drawing.Size(489, 260)
        Me.FrameLevfiler.TabIndex = 0
        Me.FrameLevfiler.Text = "Leverantörsfiler"
        '
        'frameLev
        '
        Me.frameLev.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.frameLev.Controls.Add(Me.lstLev)
        Me.frameLev.HeaderText = "Upplagda leverantörer"
        Me.frameLev.Location = New System.Drawing.Point(158, 19)
        Me.frameLev.Name = "frameLev"
        Me.frameLev.Size = New System.Drawing.Size(489, 173)
        Me.frameLev.TabIndex = 8
        Me.frameLev.Text = "Upplagda leverantörer"
        '
        'frameCmd
        '
        Me.frameCmd.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.frameCmd.Controls.Add(Me.cmdTransfer)
        Me.frameCmd.Controls.Add(Me.chkVerifiering)
        Me.frameCmd.HeaderText = ""
        Me.frameCmd.Location = New System.Drawing.Point(12, 26)
        Me.frameCmd.Name = "frameCmd"
        Me.frameCmd.Size = New System.Drawing.Size(128, 439)
        Me.frameCmd.TabIndex = 9
        '
        'frmMain
        '
        Me.AccessibleName = "frmMain"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(671, 501)
        Me.Controls.Add(Me.frameCmd)
        Me.Controls.Add(Me.frameLev)
        Me.Controls.Add(Me.FrameLevfiler)
        Me.Controls.Add(Me.statusStrip)
        Me.Controls.Add(Me.RadMenu1)
        Me.Name = "frmMain"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Pristrygg"
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstLev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkVerifiering, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdTransfer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstFiles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.statusStrip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FrameLevfiler, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FrameLevfiler.ResumeLayout(False)
        CType(Me.frameLev, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frameLev.ResumeLayout(False)
        CType(Me.frameCmd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frameCmd.ResumeLayout(False)
        Me.frameCmd.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadMenu1 As Telerik.WinControls.UI.RadMenu
    Friend WithEvents RadMenuItem4 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuSettings As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents RadMenuSeparatorItem1 As Telerik.WinControls.UI.RadMenuSeparatorItem
    Friend WithEvents mnuExit As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents RadMenuItem5 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuNewSupplier As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents RadMenuItem1 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuUpdateSupplier As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuDeleteSupplier As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuHelp As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuAbout As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents AquaTheme1 As Telerik.WinControls.Themes.AquaTheme
    Friend WithEvents BreezeTheme1 As Telerik.WinControls.Themes.BreezeTheme
    Friend WithEvents CrystalTheme1 As Telerik.WinControls.Themes.CrystalTheme
    Friend WithEvents CrystalDarkTheme1 As Telerik.WinControls.Themes.CrystalDarkTheme
    Friend WithEvents DesertTheme1 As Telerik.WinControls.Themes.DesertTheme
    Friend WithEvents FluentTheme1 As Telerik.WinControls.Themes.FluentTheme
    Friend WithEvents FluentDarkTheme1 As Telerik.WinControls.Themes.FluentDarkTheme
    Friend WithEvents Office2010BlackTheme1 As Telerik.WinControls.Themes.Office2010BlackTheme
    Friend WithEvents Office2010BlueTheme1 As Telerik.WinControls.Themes.Office2010BlueTheme
    Friend WithEvents Office2010SilverTheme1 As Telerik.WinControls.Themes.Office2010SilverTheme
    Friend WithEvents Office2013DarkTheme1 As Telerik.WinControls.Themes.Office2013DarkTheme
    Friend WithEvents Office2013LightTheme1 As Telerik.WinControls.Themes.Office2013LightTheme
    Friend WithEvents Windows8Theme1 As Telerik.WinControls.Themes.Windows8Theme
    Friend WithEvents lstLev As Telerik.WinControls.UI.RadListControl
    Friend WithEvents chkVerifiering As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents cmdTransfer As Telerik.WinControls.UI.RadButton
    Friend WithEvents lstFiles As Telerik.WinControls.UI.RadListControl
    Friend WithEvents statusStrip As Telerik.WinControls.UI.RadStatusStrip
    Friend WithEvents txtProgressBar As Telerik.WinControls.UI.RadLabelElement
    Friend WithEvents CommandBarSeparator1 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents progressBarElement As Telerik.WinControls.UI.RadProgressBarElement
    Friend WithEvents CommandBarSeparator2 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents labelStatus As Telerik.WinControls.UI.RadLabelElement
    Friend WithEvents CommandBarSeparator3 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents labelDateTime As Telerik.WinControls.UI.RadLabelElement
    Friend WithEvents FrameLevfiler As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents frameLev As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents frameCmd As Telerik.WinControls.UI.RadGroupBox
End Class

