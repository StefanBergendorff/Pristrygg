Imports System.ComponentModel

Public Class FrmHelp

    Private meLAntalDecimaler As Integer

    Public Property lAntalDecimaler As Integer
        Get
            lAntalDecimaler = meLAntalDecimaler
        End Get
        Set(value As Integer)
            meLAntalDecimaler = value
        End Set
    End Property

    Private Sub FrmHelp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim s As String

        GetSaveWindowsPreferences("Get", Me)

        s = "Om det förekommer decimaltecken i talet (punkt, eller komma-tecken) ska [-1] anges." & vbCrLf
        s = s & "[-1] ska även anges om talet inte innehåller några decimaler i leverantörsfilen." & vbCrLf
        s = s & "Tex om ett pris anges i hela kronor ska [-1] anges." & vbCrLf & vbCrLf
        s = s & "[1] Anges om talet är angivet med decimaler men utan decimaltecken. (det korrekta formatet.)" & vbCrLf
        If lAntalDecimaler = 2 Then
            s = s & "Tex om priset 15 kronor och 75 öre är angivet som 1575 i leverantörsfilen." & vbCrLf & vbCrLf
        ElseIf lAntalDecimaler = 3 Then
            s = s & "Tex om priset 15 kronor och 75 öre är angivet som 15750 i leverantörsfilen." & vbCrLf & vbCrLf
        ElseIf lAntalDecimaler = 1 Then
            s = s & "Tex om antalet 15,1 stycken är angivet som 151 i leverantörsfilen." & vbCrLf & vbCrLf
        ElseIf lAntalDecimaler = 5 Then
            s = s & "Tex om faktorn 15,12345 är angivet som 1512345 i leverantörsfilen." & vbCrLf & vbCrLf
        Else
            s = s & "Tex om priset 15 kronor och 75 öre är angivet som 1575 i leverantörsfilen." & vbCrLf & vbCrLf
        End If
        s = s & "Värden större än 0 anges om talet behöver divideras för att få rätt format." & vbCrLf
        If lAntalDecimaler = 2 Then
            s = s & "Om priset 15,75 har angivits som 15750 ska 10 anges för att få det rätta värdet 1575." & vbCrLf & vbCrLf
        ElseIf lAntalDecimaler = 3 Then
            s = s & "Om priset 15,752 har angivits som 157520 ska 10 anges för att få det rätta värdet 15752." & vbCrLf & vbCrLf
        ElseIf lAntalDecimaler = 1 Then
            s = s & "Om antalet 15,1 stycken är angivet som 1510 ska 10 anges för att få det rätta värdet 151." & vbCrLf & vbCrLf
        ElseIf lAntalDecimaler = 5 Then
            s = s & "Tex om faktorn 15,12345 är angivet som 15123450 ska 10 anges för att få det rätta värdet 1512345" & vbCrLf & vbCrLf
        Else
            s = s & "Om priset 15,75 har angivits som 15750 ska 10 anges för att få det rätta värdet 1575." & vbCrLf & vbCrLf
        End If

        s = s & "Tillåtna omräkningstal är: -1 0,001 0,01 0,1 1 10 100 1000"

        lblHelp.Text = s

    End Sub

    Private Sub FrmHelp_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        GetSaveWindowsPreferences("Save", Me)

    End Sub
End Class
