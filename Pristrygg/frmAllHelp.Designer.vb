<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAllHelp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAllHelp))
        Me.grpHelptext = New Telerik.WinControls.UI.RadGroupBox()
        Me.txtHelp = New Telerik.WinControls.UI.RadTextBox()
        CType(Me.grpHelptext, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpHelptext.SuspendLayout()
        CType(Me.txtHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpHelptext
        '
        Me.grpHelptext.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.grpHelptext.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpHelptext.Controls.Add(Me.txtHelp)
        Me.grpHelptext.HeaderText = "Hjälptext"
        Me.grpHelptext.Location = New System.Drawing.Point(13, 13)
        Me.grpHelptext.Name = "grpHelptext"
        Me.grpHelptext.Size = New System.Drawing.Size(581, 405)
        Me.grpHelptext.TabIndex = 0
        Me.grpHelptext.Text = "Hjälptext"
        '
        'txtHelp
        '
        Me.txtHelp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHelp.AutoScroll = True
        Me.txtHelp.Location = New System.Drawing.Point(5, 21)
        Me.txtHelp.Multiline = True
        Me.txtHelp.Name = "txtHelp"
        Me.txtHelp.ReadOnly = True
        '
        '
        '
        Me.txtHelp.RootElement.StretchVertically = True
        Me.txtHelp.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtHelp.Size = New System.Drawing.Size(571, 369)
        Me.txtHelp.TabIndex = 1
        '
        'FrmAllHelp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 440)
        Me.Controls.Add(Me.grpHelptext)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmAllHelp"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "FrmAllHelp"
        CType(Me.grpHelptext, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpHelptext.ResumeLayout(False)
        Me.grpHelptext.PerformLayout()
        CType(Me.txtHelp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpHelptext As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents txtHelp As Telerik.WinControls.UI.RadTextBox
End Class

