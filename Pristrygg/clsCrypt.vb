Public Class clsCrypt

    Private Const ERR_TO_LONG = vbObjectError + 600
    Private Const ERR_NOT_NUMERIC = vbObjectError + 601
    Private Const ERR_NO_PASSWORD = vbObjectError + 602


    '-- ====================================================================================
    '-- Krypterar strängen [sPassWord] och returnerar krypterad sträng.
    '-- ====================================================================================
    Public Function Crypt(sPassWord As String) As String
        Dim J As Long
        Dim llLen As Long
        Dim lsTemp As String
        Dim llCountUp As Long

        On Error GoTo EH

        llLen = Len(sPassWord)

        '-- Lösenord max 80 tecken
        If llLen > 80 Then
            'Err.Raise Number:=ERR_TO_LONG,
            ' Description:="Får vara max 80 tecken i strängen som ska krypteras."
        End If

        If llLen = 0 Then
            'Err.Raise Number:=ERR_NO_PASSWORD,
            ' Description:="Lösenord saknas."
        End If

        For J = 1 To llLen
            llCountUp = llCountUp + 7
            lsTemp = lsTemp & Format(CStr(CLng(Asc(Mid$(sPassWord, J, 1)) + llCountUp)), "000")
        Next J

        '-- Returnera krypterat lösenord
        Crypt = lsTemp

        Exit Function

EH:
        'Err.Raise Number:=Err.Number,
        'Source:="clsCrypt.Crypt",
        'Description:=Err.Description

    End Function


    '-- ====================================================================================
    '-- Returnerar sträng i klartext utifrån den krypterade strängen [sPassWord]
    '-- ====================================================================================
    Public Function DeCrypt(sPassWord As String) As String
        Dim J As Long
        Dim lsTemp As String
        Dim llCountUp As Long

        On Error GoTo EH

        '-- Kontroll att det är en numerisk sträng som ska dekrypteras.
        If Not IsNumeric(sPassWord) And Len(sPassWord) <> 0 Then
            'Err.Raise Number:=ERR_NOT_NUMERIC,
            'Description:="Strängen som ska dekrypteras är inte numerisk."
        End If

        For J = 1 To Len(sPassWord) Step 3
            llCountUp = llCountUp + 7
            lsTemp = lsTemp & Chr(CLng(Mid$(sPassWord, J, 3) - llCountUp))
        Next J

        '-- Returnera dekrypterat lösenord
        DeCrypt = lsTemp

        Exit Function

EH:
        'Err.Raise Number:=Err.Number,
        'Source:="clsCrypt.DeCrypt",
        'Description:=Err.Description

    End Function

End Class
