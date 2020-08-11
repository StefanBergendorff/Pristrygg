Imports System.ComponentModel
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class FrmVerifyInfile

    Private lastRownum As Integer

    Private Sub FrmVerifyInfile_Load(sender As Object, e As EventArgs) Handles Me.Load

        initiateData()
        InitializeGrid()
        hideColumns()
        addData()
        If grdVerify.Rows.Count > 1 Then
            grdVerify.CurrentRow = grdVerify.Rows(0)
        End If

        'getWindowPlace()
        GetSaveWindowsPreferences("Get", Me)

    End Sub

    Private Sub FrmVerifyInfile_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        'Sätter plats och storlek på fönstret
        GetSaveWindowsPreferences("Save", Me)

    End Sub

    Private Sub chlAllColumns_ToggleStateChanged(sender As Object, args As StateChangedEventArgs) Handles chlAllColumns.ToggleStateChanged

        hideColumns()

    End Sub

    Private Sub txtNewRecords_TextChanged(sender As Object, e As EventArgs) Handles txtNewRecords.TextChanged

        Dim args = TryCast(e, TextChangingEventArgs)
        Dim i As Integer

        Try
            If args Is Nothing Then
                Exit Sub
            End If
            args.Cancel = String.IsNullOrEmpty(args.NewValue)
            If args.Cancel = False Then
                i = CInt(args.NewValue)
            End If

        Catch ex As Exception
            args.Cancel = True
        End Try

        If args.Cancel = True Then
            MsgBox("Fyll i ett heltal för antalet poster som ska hämtas!")
        End If

    End Sub

    Private Sub cmdCreateRecords_Click(sender As Object, e As EventArgs) Handles cmdCreateRecords.Click

        waitingAddData.StartWaiting()
        waitingAddData.Top = Math.Abs(grdVerify.Top + grdVerify.Height / 5)
        waitingAddData.Left = Math.Abs(grdVerify.Left + grdVerify.Width / 4)
        waitingAddData.WaitingSpeed = 95
        'waitingAddData.WaitingStyle = Enumerations.WaitingBarStyles.RotatingRings
        waitingAddData.Visible = True
        waitingAddData.BringToFront()
        Application.DoEvents()

        addData()

        waitingAddData.Visible = False
        waitingAddData.StopWaiting()

    End Sub

    Private Sub initiateData()

        chlAllColumns.Checked = False
        txtNewRecords.Text = "10"
        lastRownum = 0
        waitingAddData.Visible = False
        'waitingAddData.ShowText = True
        'waitingAddData.Text = "Läser..."

    End Sub
    Private Sub InitializeGrid()

        Try
            grdVerify.ShowGroupPanel = False
            grdVerify.EnableGrouping = False
            grdVerify.AllowAddNewRow = False
            grdVerify.AllowColumnReorder = True
            grdVerify.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.None
            'grdVerify.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill
            grdVerify.ShowFilteringRow = True
            grdVerify.EnableFiltering = True
            grdVerify.MasterTemplate.ShowFilterCellOperatorText = False
            grdVerify.EnterKeyMode = RadGridViewEnterKeyMode.EnterMovesToNextRow

            AppendNewColumns()

        Catch ex As Exception
            '

        End Try

    End Sub

    Private Sub AppendNewColumns()

        Dim newColumn As GridViewDataColumn = Nothing
        Dim i As Integer

        Try

            For i = 1 To cLev.NumberOfPosts
                newColumn = New GridViewTextBoxColumn()
                newColumn.FieldName = cLev.Post(i).FINFO_Description
                newColumn.ReadOnly = True
                newColumn.HeaderText = cLev.Post(i).FINFO_Description
                If cLev.Post(i).FINFO_DataFormat = "Tal" Then
                    newColumn.HeaderTextAlignment = ContentAlignment.MiddleRight
                    newColumn.TextAlignment = ContentAlignment.MiddleRight
                Else
                    If cLev.Post(i).FINFO_Length < 7 Then
                        newColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter
                        newColumn.TextAlignment = ContentAlignment.MiddleCenter
                    Else
                        newColumn.HeaderTextAlignment = ContentAlignment.MiddleLeft
                        newColumn.TextAlignment = ContentAlignment.MiddleLeft
                    End If
                End If
                newColumn.AutoSizeMode = BestFitColumnMode.AllCells
                newColumn.AllowFiltering = True
                grdVerify.Columns.Add(newColumn)
            Next

        Catch ex As Exception
            '

        End Try

    End Sub

    Private Sub addData()

        Dim fnr As Integer
        Dim i As Integer
        Dim j As Integer
        Dim lRowNo As Integer
        Dim lRowNo2 As Integer
        Dim lRowNoStart As Integer
        Dim sRecord As String
        Dim sRecord2 As String
        Dim sValue As String
        Dim rowInfo As GridViewRowInfo

        Try
            fnr = FreeFile()
            FileOpen(fnr, Me.Tag, OpenMode.Input)
            lRowNo = 0
            lRowNo2 = 0
            lRowNoStart = lastRownum

            Do Until EOF(fnr)
                lRowNo += 1
                sRecord2 = LineInput(fnr)
                'Check if some records are already read
                If lastRownum > 0 And lastRownum >= lRowNo Then
                    'just read next record
                Else
                    lRowNo2 += 1
                    sRecord = Space(Len(sRecord2))
                    i = OemToChar(sRecord2, sRecord)
                    rowInfo = grdVerify.Rows.AddNew()
                    For j = 1 To cLev.NumberOfPosts
                        If grdVerify.Columns(j - 1).IsVisible = True Then
                            sValue = Trim(Mid(sRecord, cLev.Post(j).FINFO_StartPos, cLev.Post(j).FINFO_Length))
                            rowInfo.Cells(j - 1).Value = sValue
                        End If
                    Next
                    If lRowNo2 = CInt(txtNewRecords.Text) Then
                        lastRownum = lRowNo
                        If grdVerify.Rows.Count > 1 Then
                            grdVerify.CurrentRow = grdVerify.Rows(lRowNoStart)
                        End If
                        Exit Try
                    End If
                End If
                Application.DoEvents()
            Loop

            'If the eof is met before the coounter is reached
            If lRowNo2 <> CInt(txtNewRecords.Text) Then
                lastRownum = lRowNo
                grpboxRecords.Visible = False
            End If
            If grdVerify.Rows.Count > 1 And lRowNoStart < grdVerify.Rows.Count Then
                grdVerify.CurrentRow = grdVerify.Rows(lRowNoStart)
            End If


        Catch ex As Exception
            MsgBox("Fel när data hämtas. Felet är " & ex.Message)
        End Try

        FileClose(fnr)

    End Sub

    Private Sub hideColumns()
        'Make an array with columns indexes. Set only columns to visible that contains some data

        Dim fnr As Integer
        Dim i As Integer
        Dim j As Integer
        Dim columns() As Integer
        Dim sRecord As String
        Dim sValue As String
        Dim sSign As String

        Try
            ReDim columns(0 To cLev.NumberOfPosts)
            'Set all columns to not visible. 0 = hidden, 1 = visible
            If chlAllColumns.CheckState = CheckState.Checked = True Then
                'Set all columns to visible when checkobos says so. 0 = hidden, 1 = visible
                For i = 0 To cLev.NumberOfPosts - 1
                    grdVerify.Columns(i).IsVisible = True
                Next
                Exit Try
            Else
                'Set all columns to not visible. 0 = hidden, 1 = visible
                j = 0
            End If

            For i = 1 To cLev.NumberOfPosts
                columns(i) = j
            Next

            fnr = FreeFile()
            FileOpen(fnr, Me.Tag, OpenMode.Input)

            Do Until EOF(fnr)
                sRecord = LineInput(fnr)
                For j = 1 To cLev.NumberOfPosts
                    If cLev.FileFormat Is Nothing Then    'Finfofil, ingen extern fil
                        sValue = Trim(Mid(sRecord, cLev.Post(j).FINFO_StartPos, cLev.Post(j).FINFO_Length))
                        If cLev.Post(j).FINFO_DataFormat = "Text" Then
                            If sValue <> "" Then
                                'Set column to be visible
                                columns(j) = 1
                            End If
                        Else
                            If sValue <> StrDup(cLev.Post(j).FINFO_Length, "0") And sValue <> "" Then
                                'Set column to be visible
                                columns(j) = 1
                            End If
                        End If
                    Else
                        sValue = Trim(Mid(sRecord, cLev.Post(j).FINFO_StartPos, cLev.Post(j).FINFO_Length))
                        If cLev.Post(j).FINFO_DataFormat = "Text" Then
                            sSign = "X"
                        Else
                            sSign = "9"
                        End If
                        If sValue <> StrDup(cLev.Post(j).FINFO_Length, sSign) Then
                            'Set column to be visible
                            columns(j) = 1
                        End If
                    End If
                Next
            Loop

            FileClose(fnr)

            'Set all columns with no real data to not visible. 0 = hidden, 1 = visible
            For i = 1 To cLev.NumberOfPosts
                If columns(i) = 0 Then
                    grdVerify.Columns(i - 1).IsVisible = False
                Else
                    grdVerify.Columns(i - 1).IsVisible = True
                End If
            Next

        Catch ex As Exception

        End Try

    End Sub
End Class
