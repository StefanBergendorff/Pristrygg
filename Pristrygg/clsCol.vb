Public Class clsCol
    Private m_Key As Long
    Private m_GridID As Long
    Private m_ColID As Long
    Private m_Width As Long
    Private m_TextBoxSize As Long
    Private m_Caption As String
    Private m_InputType As String
    Private m_ToolTipText As Boolean
    Private m_Lista As Boolean
    Private m_Visible As Boolean

    Private m_Locked As Boolean
    Private m_AllowFocus As Boolean
    Private m_ComboExist As Boolean

    'Nyckel
    Public Property Key() As Long
        Get
            Key = m_Key
        End Get
        Set(value As Long)
            m_Key = value
        End Set

    End Property

    'Grid ID
    Public Property GridID() As Long
        Get
            GridID = m_GridID
        End Get
        Set(value As Long)
            m_GridID = value
        End Set

    End Property

    'Kolumn ID
    Public Property ColID() As Long
        Get
            ColID = m_ColID
        End Get
        Set(value As Long)
            m_ColID = value
        End Set

    End Property

    'Bredd
    Public Property Width() As Long
        Get
            Width = m_Width
        End Get
        Set(value As Long)
            m_Width = value
        End Set

    End Property

    'Textboxarnas storlek.
    Public Property TextBoxSize() As Long
        Get
            TextBoxSize = m_TextBoxSize
        End Get
        Set(value As Long)
            m_TextBoxSize = value
        End Set

    End Property

    'Namn
    Public Property Caption() As String
        Get
            Caption = m_Caption
        End Get
        Set(value As String)
            m_Caption = value
        End Set

    End Property

    'InputType
    Public Property InputType() As String
        Get
            InputType = m_InputType
        End Get
        Set(value As String)
            m_InputType = value
        End Set

    End Property

    'ToolTipText
    Public Property ToolTipText() As Boolean
        Get
            ToolTipText = m_ToolTipText
        End Get
        Set(value As Boolean)
            m_ToolTipText = value
        End Set

    End Property

    'Synlig
    Public Property Visible() As Boolean
        Get
            Visible = m_Visible
        End Get
        Set(value As Boolean)
            m_Visible = value
        End Set

    End Property

    'Vallista
    Public Property Lista() As Boolean
        Get
            Lista = m_Lista
        End Get
        Set(value As Boolean)
            m_Lista = value
        End Set

    End Property

    'Kombobox i kolumnen ?
    Public Property ComboExist() As Boolean
        Get
            ComboExist = m_ComboExist
        End Get
        Set(value As Boolean)
            m_ComboExist = value
        End Set

    End Property


    'Låst
    Public Property Locked() As Boolean
        Get
            Locked = m_Locked
        End Get
        Set(value As Boolean)
            m_Locked = value
        End Set

    End Property

    'Focus
    Public Property AllowFocus() As Boolean
        Get
            AllowFocus = m_AllowFocus
        End Get
        Set(value As Boolean)
            m_AllowFocus = value
        End Set

    End Property


    Private Sub Class_Initialize()
        m_ComboExist = False
    End Sub

End Class
