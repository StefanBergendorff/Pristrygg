Public Class clsPost
    Private m_Key As Integer
    Private m_StartPos As Integer
    Private m_Length As Integer
    Private m_Divider As Double
    Private m_Value As String
    Private m_TemplateField As Boolean
    Private m_FINFO_Bild As String
    Private m_FINFO_Name As String
    Private m_FINFO_Description As String
    Private m_FINFO_StartPos As Integer
    Private m_FINFO_Length As Integer
    Private m_FINFO_Decimals As Integer
    Private m_FINFO_Alignment As Byte
    Private m_FINFO_DataFormat As String
    Private m_Comment As String


    Private Sub Class_Initialize()
        m_Divider = 1
        m_TemplateField = False
    End Sub

    'Nyckel
    Public Property Key() As Integer
        Get
            Key = m_Key
        End Get
        Set(value As Integer)
            m_Key = value
        End Set

    End Property

    'Bild
    Public Property FINFO_Bild() As String
        Get
            FINFO_Bild = m_FINFO_Bild
        End Get
        Set(value As String)
            m_FINFO_Bild = value
        End Set

    End Property

    'Fältnamn
    Public Property FINFO_Name() As String
        Get
            FINFO_Name = m_FINFO_Name
        End Get
        Set(value As String)
            m_FINFO_Name = value
        End Set

    End Property

    'Beskrivning
    Public Property FINFO_Description() As String
        Get
            FINFO_Description = m_FINFO_Description
        End Get
        Set(value As String)
            m_FINFO_Description = value
        End Set

    End Property

    'StartPosition
    Public Property StartPos() As Integer
        Get
            StartPos = m_StartPos
        End Get
        Set(value As Integer)
            m_StartPos = value
        End Set

    End Property

    'StartPosition FINFO
    Public Property FINFO_StartPos() As Integer
        Get
            FINFO_StartPos = m_FINFO_StartPos
        End Get
        Set(value As Integer)
            m_FINFO_StartPos = value
        End Set

    End Property

    'Längd på posten
    Public Property Length() As Integer
        Get
            Length = m_Length
        End Get
        Set(value As Integer)
            m_Length = value
        End Set

    End Property

    'Maximalt tillåten Längd på posten
    Public Property FINFO_Length() As Integer
        Get
            FINFO_Length = m_FINFO_Length
        End Get
        Set(value As Integer)
            m_FINFO_Length = value
        End Set

    End Property

    'Antal decinaler
    Public Property FINFO_Decimals() As Integer
        Get
            FINFO_Decimals = m_FINFO_Decimals
        End Get
        Set(value As Integer)
            m_FINFO_Decimals = value
        End Set

    End Property

    'Höger, eller vänsterställt
    Public Property FINFO_Alignment() As Byte
        Get
            FINFO_Alignment = m_FINFO_Alignment
        End Get
        Set(value As Byte)
            m_FINFO_Alignment = value
        End Set

    End Property

    'Text, eller numeriskt
    Public Property FINFO_DataFormat() As String
        Get
            FINFO_DataFormat = m_FINFO_DataFormat
        End Get
        Set(value As String)
            m_FINFO_DataFormat = value
        End Set

    End Property

    'Dividera med...
    Public Property Divider() As Double
        Get
            Divider = m_Divider
        End Get
        Set(value As Double)
            m_Divider = value
        End Set

    End Property

    'Data
    Public Property Value() As String
        Get
            Value = m_Value
        End Get
        Set(inValue As String)
            m_Value = inValue
        End Set

    End Property

    'Mallfält
    Public Property TemplateField() As Boolean
        Get
            TemplateField = m_TemplateField
        End Get
        Set(value As Boolean)
            m_TemplateField = value
        End Set

    End Property

    'Data
    Public Property Comment() As String
        Get
            Comment = m_Comment
        End Get
        Set(inValue As String)
            m_Comment = inValue
            'Last pipe is often the data format and not the comment. In that case set comment to blanks
            If FINFO_DataFormat = m_Comment Then
                m_Comment = ""
            End If
        End Set

    End Property

End Class
