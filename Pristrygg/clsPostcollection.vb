Public Class clsPostcollection
    Private m_Collection As New Collection

    Public Sub AddPost(Optional Key As Integer = -1)
        Dim NewPost As New clsPost

        Try
            NewPost.Key = Key
            m_Collection.Add(NewPost)

        Catch ex As Exception
            'Key already exists
        End Try

    End Sub

    Public ReadOnly Property count As Integer
        Get
            count = m_Collection.Count
        End Get
    End Property

    Public Function Item(Index As Integer) As clsPost
        Item = m_Collection.Item(Index)
    End Function

End Class
