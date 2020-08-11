<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.mnuFile = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuSettings = New Telerik.WinControls.UI.RadMenuItem()
        Me.RadMenuSeparatorItem1 = New Telerik.WinControls.UI.RadMenuSeparatorItem()
        Me.mnuTheme = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuThemes = New Telerik.WinControls.UI.RadMenuComboItem()
        Me.RadMenuSeparatorItem2 = New Telerik.WinControls.UI.RadMenuSeparatorItem()
        Me.mnuExit = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuSupplier = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuNewSupplier = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuUpdateSupplier = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuDeleteSupplier = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuMainHelp = New Telerik.WinControls.UI.RadMenuItem()
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
        Me.menuRightclick = New Telerik.WinControls.UI.RadContextMenu(Me.components)
        Me.menuRightclickChange = New Telerik.WinControls.UI.RadMenuItem()
        Me.menuRightclickCopy = New Telerik.WinControls.UI.RadMenuItem()
        Me.menuRightclickDelete = New Telerik.WinControls.UI.RadMenuItem()
        Me.menuRightClickFiles = New Telerik.WinControls.UI.RadContextMenu(Me.components)
        Me.menuRightClickFilesDelete = New Telerik.WinControls.UI.RadMenuItem()
        Me.menuRightClickFilesVerify = New Telerik.WinControls.UI.RadMenuItem()
        Me.MainMenu = New Telerik.WinControls.UI.RadMenu()
        Me.HighContrastBlackTheme1 = New Telerik.WinControls.Themes.HighContrastBlackTheme()
        Me.Office2007BlackTheme1 = New Telerik.WinControls.Themes.Office2007BlackTheme()
        Me.Office2007SilverTheme1 = New Telerik.WinControls.Themes.Office2007SilverTheme()
        Me.TelerikMetroTheme1 = New Telerik.WinControls.Themes.TelerikMetroTheme()
        Me.TelerikMetroBlueTheme1 = New Telerik.WinControls.Themes.TelerikMetroBlueTheme()
        Me.VisualStudio2012DarkTheme1 = New Telerik.WinControls.Themes.VisualStudio2012DarkTheme()
        Me.VisualStudio2012LightTheme1 = New Telerik.WinControls.Themes.VisualStudio2012LightTheme()
        Me.Windows7Theme1 = New Telerik.WinControls.Themes.Windows7Theme()
        Me.Windows8Theme2 = New Telerik.WinControls.Themes.Windows8Theme()
        CType(Me.mnuThemes.ComboBoxElement, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.MainMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuFile
        '
        Me.mnuFile.Items.AddRange(New Telerik.WinControls.RadItem() {Me.mnuSettings, Me.RadMenuSeparatorItem1, Me.mnuTheme, Me.RadMenuSeparatorItem2, Me.mnuExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Text = "&Arkiv"
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
        'mnuTheme
        '
        Me.mnuTheme.Items.AddRange(New Telerik.WinControls.RadItem() {Me.mnuThemes})
        Me.mnuTheme.Name = "mnuTheme"
        Me.mnuTheme.Text = "Tema"
        '
        'mnuThemes
        '
        '
        '
        '
        Me.mnuThemes.ComboBoxElement.ArrowButtonMinWidth = 17
        Me.mnuThemes.ComboBoxElement.AutoCompleteAppend = Nothing
        Me.mnuThemes.ComboBoxElement.AutoCompleteDataSource = Nothing
        Me.mnuThemes.ComboBoxElement.AutoCompleteSuggest = Nothing
        Me.mnuThemes.ComboBoxElement.DataMember = ""
        Me.mnuThemes.ComboBoxElement.DataSource = Nothing
        Me.mnuThemes.ComboBoxElement.DefaultValue = Nothing
        Me.mnuThemes.ComboBoxElement.DisplayMember = ""
        Me.mnuThemes.ComboBoxElement.DropDownAnimationEasing = Telerik.WinControls.RadEasingType.InQuad
        Me.mnuThemes.ComboBoxElement.DropDownAnimationEnabled = True
        Me.mnuThemes.ComboBoxElement.EditableElementText = ""
        Me.mnuThemes.ComboBoxElement.EditorElement = Me.mnuThemes.ComboBoxElement
        Me.mnuThemes.ComboBoxElement.EditorManager = Nothing
        Me.mnuThemes.ComboBoxElement.Filter = Nothing
        Me.mnuThemes.ComboBoxElement.FilterExpression = ""
        Me.mnuThemes.ComboBoxElement.Focusable = True
        Me.mnuThemes.ComboBoxElement.FormatString = ""
        Me.mnuThemes.ComboBoxElement.FormattingEnabled = True
        Me.mnuThemes.ComboBoxElement.MaxDropDownItems = 0
        Me.mnuThemes.ComboBoxElement.MaxLength = 32767
        Me.mnuThemes.ComboBoxElement.MaxValue = Nothing
        Me.mnuThemes.ComboBoxElement.MinValue = Nothing
        Me.mnuThemes.ComboBoxElement.NullValue = Nothing
        Me.mnuThemes.ComboBoxElement.OwnerOffset = 0
        Me.mnuThemes.ComboBoxElement.ShowImageInEditorArea = True
        Me.mnuThemes.ComboBoxElement.SortStyle = Telerik.WinControls.Enumerations.SortStyle.None
        Me.mnuThemes.ComboBoxElement.Value = Nothing
        Me.mnuThemes.ComboBoxElement.ValueMember = ""
        Me.mnuThemes.Name = "mnuThemes"
        Me.mnuThemes.Text = "Tema"
        '
        'RadMenuSeparatorItem2
        '
        Me.RadMenuSeparatorItem2.Name = "RadMenuSeparatorItem2"
        Me.RadMenuSeparatorItem2.Text = "RadMenuSeparatorItem2"
        Me.RadMenuSeparatorItem2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Text = "&Avsluta"
        '
        'mnuSupplier
        '
        Me.mnuSupplier.Items.AddRange(New Telerik.WinControls.RadItem() {Me.mnuNewSupplier, Me.mnuUpdateSupplier, Me.mnuDeleteSupplier})
        Me.mnuSupplier.Name = "mnuSupplier"
        Me.mnuSupplier.Text = "&Leverantör"
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
        'mnuMainHelp
        '
        Me.mnuMainHelp.Items.AddRange(New Telerik.WinControls.RadItem() {Me.mnuHelp, Me.mnuAbout})
        Me.mnuMainHelp.Name = "mnuMainHelp"
        Me.mnuMainHelp.Text = "&Hjälp"
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
        Me.statusStrip.Size = New System.Drawing.Size(719, 30)
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
        Me.frameLev.HeaderText = "Upplagda leverantörsmallar"
        Me.frameLev.Location = New System.Drawing.Point(158, 19)
        Me.frameLev.Name = "frameLev"
        Me.frameLev.Size = New System.Drawing.Size(489, 173)
        Me.frameLev.TabIndex = 8
        Me.frameLev.Text = "Upplagda leverantörsmallar"
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
        'menuRightclick
        '
        Me.menuRightclick.Items.AddRange(New Telerik.WinControls.RadItem() {Me.menuRightclickChange, Me.menuRightclickCopy, Me.menuRightclickDelete})
        '
        'menuRightclickChange
        '
        Me.menuRightclickChange.Name = "menuRightclickChange"
        Me.menuRightclickChange.Text = "Ändra mallen"
        '
        'menuRightclickCopy
        '
        Me.menuRightclickCopy.Name = "menuRightclickCopy"
        Me.menuRightclickCopy.Text = "Kopiera mallen"
        '
        'menuRightclickDelete
        '
        Me.menuRightclickDelete.Name = "menuRightclickDelete"
        Me.menuRightclickDelete.Text = "Ta bort mallen"
        '
        'menuRightClickFiles
        '
        Me.menuRightClickFiles.Items.AddRange(New Telerik.WinControls.RadItem() {Me.menuRightClickFilesDelete, Me.menuRightClickFilesVerify})
        '
        'menuRightClickFilesDelete
        '
        Me.menuRightClickFilesDelete.Name = "menuRightClickFilesDelete"
        Me.menuRightClickFilesDelete.Text = "Ta bort filen"
        '
        'menuRightClickFilesVerify
        '
        Me.menuRightClickFilesVerify.Name = "menuRightClickFilesVerify"
        Me.menuRightClickFilesVerify.Text = "Verifiera filen"
        '
        'MainMenu
        '
        Me.MainMenu.Items.AddRange(New Telerik.WinControls.RadItem() {Me.mnuFile, Me.mnuSupplier, Me.mnuMainHelp})
        Me.MainMenu.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu.Name = "MainMenu"
        Me.MainMenu.Size = New System.Drawing.Size(719, 20)
        Me.MainMenu.TabIndex = 0
        '
        'frmMain
        '
        Me.AccessibleName = "frmMain"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 501)
        Me.Controls.Add(Me.frameCmd)
        Me.Controls.Add(Me.frameLev)
        Me.Controls.Add(Me.FrameLevfiler)
        Me.Controls.Add(Me.statusStrip)
        Me.Controls.Add(Me.MainMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Pristrygg"
        CType(Me.mnuThemes.ComboBoxElement, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.MainMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuFile As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuSettings As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents RadMenuSeparatorItem1 As Telerik.WinControls.UI.RadMenuSeparatorItem
    Friend WithEvents mnuExit As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuSupplier As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuNewSupplier As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuMainHelp As Telerik.WinControls.UI.RadMenuItem
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
    Friend WithEvents menuRightclick As Telerik.WinControls.UI.RadContextMenu
    Friend WithEvents menuRightclickChange As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents menuRightclickCopy As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents menuRightclickDelete As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents menuRightClickFiles As Telerik.WinControls.UI.RadContextMenu
    Friend WithEvents menuRightClickFilesDelete As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents menuRightClickFilesVerify As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents RadMenuSeparatorItem2 As Telerik.WinControls.UI.RadMenuSeparatorItem
    Friend WithEvents mnuTheme As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuThemes As Telerik.WinControls.UI.RadMenuComboItem
    Friend WithEvents MainMenu As Telerik.WinControls.UI.RadMenu
    Friend WithEvents HighContrastBlackTheme1 As Telerik.WinControls.Themes.HighContrastBlackTheme
    Friend WithEvents Office2007BlackTheme1 As Telerik.WinControls.Themes.Office2007BlackTheme
    Friend WithEvents Office2007SilverTheme1 As Telerik.WinControls.Themes.Office2007SilverTheme
    Friend WithEvents TelerikMetroTheme1 As Telerik.WinControls.Themes.TelerikMetroTheme
    Friend WithEvents TelerikMetroBlueTheme1 As Telerik.WinControls.Themes.TelerikMetroBlueTheme
    Friend WithEvents VisualStudio2012DarkTheme1 As Telerik.WinControls.Themes.VisualStudio2012DarkTheme
    Friend WithEvents VisualStudio2012LightTheme1 As Telerik.WinControls.Themes.VisualStudio2012LightTheme
    Friend WithEvents Windows7Theme1 As Telerik.WinControls.Themes.Windows7Theme
    Friend WithEvents Windows8Theme2 As Telerik.WinControls.Themes.Windows8Theme
End Class

