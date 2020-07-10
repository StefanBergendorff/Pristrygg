Module modMain
    '2012-01-30 sbf Implementerar Vilma 2 som Vilma-fil
    '2013-01-23 sbf Konverterar mallar från Vilma1 till Vilma2 så de hamnar på rätt fält
    '2013-03-07 sbf Implementerar längden på BidCon fälten


    Public cLev As clsSupplier
    Public oWshShell As Object                                  'Talks with the register

    '-- Namnet på applikationen. Anges som titel på alla messageboxar.
    Public Const APPNAME As String = "PrisTryggRel11"

    '-- Ini-filen som definierar alla fält i Trygg.
    'Public Const INI_FILE As String = "finfo.ini"

    '-- extern.ini används då filer skapas enligt upplagda mallar.
    Public Const INI_FILE As String = "extern.ini"
    Public Const INI_FILE_EXTERN_VILMA1 As String = "Vilma1Extern.ini"   '2012-01-30
    Public Const INI_FILE_EXTERN_VILMA2 As String = "Vilma2Extern.ini"   '2012-01-30
    '-- intern.ini har samma utseende som gamla finfo.ini
    Public Const INI_FILE_INTERN As String = "intern.ini"
    '-- intern.ini har samma utseende som gamla finfo.ini
    Public Const INI_FILE_INTERN_VILMA As String = "VilmaIntern.ini"
    Public Const INI_FILE_INTERN_VILMA2 As String = "Vilma2Intern.ini"

    'Public Const NUMBER_OF_POSTS As integer = 16

    Public Const FILE_EXCEL_ANSI As String = "EXCEL-ANSI"
    Public Const FILE_EXCEL_DOS As String = "EXCEL-DOS"
    Public Const FILE_ANSI As String = "ANSI"
    Public Const FILE_DOS As String = "DOS"
    Public Const FILE_CSV As String = "Semikolonseparerad"
    Public Const FILE_FINFO As String = "FINFO"

    Public Const ALIGNMENT_LEFT As Byte = 1
    Public Const ALIGNMENT_RIGHT As Byte = 2

    Public Const FORMAT_TEXT As String = "Text"
    Public Const FORMAT_NUMERIC As String = "Tal"

    Public Const APP_NAME = "HKEY_CURRENT_USER\Software\Trygg"
    Public Const WINDOW_POS_KEY = "Fönsterposition"
    Public Const FRAME_POS_KEY = "Frameposition"
    Public Const GRID_LAYOUT = "GridLayout"

    '-- Sökvägar
    Public APP_DIR_INDATA As String
    Public APP_DIR_UTDATA As String
    Public APP_DIR_MALL As String
    Public APP_DIR_AS400 As String

    Public APP_FTP_HOST As String
    Public APP_FTP_USER As String
    Public APP_FTP_PW As String
    Public APP_FTP_COMMAND_BTE As String
    Public APP_FTP_COMMAND_BTF As String

    Public APP_FINFO_LANGD As String
    Public APP_VILMA_LANGD As String
    Public APP_VILMA2_LANGD As String '2012-01-30
    Public APP_VILMA2_FLAG As String '2012-01-30
    Public APP_BIDCON_LANGD As String '2013-03-07

    '-- En array med längden = "antalet mallfält" som innehåller vilka rader i filen
    '-- som ska vara mallfält.
    Public MALL_POST() As Integer

    '-- REGISTER KONSTANTER
    '-- Register inställningar Mainkeys.
    'Public Const REG_MAIN_KEY = "HKEY_LOCAL_MACHINE\SOFTWARE\Sema"
    Public Const REG_MAIN_KEY = "HKEY_CURRENT_USER\Software"

    '-- Regedit aktuella nycklar.
    Public Const REG_APP_KEY As String = "PrisTryggRel11"
    Public Const REG_APP__UTV_KEY As String = "PrisTryggRel8Utv"


    '-- Regedit aktuella namn på värden.
    Public Const REG_VALUENAME_CREATED As String = "DirCreated"
    Public Const REG_VALUENAME_INDATA_DIR As String = "Input Directory"
    Public Const REG_VALUENAME_UTDATA_DIR As String = "OutPut Directory"
    Public Const REG_VALUENAME_MALL_DIR As String = "Template Directory"
    Public Const REG_VALUENAME_AS400_DIR As String = "AS 400 Directory"

    Public Const REG_VALUENAME_FTP_HOST As String = "FTP Host"
    Public Const REG_VALUENAME_FTP_USER As String = "FTP User"
    Public Const REG_VALUENAME_FTP_PW As String = "FTP Password"  '-- KRYPTERAS ????????
    Public Const REG_VALUENAME_FTP_COMMAND_BTE As String = "FTP Command BTE"
    Public Const REG_VALUENAME_FTP_COMMAND_BTF As String = "FTP Command BTF"

    Public Const REG_VALUENAME_FINFO_LANGD As String = "FINFO postlängd"
    Public Const REG_VALUENAME_VILMA_LANGD As String = "VILMA postlängd"
    Public Const REG_VALUENAME_VILMA2_LANGD As String = "VILMA2 postlängd"
    Public Const REG_VALUENAME_VILMA2_FLAG As String = "VILMA2 flagga"
    Public Const REG_VALUENAME_BIDCON_LANGD As String = "BIDCON fältlängd"  '2013-03-07


    Public Const ERR_FILE_ISCREATED = vbObjectError + 900

    Public Declare Function OemToChar Lib "user32" Alias "OemToCharA" (ByVal lpszSrc As String, ByVal lpszDst As String) As Integer
    Public Declare Function CharToOem Lib "user32" Alias "CharToOemA" (ByVal lpszSrc As String, ByVal lpszDst As String) As Integer




    '-- ====================================================================================
    '-- Räknar antalet rader i filen som anges i sökvägen [sFile].
    '-- Om sökvägen är felaktig returneras -1.
    '-- ====================================================================================
    Public Function RecordCount(sFile As String) As Integer
        Dim lsDummy As String
        Dim llAntal As Integer
        Dim llFnr As Integer
        Dim s As String

        Try
            '-- Hämtar vilket filnummer samt filnamn
            llFnr = FreeFile()
            FileOpen(llFnr, sFile, OpenMode.Input)

            '-- Loopar igenom filen och räknar raderna.
            Do While Not EOF(llFnr)
                lsDummy = LineInput(llFnr)
                llAntal = llAntal + 1
            Loop

            '-- Stänger filen
            FileClose(llFnr)

            RecordCount = llAntal

        Catch ex As Exception

            If ex.HResult = 53 Or ex.HResult() = 76 Then
                RecordCount = -1
            Else
                s = "Fel vid räkning av antalet poster."
                s = s & vbCrLf
                s = s & "Felkoden är:" & ex.Message
                MsgBox(s, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                RecordCount = -1
            End If
        End Try

    End Function


    '-- ====================================================================================
    '-- Lägger till "\" i slutet av strängen [sPath] om det inte redan finns.
    '-- ====================================================================================
    Function FixDirStr(sPath As String) As String
        Dim sTemp As String

        sTemp = sPath

        If Right$(sTemp, 1) <> "\" Then
            FixDirStr = sTemp & "\"
        Else
            FixDirStr = sTemp
        End If

    End Function


    '-- ====================================================================================
    '-- Returnerar TRUE om katalogen [sPath] finns
    '-- ====================================================================================
    Public Function DirExist(sPath As String) As Boolean
        Dim lsTmp As String

        If Len(Trim(sPath)) = 0 Then
            DirExist = False
            Exit Function
        End If

        lsTmp = Dir(sPath, vbDirectory)
        If Len(lsTmp) <> 0 Then
            DirExist = True
        Else
            DirExist = False
        End If

    End Function


    '-- ====================================================================================
    '-- Returnerar TRUE om filen [sFile] finns
    '-- ====================================================================================
    Public Function FileExists(sFile As String) As Boolean
        Dim lsTmp As String

        If Len(Trim(sFile)) = 0 Then
            FileExists = False
            Exit Function
        End If

        lsTmp = Dir(sFile)
        If Len(lsTmp) <> 0 Then
            FileExists = True
        Else
            FileExists = False
        End If

    End Function


    Public Sub GetSaveWindowsPreferences(sGetSave As String,
                                    ByRef frm As Form,
                                    Optional sKeypart2 As String = "",
                                    Optional lFrmTag As Integer = 0,
                                    Optional lGridTag As Integer = 0)
        '**************************************************************
        ' PRIVATE SUB GetSaveUserPreferences:  This uses GetSetting
        ' to get user preferences from the Windows Registry. It also
        ' uses SaveSetting to save user preferences to the Windows
        ' Registry.
        ' Parameters:
        '   sGetSave    Set to "Save" is keys is to be saved.
        '   frm         The form which should have the keys

        '               The three parameters below Is used by the generell windows for grids and preview
        '   sKeyPart2   In this sub the same form can be used by differents routines
        '               and hence the fmr is the same. This parameter helps with that problem
        '   lFrmTag     Is used by the translation
        '   lGridTag    Is used by the translation
        '**************************************************************
        Dim s As String
        Dim sOrg As String
        Dim ctl As Control
        Dim sCtlType As String

        On Error Resume Next
        If frm Is Nothing Then
            Exit Sub
        End If

        '----------------------------------------------------------
        ' Save:  If saving the preferences, save them and then
        ' exit the subroutine.
        '----------------------------------------------------------
        s = APP_NAME & "\" & frm.Name
        If sKeypart2 <> "" Then
            s = s & "\" & sKeypart2
        End If
        s = s & "\" & WINDOW_POS_KEY & "\"
        If sGetSave = "Save" Then
            If frm.WindowState = FormWindowState.Minimized Then
            ElseIf frm.WindowState = FormWindowState.Maximized Then
                oWshShell.RegWrite(s & "Maximized", "1")
            Else
                oWshShell.RegWrite(s & "Maximized", "0")
                oWshShell.RegWrite(s & "Left", frm.Left)
                oWshShell.RegWrite(s & "Top", frm.Top)
                oWshShell.RegWrite(s & "Width", frm.Width)
                oWshShell.RegWrite(s & "Height", frm.Height)
            End If

            'Saves all frames too
            sOrg = s
            For Each ctl In frm.Controls
                sCtlType = TypeName(ctl)
                If sCtlType = "Frame" Then
                    s = sOrg & ctl.Name & "\" & FRAME_POS_KEY & "\"
                    oWshShell.RegWrite(s & "Left", ctl.Left)
                    oWshShell.RegWrite(s & "Top", ctl.Top)
                    oWshShell.RegWrite(s & "Width", ctl.Width)
                    oWshShell.RegWrite(s & "Height", ctl.Height)
                End If
            Next ctl

            On Error GoTo 0
            Exit Sub
        End If

        '----------------------------------------------------------
        ' Get:  If no coordinates were saved, center the screen;
        ' otherwise, get the last window position.
        '----------------------------------------------------------
        If oWshShell.RegRead(s & "Maximized") = String.Empty Then
        Else
            If oWshShell.RegRead(s & "Maximized") = "1" Then
                frm.WindowState = FormWindowState.Maximized
            End If
        End If

        If IsNothing(oWshShell.RegRead(s & "Left")) Then

            '        Move (Screen.Width - frm.Width) / 2, _
            '            (Screen.Height - frm.Height) / 2
            '        If frm.WindowState = vbMinimized Then
            '        ElseIf frm.WindowState = FormWindowState.Maximized Then
            '            oWshShell.RegWrite s & "Maximized", "1"
            '        Else

        Else
            If frm.WindowState <> FormWindowState.Maximized Then
                frm.Left = oWshShell.RegRead(s & "Left")
                frm.Top = oWshShell.RegRead(s & "Top")
                frm.Width = oWshShell.RegRead(s & "Width")
                frm.Height = oWshShell.RegRead(s & "Height")
            End If

            'Set all frames too
            sOrg = s
            For Each ctl In frm.Controls
                sCtlType = TypeName(ctl)
                If sCtlType = "Frame" Then
                    If False Then            'OBS********* neutrilized
                        s = sOrg & ctl.Name & "\" & FRAME_POS_KEY & "\"
                        ctl.Left = oWshShell.RegRead(s & "Left")
                        ctl.Top = oWshShell.RegRead(s & "Top")
                        ctl.Width = oWshShell.RegRead(s & "Width")
                        ctl.Height = oWshShell.RegRead(s & "Height")
                    End If
                    'Take some anyway
                    If UCase(ctl.Name) = UCase("framedraw") Then
                        s = sOrg & ctl.Name & "\" & FRAME_POS_KEY & "\"
                        ctl.Left = oWshShell.RegRead(s & "Left")
                    End If
                End If
            Next ctl

        End If

        '    translateForm frm, lFrmTag, lGridTag
        On Error GoTo 0

    End Sub


    Public Function sortCollection(c As Collection, col As Integer, Optional descending As Boolean = False, Optional numeric As Boolean = False) As Collection

        Dim ar() As Object, l As Integer, ret As Collection

        Try
            If c Is Nothing Then Return Nothing
            If c.Count = 0 Then
                sortCollection = New Collection
                Return sortCollection
            End If
            ReDim ar(0 To c.Count)
            For l = 1 To c.Count
                ar(l) = c(l)
            Next l
            Call quickSort(ar, 1, c.Count, col, numeric)
            ret = New Collection
            If descending Then
                For l = c.Count To 1 Step -1
                    Call ret.Add(ar(l))
                    ar(l).Index = ret.Count
                Next l
            Else
                For l = 1 To c.Count
                    Call ret.Add(ar(l))
                    ar(l).Index = ret.Count
                Next l
            End If
            sortCollection = ret
            Return sortCollection

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Sub quickSort(ByRef ar() As Object, l As Integer, r As Integer, col As Integer, Optional numeric As Boolean = False)

        Dim i As Integer, J As Integer, p As Object, o As Object, ret As Boolean

        i = l
        J = r
        p = ar(Int(((l + r) / 2) + 0.5))

        If numeric Then
            On Error GoTo numErr
            Do
                Do While Val(ar(i).getColDataString(col)) < Val(p.getColDataString(col))
                    i = i + 1
                Loop
                Do While Val(ar(J).getColDataString(col)) > Val(p.getColDataString(col))
                    J = J - 1
                Loop
                If i <= J Then
                    o = ar(i)
                    ar(i) = ar(J)
                    ar(J) = o
                    i = i + 1
                    J = J - 1
                End If
            Loop While i <= J
            On Error GoTo 0
            If False Then
numErr:     'Call localSysLog("Sorting error. Numeric values expected.", logError)
                Resume abortSort
            End If
        Else
            Do
                Do While StrComp(ar(i).getColDataString(col), p.getColDataString(col), vbTextCompare) = -1
                    i = i + 1
                Loop
                Do While StrComp(ar(J).getColDataString(col), p.getColDataString(col), vbTextCompare) = 1
                    J = J - 1
                Loop
                If i <= J Then
                    o = ar(i)
                    ar(i) = ar(J)
                    ar(J) = o
                    i = i + 1
                    J = J - 1
                End If
            Loop While i <= J
        End If

        If (l < J) Then Call quickSort(ar, l, J, col, numeric)
        If (i < r) Then Call quickSort(ar, i, r, col, numeric)
abortSort:

    End Sub
    Public Function GetValue(ByRef inValue As String, Optional ByRef isNumeric As Boolean = False) As String
        Dim returnValue As String = String.Empty
        Try
            If String.IsNullOrEmpty(inValue) Then
                If isNumeric = True Then
                    returnValue = CStr(0)
                Else
                    returnValue = String.Empty
                End If
            ElseIf String.IsNullOrEmpty(inValue) Then
                If isNumeric = True Then
                    returnValue = CStr(0)
                Else
                    returnValue = String.Empty
                End If
            Else
                inValue = inValue.Replace(",", ".")

                If (isNumeric = True And Information.IsNumeric(inValue) = False) Then
                    returnValue = CStr(0)
                Else
                    If isNumeric = True Then
                        Dim resultTwo As Double
                        Double.TryParse(inValue, resultTwo)
                        returnValue = CStr(resultTwo)
                    Else
                        returnValue = inValue.Trim()
                    End If
                End If
            End If

            Return returnValue
        Catch ex As Exception
            Return returnValue
        End Try
    End Function

    '--->2013-01-23, konverterar till en Vilma2-mall
    Public Sub convertMall(sLevFile As String)

        Dim s As String
        Dim c As Collection

        On Error GoTo EH
        If Trim(sLevFile) = "" Then
            GoTo EH
        End If
        sLevFile = FixDirStr(APP_DIR_MALL) & sLevFile

        c = New Collection

        'läs in och skapa en collection för fältnamn + ny rad
        If setVilma2Collection(c) = False Then
            GoTo EH
        End If

        'läs in och uppdatera collection med gammal rad
        If setVilma1InCollection(c) = False Then
            GoTo EH
        End If

        'läs in och uppdatera collection med mallposten
        If setMallInCollection(c, sLevFile) = False Then
            GoTo EH
        End If

        'Läs collection i ny-rad ordning och skriv ner mallposterna
        If writeMallCollection(c, sLevFile) = False Then
            GoTo EH
        End If

EH:
        If Err.Number <> 0 Then
            s = "Felmeddelande när mallen ska konverteras till ny mall"
            s = s & vbCrLf
            s = s & "Felnummer: " & Err.Number
            s = s & vbCrLf
            s = s & "Meddelande: " & Err.Description
        End If

        On Error GoTo 0

    End Sub

    Private Function setVilma2Collection(ByRef c As Collection) As Boolean

        Dim sIniFile As String
        Dim Fnr As Integer
        Dim lRad As Integer
        Dim sBuffer As String
        Dim cString As New clsString
        Dim sTemp As String
        Dim o As clsNewRecord

        setVilma2Collection = False
        On Error GoTo EH

        sIniFile = FixDirStr(Application.StartupPath) & INI_FILE_EXTERN_VILMA2

        '-- Kontroll att inifil existerar.
        If Not FileExists(sIniFile) Then
            MsgBox("Filen '" & sIniFile & "' finns inte.", vbInformation, APPNAME)
            Exit Function
        End If

        lRad = 0
        Fnr = FreeFile()
        FileOpen(Fnr, sIniFile, OpenMode.Input)
        Do Until EOF(Fnr)
            sBuffer = LineInput(Fnr)
            cString.ResetValue()
            cString.StringData = sBuffer
            sTemp = cString.FindNextPipe
            If sTemp = "1" Then 'en rad som ska behandlas i mallar
                lRad = lRad + 1
                sTemp = cString.FindNextPipe

                o = New clsNewRecord
                o.NewLine = lRad
                o.FieldName = cString.FindNextPipe

                'Skapa samtliga rader i Vilma2 till collection som ska skrivas till den nya mallen.
                'Radnummer blir det nya fältnumret som ska synkas med det gamla radnumret, se i setVilma1InCollection
                c.Add(o, CStr(lRad))
            End If
        Loop

        setVilma2Collection = True

EH:
        FileClose(Fnr)
        On Error GoTo 0

    End Function

    Private Function setVilma1InCollection(ByRef c As Collection) As Boolean

        Dim sIniFile As String
        Dim Fnr As Integer
        Dim lRad As Integer
        Dim sBuffer As String
        Dim cString As New clsString
        Dim sTemp As String
        Dim sSaknas As String
        Dim o As clsNewRecord
        Dim bFound As Boolean

        setVilma1InCollection = False
        On Error GoTo EH

        sIniFile = FixDirStr(Application.StartupPath) & INI_FILE_EXTERN_VILMA1

        '-- Kontroll att inifil existerar.
        If Not FileExists(sIniFile) Then
            MsgBox("Filen '" & sIniFile & "' finns inte.", vbInformation, APPNAME)
            Exit Function
        End If

        lRad = 0
        sSaknas = ""
        Fnr = FreeFile()
        FileOpen(Fnr, sIniFile, OpenMode.Input)
        Do Until EOF(Fnr)
            sBuffer = LineInput(Fnr)
            cString.ResetValue()
            cString.StringData = sBuffer
            sTemp = cString.FindNextPipe
            If sTemp = "1" Then 'en rad som ska behandlas i mallar
                lRad = lRad + 1
                sTemp = cString.FindNextPipe
                sTemp = cString.FindNextPipe  'Fieldname

                'Leta upp fältet och uppdatera med gammalt radnummer
                bFound = False
                For Each o In c
                    If o.FieldName = sTemp Then
                        o.OldLine = lRad
                        bFound = True
                        Exit For
                    End If
                Next o
                If bFound = False Then  'Fältet saknas i Rel10
                    If sSaknas = "" Then
                        sSaknas = "Fält som saknas och som måste läggas in manuellt igen:"
                    End If
                    sSaknas = sSaknas & vbCrLf
                    sSaknas = sSaknas & sTemp
                End If
            End If

        Loop

        If Trim(sSaknas) <> "" Then
            'MsgBox sSaknas, vbInformation
        End If

        setVilma1InCollection = True

EH:
        FileClose(Fnr)
        On Error GoTo 0

    End Function

    Private Function setMallInCollection(ByRef c As Collection, sFileName As String) As Boolean

        Dim Fnr As Integer
        Dim lRad As Integer
        Dim sBuffer As String
        Dim cString As New clsString
        Dim sTemp As String
        Dim o As clsNewRecord

        setMallInCollection = False
        On Error GoTo EH

        '-- Kontroll att inifil existerar.
        If Not FileExists(sFileName) Then
            MsgBox("Filen '" & sFileName & "' finns inte.", vbInformation, APPNAME)
            Exit Function
        End If

        lRad = -1
        Fnr = FreeFile()
        FileOpen(Fnr, sFileName, OpenMode.Input)
        Do Until EOF(Fnr)
            lRad = lRad + 1
            sBuffer = LineInput(Fnr)
            If lRad = 0 Then 'Rubrikraden, som ligger först i mallfilen
                o = New clsNewRecord
                o.NewLine = 0
                o.MallLine = sBuffer
                c.Add(o, CStr(lRad))
            Else
                'Leta upp gammalt radnummer och uppdatera med mallposten
                For Each o In c
                    If o.OldLine = lRad Then
                        o.MallLine = sBuffer
                        Exit For
                    End If
                Next o
            End If

        Loop

        setMallInCollection = True

EH:
        FileClose(Fnr)
        On Error GoTo 0

    End Function

    Private Function writeMallCollection(ByRef c As Collection, sFileName As String) As Boolean

        Dim Fnr As Integer
        Dim lRad As Integer
        Dim sBuffer As String
        Dim cString As New clsString
        Dim sTemp As String
        Dim o As clsNewRecord

        writeMallCollection = False
        On Error GoTo EH

        '-- Byt namn på den
        'sFileName = sFileName & "_R10.lev"

        lRad = 0
        Fnr = FreeFile()
        FileOpen(Fnr, sFileName, OpenMode.Output)

        For lRad = 0 To c.Count - 1
            o = c.Item(CStr(lRad))
            If Not o Is Nothing Then
                PrintLine(Fnr, o.MallLine)
            End If
        Next lRad

        writeMallCollection = True

EH:
        If Err.Number = 5 Then 'raden saknas som nycket i collection då raden inte ska finnas i mallar
            o = Nothing
            Resume Next
        End If
        FileClose(Fnr)
        On Error GoTo 0

    End Function
    '---<2013-01-23

    '--->2013-03-07
    Public Function fCheckInteger(ByVal intAscii As Integer, Optional blnSigned As Boolean = False) As Integer
        On Error GoTo EH

        Select Case intAscii
            Case Asc("0") To Asc("9")
                fCheckInteger = intAscii
            Case Asc("-")
                If blnSigned Then
                    fCheckInteger = intAscii
                Else
                    Beep()
                    fCheckInteger = 0
                End If
            Case Else
                Beep()
                fCheckInteger = 0
        End Select

EH:
        On Error GoTo 0

    End Function
    '--->2013-03-07


End Module
