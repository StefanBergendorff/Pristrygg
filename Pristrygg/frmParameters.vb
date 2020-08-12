Public Class FrmParameters

    Private Const COLOR_GOT_FOCUS = &HE0E0E0
    Private Const COLOR_LOST_FOCUS = &H80000005


    '-- ====================================================================================
    '-- Sätter formulärets "TAG"-property till CANCEL och tar ner formuläret.
    '-- ====================================================================================

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        frmMain.Tag = "CANCEL"
        Me.Close()
    End Sub


    '-- ====================================================================================
    '-- Kontrollerar värdena i textboxarna innan dessa skrivs till registret. Går allt
    '-- bra tas formuläret ner.
    '-- ====================================================================================

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim cRegEdit As New clsRegistry

        Dim lsKey As String
        Dim lsCryptPW As String

        On Error GoTo EH

        If Len(txtInputDir.Text) = 0 Or Len(txtOutputDir.Text) = 0 Or Len(txtMallDir.Text) = 0 Then
            MsgBox("Nödvändiga registervärden ej satta!", vbInformation, APPNAME)
            Exit Sub
        End If

        '-- Kontroll att kataloger finns.
        If Not DirExist(txtInputDir.Text) Then
            MsgBox("Katalogen " & txtInputDir.Text & " finns inte.", vbInformation, APPNAME)
            txtInputDir.Focus()
            Exit Sub
        End If
        If Not DirExist(txtOutputDir.Text) Then
            MsgBox("Katalogen " & txtOutputDir.Text & " finns inte.", vbInformation, APPNAME)
            txtOutputDir.Focus()
            Exit Sub
        End If
        If Not DirExist(txtMallDir.Text) Then
            MsgBox("Katalogen " & txtMallDir.Text & " finns inte.", vbInformation, APPNAME)
            txtMallDir.Focus()
            Exit Sub
        End If
        If Not DirExist(txtAS400Dir.Text) Then
            MsgBox("Katalogen " & txtAS400Dir.Text & " finns inte.", vbInformation, APPNAME)
            txtAS400Dir.Focus()
            Exit Sub
        End If

        If UCase(txtInputDir.Text) = UCase(txtOutputDir.Text) Then
            MsgBox("Indatakatalog och utdatakatalog kan ej vara samma.", vbInformation, APPNAME)
            txtInputDir.Focus()
            Exit Sub
        End If

        '-- Register-sökväg.
        lsKey = REG_MAIN_KEY & "\" & REG_APP_KEY

        '-- Skriver värden till registret
        cRegEdit.AddValue(lsKey, REG_VALUENAME_INDATA_DIR, txtInputDir.Text)
        cRegEdit.AddValue(lsKey, REG_VALUENAME_UTDATA_DIR, txtOutputDir.Text)
        cRegEdit.AddValue(lsKey, REG_VALUENAME_MALL_DIR, txtMallDir.Text)
        cRegEdit.AddValue(lsKey, REG_VALUENAME_AS400_DIR, txtAS400Dir.Text)
        cRegEdit.AddValue(lsKey, REG_VALUENAME_ONE_FILE, chkOneFile.CheckState)

        Me.Close()

        Exit Sub

EH:
        MsgBox("Fel vid skrivning till registret." & vbCrLf & "Felbeskrivning :  " & Err.Description & vbCrLf, vbInformation, APPNAME)
        On Error GoTo 0

    End Sub


    '-- ====================================================================================
    '-- Läser in registerinställningar i textboxarna från register-variablerna.
    '-- ====================================================================================

    Private Sub FrmParameters_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtInputDir.Text = APP_DIR_INDATA
        txtOutputDir.Text = APP_DIR_UTDATA
        txtMallDir.Text = APP_DIR_MALL
        txtAS400Dir.Text = APP_DIR_AS400
        chkOneFile.Checked = (APP_ONE_FILE = "1")

    End Sub

End Class
