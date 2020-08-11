Public Class clsSupplier

    Private m_LevNamn As String
    Private m_LevNr As String
    Private m_FileFormat As String
    Private m_Header As Byte
    Private m_NumberOfPosts As Integer
    Private m_NumberOfTemplatePosts As Integer

    Private m_Post As New clsPostcollection

    '-- Sätts som namn på leverantörens mall-fil.
    Public Property LevNamn() As String
        Get
            LevNamn = m_LevNamn
        End Get
        Set(value As String)
            m_LevNamn = value
        End Set

    End Property

    Public Property LevNr() As String
        Get
            LevNr = m_LevNr
        End Get
        Set(value As String)
            m_LevNr = value
        End Set

    End Property

    '-- Kan vara ANSI, DOS, EXCEL-ANSI eller EXCEL-DOS.
    Public Property FileFormat() As String
        Get
            FileFormat = m_FileFormat
        End Get
        Set(value As String)
            m_FileFormat = value
        End Set

    End Property

    '-- Antalet rubrikrader i filen
    Public Property Header() As Byte
        Get
            Header = m_Header
        End Get
        Set(value As Byte)
            m_Header = value
        End Set

    End Property

    '-- Totalt antal fält i FINFO-fil
    Public Property NumberOfPosts() As Integer
        Get
            NumberOfPosts = m_NumberOfPosts
        End Get
        Set(value As Integer)
            m_NumberOfPosts = value
        End Set

    End Property

    '-- Totalt antal fält som ska läsas från leverantörsfil.
    Public Property NumberOfTemplatePosts() As Integer
        Get
            NumberOfTemplatePosts = m_NumberOfTemplatePosts
        End Get
        Set(value As Integer)
            m_NumberOfTemplatePosts = value
        End Set

    End Property

    Public ReadOnly Property PostCollection() As clsPostcollection
        Get
            PostCollection = m_Post
        End Get
    End Property

    Public ReadOnly Property Post(ByVal Index As Integer) As clsPost
        Get
            Post = m_Post.Item(Index)
        End Get
    End Property

    '-- Skapar poster.
    Public Function CreatePosts(Optional sFileType As String = INI_FILE_EXTERN_VILMA2) As Boolean
        Dim cString As New clsString
        Dim lsBuffer As String
        Dim lsTemp As String
        Dim lsIniFile As String
        Dim Fnr As Integer
        Dim J As Integer
        Dim bFileOpen As Boolean

        Try

            bFileOpen = False
            CreatePosts = False

            If sFileType = INI_FILE_INTERN Then

                lsIniFile = FixDirStr(Application.StartupPath) & INI_FILE_INTERN
            ElseIf sFileType = INI_FILE_INTERN_VILMA Then
                lsIniFile = FixDirStr(Application.StartupPath) & INI_FILE_INTERN_VILMA
            ElseIf sFileType = INI_FILE_INTERN_VILMA2 Then
                lsIniFile = FixDirStr(Application.StartupPath) & INI_FILE_INTERN_VILMA2
            Else
                lsIniFile = FixDirStr(Application.StartupPath) & INI_FILE
                '--->2012-01-30, ser efter om Vilma 2 körs
                If APP_VILMA2_FLAG = "1" Then 'Vilma2
                    lsIniFile = FixDirStr(Application.StartupPath) & INI_FILE_EXTERN_VILMA2
                Else
                    lsIniFile = FixDirStr(Application.StartupPath) & INI_FILE_EXTERN_VILMA1
                End If
                '---<2012-01-30
            End If

            '-- Kontroll att inifil existerar.
            If Not FileExists(lsIniFile) Then
                MsgBox("Filen '" & lsIniFile & "' finns inte.", vbInformation, APPNAME)
                Exit Function
            End If

            Fnr = FreeFile()
            FileOpen(Fnr, lsIniFile, OpenMode.Input)
            bFileOpen = True
            Do Until EOF(Fnr)
                J += 1
                PostCollection.AddPost(J)
                lsBuffer = LineInput(Fnr)
                cString.StringData = lsBuffer
                lsTemp = cString.FindNextPipe

                If lsTemp = "1" Then
                    '-- Post J ska läsas från leverantörsfil.
                    Post(J).TemplateField = True
                    m_NumberOfTemplatePosts = m_NumberOfTemplatePosts + 1
                    ReDim Preserve MALL_POST(m_NumberOfTemplatePosts)
                    MALL_POST(m_NumberOfTemplatePosts) = J
                End If

                Post(J).FINFO_Bild = cString.FindNextPipe
                Post(J).FINFO_Name = cString.FindNextPipe
                Post(J).FINFO_Description = cString.FindNextPipe
                Post(J).FINFO_StartPos = CLng(cString.FindNextPipe)
                Post(J).FINFO_Length = CLng(cString.FindNextPipe)
                Post(J).FINFO_Decimals = CLng(cString.FindNextPipe)
                Post(J).FINFO_DataFormat = cString.FindNextPipe
                Post(J).Comment = cString.FindNextPipe
                cString.ResetValue()
            Loop

            m_NumberOfPosts = J

            FileClose(Fnr)

            bFileOpen = False
            CreatePosts = True

            Exit Function


        Catch ex As Exception
            If bFileOpen Then
                FileClose(Fnr)
            End If
            CreatePosts = False
            MsgBox("Ett fel har inträffat." & vbCrLf & "Felbeskrivning :  " & Err.Description, vbInformation, APPNAME)

        End Try

    End Function




End Class
