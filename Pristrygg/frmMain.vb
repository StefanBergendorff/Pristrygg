Imports System.ComponentModel
Imports Excel = Microsoft.Office.Interop.Excel


Public Class frmMain

    Private RecordCounter As Long
    Private bTransfer As Boolean
    Private sTryggFile As String

    Private Sub mnuSettings_Click(sender As Object, e As EventArgs) Handles mnuSettings.Click
        FrmParameters.Show()
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Private Sub mnuNewSupplier_Click(sender As Object, e As EventArgs) Handles mnuNewSupplier.Click

        cLev = New clsSupplier
        If Not cLev.CreatePosts Then Exit Sub
        FrmSupplierTemplate.Tag = "NEWLEV"
        FrmSupplierTemplate.Show()
        Me.Hide()

    End Sub

    Private Sub mnuUpdateSupplier_Click(sender As Object, e As EventArgs) Handles mnuUpdateSupplier.Click
        On Error GoTo EH

        If Not LoadIniFile() Then Exit Sub

        FrmSupplierTemplate.Tag = "OLDLEV"
        FrmSupplierTemplate.Show()
        Me.Hide()

        Exit Sub

EH:
        MsgBox("Ett fel har inträffat." & vbCrLf & "Felbeskrivning :  " & Err.Description, vbInformation, APPNAME)


    End Sub

    Private Sub mnuDeleteSupplier_Click(sender As Object, e As EventArgs) Handles mnuDeleteSupplier.Click

        Dim lsLevFile As String

        lsLevFile = lstLev.SelectedItem.Text

        If Len(lsLevFile) = 0 Then
            MsgBox("Markera den leverantör i listan som ska tas bort.", vbInformation, APPNAME)
            Exit Sub
        End If

        If MsgBox("Är du säker på att du vill plocka bort leverantör " & lsLevFile & " ?", vbYesNo + vbQuestion, APPNAME) = vbNo Then
            Exit Sub
        End If

        Kill(FixDirStr(APP_DIR_MALL) & lsLevFile)

        MsgBox("Leverantören borttagen.", vbInformation)

        UpdateListboxes()

        Exit Sub

EH:
        MsgBox("Ett fel har inträffat." & vbCrLf & "Felbeskrivning :  " & Err.Description, vbInformation, APPNAME)

    End Sub

    Private Sub mnuHelp_Click(sender As Object, e As EventArgs) Handles mnuHelp.Click

    End Sub

    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click

    End Sub

    Private Sub cmdTransfer_Click(sender As Object, e As EventArgs) Handles cmdTransfer.Click

        Dim s As String

        'Lista ut vilken typ av överföring det ska vara.
        'Det finns fyra alternativ:
        ' 1. Om leverantör iklickad är det en extern fil
        ' 2. Om fillängden = APP_FINFO_LANGD är det en FINFO-fil
        ' 3. Om fillängden = APP_VILMA_LANGD ar det en Vilma-fil
        ' 4. Om fillängden = APP_VILMA2_LANGD ar det en Vilma-fil 2012-01-30
        '2019-01-14
        'Observera att Vilma1 2.1 har exakt lika lång postlängd - 1508 tecken som en Vilma2 fil.
        'Därför måste en fråga ställas om det är en Vilma2, eller en Vilma1 som efterfrågas.

        On Error GoTo EH

        bTransfer = False
        sTryggFile = ""

        '--->2009-08-20, kontrollerar uppkopplingen mot 400an direkt
        '-- Kontroll att AS400 katalog existerar och att det finns en nätverksuppkoppling
        If chkVerifiering.Checked = False Then
            If Not DirExist(APP_DIR_AS400) Then
                s = "Katalogen " & APP_DIR_AS400 & " där filen till AS400 skapas finns inte."
                s = s & vbCrLf
                s = s & "Gå in i inställningar och skriv in en giltig sökväg."
                s = s & vbCrLf
                s = s & "Eventuellt har inte " & APP_DIR_AS400 & " anslutits och en nätverkskoppling till " & APP_DIR_AS400 & " saknas."
                s = s & vbCrLf
                s = s & "Öppna i så fall utforskaren och anslut " & APP_DIR_AS400 & " genom att högerklicka på " & APP_DIR_AS400 & " och välja Anslut."
                MsgBox(s, vbInformation, APPNAME)
                Exit Sub
            End If
        End If
        '---<2009-08-20

        'Kolla om leverantör iklickad
        If lstLev.SelectedIndex > 0 Then
            transferExtern()
        Else
            transferFinfoVilma()
        End If

        'Ska filen föras över direkt, eller endast verifieras
        If bTransfer = True Then
            If chkVerifiering.Checked = True Then
                mnuVerifyTryggFile_Click()
            Else
                transferAS400()
            End If
        End If

        labelStatus.Text = ""
        Me.Cursor = Cursors.Default

        '--->2009-08-20
EH:
        If Err.Description <> "" Then
            MsgBox("Ett fel har inträffat." & vbCrLf & "Felbeskrivning:" & vbCrLf & Err.Number & " - " & Err.Description, vbInformation, APPNAME)
        End If
        On Error GoTo 0
        '---<2009-08-20

    End Sub

    Private Sub transferExtern()
        Dim lsInfil As String
        Dim lsTextFil As String
        Dim lsOldInFil As String
        Dim lsUtFil As String
        Dim lsBackUpDirParent As String
        Dim lsBackUpDirChild As String
        Dim lsBackUpFil As String
        Dim s As String
        Dim i As Integer

        lsUtFil = ""
        lsInfil = ""
        Try

            '-- Kontroll att indatafil är vald.
            If lstFiles.SelectedItem Is Nothing Then
                MsgBox("Markera fil från leverantör.", vbInformation, APPNAME)
                Exit Sub
            End If

            lsInfil = FixDirStr(APP_DIR_INDATA) & lstFiles.SelectedItem.Text
            sTryggFile = "TRBTE00"
            lsUtFil = FixDirStr(APP_DIR_UTDATA) & sTryggFile
            lsOldInFil = 0

            lsBackUpDirParent = FixDirStr(APP_DIR_INDATA) & "backup"

            lsBackUpDirChild = lsBackUpDirParent & "\" & Format(System.DateTime.Now, "yyyyMMdd")
            lsBackUpFil = lsBackUpDirChild & "\" & lstFiles.SelectedItem.Text

            '-- Kontroll att utdatakatalog existerar.
            If Not DirExist(APP_DIR_UTDATA) Then
                MsgBox("Katalogen " & UCase(APP_DIR_UTDATA) & " där filen till Trygg skapas finns inte." & vbCrLf &
                 "Gå in i inställningar och skriv in en giltig sökväg.", vbInformation, APPNAME)
                Exit Sub
            End If

            '-- Om gammal Trygg_fil finns kvar, fråga om denna ska tas bort.
            labelStatus.Text = "Kontrollerar infilen och mallen..."
            If FileExists(lsUtFil) Then
                Kill(lsUtFil)
            End If

            Me.Cursor = Cursors.WaitCursor

            '-- Läs i  n egenskaper från mall-fil till objektet.
            If Not LoadIniFile() Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            '-- Om det är en excel-fil från leverantören, gör om den till en textfil.
            If cLev.FileFormat = FILE_EXCEL_ANSI Or cLev.FileFormat = FILE_EXCEL_DOS Then
                labelStatus.Text = "Omvandla Excelfil till textfil..."

                '-- Skapa namnet på textfilen (xls byts mot txt)
                i = InStrRev(lsInfil, ".")
                If i = 0 Then
                    lsTextFil = lsInfil.Trim & ".txt"
                Else
                    lsTextFil = lsInfil.Substring(0, i) & "txt"
                End If

                '-- Konverterar [lsInfil] från excel-format till textformat.
                If Not ConvertExcelToText(lsInfil, lsTextFil) Then
                    Me.Cursor = Cursors.Default
                    MsgBox("Fel vid konvertering av " & lsInfil & " till en textfil.", vbInformation, APPNAME)
                    Exit Sub
                End If

                '-- Sätt infilen till den skapade textfilen. Spara excel-filen i [lsOldInFil]
                lsOldInFil = lsInfil
                lsInfil = lsTextFil

            End If

            '-- Skapa utdatafil till Trygg.
            labelStatus.Text = "Omvandlar infilen till Trygguppgifter..."
            Me.Cursor = Cursors.WaitCursor
            If Not CreateTryggFile(lsInfil, lsUtFil) Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            labelStatus.Text = "Kopierar till Trygg och rensar upp..."
            If cLev.FileFormat = FILE_EXCEL_ANSI Or cLev.FileFormat = FILE_EXCEL_DOS Then
                '-- Döda textfilen.
                Kill(lsInfil)
                '-- Sätt [lsInFil] till orginal-excelfilen för backup.
                lsInfil = lsOldInFil
            End If


            Me.Cursor = Cursors.Default

            If chkVerifiering.Checked = False Then  'Inte endast verifiering

                '-- Finns inte katalogen [APP_DIR_INDATA]\backup, skapa den.
                If Not DirExist(lsBackUpDirParent) Then MkDir(lsBackUpDirParent)

                '-- Finns inte katalogen [APP_DIR_INDATA]\backup\'dagens datum', skapa den.
                If Not DirExist(lsBackUpDirChild) Then MkDir(lsBackUpDirChild)

                '-- Finns det redan en fil med samma namn i [APP_DIR_INDATA]\backup\'dagens datum' ?
                If FileExists(lsBackUpFil) Then
                    Kill(lsBackUpFil)
                End If

                '-- Flyttar behandlad leverantörsfil till backupkatalog.
                'Name lsInfil As lsBackUpFil
                FileCopy(lsInfil, lsBackUpFil)
                Kill(lsInfil)

                UpdateListboxes()
            End If

            bTransfer = True


        Catch ex As Exception
            UpdateListboxes()
            s = "Ett fel har inträffat." & vbCrLf
            s = s & "Felbeskrivning :  " & ex.Message & vbCrLf
            s = s & "Filen " & lsUtFil & " har dock skapats." & vbCrLf
            If ex.HResult = 70 Then
                s = s & "OBS! Felet är att " & lsInfil & " inte går att ta bort!" & vbCrLf
                s = s & "Filen kanske är uppe i Excel? - I så fall stäng Excel"
            End If
            MsgBox(s, vbInformation, APPNAME)

        End Try

    End Sub

    Private Sub transferFinfoVilma()

        Dim lsBuffer As String
        Dim lsInfil As String
        Dim lsUtFil As String
        Dim lsBackUpDirParent As String
        Dim lsBackUpDirChild As String
        Dim lsBackUpFil As String
        Dim FnrIn As Integer
        Dim J As Long
        Dim bFileOpen As Boolean
        Dim llRecord As Long
        Dim bFinfo As Boolean
        Dim bVilma As Boolean
        Dim bVilma2 As Boolean  '2012-01-30
        Dim s As String
        Dim lPostLangd As Long
        Dim bFirstRecord As Boolean '2013-03-07
        Dim bBidCon As Boolean  '2013-03-07

        On Error GoTo EH

        bFileOpen = False
        bVilma = False
        bVilma2 = False '2012-01-30
        bFinfo = False
        lPostLangd = 0
        bFirstRecord = True '2013-03-07
        bBidCon = False '2013-03-07

        '-- Kontroll att indatafil är vald.
        If lstFiles.SelectedItem Is Nothing Then
            MsgBox("Markera filen som ska överföras.", vbInformation, APPNAME)
            lstFiles.Focus()
            Exit Sub
        End If

        lsInfil = FixDirStr(APP_DIR_INDATA) & lstFiles.SelectedItem.Text
        labelStatus.Text = "Bestämer Finfo/Vilma..."

        'Kontrollera längden
        FnrIn = FreeFile()
        FileOpen(FnrIn, lsInfil, OpenMode.Input)
        bFileOpen = True

        '-- Läs första raden i filen
        Do Until EOF(FnrIn)
            lsBuffer = LineInput(FnrIn)

            If bFirstRecord = True Then '2013-03-07

                If Len(lsBuffer) = APP_FINFO_LANGD Then
                    bFinfo = True
                    lPostLangd = APP_FINFO_LANGD
                End If
                If Len(lsBuffer) = APP_VILMA_LANGD Then
                    bVilma = True
                    lPostLangd = APP_VILMA_LANGD
                End If
                '--->2019-01-19, kolla även med Bidcon
                If Len(lsBuffer) = APP_VILMA_LANGD + APP_BIDCON_LANGD Then
                    bVilma = True
                    lPostLangd = Len(lsBuffer)
                End If
                '---<2019-01-19

                '--->2018-09-14, då Vilma1 fått ny längd kör jag allt som är mindre än vilma2 som vilma1
                If Len(lsBuffer) < APP_VILMA2_LANGD And Len(lsBuffer) > APP_VILMA_LANGD Then
                    bVilma2 = True
                    lPostLangd = Len(lsBuffer)
                End If
                '---<2018-02-14

                '--->2012-01-30
                If Len(lsBuffer) = APP_VILMA2_LANGD Then
                    bVilma2 = True
                    lPostLangd = APP_VILMA2_LANGD
                End If
                '---<2012-01-30

                '--->2018-02-14, då Vilma2 kommer med många uppdateringar i den närmaste framtiden kör jag allt som är större som vilma2
                If Len(lsBuffer) > APP_VILMA2_LANGD Then
                    bVilma2 = True
                    lPostLangd = Len(lsBuffer)
                End If
                '---<2018-02-14

                '--->2019-01-14, då Vilma1 1.2 har exakt lika lång postlängd som Vilma2 måste jag ställa en fråga vilken fil det är
                If Len(lsBuffer) = APP_VILMA2_LANGD Or Len(lsBuffer) = APP_VILMA2_LANGD + APP_BIDCON_LANGD Then
                    s = "Det går inte att avgöra om detta är en Vilma2 fil, eller en Vilma1 fil."
                    s = s & vbCrLf
                    s = s & "Är det en Vilma2 fil som ska läsas in svara Ja, nedan."
                    s = s & vbCrLf
                    s = s & "Är det en Vilma1 fil som ska läsas in svara Nej, nedan."
                    s = s & vbCrLf
                    s = s & "Avbryt inläsningen med Avbryt."
                    J = MsgBox(s, vbYesNoCancel, "Filtyp")
                    Select Case J
                        Case 6
                            bVilma2 = True
                            bVilma = False
                        Case 7
                            bVilma = True
                            bVilma2 = False
                        Case Else
                            Exit Sub
                    End Select
                    lPostLangd = Len(lsBuffer)
                End If
                '---<2018-02-14

                '--->2013-03-07, ser efter om det är en fil med BidCon-uppgifter
                If APP_BIDCON_LANGD > 0 Then
                    '--->2019-01-14, gör det lite lättare
                    If 1 = 1 Then
                        'Fast jag kan ju inte öka postlängden här då den redan är satt från infilen...
                        '->lPostLangd = lPostLangd + getValue(APP_BIDCON_LANGD, True)
                    Else
                        '---<2019-01-14
                        If Len(lsBuffer) = GetValue(APP_FINFO_LANGD, True) + GetValue(APP_BIDCON_LANGD, True) Then
                            bFinfo = True
                            lPostLangd = GetValue(APP_FINFO_LANGD, True) + GetValue(APP_BIDCON_LANGD, True)
                            bBidCon = True
                        End If
                        If Len(lsBuffer) = GetValue(APP_VILMA_LANGD, True) + GetValue(APP_BIDCON_LANGD, True) Then
                            bVilma = True
                            lPostLangd = GetValue(APP_VILMA_LANGD, True) + GetValue(APP_BIDCON_LANGD, True)
                            bBidCon = True
                        End If
                        If Len(lsBuffer) = GetValue(APP_VILMA2_LANGD, True) + GetValue(APP_BIDCON_LANGD, True) Then
                            bVilma2 = True
                            lPostLangd = GetValue(APP_VILMA2_LANGD, True) + GetValue(APP_BIDCON_LANGD, True)
                            bBidCon = True
                        End If
                    End If  '2019-01-14
                End If
                bFirstRecord = False
                '---<2013-03-07

                '--->2013-03-07
            Else
                '-- Verifiera att alla rader är rätt antal tecken
                If Len(lsBuffer) <> lPostLangd Then 'Post med fel postlängd
                    bFinfo = False
                    bVilma = False
                    bVilma2 = False
                    Exit Do
                End If
            End If
            '->Exit Do
            '---<2013-03-07

        Loop
        FileClose(FnrIn)

        If bVilma = False And bFinfo = False And bVilma2 = False Then
            s = "Den markerade filen är varken en FINFO- eller en VILMA-fil."
            s = s & vbCrLf
            s = s & "Är det en specialfil för en leverantör; markera leverantören och försök igen."
            MsgBox(s, vbInformation, APPNAME)
            lstLev.Focus()
            Exit Sub
        End If

        labelStatus.Text = "Kontrollerar infilen..."
        lsUtFil = "TRBTF00"
        If bVilma = True Then
            lsUtFil = "TRBTV00"
        End If
        If bVilma2 = True Then
            lsUtFil = "TRBTW00"
        End If

        '--->2013-03-07, nya filnamn för BidCon
        If bBidCon = True Then
            'byta ut filnamnet till filnamnet enligt BidCon
            lsUtFil = "TRBI" & Mid(lsUtFil, 5, Len(lsUtFil))
        End If
        '---<2013-03-07

        sTryggFile = lsUtFil
        lsUtFil = FixDirStr(APP_DIR_UTDATA) & lsUtFil

        lsBackUpDirParent = FixDirStr(APP_DIR_INDATA) & "backup"
        lsBackUpDirChild = lsBackUpDirParent & "\" & Format(System.DateTime.Now, "YYYYMMDD")
        lsBackUpFil = lsBackUpDirChild & "\" & lstFiles.SelectedItem.Text

        '-- Kontroll att utdatakatalog existerar.
        If Not DirExist(APP_DIR_UTDATA) Then
            MsgBox("Katalogen " & UCase(APP_DIR_UTDATA) & " där filen till Trygg skapas finns inte." & vbCrLf &
             "Gå in i inställningar och skriv in en giltig sökväg.", vbInformation, APPNAME)
            Exit Sub
        End If

        '-- Om gammal FINFO-fil finns kvar, fråga om denna ska tas bort.
        If FileExists(lsUtFil) Then
            Kill(lsUtFil)  'Tar bort den utan att fråga
        Else
            MsgBox("Rutinen avbryts.", vbInformation)
            Exit Sub
        End If

        '-- Öppna infil för läsning.
        FnrIn = FreeFile()
        FileOpen(FnrIn, lsBackUpFil, OpenMode.Input)

        bFileOpen = True

        '-- Gå igenom alla rader i FINFO-fil.
        Do Until EOF(FnrIn)
            lsBuffer = LineInput(FnrIn)

            llRecord = llRecord + 1

            '-- Verifiera att alla rader är rätt antal tecken
            If Len(lsBuffer) <> lPostLangd Then

                FileClose(FnrIn)
                MsgBox("Rad " & llRecord & " i in-filen " & lsInfil & " har ej rätt längd(" & lPostLangd & ")." & vbCrLf &
                "Ingen fil är skapad.", vbInformation, APPNAME)
                Exit Sub
            End If

            Application.DoEvents()

        Loop

        FileClose(FnrIn)

        bFileOpen = False

        '-- Kopiera den kontrollerade FINFO-filen till [APP_DIR_UTDATA]
        labelStatus.Text = "Kopierar till Trygg och rensar upp..."
        FileCopy(lsInfil, lsUtFil)

        If chkVerifiering.Checked = False Then  'Inte endast verifiering
            '-- Finns inte katalogen [APP_DIR_INDATA]\backup, skapa den.
            If Not DirExist(lsBackUpDirParent) Then MkDir(lsBackUpDirParent)

            '-- Finns inte katalogen [APP_DIR_INDATA]\backup\'dagens datum', skapa den.
            If Not DirExist(lsBackUpDirChild) Then MkDir(lsBackUpDirChild)

            '-- Finns det redan en fil med samma namn i [APP_DIR_INDATA]\backup\'dagens datum' ?
            If FileExists(lsBackUpFil) Then
                Kill(lsBackUpFil)
            End If

            '-- Flyttar behandlad leverantörsfil till backupkatalog.
            'Name lsInfil As lsBackUpFil
            FileCopy(lsInfil, lsBackUpFil)
            Kill(lsInfil)

            UpdateListboxes()
        End If

        bTransfer = True

        On Error GoTo 0

        Exit Sub

EH:
        If bFileOpen Then FileClose(FnrIn)
        UpdateListboxes()
        MsgBox("Ett fel har inträffat." & vbCrLf & "Felbeskrivning :  " & Err.Description, vbInformation, APPNAME)
        On Error GoTo 0

    End Sub

    Private Sub transferAS400()

        Dim lsSource As String
        Dim lsTarget As String
        Dim lsFile As String
        Dim lsMsg As String

        On Error GoTo EH

        lsFile = sTryggFile

        lsSource = FixDirStr(APP_DIR_UTDATA) & lsFile
        lsTarget = FixDirStr(APP_DIR_AS400) & lsFile

        '-- Kontroll att AS400 katalog existerar.
        If Not DirExist(APP_DIR_AS400) Then
            MsgBox("Katalogen " & UCase(APP_DIR_AS400) & " där filen till AS400 skapas finns inte." & vbCrLf &
                "Gå in i inställningar och skriv in en giltig sökväg.", vbInformation, APPNAME)
            Exit Sub
        End If

        '-- Kontroll att Tryggfil är vald.
        If Len(lsFile) = 0 Then
            MsgBox("Markera Trygg-fil.", vbInformation, APPNAME)
            Exit Sub
        End If

        '-- Om gammal AS400-fil finns kvar, fråga om denna ska tas bort.
        If FileExists(lsTarget) Then
            Kill(lsTarget)
        End If

        Me.Cursor = Cursors.WaitCursor

        '-- Kopiering av trygg-fil till AS400 katalog
        FileCopy(lsSource, lsTarget)

        lsMsg = "Filen " & lsFile & " har kopierats till " & UCase(APP_DIR_AS400) & "."
        Me.Cursor = Cursors.Default

        MsgBox(lsMsg, vbInformation, APPNAME)

        UpdateListboxes()
        On Error GoTo 0

        Exit Sub

EH:
        UpdateListboxes()
        MsgBox("Ett fel har inträffat." & vbCrLf & "Felbeskrivning :  " & Err.Description, vbInformation, APPNAME)
        On Error GoTo 0

    End Sub

    Private Function ConvertExcelToText(sInfil As String, sTextFil As String) As Boolean

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim i As Integer

        Try

            ConvertExcelToText = False

            '-- Kontroll att [sInFil] är en excel-fil
            i = InStrRev(sInfil, ".")
            If i > 0 Then
                If UCase(sInfil.Substring(i, 3)) <> "XLS" Then
                    i = 0
                End If
            End If
            If i = 0 Then
                MsgBox("Ej en giltig excel-fil. Ska ha ändelsen 'xls', eller 'xlsx." & vbCrLf & "Ingen fil skapad.", vbInformation, APPNAME)
                Exit Function
            End If

            xlApp = New Excel.Application
            xlWorkBook = xlApp.Workbooks.Open(sInfil)

            '-- Ta bort gammal fil om sådan finns.
            If FileExists(sTextFil) Then
                Kill(sTextFil)
            End If

            'siffran 20 i nedanstående gör at den spara som windows text.
            'MEN den sparar ner decimalkomma som decimalpunkt vilket kan bli problem ibland med tal med många decimaler
            xlWorkBook.SaveAs(sTextFil, 20)
            xlWorkBook.Close(False)

            xlWorkBook = Nothing
            xlApp = Nothing

            ConvertExcelToText = True

        Catch ex As Exception
            MsgBox("Ett fel har inträffat." & vbCrLf & "Felbeskrivning :  " & ex.Message & vbCrLf &
              "Ingen fil skapad.", vbInformation, APPNAME)
            Return False
        End Try


    End Function




    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        oWshShell = CreateObject("WScript.Shell")
        GetSaveWindowsPreferences("Get", Me)
        labelDateTime.Text = Date.Now.ToString
        labelStatus.Text = ""

        'Gör vissa kontroller visable = No
        progressBarElement.Value1 = 0
        progressBarElement.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        txtProgressBar.Visibility = Telerik.WinControls.ElementVisibility.Hidden


    End Sub


    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        Dim lW As Long
        Dim lH As Long
        Dim dblFactorW As Double
        Dim dblFactorH As Double

        lW = System.Math.Abs(Me.Width - 100)
        lH = System.Math.Abs(Me.Height - 100)
        dblFactorW = 0.95
        dblFactorH = 0.87

        frameCmd.Height = System.Math.Abs(lH * (dblFactorH + 0.15))

        frameLev.Height = System.Math.Abs(frameCmd.Height * 0.4)
        lstLev.Height = System.Math.Abs(frameLev.Height * (dblFactorH - 0.035))
        frameLev.Width = System.Math.Abs(lW - frameCmd.Width - 30)
        lstLev.Width = System.Math.Abs(frameLev.Width * dblFactorW)

        FrameLevfiler.Top = System.Math.Abs(frameLev.Top + frameLev.Height + 10)
        FrameLevfiler.Height = System.Math.Abs(frameCmd.Height * 0.57)
        lstFiles.Height = System.Math.Abs(FrameLevfiler.Height * (dblFactorH + 0.01))
        FrameLevfiler.Width = frameLev.Width
        lstFiles.Width = lstLev.Width

    End Sub

    Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        GetSaveWindowsPreferences("Save", Me)

    End Sub

    Private Sub frmMain_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        On Error GoTo EH

        Me.Text = "PrisTrygg.  Version : " & Application.ProductVersion


        '-- Om inte alla registervärden är satta så visa fönster med inställningar
        '-- "frmParameters". Om vi kommer i retur från "frmParameters" via "Avbryt-knappen"
        '-- och nödvändiga registervärden inte är satta så meddelas detta till användaren
        '-- vars enda valmöjligheter är att avsluta programmet eller gå till inställningar.

        If Not RegAppDirExist() Then
            If Not DirExist("C:\" & APPNAME) Then MkDir("C:\" & APPNAME)
            If Not DirExist("C:\" & APPNAME & "\Mall") Then MkDir("C:\" & APPNAME & "\Mall")
            If Not DirExist("C:\" & APPNAME & "\In") Then MkDir("C:\" & APPNAME & "\In")
            If Not DirExist("C:\" & APPNAME & "\Ut") Then MkDir("C:\" & APPNAME & "\Ut")
            Call SetRegistryValues()
        End If

        '-- Kommer från frmSupplierTemplate. Registervärden redan satta.
        If Me.Tag = "LEV" Then
            Me.Tag = ""
        Else
            If Not ReitriveRegEditSettings() Then
                'Valt "Avbryt" i inställningar.
                If Me.Tag = "CANCEL" Then
                    Me.Tag = ""

                    '-- Knappen "Avsluta" och menyn klickbar.
                    MsgBox("Nödvändiga registervärden ej satta!", vbInformation, APPNAME)

                    Exit Sub
                Else
                    '-- Fönster med inställningar visas.
                    FrmParameters.Show()
                    FrmParameters.BringToFront()
                    Exit Sub
                End If
            End If
        End If

        UpdateListboxes()

        Exit Sub

EH:
        MsgBox("Ett fel har inträffat." & vbCrLf & "Felbeskrivning :  " & Err.Description, vbInformation, APPNAME)

    End Sub


    Public Sub UpdateListboxes()
        Dim lsTemp As String

        lsTemp = Dir(FixDirStr(APP_DIR_MALL) & "*.lev")
        lstLev.Items.Clear()
        lstLev.Items.Add("<Ingen leverantör>")
        While lsTemp <> ""
            lstLev.Items.Add(lsTemp)
            lsTemp = Dir()
        End While

        lsTemp = Dir(FixDirStr(APP_DIR_INDATA) & "*.*")
        lstFiles.Items.Clear()
        While lsTemp <> ""
            lstFiles.Items.Add(lsTemp)
            lsTemp = Dir()
        End While

    End Sub

    Private Sub SetRegistryValues()
        Dim cRegEdit As New clsRegistry
        Dim lsKey As String

        On Error GoTo EH

        '-- Register-sökväg.
        lsKey = REG_MAIN_KEY & "\" & REG_APP_KEY

        '-- Skapa nyckel om den inte finns.
        If Not cRegEdit.KeyExist(lsKey) Then cRegEdit.AddKey(lsKey)

        '-- Skriver värden till registret
        cRegEdit.AddValue(lsKey, REG_VALUENAME_INDATA_DIR, "C:\" & APPNAME & "\In")
        cRegEdit.AddValue(lsKey, REG_VALUENAME_UTDATA_DIR, "C:\" & APPNAME & "\Ut")
        cRegEdit.AddValue(lsKey, REG_VALUENAME_MALL_DIR, "C:\" & APPNAME & "\Mall")
        'cRegEdit.AddValue lsKey, REG_VALUENAME_AS400_DIR, "V:\" & APPNAME
        '-- Flagga som talar om att kataloger är skapade.
        cRegEdit.AddValue(lsKey, REG_VALUENAME_CREATED, "YES")
        Exit Sub

EH:
        'Err.Raise Number:=Err.Number,
        ' Source:="SetRegistryValues",
        ' Description:=Err.Description

    End Sub

    Private Function RegAppDirExist() As Boolean
        Dim cRegEdit As New clsRegistry
        Dim lbTemp As Boolean
        Dim lsKey As String

        On Error GoTo EH

        RegAppDirExist = False

        '-- Fullständig sökväg till nyckeln med registervärden.
        '-- [REG_MAIN_KEY] + [REG_APP_KEY]
        lsKey = REG_MAIN_KEY & "\" & REG_APP_KEY

        If cRegEdit.KeyExist(lsKey) Then

            '-- Kataloger är skapade.
            If cRegEdit.ValueExist(lsKey, REG_VALUENAME_CREATED) Then
                RegAppDirExist = True
            End If
        End If

        Exit Function

EH:

    End Function


    '-- ====================================================================================
    '-- Hämtar värden från registret om dessa är satta i "Inställningar". Är de ej satta
    '-- Skapas en nyckel på formen
    '-- [REG_MAIN_KEY] + [REG_APP_KEY] och
    '-- FALSE returneras. Annars returneras TRUE.
    '-- ====================================================================================
    Private Function ReitriveRegEditSettings() As Boolean
        Dim cRegEdit As New clsRegistry

        Dim lbTemp As Boolean
        Dim lsKey As String

        On Error GoTo EH

        lbTemp = True
        '-- Fullständig sökväg till nyckeln med registervärden.
        '-- [REG_MAIN_KEY] + [REG_APP_KEY]
        lsKey = REG_MAIN_KEY & "\" & REG_APP_KEY

        '-- Om nyckel finns, ta fram värden
        If cRegEdit.KeyExist(lsKey) Then

            '-- infil
            If cRegEdit.ValueExist(lsKey, REG_VALUENAME_INDATA_DIR) Then
                APP_DIR_INDATA = cRegEdit.RetriveValue(lsKey, REG_VALUENAME_INDATA_DIR)
                If Len(APP_DIR_INDATA) = 0 Then lbTemp = False
            Else
                lbTemp = False
            End If

            '-- utfil
            If cRegEdit.ValueExist(lsKey, REG_VALUENAME_UTDATA_DIR) Then
                APP_DIR_UTDATA = cRegEdit.RetriveValue(lsKey, REG_VALUENAME_UTDATA_DIR)
                If Len(APP_DIR_UTDATA) = 0 Then lbTemp = False
            Else
                lbTemp = False
            End If

            '-- mallar
            If cRegEdit.ValueExist(lsKey, REG_VALUENAME_MALL_DIR) Then
                APP_DIR_MALL = cRegEdit.RetriveValue(lsKey, REG_VALUENAME_MALL_DIR)
                If Len(APP_DIR_MALL) = 0 Then lbTemp = False
            Else
                lbTemp = False
            End If

            '-- AS 400-fil
            If cRegEdit.ValueExist(lsKey, REG_VALUENAME_AS400_DIR) Then
                APP_DIR_AS400 = cRegEdit.RetriveValue(lsKey, REG_VALUENAME_AS400_DIR)
                If Len(APP_DIR_AS400) = 0 Then lbTemp = False
            Else
                lbTemp = False
            End If

            '-- FINFO-längden
            If cRegEdit.ValueExist(lsKey, REG_VALUENAME_FINFO_LANGD) Then
                APP_FINFO_LANGD = cRegEdit.RetriveValue(lsKey, REG_VALUENAME_FINFO_LANGD)
                If Len(APP_FINFO_LANGD) = 0 Then
                    APP_FINFO_LANGD = "548"
                End If
            Else
                APP_FINFO_LANGD = "548"
            End If

            '-- VILMA-längden
            If cRegEdit.ValueExist(lsKey, REG_VALUENAME_VILMA_LANGD) Then
                APP_VILMA_LANGD = cRegEdit.RetriveValue(lsKey, REG_VALUENAME_VILMA_LANGD)
                If Len(APP_VILMA_LANGD) = 0 Then
                    APP_VILMA_LANGD = "717"
                End If
            Else
                APP_VILMA_LANGD = "717"
            End If

            '--->2012-01-30
            '-- VILMA2-längden
            If cRegEdit.ValueExist(lsKey, REG_VALUENAME_VILMA2_LANGD) Then
                APP_VILMA2_LANGD = cRegEdit.RetriveValue(lsKey, REG_VALUENAME_VILMA2_LANGD)
                If Len(APP_VILMA2_LANGD) = 0 Then
                    APP_VILMA2_LANGD = "1508"
                End If
            Else
                APP_VILMA2_LANGD = "1508"
            End If
            '-- VILMA2-flagga
            If cRegEdit.ValueExist(lsKey, REG_VALUENAME_VILMA2_FLAG) Then
                APP_VILMA2_FLAG = cRegEdit.RetriveValue(lsKey, REG_VALUENAME_VILMA2_FLAG)
                If Len(Trim(APP_VILMA2_FLAG)) = 0 Then
                    APP_VILMA2_FLAG = "0"
                End If
                If Len(Trim(APP_VILMA2_FLAG)) > 1 Then
                    APP_VILMA2_FLAG = "0"
                End If
            Else
                APP_VILMA2_FLAG = "1"   'Sätter den alltid till Vilma2
            End If
            '---<2012-01-30

            '--->2013-03-07, längden på BidCon-fälten
            If cRegEdit.ValueExist(lsKey, REG_VALUENAME_BIDCON_LANGD) Then
                APP_BIDCON_LANGD = cRegEdit.RetriveValue(lsKey, REG_VALUENAME_BIDCON_LANGD)
                If Len(APP_BIDCON_LANGD) = 0 Then
                    APP_BIDCON_LANGD = "29"
                End If
            Else
                APP_BIDCON_LANGD = "29"
            End If
            '---<2013-03-07

            APP_FTP_COMMAND_BTE = ""
            APP_FTP_COMMAND_BTF = ""
        Else
            '-- Skapa nyckel.
            cRegEdit.AddKey(lsKey)
            lbTemp = False
        End If

        ReitriveRegEditSettings = lbTemp

        Exit Function

EH:
        'Err.Raise Number:=Err.Number,
        'Source:="ReitriveRegEditSettings",
        'Description:=Err.Description

    End Function

    Private Sub lblLeverantorer_Click()
        Dim lsTemp As String

        lsTemp = Dir(FixDirStr(APP_DIR_MALL) & "*.lev")
        lstLev.Items.Clear()

        Do While lsTemp <> ""
            lstLev.Items.Add(lsTemp)
            lsTemp = Dir()
        Loop

    End Sub

    Private Sub lblLevFiles_Click()
        Dim lsTemp As String

        lsTemp = Dir(FixDirStr(APP_DIR_INDATA) & "*.*")
        lstFiles.Items.Clear()

        Do While lsTemp <> ""
            lstFiles.Items.Add(lsTemp)
            lsTemp = Dir()
        Loop

    End Sub

    Private Sub FrameLev_Click()

        UpdateListboxes()

    End Sub

    Private Sub FrameLevfiler_Click()

        UpdateListboxes()

    End Sub

    Private Sub FrameTryggfiler_Click()

        UpdateListboxes()

    End Sub

    Private Sub lstLev_DblClick()

        Dim sender As Object = Nothing
        Dim e As EventArgs = Nothing

        If lstLev.SelectedItem Is Nothing Then
            MsgBox("Klicka på en leverantör i listan.", vbInformation, APPNAME)
            Exit Sub
        End If

        mnuUpdateSupplier_Click(sender, e) 'Ändra på leverantören

    End Sub

    Private Sub mnuAbout_Click()
        'frmAbout.Show
    End Sub

    '-- ====================================================================================
    '-- Visar fönster med inställningar.
    '-- ====================================================================================
    Private Sub mnuConfig_Click()
        'frmParameters.Show
    End Sub

    '-- ====================================================================================
    '-- Avsluta.
    '-- ====================================================================================


    Private Sub mnuHelptext_Click()
        'frmAllHelp.Show
    End Sub

    Private Sub mnuVerifyTryggFile_Click()

        Dim lsIntern As String

        On Error GoTo EH

        If InStr(sTryggFile, "BTF") > 0 Then
            lsIntern = INI_FILE_INTERN
        ElseIf InStr(sTryggFile, "BTV") > 0 Then
            lsIntern = INI_FILE_INTERN_VILMA
        ElseIf InStr(sTryggFile, "BTW") > 0 Then
            lsIntern = INI_FILE_INTERN_VILMA2
        Else
            lsIntern = ""
        End If

        cLev = New clsSupplier
        If Not cLev.CreatePosts(lsIntern) Then Exit Sub
        FrmVerifyInfile.Tag = sTryggFile
        FrmVerifyInfile.Tag = FixDirStr(APP_DIR_UTDATA) & sTryggFile
        FrmVerifyInfile.Show()

        On Error GoTo 0

        Exit Sub

EH:
        MsgBox("Ett fel har inträffat." & vbCrLf & "Felbeskrivning :  " & Err.Description, vbInformation, APPNAME)
        On Error GoTo 0

    End Sub

    '-- Läser in egenskaper från mallfilen som är vald i listan till leverantörsobjektet.
    Private Function LoadIniFile() As Boolean
        Dim cString As New clsString
        Dim lsBuffer As String
        Dim lsLevFile As String
        Dim Fnr As Integer
        Dim J As Long
        Dim bFileOpen As Boolean
        Dim llPos1 As Long
        Dim llPos2 As Long
        Dim llPos3 As Long
        Dim s As String

LoadInFileStart:
        On Error GoTo EH

        LoadIniFile = True
        bFileOpen = False

        lsLevFile = lstLev.SelectedItem.Text

        If Len(lsLevFile) = 0 Then
            MsgBox("Markera leverantör i listan.", vbInformation, APPNAME)
            LoadIniFile = False

            Exit Function
        End If

        cLev = New clsSupplier

        Fnr = FreeFile()
        FileOpen(Fnr, FixDirStr(APP_DIR_MALL) & lsLevFile, OpenMode.Input)

        bFileOpen = True

        '-- Header
        lsBuffer = LineInput(Fnr)
        cString.StringData = lsBuffer
        cLev.LevNamn = cString.FindNextPipe
        cLev.LevNr = cString.FindNextPipe
        cLev.FileFormat = cString.FindNextPipe
        cLev.Header = cString.FindNextPipe
        cString.ResetValue()

        cLev.CreatePosts()

        For J = 1 To cLev.NumberOfTemplatePosts
            lsBuffer = LineInput(Fnr)
            cString.StringData = lsBuffer
            cLev.Post(MALL_POST(J)).StartPos = cString.FindNextPipe
            cLev.Post(MALL_POST(J)).Length = cString.FindNextPipe
            cLev.Post(MALL_POST(J)).Divider = cString.FindNextPipe
            cString.ResetValue()
        Next J

        FileClose(Fnr)

        bFileOpen = False

        cString = Nothing

        Exit Function

EH:
        LoadIniFile = False
        If bFileOpen Then FileClose(Fnr)
        '-- Input pat eof
        If Err.Number = 62 Then
            s = "Det finns fler tillgängliga fält än vad det finns fält i mall-filen."
            s = s & vbCrLf
            s = s & "Ska mallfilen justeras så den passar antalet tillgängliga fält?"
            If MsgBox(s, vbYesNo, APPNAME) = vbYes Then
                makeMallRows(cLev.NumberOfTemplatePosts - J + 1)
                On Error GoTo 0
                GoTo LoadInFileStart
            End If
        Else
            MsgBox("Ett fel har inträffat." & vbCrLf & "Felbeskrivning :  " & Err.Description, vbInformation, APPNAME)
        End If

    End Function

    Private Sub mnuEnd_Click()
        End
    End Sub


    Private Function VerifyInFile(sFile As String, bExc As Boolean, ByRef llRecord As Long) As Boolean

        Dim lsBuffer As String
        Dim FnrIn As Integer
        Dim J As Long
        Dim lsArray() As String
        Dim lsStrippedValue As String
        Dim b As Boolean

        On Error GoTo EH

        VerifyInFile = True
        lsArray = Split("", "")

        '-- Öppna infil för läsning.
        FnrIn = FreeFile()
        FileOpen(FnrIn, sFile, OpenMode.Input)

        Do Until EOF(FnrIn)
            lsBuffer = LineInput(FnrIn)

            '-- Första raden ?
            If llRecord = 0 Then
                '-- Finns rubrikrader ?
                If cLev.Header > 0 Then
                    '-- Hoppa över de rader som innehåller kolumnrubriker.
                    For J = 1 To cLev.Header
                        '-- Kontrollera att det finns fler rader i filen.
                        If Not EOF(FnrIn) Then
                            lsBuffer = LineInput(FnrIn)
                            llRecord = llRecord + 1
                        Else
                            MsgBox("Filen " & sFile & " innehåller endast kolumnrubriker." & vbCrLf &
                                "Ingen fil skapad.", vbInformation, APPNAME)
                            VerifyInFile = False
                            FileClose(FnrIn)
                            Exit Function
                        End If
                    Next J

                    J = 0

                End If
            End If

            If bExc Then lsArray = Split(lsBuffer, vbTab)

            '--->Om det är en semikolonseparerad fil simulerar jag en excelfil. Excelfilen har tab som fältavskiljare
            If cLev.FileFormat = FILE_CSV Then
                bExc = True
                lsArray = Split(lsBuffer, ";")
            End If

            llRecord = llRecord + 1

            'Hoppa över tomrader
            If Len(Trim(Replace(lsBuffer, vbTab, ""))) > 0 Then


                '-- Gå igenom samtliga fält i leverantörsfil. hoppa över Levnr
                For J = 2 To cLev.NumberOfTemplatePosts
                    '-- Om startpos = 0 ska posten hoppas över.
                    If cLev.Post(MALL_POST(J)).StartPos <> 0 Then

                        b = False
                        If bExc Then
                            If cLev.Post(MALL_POST(J)).StartPos >= UBound(lsArray) Then
                                b = True
                            Else
                                cLev.Post(MALL_POST(J)).Value = Replace(Trim(lsArray(cLev.Post(MALL_POST(J)).StartPos - 1)), """", "")
                            End If
                        Else
                            cLev.Post(MALL_POST(J)).Value = Trim(Mid(lsBuffer, cLev.Post(MALL_POST(J)).StartPos, cLev.Post(MALL_POST(J)).Length))
                        End If

                        If b = False Then
                            '-- Kontroll numeriskt fält.
                            If cLev.Post(MALL_POST(J)).FINFO_DataFormat = FORMAT_NUMERIC Then

                                '-- Blanka numeriska fält sätts till "0".
                                If Len(Trim(cLev.Post(MALL_POST(J)).Value)) = 0 Then cLev.Post(MALL_POST(J)).Value = "0"

                                'Försöker ta hand om decimaltecknet
                                If Not IsNumeric(cLev.Post(MALL_POST(J)).Value) Then
                                    cLev.Post(MALL_POST(J)).Value.Replace(",", ".")
                                    If Not IsNumeric(cLev.Post(MALL_POST(J)).Value) Then
                                        cLev.Post(MALL_POST(J)).Value.Replace(".", ",")
                                    End If
                                End If

                                If Not IsNumeric(cLev.Post(MALL_POST(J)).Value) Then
                                    MsgBox(cLev.Post(MALL_POST(J)).FINFO_Description & " ska vara ett numeriskt värde." & vbCrLf &
                              "Värde i filen = " & cLev.Post(MALL_POST(J)).Value & "  Radnr = " & llRecord & vbCrLf & "Ingen fil skapad.", vbInformation, APPNAME)
                                    VerifyInFile = False
                                    FileClose(FnrIn)
                                    Exit Function
                                End If

                                '-- Vid längdkontroll av numeriska fält, räkna inte med komma eller punkt.
                                lsStrippedValue = Replace(cLev.Post(MALL_POST(J)).Value, ",", "")
                                lsStrippedValue = Replace(lsStrippedValue, ".", "")

                                If Len(lsStrippedValue) > cLev.Post(MALL_POST(J)).FINFO_Length Then
                                    MsgBox(cLev.Post(MALL_POST(J)).FINFO_Description & " får max vara " & cLev.Post(MALL_POST(J)).FINFO_Length & " tecken långt." &
                                  "  Radnr = " & llRecord & vbCrLf & "Ingen fil skapad.", vbInformation, APPNAME)
                                    VerifyInFile = False
                                    FileClose(FnrIn)
                                    Exit Function
                                End If
                                '=== /2004-05-07 ===

                                If Len(Trim(cLev.Post(MALL_POST(J)).Value)) <> 0 And cLev.Post(MALL_POST(J)).Divider > 0 And cLev.Post(MALL_POST(J)).Value <> "0" Then
                                    cLev.Post(MALL_POST(J)).Value = CStr(CLng(cLev.Post(MALL_POST(J)).Value) / cLev.Post(MALL_POST(J)).Divider)

                                    If Len(cLev.Post(MALL_POST(J)).Value) > cLev.Post(MALL_POST(J)).FINFO_Length Then
                                        MsgBox("Vid division med " & CStr(cLev.Post(MALL_POST(J)).Divider) & " har " & cLev.Post(MALL_POST(J)).FINFO_Description & vbCrLf &
                                     "överskridit maxlängden " & cLev.Post(MALL_POST(J)).FINFO_Length & vbCrLf & "Ingen fil skapad.", vbInformation, APPNAME)
                                        VerifyInFile = False
                                        FileClose(FnrIn)
                                        Exit Function
                                    End If

                                End If

                            End If

                        End If

                    End If

                Next J
            End If

        Loop

        FileClose(FnrIn)

        Exit Function

EH:
        VerifyInFile = False
        FileClose(FnrIn)
        MsgBox("Ett fel har inträffat." & vbCrLf & "Felbeskrivning :  " & Err.Description & vbCrLf &
          "Ingen fil skapad.", vbInformation, APPNAME)

    End Function

    Private Function CreateTryggFile(sInfil As String, sUtFil As String) As Boolean

        '2005-03-29 Lagt till flexibel ändring av extern.ini
        Dim cString As clsString
        Dim lsBuffer As String
        Dim bExcel As Boolean
        Dim llPos As Long
        Dim llDecimals As Long

        Dim FnrIn As Integer
        Dim FnrOut As Integer
        Dim J As Long
        Dim bFilesIsOpen As Boolean
        Dim llRecord As Long
        Dim lsData As String
        Dim lsArray() As String
        Dim STLNRA As String

        '-- Denna måste ändras då nya fält tillkommer i EXTERN.ini
        '-- Borde inte hårdkodas
        '2005-03-29 tar bort hårdkodningen
        Dim lsConvertedData As String '2005-03-29 * 751 '591
        Dim RV As Long
        Dim lRecordLength As Long '2005-03-29
        Dim lNoOfRecords As Long

        On Error GoTo EH

        CreateTryggFile = True
        bFilesIsOpen = False
        bExcel = False
        RecordCounter = 0
        lsConvertedData = ""
        lsData = ""

        '-- Om det är en excel-fil från leverantören sätts [bExcel] = TRUE.
        If cLev.FileFormat = FILE_EXCEL_ANSI Or cLev.FileFormat = FILE_EXCEL_DOS Then
            bExcel = True
            cString = New clsString
        End If

        '-- Verifierar fil från leverantör.
        lNoOfRecords = 0
        If Not VerifyInFile(sInfil, bExcel, lNoOfRecords) Then
            CreateTryggFile = False
            Exit Function
        End If

        '-- Leverantörsnummer är samma för alla rader.
        '-- FIXA TILL LÖSNING!!!!!!
        STLNRA = cLev.LevNr & Space(cLev.Post(1).FINFO_Length - Len(cLev.LevNr))
        lRecordLength = Len(STLNRA) '2005-03-29


        '-- Öppna utfil för skrivning.
        FnrOut = FreeFile()
        FileOpen(FnrOut, sUtFil, OpenMode.Output)

        '--->2008-02-11, lagt in en räknare
        If lNoOfRecords > 0 Then
            writeCounter(True, lNoOfRecords)
        End If
        '---<2008-02-11

        '-- Öppna infil för läsning.
        FnrIn = FreeFile()
        FileOpen(FnrIn, sInfil, OpenMode.Input)

        bFilesIsOpen = True
        lsArray = Split("", "")

        Do Until EOF(FnrIn)

            lsBuffer = LineInput(FnrIn)

            writeCounter()  '2008-02-11
            '-- Första raden ?
            If RecordCounter = 0 Then
                '-- Finns rubrikrader ?
                If cLev.Header > 0 Then
                    '-- Hoppa över de rader som innehåller kolumnrubriker.
                    For J = 1 To cLev.Header
                        lsBuffer = LineInput(FnrIn)
                        writeCounter()
                    Next J
                    J = 0
                End If
            End If


            lRecordLength = Len(STLNRA) '2005-12-19
            If bExcel Then lsArray = Split(lsBuffer, vbTab)

            '--->2009-06-01 Om det är en semikolonseparerad fil simulerar jag en excelfil. Excelfilen har tab som fältavskiljare
            If cLev.FileFormat = FILE_CSV Then
                bExcel = True
                lsArray = Split(lsBuffer, ";")
            End If
            '---<2009-06-01

            '2003-12-16. Hoppa över tomrader
            If Len(Trim(Replace(lsBuffer, vbTab, ""))) > 0 Then

                RecordCounter = RecordCounter + 1

                '-- Gå igenom samtliga fält. hoppa över Levnr
                For J = 2 To cLev.NumberOfPosts
                    '-- Koll om det är en post som ska läsas från leverantörsfil, och om så är
                    '-- fallet kolla att startpos <> 0. Om startpos = 0 ska posten hoppas över.
                    If cLev.Post(J).TemplateField And cLev.Post(J).StartPos <> 0 Then


                        '******************************************************************************************

                        If bExcel Then
                            cLev.Post(J).Value = Replace(Trim(lsArray(cLev.Post(J).StartPos - 1)), """", "")
                        Else
                            cLev.Post(J).Value = Trim(Mid(lsBuffer, cLev.Post(J).StartPos, cLev.Post(J).Length))
                        End If

                        '-- Är värdet numeriskt ?
                        If cLev.Post(J).FINFO_DataFormat = FORMAT_NUMERIC Then

                            '-- Om komma, kolla FINFO_Decimals
                            If cLev.Post(J).Divider = -1 Then

                                '-- Decimaltecken saknas i posten, lägg till [FINFO_Decimals] nollor.
                                If InStrRev(cLev.Post(J).Value, ".") = 0 And InStrRev(cLev.Post(J).Value, ",") = 0 Then
                                    cLev.Post(J).Value = cLev.Post(J).Value & New String("0", cLev.Post(J).FINFO_Decimals)
                                Else
                                    '-- Sök efter punkt.
                                    llPos = InStrRev(cLev.Post(J).Value, ".")
                                    '-- Hittas ingen punkt, sök efter komma.
                                    If llPos = 0 Then llPos = InStrRev(cLev.Post(J).Value, ",")

                                    '-- Lägg antalet decimaler i [llDecimals]
                                    llDecimals = Len(cLev.Post(J).Value) - llPos

                                    '-- Om för många decimaler är angivna, plocka bort. (ex, 2 dec. 25,500 --> 25,50)
                                    If llDecimals > cLev.Post(J).FINFO_Decimals Then
                                        cLev.Post(J).Value = Strings.Left(cLev.Post(J).Value, Len(cLev.Post(J).Value) - (llDecimals - cLev.Post(J).FINFO_Decimals))
                                    Else
                                        '-- Fyll ut med nollor om ej tillräckligt med decimaler. (ex, 2 dec. 25,5 --> 25,50)
                                        cLev.Post(J).Value = cLev.Post(J).Value & New String("0", cLev.Post(J).FINFO_Decimals - llDecimals)
                                    End If

                                End If

                            End If

                            cLev.Post(J).Value = Replace(cLev.Post(J).Value, ",", "")
                            cLev.Post(J).Value = Replace(cLev.Post(J).Value, ".", "")

                            '-- Ska värdet divideras med någon 10-potens ?
                            If Len(Trim(cLev.Post(J).Value)) <> 0 And cLev.Post(J).Divider > 0 Then
                                cLev.Post(J).Value = CStr(CLng(cLev.Post(J).Value) / cLev.Post(J).Divider)
                            End If

                            '-- Numeriskt fält, fyll ut med nollor. HS
                            '--->2008-01-22, kontroll att längden inte blir mindre än 0
                            'cLev.Post(J).Value = String(CLng(cLev.Post(J).FINFO_Length) - Len(cLev.Post(J).Value), "0") & cLev.Post(J).Value
                            If (CLng(cLev.Post(J).FINFO_Length) - Len(cLev.Post(J).Value)) > 0 Then
                                cLev.Post(J).Value = New String("0", CLng(cLev.Post(J).FINFO_Length) - Len(cLev.Post(J).Value)) & cLev.Post(J).Value
                            End If
                            '---<2008-01-22

                        Else
                            '-- Om textfält är för långt, trimma slutet så att längden blir maximalt tillåten.
                            If Len(cLev.Post(J).Value) > cLev.Post(J).FINFO_Length Then
                                cLev.Post(J).Value = Strings.Left(cLev.Post(J).Value, cLev.Post(J).FINFO_Length)
                            End If

                            '-- Är det ett textfält, fyll ut med rätt antal blanka om längden understiger def. maxlängd. VS
                            cLev.Post(J).Value = cLev.Post(J).Value & Space(cLev.Post(J).FINFO_Length - Len(cLev.Post(J).Value))

                        End If

                        '-- Värde ska ej tas från fil.
                    Else

                        '-- Är det ett textfält, fyll ut med rätt antal X. VS
                        If cLev.Post(J).FINFO_DataFormat = FORMAT_TEXT Then
                            'cLev.Post(J).Value = Space(cLev.Post(J).FINFO_Length)
                            cLev.Post(J).Value = New String("X", cLev.Post(J).FINFO_Length)
                            '-- Numeriskt fält, fyll ut med nior.
                        Else
                            cLev.Post(J).Value = New String("9", cLev.Post(J).FINFO_Length)
                        End If

                    End If

                    '-- Bygg utdatarecord.
                    lsData = lsData & cLev.Post(J).Value
                    lRecordLength = lRecordLength + Len(cLev.Post(J).Value) '2005-03-29
                Next J

                '-- Konvertera till DOS-format om infil = ANSI.
                If cLev.FileFormat = FILE_ANSI Or cLev.FileFormat = FILE_EXCEL_ANSI Then
                    lsConvertedData = Space(lRecordLength) '2005-03-29
                    RV = CharToOem(STLNRA & lsData, lsConvertedData)
                    '-- Om infil = DOS, ingen åtgärd.
                ElseIf cLev.FileFormat = FILE_DOS Or cLev.FileFormat = FILE_EXCEL_DOS Then
                    lsConvertedData = STLNRA & lsData
                ElseIf cLev.FileFormat = FILE_CSV Then
                    lsConvertedData = Space(lRecordLength)
                    RV = CharToOem(STLNRA & lsData, lsConvertedData)
                End If


                '-- Skriv utdatarecord.
                Print(FnrOut, lsConvertedData)
                lsData = ""
            End If

            Application.DoEvents()

        Loop

        writeCounter(, , True)

        FileClose(FnrIn)
        FileClose(FnrOut)

        bFilesIsOpen = False

        UpdateListboxes()

        Exit Function

EH:
        If bFilesIsOpen Then
            FileClose(FnrIn)
            FileClose(FnrOut)
        End If
        CreateTryggFile = False
        UpdateListboxes()
        MsgBox("Ett fel har inträffat." & vbCrLf & "Felbeskrivning :  " & Err.Description & vbCrLf &
          "Filen " & sUtFil & " har skapats.", vbInformation, APPNAME)

    End Function

    Private Sub makeMallRows(lNoOfRows As Long)

        Dim l As Long
        Dim s As String
        Dim sLevFile As String
        Dim lFileNo As Long

        On Error GoTo errorHandle

        sLevFile = lstLev.SelectedValue

        If Len(sLevFile) = 0 Then
            Exit Sub
        End If

        convertMall(sLevFile)

errorHandle:
        FileClose(lFileNo)
        If Err.Description <> "" Then
            MsgBox("Fel vid komplettering av mall! Felet är:" & vbCrLf & Err.Description)
        End If
        On Error GoTo 0

    End Sub

    Public Sub writeCounter(Optional bInitiate As Boolean = False,
                            Optional lMaxRecords As Long = 0,
                            Optional bCloseCounter As Boolean = False)

        If bCloseCounter = True Then
            progressBarElement.Value1 = 0
            progressBarElement.Visibility = Telerik.WinControls.ElementVisibility.Hidden
            txtProgressBar.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        Else
            If bInitiate = True Then
                txtProgressBar.Text = ""
                txtProgressBar.Visibility = Telerik.WinControls.ElementVisibility.Visible
                progressBarElement.Value1 = 0
                progressBarElement.Minimum = 0
                progressBarElement.Maximum = lMaxRecords
                txtProgressBar.Visibility = Telerik.WinControls.ElementVisibility.Visible
            Else
                If progressBarElement.Visibility = Telerik.WinControls.ElementVisibility.Visible Then
                    If progressBarElement.Value1 < progressBarElement.Maximum Then
                        progressBarElement.Value1 = progressBarElement.Value1 + 1
                        txtProgressBar.Text = progressBarElement.Value1 & "/" & progressBarElement.Maximum
                        Application.DoEvents()
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub chkVerifiering_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkVerifiering.ToggleStateChanged

        If args.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off Then
            cmdTransfer.Text = "Skapa fil till Trygg"
        Else
            cmdTransfer.Text = "Verifiera infilen"
        End If

    End Sub

End Class

