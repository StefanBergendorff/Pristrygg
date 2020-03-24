Public Class clsNewRecord

    Private lMeNewLine As Integer
    Private lMeOldLine As Integer
    Private sMeFieldName As String
    Private sMeMallLine As String


    Private Sub Class_Initialize()

        lMeNewLine = 0
        lMeOldLine = 99999
        sMeFieldName = ""
        sMeMallLine = "0|0|1"

    End Sub

    Public Property NewLine() As Integer
        Get
            NewLine = lMeNewLine
        End Get
        Set(value As Integer)
            lMeNewLine = value
        End Set
    End Property

    Public Property OldLine() As Integer
        Get
            OldLine = lMeOldLine
        End Get
        Set(value As Integer)
            lMeOldLine = value
        End Set
    End Property

    Public Property FieldName() As String
        Get
            FieldName = sMeFieldName
        End Get
        Set(value As String)
            sMeFieldName = value
        End Set
    End Property

    Public Property MallLine() As String
        Get
            MallLine = sMeMallLine
        End Get
        Set(value As String)
            sMeMallLine = value
        End Set
    End Property


End Class
