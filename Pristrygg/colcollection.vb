Public Class colcollection
    Private m_Collection As New Collection

    Public Sub AddCol(Optional Key As Integer = -1)
        Dim NewCol As New clsCol

        Try
            NewCol.Key = Key
            m_Collection.Add(NewCol)

        Catch ex As Exception
            'Key already exists
        End Try

    End Sub

    Public ReadOnly Property count As Integer
        Get
            count = m_Collection.Count
        End Get
    End Property

    Public Function Item(Index As Integer) As clsCol
        Item = m_Collection.Item(Index)
    End Function


End Class
