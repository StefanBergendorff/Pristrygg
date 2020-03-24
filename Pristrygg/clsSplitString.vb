Public Class clsSplitString
    Private my_count As Long

    Private fields() As String

    Private Sub Class_Initialize()
        my_count = 0
    End Sub

    Public Sub split(thestring As String, sepchar As String)

        Dim pos As Integer
        Dim pos1 As Integer
        Dim found As Boolean
        Dim s As String

        pos = InStr(thestring, sepchar)
        If pos = 0 Then
            If thestring = "" Then
                my_count = 0
            Else
                my_count = 1
                ReDim fields(0 To 1)
                fields(1) = thestring
            End If
        Else
            found = True
            my_count = 0

            If True Then

                pos1 = 1
                s = thestring
                Do While pos > 0
                    my_count = my_count + 1
                    ReDim Preserve fields(0 To my_count)

                    fields(my_count) = Mid(s, 1, pos - 1)
                    s = Mid(s, pos + Len(sepchar), Len(s))
                    pos = InStr(s, sepchar)
                Loop
                If Len(s) > 0 Then
                    my_count = my_count + 1
                    ReDim Preserve fields(0 To my_count)
                    fields(my_count) = s
                End If

            Else
                Do While found
                    my_count = my_count + 1
                    ReDim Preserve fields(0 To my_count)
                    pos1 = pos
                    pos = InStr(pos1 + 1, thestring, sepchar)
                    If pos > pos1 Then
                        fields(my_count) = Mid(thestring, pos1 + 1, pos - pos1 - 1)
                        fields(my_count) = Mid(thestring, pos1 + Len(sepchar), pos - pos1)
                    Else
                        fields(my_count) = Right(thestring, Len(thestring) - pos1)
                        found = False
                    End If
                Loop
            End If
        End If

    End Sub

    Public Function Find(ByVal astring As String, Optional caseSensitive As Boolean = False) As Long
        Dim llop As Integer
        Dim found As Boolean

        Find = 0
        found = False
        If Not caseSensitive Then astring = UCase(astring)

        For llop = 1 To my_count
            If caseSensitive Then
                found = astring = fields(llop)
            Else
                found = astring = UCase(fields(llop))
            End If
            If found Then
                Find = llop
                Exit For
            End If
        Next
    End Function

    Public Property Item(Index As Long) As String
        Get
            If Index >= 1 And Index <= my_count Then
                Item = fields(Index)
            Else
                Item = ""
            End If

        End Get
        Set(value As String)
            If Index >= 1 And Index <= my_count Then
                fields(Index) = value
            End If
            If Index = 0 Then
                my_count = my_count + 1
                ReDim Preserve fields(0 To my_count)
                fields(my_count) = value
            End If

        End Set
    End Property

    Public ReadOnly Property Count() As Long
        Get
            Count = my_count
        End Get

    End Property




End Class
