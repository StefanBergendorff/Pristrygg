Imports System.ComponentModel
Imports Telerik.WinControls.UI

Public Class FrmSupplierTemplate

    Private bExcel As Boolean
    Private Counter As Long
    Private lastRowIndex As Long
    Private lCounterSaved As Long
    Private cExcel As New clsExcelColumns
    Private isNotLoading As Boolean
    Private bErrorPending As Boolean

    Private Enum grdFieldsColumns
        fieldname = 0
        description
        mandatory
        comment
        type
        length
        active
        chosenValue
        divider
        originalIndex
    End Enum

    Private Sub cmbFilTyp_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbFilTyp.SelectedIndexChanged

        If cmbFilTyp.Text = FILE_EXCEL_ANSI Or cmbFilTyp.Text = FILE_EXCEL_DOS Then
            bExcel = True
        Else
            bExcel = False
        End If

        If cmbFilTyp.Text = FILE_CSV Then 'Semikolon
            cLev.FileFormat = cmbFilTyp.Text
        End If
        cLev.FileFormat = cmbFilTyp.Text

        Select Case cmbFilTyp.Text
            Case FILE_EXCEL_ANSI, FILE_EXCEL_DOS
                lblPostLen.Visible = False
                txtPostLen.Visible = False
                lblStartPos.Text = "Kolumn (A - FX):"
            Case FILE_CSV
                lblPostLen.Visible = False
                txtPostLen.Visible = False
                lblStartPos.Text = "Fältnummer:"
            Case FILE_ANSI, FILE_DOS
                lblPostLen.Visible = True
                lblPostLen.Text = "Postlängd :"
                txtPostLen.Visible = True
                lblStartPos.Text = "Startposition :"
        End Select

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click

        Dim oFrm As New FrmHelp

        oFrm.lAntalDecimaler = cLev.Post(MALL_POST(Counter)).FINFO_Decimals
        oFrm.Show()

        oFrm = Nothing

    End Sub

    Private Sub FrmSupplierTemplate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim i As Integer

        If Len(Me.Tag) <> 0 Then

            InitExcelArray()

            cmbFilTyp.Items.Add(FILE_ANSI)
            cmbFilTyp.Items.Add(FILE_DOS)
            cmbFilTyp.Items.Add(FILE_EXCEL_ANSI)
            'cmbFilTyp.Items.Add(FILE_EXCEL_DOS)
            cmbFilTyp.Items.Add(FILE_CSV)


            '-- Ny leverantör, sätt defaultvärden.
            If Me.Tag = "NEWLEV" Then
                cmbFilTyp.SelectedItem = cmbFilTyp.Items(2)
                cmbFilTyp.SelectedIndex = 2
                cmbFilTyp.Text = cmbFilTyp.Items(2).Text
                txtHeader.Text = "0"

                '-- Befintlig leverantör, läs från objektet.
            ElseIf Me.Tag = "OLDLEV" Then
                txtLevNamn.Text = cLev.LevNamn
                txtLevNr.Text = cLev.LevNr
                Select Case UCase(cLev.FileFormat)
                    Case FILE_EXCEL_ANSI_OLD
                        cmbFilTyp.Text = FILE_EXCEL_ANSI
                    Case FILE_EXCEL_DOS
                        cmbFilTyp.Text = FILE_EXCEL_ANSI
                    Case FILE_ANSI_OLD, FILE_ANSI_OLD2
                        cmbFilTyp.Text = FILE_ANSI
                    Case FILE_DOS_OLD
                        cmbFilTyp.Text = FILE_DOS
                    Case Else
                        cmbFilTyp.Text = cLev.FileFormat
                End Select

                'Set index in filetype
                For i = 0 To cmbFilTyp.Items.Count - 1
                    If cmbFilTyp.Items(i).Text = cmbFilTyp.Text Then
                        cmbFilTyp.SelectedItem = cmbFilTyp.Items(i)
                        cmbFilTyp.SelectedIndex = i
                        Exit For
                    End If
                Next

                txtHeader.Text = cLev.Header

                If cLev.FileFormat = FILE_EXCEL_ANSI Or cLev.FileFormat = FILE_EXCEL_DOS Then
                    bExcel = True
                Else
                    bExcel = False
                End If

            End If

            Counter = 1
            lastRowIndex = -1
            SetFields()
            InitializeGrid()
            InitListBox()

            'getWindowPlace()
            GetSaveWindowsPreferences("Get", Me)
        End If

        Me.Tag = ""
        Counter = 1
        isNotLoading = True

    End Sub

    Private Sub FrmSupplierTemplate_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        Dim lW As Long
        Dim lH As Long
        Dim dblFactorW As Double
        Dim dblFactorH As Double

        lW = System.Math.Abs(Me.Width - 100)
        lH = System.Math.Abs(Me.Height - 100)
        dblFactorW = 0.95
        dblFactorH = 0.95

        grdFields.Height = System.Math.Abs(fraPost.Height * (dblFactorH))

    End Sub

    Private Sub FrmSupplierTemplate_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        'Sätter plats och storlek på fönstret
        GetSaveWindowsPreferences("Save", Me)
        frmMain.Tag = "LEV"
        frmMain.Show()

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        Dim J As Long
        Dim Fnr As Integer
        Dim lsFileName As String
        Dim bFileOpen As Boolean
        Dim lsMsg As String
        Dim bUpdate As Boolean

        On Error GoTo EH

        bFileOpen = False



        If Len(txtLevNamn.Text) = 0 Then
            MsgBox("Leverantörsnamn saknas.", vbInformation, APPNAME)
            txtLevNamn.Focus()
            Exit Sub
        End If

        If Len(txtLevNr.Text) = 0 Then
            MsgBox("Leverantörsnummer saknas.", vbInformation, APPNAME)
            txtLevNr.Focus()
            Exit Sub
        End If

        If Len(txtLevNr.Text) > 10 Then
            MsgBox("Leverantörsnummer får vara max 10 positioner.", vbInformation, APPNAME)
            txtLevNr.Focus()
            Exit Sub
        End If


        If Len(txtHeader.Text) = 0 Or Not IsNumeric(txtHeader.Text) Then
            MsgBox("'Rubrikrader i filen' ska vara ett värde mellan 0 och 9.", vbInformation, APPNAME)
            txtHeader.Focus()
            Exit Sub
        Else
            If CLng(txtHeader.Text) < 0 Or CLng(txtHeader.Text) > 9 Then
                MsgBox("'Rubrikrader i filen' ska vara ett värde mellan 0 och 9.", vbInformation, APPNAME)
                txtHeader.Focus()
                Exit Sub
            End If
        End If

        '-- Verifiera fält.
        lsMsg = VerifyFields()

        If lsMsg <> "" Then
            MsgBox(lsMsg, vbInformation, APPNAME)
            Exit Sub
        End If

        '-- Spara värden i textfält till klass.
        Call SaveFields()

        '-- Lägger header-information i objekt.
        cLev.LevNamn = txtLevNamn.Text
        cLev.LevNr = txtLevNr.Text
        cLev.FileFormat = cmbFilTyp.Text
        cLev.Header = txtHeader.Text

        '-- Namn på mallfilen.
        lsFileName = FixDirStr(APP_DIR_MALL) & cLev.LevNamn & ".lev"
        bUpdate = False
        If FileExists(lsFileName) Then
            If False Then
                If MsgBox("Leverantören " & cLev.LevNamn & " finns redan upplagd och kommer att uppdateras." & vbCrLf &
                "Vill du fortsätta ?", vbYesNo + vbQuestion, APPNAME) = vbNo Then
                    MsgBox("Ingen data sparad.", vbInformation)
                    Exit Sub
                End If
            End If
            bUpdate = True 'Posten uppdateras
        End If

        Fnr = FreeFile()
        FileOpen(Fnr, lsFileName, OpenMode.Output)
        bFileOpen = True

        '-- Header
        PrintLine(Fnr, cLev.LevNamn & "|" & cLev.LevNr & "|" & cLev.FileFormat & "|" & cLev.Header)

        '-- Går igenom alla poster som är markerade som mall-poster i Finfo.ini
        For J = 1 To cLev.NumberOfTemplatePosts
            PrintLine(Fnr, cLev.Post(MALL_POST(J)).StartPos & "|" & cLev.Post(MALL_POST(J)).Length & "|" & cLev.Post(MALL_POST(J)).Divider)
        Next J

        FileClose(Fnr)

        bFileOpen = False

        If bUpdate = False Then 'Posten har inte uppdaterats
            MsgBox("Leverantörsmall skapad.", vbInformation, APPNAME)
        End If

        Me.Close()

        Exit Sub

EH:
        If bFileOpen Then FileClose(Fnr)
        MsgBox("Ett fel har inträffat." & vbCrLf & "Felbeskrivning :  " & Err.Description, vbInformation, APPNAME)

    End Sub
    '---<2012-03-28

    Private Sub SetFields()
        Dim s As String

        Try
            If cLev.NumberOfTemplatePosts = 0 Then
                MsgBox("Inga fält är markerade i filen " & INI_FILE, vbInformation, APPNAME)
                Me.Close()
                Exit Sub
            End If

            txtPostLen.Text = cLev.Post(MALL_POST(Counter)).Length
            If cLev.Post(MALL_POST(Counter)).Divider <> 0 Then
                txtDivider.Text = cLev.Post(MALL_POST(Counter)).Divider
            End If
            If cLev.Post(MALL_POST(Counter)).FINFO_DataFormat = FORMAT_TEXT Then
                lblPostTyp.Text = cLev.Post(MALL_POST(Counter)).FINFO_DataFormat
                txtDivider.Visible = False
                lblDivider.Visible = False
                cmdHelp.Visible = False
            Else
                '-- Visa antalet decimaler om det är tal.
                lblPostTyp.Text = cLev.Post(MALL_POST(Counter)).FINFO_DataFormat & "  (" & cLev.Post(MALL_POST(Counter)).FINFO_Decimals & " decimaler)"
                txtDivider.Visible = True
                lblDivider.Visible = True
                cmdHelp.Visible = True
            End If

            If bExcel Then
                If cLev.Post(MALL_POST(Counter)).StartPos > 0 Then '/*
                    '        'txtStartPos.Text = Chr(CInt(cLev.Post(MALL_POST(Counter)).StartPos) + 64)
                    txtStartPos.Text = cExcel.ReplaceDigitWithLetter(CInt(cLev.Post(MALL_POST(Counter)).StartPos))
                Else
                    txtStartPos.Text = ""
                End If '*/
                'lblPostLen.Text = ""
                '    txtPostLen.Visible = False
                '    lblStartPos.Text = "Kolumn (A - FX):"
                '    '--->2009-06-01
            ElseIf cLev.FileFormat = FILE_CSV Then 'Semikolon
                If cLev.Post(MALL_POST(Counter)).StartPos > 0 Then
                    txtStartPos.Text = cLev.Post(MALL_POST(Counter)).StartPos
                Else
                    txtStartPos.Text = ""
                End If
                '    lblPostLen.Text = ""
                '    txtPostLen.Visible = False
                '    lblStartPos.Text = "Fältnummer:"
                '    '---<2009-06-01
            Else
                If cLev.Post(MALL_POST(Counter)).StartPos > 0 Then
                    txtStartPos.Text = cLev.Post(MALL_POST(Counter)).StartPos
                Else
                    txtStartPos.Text = ""
                End If
                '    lblPostLen.Text = "Postlängd :"
                '    txtPostLen.Visible = True
                '    lblStartPos.Text = "Startposition :"
            End If

        Catch ex As Exception
            s = "Fel när raden hämtades!"
            s = s & vbCrLf
            s = s & "Felet är " & ex.Message
            MsgBox(s, vbExclamation, APPNAME)

        End Try

    End Sub

    Private Function VerifyFields() As String

        Dim llStartPos As Long
        Dim s As String
        'Const lcLetters As String = "ABCDEFGHIJKLMNOPQRSTUVXYZ"

        Try
            VerifyFields = ""

            If bExcel Then
                '-- Endast verifiera om kolumn är ifylld.
                If txtStartPos.Text <> "" Then
                    '-- Räkna om kolumnbokstav till motsvarande nummer.
                    llStartPos = cExcel.ReplaceLetterWithDigit(UCase(txtStartPos.Text))
                    If llStartPos = 0 Then
                        VerifyFields = "Ej giltig excelkolumn."
                        txtStartPos.Focus()
                        Exit Function
                    End If
                End If
            Else
                If Trim(txtStartPos.Text) = "" Then
                    txtStartPos.Text = 0
                End If
                If Not IsNumeric(txtStartPos.Text) Then
                    VerifyFields = "Kolumn ska vara numerisk."
                    txtStartPos.Focus()
                    Exit Function
                End If
            End If

            If Not bExcel Then
                '--->2009-06-01
                If cLev.FileFormat = FILE_CSV Then 'Semikolon
                    If IsNumeric(txtStartPos.Text) = False Then
                        VerifyFields = "Fältet ska vara numerisk."
                        txtStartPos.Focus()
                        Exit Function
                    End If
                Else
                    If Not IsNumeric(txtPostLen.Text) Then
                        VerifyFields = "Postlängd ska vara numerisk."
                        txtPostLen.Focus()
                        Exit Function
                    End If

                    If CLng(txtPostLen.Text) > cLev.Post(MALL_POST(Counter)).FINFO_Length And CLng(txtStartPos.Text) <> 0 Then
                        VerifyFields = cLev.Post(MALL_POST(Counter)).FINFO_Description & " får ha en postlängd på max " & cLev.Post(MALL_POST(Counter)).FINFO_Length
                        txtPostLen.Focus()
                        Exit Function
                    End If

                    If CLng(txtStartPos.Text) <> 0 And CLng(txtPostLen.Text) = 0 Then
                        VerifyFields = "Postlängd måste anges om startposition är skild från noll."
                        txtPostLen.Focus()
                        Exit Function
                    End If
                End If
            End If

            If txtDivider.Visible Then
                If Trim(txtStartPos.Text) <> "" And
                    Trim(txtStartPos.Text) <> "0" And
                    txtDivider.Text <> "1" And
                    txtDivider.Text <> "10" And
                    txtDivider.Text <> "100" And
                    txtDivider.Text <> "1000" And
                    txtDivider.Text <> "-1" And
                    txtDivider.Text <> "0,1" And
                    txtDivider.Text <> "0,01" And
                    txtDivider.Text <> "0,001" Then
                    'VerifyFields = "Fältet 'Omräkningstal' ska innehålla -1, 1, 10, 100 eller 1000" & vbCrLf
                    VerifyFields = "Omräkningstal felaktigt" & vbCrLf & "Klicka på hjälpknappen vid fältet för mer information."
                    txtDivider.Focus()
                    Exit Function
                End If
            End If

        Catch ex As Exception
            s = "Fel när raden verifierades!"
            s = s & vbCrLf
            s = s & "Felet är " & ex.Message
            MsgBox(s, vbExclamation, APPNAME)
            Return ""
        End Try

    End Function

    Public Sub SaveFields()
        Dim s As String
        Dim i As Integer

        Try
            '-- Spara värden till klass innan nästa post.
            If bExcel Then
                If txtStartPos.Text = "" Or txtStartPos.Text = "0" Then
                    cLev.Post(MALL_POST(Counter)).StartPos = "0"
                    grdFields.Rows(Counter - 1).Cells(grdFieldsColumns.active).Value = ""
                    grdFields.Rows(Counter - 1).Cells(grdFieldsColumns.chosenValue).Value = ""
                    grdFields.Rows(Counter - 1).Cells(grdFieldsColumns.divider).Value = ""
                Else
                    '-- Räkna om kolumnbokstav till motsvarande nummer.
                    cLev.Post(MALL_POST(Counter)).StartPos = cExcel.ReplaceLetterWithDigit(UCase(txtStartPos.Text))
                    grdFields.Rows(Counter - 1).Cells(grdFieldsColumns.active).Value = "Ja"
                    grdFields.Rows(Counter - 1).Cells(grdFieldsColumns.chosenValue).Value = UCase(txtStartPos.Text)
                    grdFields.Rows(Counter - 1).Cells(grdFieldsColumns.divider).Value = txtDivider.Text
                End If

            Else
                If txtStartPos.Text = "" Or txtStartPos.Text = "0" Then
                    cLev.Post(MALL_POST(Counter)).StartPos = "0"
                    grdFields.Rows(Counter - 1).Cells(grdFieldsColumns.active).Value = ""
                    grdFields.Rows(Counter - 1).Cells(grdFieldsColumns.chosenValue).Value = ""
                    grdFields.Rows(Counter - 1).Cells(grdFieldsColumns.divider).Value = ""
                Else
                    cLev.Post(MALL_POST(Counter)).StartPos = GetValue(txtStartPos.Text, True)
                    grdFields.Rows(Counter - 1).Cells(grdFieldsColumns.active).Value = "Ja"
                    If cLev.FileFormat = FILE_CSV Then 'Semikolon
                        grdFields.Rows(Counter - 1).Cells(grdFieldsColumns.chosenValue).Value = txtStartPos.Text
                    Else
                        i = CInt(txtStartPos.Text) + CInt(txtPostLen.Text) - 1
                        grdFields.Rows(Counter - 1).Cells(grdFieldsColumns.chosenValue).Value = GetValue(txtStartPos.Text, True) & " - " & i
                    End If
                    grdFields.Rows(Counter - 1).Cells(grdFieldsColumns.divider).Value = txtDivider.Text
                End If
            End If

            cLev.Post(MALL_POST(Counter)).Length = txtPostLen.Text
            If txtDivider.Text = "" Or txtDivider.Visible = False Then
                cLev.Post(MALL_POST(Counter)).Divider = 0
            Else
                cLev.Post(MALL_POST(Counter)).Divider = txtDivider.Text
            End If

        Catch ex As Exception
            s = "Fel när raden sparades!"
            s = s & vbCrLf
            s = s & "Felet är " & ex.Message
            MsgBox(s, vbExclamation, APPNAME)

        End Try

    End Sub

    Public Sub InitListBox()

        Dim rowInfo As GridViewRowInfo
        Dim j As Long

        Try
            For j = 1 To cLev.NumberOfTemplatePosts
                rowInfo = grdFields.Rows.AddNew()

                rowInfo.Cells(grdFieldsColumns.fieldname).Value = cLev.Post(MALL_POST(j)).FINFO_Name
                rowInfo.Cells(grdFieldsColumns.description).Value = cLev.Post(MALL_POST(j)).FINFO_Description.Substring(0, Len(cLev.Post(MALL_POST(j)).FINFO_Description) - 1)
                If cLev.Post(MALL_POST(j)).FINFO_Description.Substring(Len(cLev.Post(MALL_POST(j)).FINFO_Description) - 1, 1) = "*" Then
                    rowInfo.Cells(grdFieldsColumns.mandatory).Value = "Ja"
                End If
                rowInfo.Cells(grdFieldsColumns.comment).Value = cLev.Post(MALL_POST(j)).Comment
                rowInfo.Cells(grdFieldsColumns.type).Value = cLev.Post(MALL_POST(j)).FINFO_DataFormat
                If cLev.Post(MALL_POST(j)).FINFO_DataFormat = "Tal" Then
                    rowInfo.Cells(grdFieldsColumns.length).Value = cLev.Post(MALL_POST(j)).FINFO_Length & "," & cLev.Post(MALL_POST(j)).FINFO_Decimals
                Else
                    rowInfo.Cells(grdFieldsColumns.length).Value = cLev.Post(MALL_POST(j)).FINFO_Length
                End If
                If cLev.Post(MALL_POST(j)).StartPos <> 0 Then
                    rowInfo.Cells(grdFieldsColumns.active).Value = "Ja"
                    If InStr(UCase(cLev.FileFormat), "EXCEL") > 0 Then
                        rowInfo.Cells(grdFieldsColumns.chosenValue).Value = cExcel.ReplaceDigitWithLetter(cLev.Post(MALL_POST(j)).StartPos)
                    ElseIf cLev.FileFormat = FILE_CSV Then 'Semikolon
                        rowInfo.Cells(grdFieldsColumns.chosenValue).Value = cLev.Post(MALL_POST(j)).StartPos
                    Else
                        rowInfo.Cells(grdFieldsColumns.chosenValue).Value = cLev.Post(MALL_POST(j)).StartPos & " - " & cLev.Post(MALL_POST(j)).StartPos + cLev.Post(MALL_POST(j)).Length - 1
                    End If
                    If cLev.Post(MALL_POST(j)).Divider <> 0 Then
                        rowInfo.Cells(grdFieldsColumns.divider).Value = cLev.Post(MALL_POST(j)).Divider
                    Else
                        rowInfo.Cells(grdFieldsColumns.divider).Value = ""
                    End If
                Else
                    rowInfo.Cells(grdFieldsColumns.active).Value = ""
                    rowInfo.Cells(grdFieldsColumns.chosenValue).Value = ""
                    rowInfo.Cells(grdFieldsColumns.divider).Value = ""
                End If
                rowInfo.Cells(grdFieldsColumns.originalIndex).Value = j
            Next
            If grdFields.Rows.Count > 1 Then
                grdFields.CurrentRow = grdFields.Rows(0)
            End If
            grdFields.Focus()

        Catch ex As Exception
            MsgBox("fel vid laddningen av fält. Felet är" & ex.Message)
        End Try


    End Sub

    Private Sub InitExcelArray()

        cExcel.InitArray()

    End Sub

    'Sätter plats och storlek på fönstret
    Public Sub setWindowPlace()

        GetSaveWindowsPreferences("Get", Me)
        Exit Sub

    End Sub
    Private Sub InitializeGrid()

        Try
            grdFields.ShowGroupPanel = False
            grdFields.EnableGrouping = False
            grdFields.AllowAddNewRow = False
            grdFields.AllowDeleteRow = False
            grdFields.AllowEditRow = False
            grdFields.ClipboardCopyMode = GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
            grdFields.MultiSelect = True
            grdFields.AllowColumnReorder = True
            grdFields.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill
            grdFields.ShowFilteringRow = True
            grdFields.EnableFiltering = True
            grdFields.MasterTemplate.ShowFilterCellOperatorText = False
            grdFields.EnterKeyMode = RadGridViewEnterKeyMode.EnterMovesToNextRow

            AppendNewColumns()

        Catch ex As Exception
            '

        End Try

    End Sub

    Private Sub AppendNewColumns()
        Dim newColumn As GridViewDataColumn = Nothing

        Try

            'Fieldname
            newColumn = New GridViewTextBoxColumn()
            newColumn.FieldName = "fieldname"
            newColumn.ReadOnly = True
            newColumn.TextAlignment = ContentAlignment.MiddleLeft
            newColumn.HeaderText = "Fältnamn"
            newColumn.HeaderTextAlignment = ContentAlignment.MiddleLeft
            newColumn.AutoSizeMode = BestFitColumnMode.AllCells
            newColumn.AllowFiltering = True
            grdFields.Columns.Add(newColumn)

            'Description
            newColumn = New GridViewTextBoxColumn()
            newColumn.FieldName = "description"
            newColumn.ReadOnly = True
            newColumn.TextAlignment = ContentAlignment.MiddleLeft
            newColumn.HeaderText = "Beskrivning"
            newColumn.HeaderTextAlignment = ContentAlignment.MiddleLeft
            newColumn.AutoSizeMode = BestFitColumnMode.AllCells
            grdFields.Columns.Add(newColumn)

            'Mandatory
            newColumn = New GridViewTextBoxColumn()
            newColumn.FieldName = "mandatory"
            newColumn.ReadOnly = True
            newColumn.TextAlignment = ContentAlignment.MiddleCenter
            newColumn.HeaderText = "Bör anges"
            newColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter
            newColumn.AutoSizeMode = BestFitColumnMode.AllCells
            newColumn.IsVisible = False
            grdFields.Columns.Add(newColumn)

            'Comment
            newColumn = New GridViewTextBoxColumn()
            newColumn.FieldName = "comment"
            newColumn.ReadOnly = True
            newColumn.TextAlignment = ContentAlignment.MiddleLeft
            newColumn.HeaderText = "Kommentar"
            newColumn.HeaderTextAlignment = ContentAlignment.MiddleLeft
            newColumn.AutoSizeMode = BestFitColumnMode.AllCells
            grdFields.Columns.Add(newColumn)

            'The type of field
            newColumn = New GridViewTextBoxColumn()
            newColumn.FieldName = "Type"
            newColumn.ReadOnly = True
            newColumn.TextAlignment = ContentAlignment.MiddleCenter
            newColumn.HeaderText = "Typ"
            newColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter
            newColumn.AutoSizeMode = BestFitColumnMode.AllCells
            grdFields.Columns.Add(newColumn)

            'Length of field
            newColumn = New GridViewTextBoxColumn()
            newColumn.FieldName = "length"
            newColumn.ReadOnly = True
            newColumn.TextAlignment = ContentAlignment.MiddleCenter
            newColumn.HeaderText = "Längd"
            newColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter
            newColumn.AutoSizeMode = BestFitColumnMode.AllCells
            grdFields.Columns.Add(newColumn)

            'Field is chosen
            newColumn = New GridViewTextBoxColumn()
            newColumn.FieldName = "active"
            newColumn.ReadOnly = True
            newColumn.TextAlignment = ContentAlignment.MiddleCenter
            newColumn.HeaderText = "Valt fält"
            newColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter
            newColumn.AutoSizeMode = BestFitColumnMode.AllCells
            grdFields.Columns.Add(newColumn)

            'Chosen value
            newColumn = New GridViewTextBoxColumn()
            newColumn.FieldName = "chosenValue"
            newColumn.ReadOnly = True
            newColumn.TextAlignment = ContentAlignment.MiddleCenter
            newColumn.HeaderText = "Valt värde"
            newColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter
            newColumn.AutoSizeMode = BestFitColumnMode.AllCells
            grdFields.Columns.Add(newColumn)

            'Factor for number values
            newColumn = New GridViewTextBoxColumn()
            newColumn.FieldName = "divider"
            newColumn.ReadOnly = True
            newColumn.TextAlignment = ContentAlignment.MiddleCenter
            newColumn.HeaderText = "Omräkning"
            newColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter
            newColumn.AutoSizeMode = BestFitColumnMode.AllCells
            grdFields.Columns.Add(newColumn)

            'Index to find row in table clev
            newColumn = New GridViewTextBoxColumn()
            newColumn.FieldName = "originalIndex"
            newColumn.ReadOnly = True
            newColumn.TextAlignment = ContentAlignment.MiddleCenter
            newColumn.HeaderText = "Original"
            newColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter
            newColumn.AutoSizeMode = BestFitColumnMode.AllCells
            newColumn.IsVisible = False
            grdFields.Columns.Add(newColumn)

        Catch ex As Exception
            '

        End Try

    End Sub

    Private Sub grdFields_RowFormatting(sender As Object, e As RowFormattingEventArgs) Handles grdFields.RowFormatting
        Dim row As GridRowElement = TryCast(e.RowElement, GridRowElement)
        Try
            If row IsNot Nothing Then
                If row.RowInfo.Cells(grdFieldsColumns.active).Value IsNot Nothing Then

                    If row.RowInfo.Cells(grdFieldsColumns.active).Value.ToString() <> "" Then
                        row.DrawFill = True
                        row.BackColor = System.Drawing.Color.AliceBlue '.CornflowerBlue
                        row.GradientStyle = Telerik.WinControls.GradientStyles.Solid
                    Else
                        row.ResetValue(LightVisualElement.DrawFillProperty, Telerik.WinControls.ValueResetFlags.Local)
                        row.ResetValue(LightVisualElement.BackColorProperty, Telerik.WinControls.ValueResetFlags.Local)
                        row.ResetValue(LightVisualElement.GradientStyleProperty, Telerik.WinControls.ValueResetFlags.Local)
                    End If
                End If
            Else
                row.ResetValue(LightVisualElement.DrawFillProperty, Telerik.WinControls.ValueResetFlags.Local)
                row.ResetValue(LightVisualElement.BackColorProperty, Telerik.WinControls.ValueResetFlags.Local)
                row.ResetValue(LightVisualElement.GradientStyleProperty, Telerik.WinControls.ValueResetFlags.Local)
            End If

        Catch ex As Exception
            '
        End Try

    End Sub

    Private Sub grdFields_Click(sender As Object, e As EventArgs) Handles grdFields.Click

        Try
            rowHandle()

        Catch ex As Exception
            '
        End Try

    End Sub

    Private Sub grdFields_CurrentRowChanged(sender As Object, e As CurrentRowChangedEventArgs) Handles grdFields.CurrentRowChanged

        rowHandle()

    End Sub

    Private Sub rowHandle()

        Dim lsMsg As String

        Try
            If isNotLoading = False Then    'Dont do this when window is loading
                Exit Sub
            End If
            If grdFields.CurrentRow Is Nothing Then
                Exit Sub
            End If
            If grdFields.CurrentRow.Cells(grdFieldsColumns.originalIndex).Value Is Nothing Then
                Exit Sub
            End If

            If bErrorPending Or Counter = grdFields.CurrentRow.Cells(grdFieldsColumns.originalIndex).Value Then
                bErrorPending = False
                Exit Sub
            End If

            '-- Verifiera fält.
            lsMsg = VerifyFields()

            If lsMsg <> "" Then
                bErrorPending = True
                MsgBox(lsMsg, vbInformation, APPNAME)
                If lastRowIndex > 0 Then
                    grdFields.CurrentRow = grdFields.Rows(lastRowIndex)
                End If
                Exit Sub
            End If
            bErrorPending = False

            '-- Spara värden till klass innan nästa post.
            Call SaveFields()
            Counter = grdFields.CurrentRow.Cells(grdFieldsColumns.originalIndex).Value
            lastRowIndex = grdFields.CurrentRow.Index
            SetFields()

        Catch ex As Exception
            lsMsg = "Fel när byte av rad gjordes!"
            lsMsg = lsMsg & vbCrLf
            lsMsg = lsMsg & "Felet är " & ex.Message
            MsgBox(lsMsg, vbExclamation, APPNAME)
        End Try

    End Sub
End Class
