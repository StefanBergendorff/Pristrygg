Imports System.ComponentModel

Public Class FrmAllHelp
    Private Sub FrmAllHelp_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        GetSaveWindowsPreferences("Save", Me)

    End Sub

    Private Sub FrmAllHelp_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim sHelp As String
        Dim sLine As String
        Dim sInfil As String
        Dim FnrIn As Integer

        Try

            sHelp = ""
            GetSaveWindowsPreferences("Get", Me)

            FnrIn = FreeFile()
            sInfil = FixDirStr(Application.StartupPath) & "help.txt"
            FileOpen(FnrIn, sInfil, OpenMode.Input)
            '-- Läs hjälpfilen
            Do Until EOF(FnrIn)
                sLine = LineInput(FnrIn)
                sHelp = sHelp & sLine & vbCrLf
            Loop
            FileClose(FnrIn)
            txtHelp.Text = sHelp
            txtHelp.SelectionStart = 0

        Catch ex As Exception
            txtHelp.Text = ""
        End Try

    End Sub
End Class
