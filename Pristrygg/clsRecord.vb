Public Class clsRecord
    Public Index As Integer

    Private int_cnt As String
    Private int_valid As Boolean
    Public deleteMe As Boolean
    Private dat() As String
    Private count As Integer
    Public MaxColumnCount As Integer

    Public ReadOnly Property valid() As Boolean
        Get
            valid = int_valid
        End Get
    End Property

    Public Property cnt() As String
        Get
            cnt = int_cnt
        End Get
        Set(value As String)
            If Len(Trim(value)) > 0 Then
                int_valid = True
                int_cnt = value
            Else
                int_valid = False
                int_cnt = Trim(value)
            End If

        End Set

    End Property

    Public Function initNew() As Boolean
        initNew = True
    End Function

    Public Function getColDataString(col As Integer) As String
        Dim ret As String
        If col >= count Then
            ret = "<ILLEGAL COLUMN>"
        Else
            ret = dat(col)
        End If
        getColDataString = ret
    End Function

    Public Function putColDataString(col As Integer, data As String) As Boolean
        If col >= count Then
            count = col + 8
            ReDim Preserve dat(0 To (count + 1))
        End If
        If col >= MaxColumnCount Then
            MaxColumnCount = col
        End If
        dat(col) = data

        Return True

    End Function

    Private Sub Class_Initialize()
        count = 0
        int_valid = False
        MaxColumnCount = 0
    End Sub

End Class
