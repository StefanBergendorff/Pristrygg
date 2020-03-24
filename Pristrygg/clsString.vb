Public Class clsString
    Private m_StringData As String
    Private m_start As Integer
    Private m_End As Integer
    Private m_Count As Integer

    Public Property StringData() As String
        Get
            StringData = m_StringData
        End Get
        Set(value As String)
            m_StringData = value
        End Set

    End Property

    Public Function FindNextPipe()
        Dim lsTemp As String

        m_Count = m_Count + 1
        If m_Count = 1 Then m_start = 1

        m_End = InStr(m_start, m_StringData, "|")

        If m_End < 1 Then
            lsTemp = Right(m_StringData, Len(m_StringData) - m_start + 1)
        Else
            lsTemp = Mid(m_StringData, m_start, m_End - m_start)
            m_start = m_End + 1
        End If

        FindNextPipe = lsTemp


    End Function

    Public Sub ResetValue()
        m_Count = 0
        m_StringData = ""
    End Sub

End Class
