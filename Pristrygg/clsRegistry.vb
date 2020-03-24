Public Class clsRegistry
    'Registry Constants
    Private Const HKEY_CLASSES_ROOT = &H80000000
    Private Const HKEY_CURRENT_USER = &H80000001
    Private Const HKEY_LOCAL_MACHINE = &H80000002
    Private Const HKEY_USERS = &H80000003

    'Registry Specific Access Rights
    Private Const KEY_QUERY_VALUE = &H1
    Private Const KEY_SET_VALUE = &H2
    Private Const KEY_CREATE_SUB_KEY = &H4
    Private Const KEY_ENUMERATE_SUB_KEYS = &H8
    Private Const KEY_NOTIFY = &H10
    Private Const KEY_CREATE_LINK = &H20
    Private Const KEY_ALL_ACCESS = &H3F

    'Open/Create Options
    Private Const REG_OPTION_NON_VOLATILE = 0&
    Private Const REG_OPTION_VOLATILE = &H1

    'Key creation/open disposition
    Private Const REG_CREATED_NEW_KEY = &H1
    Private Const REG_OPENED_EXISTING_KEY = &H2

    'masks for the predefined standard access types
    Private Const STANDARD_RIGHTS_ALL = &H1F0000
    Private Const SPECIFIC_RIGHTS_ALL = &HFFFF

    'Define severity codes
    Private Const ERROR_SUCCESS = 0&
    Private Const ERROR_ACCESS_DENIED = 5
    Private Const ERROR_NO_MORE_ITEMS = 259

    'Predefined Value Types
    Private Const REG_NONE = (0)                         'No value type
    Private Const REG_SZ = (1)                           'Unicode nul terminated string
    Private Const REG_EXPAND_SZ = (2)                    'Unicode nul terminated string w/enviornment var
    Private Const REG_BINARY = (3)                       'Free form binary
    Private Const REG_DWORD = (4)                        '32-bit number
    Private Const REG_DWORD_LITTLE_ENDIAN = (4)          '32-bit number (same as REG_DWORD)
    Private Const REG_DWORD_BIG_ENDIAN = (5)             '32-bit number
    Private Const REG_LINK = (6)                         'Symbolic Link (unicode)
    Private Const REG_MULTI_SZ = (7)                     'Multiple Unicode strings
    Private Const REG_RESOURCE_LIST = (8)                'Resource list in the resource map
    Private Const REG_FULL_RESOURCE_DESCRIPTOR = (9)     'Resource list in the hardware description
    Private Const REG_RESOURCE_REQUIREMENTS_LIST = (10)

    Private Structure SECURITY_ATTRIBUTES
        Public nLength As Long
        Public lpSecurityDescriptor As Long
        Public bInheritHandle As Boolean
    End Structure

    Private Structure FILETIME
        Public dwLowDateTime As Long
        Public dwHighDateTime As Long
    End Structure

    Private Structure ACL
        Public AclRevision As Byte
        Public Sbz1 As Byte
        Public AclSize As Integer
        Public AceCount As Integer
        Public Sbz2 As Integer
    End Structure

    Private Structure SECURITY_DESCRIPTOR
        Public Revision As Byte
        Public Sbz1 As Byte
        Public Control As Long
        Public Owner As Long
        Public Group As Long
        Public Sacl As ACL
        Public Dacl As ACL
    End Structure

    Private Structure WNDCLASS
        Public style As Long
        Public lpfnWndProc As Long
        Public cbClsExtra As Long
        Public cbWndExtra2 As Long
        Public hInstance As Long
        Public hIcon As Long
        Public hCursor As Long
        Public hbrBackground As Long
        Public lpszMenuName As String
        Public lpszClassName As String
    End Structure

    Private Structure WNDCLASSEX
        Public cbSize As Long
        Public style As Long
        Public lpfnWndProc As Long
        Public cbClsExtra As Long
        Public cbWndExtra As Long
        Public hInstance As Long
        Public hIcon As Long
        Public hCursor As Long
        Public hbrBackground As Long
        Public lpszMenuName As String
        Public lpszClassName As String
        Public hIconSm As Long
    End Structure

    Private Declare Function RegCloseKey Lib "advapi32.dll" (ByVal hKey As Long) As Long
    Private Declare Function RegConnectRegistry Lib "advapi32.dll" Alias "RegConnectRegistryA" (ByVal lpMachineName As String, ByVal hKey As Long, phkResult As Long) As Long
    Private Declare Function RegCreateKey Lib "advapi32.dll" Alias "RegCreateKeyA" (ByVal hKey As Long, ByVal lpSubKey As String, phkResult As Long) As Long
    Private Declare Function RegCreateKeyEx Lib "advapi32.dll" Alias "RegCreateKeyExA" (ByVal hKey As Long, ByVal lpSubKey As String, ByVal Reserved As Long, ByVal lpClass As String, ByVal dwOptions As Long, ByVal samDesired As Long, lpSecurityAttributes As SECURITY_ATTRIBUTES, phkResult As Long, lpdwDisposition As Long) As Long
    Private Declare Function RegDeleteKey Lib "advapi32.dll" Alias "RegDeleteKeyA" (ByVal hKey As Long, ByVal lpSubKey As String) As Long
    Private Declare Function RegDeleteValue Lib "advapi32.dll" Alias "RegDeleteValueA" (ByVal hKey As Long, ByVal lpValueName As String) As Long
    Private Declare Function RegEnumKey Lib "advapi32.dll" Alias "RegEnumKeyA" (ByVal hKey As Long, ByVal dwIndex As Long, ByVal lpName As String, ByVal cbName As Long) As Long
    Private Declare Function RegEnumKeyEx Lib "advapi32.dll" Alias "RegEnumKeyExA" (ByVal hKey As Long, ByVal dwIndex As Long, ByVal lpName As String, lpcbName As Long, lpReserved As Long, ByVal lpClass As String, lpcbClass As Long, lpftLastWriteTime As FILETIME) As Long
    Private Declare Function RegEnumValue Lib "advapi32.dll" Alias "RegEnumValueA" (ByVal hKey As Long, ByVal dwIndex As Long, ByVal lpValueName As String, lpcbValueName As Long, ByVal lpReserved As Long, lpType As Long, lpData As Byte, lpcbData As Long) As Long
    Private Declare Function RegFlushKey Lib "advapi32.dll" (ByVal hKey As Long) As Long
    Private Declare Function RegGetKeySecurity Lib "advapi32.dll" (ByVal hKey As Long, ByVal SecurityInformation As Long, pSecurityDescriptor As SECURITY_DESCRIPTOR, lpcbSecurityDescriptor As Long) As Long
    Private Declare Function RegisterClass Lib "user32" (ByRef Class_Renamed As WNDCLASS) As Long
    Private Declare Function RegisterClassEx Lib "user32" Alias "RegisterClassExA" (pcWndClassEx As WNDCLASSEX) As Integer
    Private Declare Function RegisterClipboardFormat Lib "user32" Alias "RegisterClipboardFormatA" (ByVal lpString As String) As Long
    Private Declare Function RegisterEventSource Lib "advapi32.dll" Alias "RegisterEventSourceA" (ByVal lpUNCServerName As String, ByVal lpSourceName As String) As Long
    Private Declare Function RegisterHotKey Lib "user32" (ByVal hwnd As Long, ByVal id As Long, ByVal fsModifiers As Long, ByVal vk As Long) As Long
    Private Declare Function RegisterServiceCtrlHandler Lib "advapi32.dll" Alias "RegisterServiceCtrlHandlerA" (ByVal lpServiceName As String, ByVal lpHandlerProc As Long) As Long
    Private Declare Function RegisterWindowMessage Lib "user32" Alias "RegisterWindowMessageA" (ByVal lpString As String) As Long
    Private Declare Function RegLoadKey Lib "advapi32.dll" Alias "RegLoadKeyA" (ByVal hKey As Long, ByVal lpSubKey As String, ByVal lpFile As String) As Long
    Private Declare Function RegNotifyChangeKeyValue Lib "advapi32.dll" (ByVal hKey As Long, ByVal bWatchSubtree As Long, ByVal dwNotifyFilter As Long, ByVal hEvent As Long, ByVal fAsynchronus As Long) As Long
    Private Declare Function RegOpenKey Lib "advapi32.dll" Alias "RegOpenKeyA" (ByVal hKey As Long, ByVal lpSubKey As String, phkResult As Long) As Long
    Private Declare Function RegOpenKeyEx Lib "advapi32.dll" Alias "RegOpenKeyExA" (ByVal hKey As Long, ByVal lpSubKey As String, ByVal ulOptions As Long, ByVal samDesired As Long, phkResult As Long) As Long
    Private Declare Function RegQueryInfoKey Lib "advapi32.dll" Alias "RegQueryInfoKeyA" (ByVal hKey As Long, ByVal lpClass As String, lpcbClass As Long, lpReserved As Long, lpcSubKeys As Long, lpcbMaxSubKeyLen As Long, lpcbMaxClassLen As Long, lpcValues As Long, lpcbMaxValueNameLen As Long, lpcbMaxValueLen As Long, lpcbSecurityDescriptor As Long, lpftLastWriteTime As FILETIME) As Long
    Private Declare Function RegQueryValue Lib "advapi32.dll" Alias "RegQueryValueA" (ByVal hKey As Long, ByVal lpSubKey As String, ByVal lpValue As String, lpcbValue As Long) As Long
    Private Declare Function RegQueryValueEx Lib "advapi32" Alias "RegQueryValueExA" (ByVal hKey As Long, ByVal lpValueName As String, ByVal lpReserved As Long, ByRef lpType As Long, ByVal szData As String, ByRef lpcbData As Long) As Long
    Private Declare Function RegReplaceKey Lib "advapi32.dll" Alias "RegReplaceKeyA" (ByVal hKey As Long, ByVal lpSubKey As String, ByVal lpNewFile As String, ByVal lpOldFile As String) As Long
    Private Declare Function RegRestoreKey Lib "advapi32.dll" Alias "RegRestoreKeyA" (ByVal hKey As Long, ByVal lpFile As String, ByVal dwFlags As Long) As Long
    Private Declare Function RegSaveKey Lib "advapi32.dll" Alias "RegSaveKeyA" (ByVal hKey As Long, ByVal lpFile As String, lpSecurityAttributes As SECURITY_ATTRIBUTES) As Long
    Private Declare Function RegSetKeySecurity Lib "advapi32.dll" (ByVal hKey As Long, ByVal SecurityInformation As Long, pSecurityDescriptor As SECURITY_DESCRIPTOR) As Long
    Private Declare Function RegSetValue Lib "advapi32.dll" Alias "RegSetValueA" (ByVal hKey As Long, ByVal lpSubKey As String, ByVal dwType As Long, ByVal lpData As String, ByVal cbData As Long) As Long
    Private Declare Function RegSetValueEx Lib "advapi32" Alias "RegSetValueExA" (ByVal hKey As Long, ByVal lpValueName As String, ByVal Reserved As Long, ByVal dwType As Long, ByVal szData As String, ByVal cbData As Long) As Long
    Private Declare Function RegUnLoadKey Lib "advapi32.dll" Alias "RegUnLoadKeyA" (ByVal hKey As Long, ByVal lpSubKey As String) As Long

    Private Const ERR_WRONG_MAINKEY = vbObjectError + 515
    Private Const ERR_FAILED_TO_CREATE_KEY = vbObjectError + 516
    Private Const ERR_CREATE_KEY = vbObjectError + 517
    Private Const ERR_OPEN_KEY = vbObjectError + 518
    Private Const ERR_DELETE_KEY = vbObjectError + 519

    Private Const ERR_DELETE_VALUE = vbObjectError + 520
    Private Const ERR_READ_VALUE = vbObjectError + 521
    Private Const ERR_WRITE_VALUE = vbObjectError + 522

    Public ReadOnly Property KeyExist(sKey As String) As Boolean
        Get
            'Key format "key\key\key"
            Dim llBaseKey As Long
            Dim lsSubKeys As String
            Dim llResult As Long
            Dim llRetval As Long

            llBaseKey = f_GetBaseKey(sKey)
            If llBaseKey = 0 Then
                KeyExist = False

            Else
                lsSubKeys = f_GetSubKeys(sKey)
                llRetval = RegOpenKeyEx(llBaseKey, lsSubKeys, 0, KEY_ALL_ACCESS, llResult)
                If llRetval = ERROR_SUCCESS Then
                    RegCloseKey(llResult)
                    KeyExist = True
                Else
                    KeyExist = False
                End If

            End If


        End Get
    End Property

    Public ReadOnly Property ValueExist(sKey As String, sValueName As String) As Boolean
        Get
            'Key format "key\key\key"
            Dim llBaseKey As Long
            Dim lsSubKeys As String
            Dim llResult As Long
            Dim llRetval As Long
            Dim sBuffer As String

            sBuffer = Space(255)
            ValueExist = False

            llBaseKey = f_GetBaseKey(sKey)
            If llBaseKey = 0 Then
                ValueExist = False
            Else
                lsSubKeys = f_GetSubKeys(sKey)
                llRetval = RegOpenKeyEx(llBaseKey, lsSubKeys, 0, KEY_ALL_ACCESS, llResult)
                If llRetval = ERROR_SUCCESS Then

                    llRetval = RegQueryValueEx(llResult, sValueName, 0, 0, sBuffer,
                    Len(sBuffer) - 1)

                    If llRetval = ERROR_SUCCESS Then
                        RegCloseKey(llBaseKey)
                        RegCloseKey(llResult)
                        ValueExist = True
                    End If

                Else
                    ValueExist = False
                End If

            End If

        End Get
    End Property

    Public Sub AddKey(sKey As String)
        'Key format "key\key\key"
        Dim llBaseKey As Long
        Dim lsSubKeys As String
        Dim llRetval As Long
        Dim llCreate As Long
        Dim llResult As Long
        Dim SA As SECURITY_ATTRIBUTES

        On Error GoTo EH

        llBaseKey = f_GetBaseKey(sKey)
        If llBaseKey = 0 Then
            'Err.Raise Number:=vbObjectError + ERR_WRONG_MAINKEY,
            ' Description:="Ingen, eller felaktig rotnyckel",
            ' Source:="clsRegistry_AddKey"
        Else
            lsSubKeys = f_GetSubKeys(sKey)

            If lsSubKeys = "" Then
                '    Err.Raise Number:=vbObjectError + ERR_WRONG_MAINKEY,
                '    Description:="Kan inte skapa rotnyckel " & sKey,
                '    Source:="clsRegistry_AddKey"
            Else

                llRetval = RegCreateKeyEx(llBaseKey, lsSubKeys, 0, "", REG_OPTION_NON_VOLATILE, KEY_ALL_ACCESS, SA, llResult, llCreate)
                If llRetval <> ERROR_SUCCESS Then
                    '    Err.Raise Number:=vbObjectError + ERR_CREATE_KEY,
                    '    Description:="Fel vid skapande av " & sKey,
                    '    Source:="clsRegistry_AddKey"
                End If

            End If

        End If

        Exit Sub

EH:
        'Err.Raise Number:=Err.Number,
        ' Description:=Err.Description,
        ' Source:="clsRegistry_AddKey"


    End Sub

    Public Sub DeleteKey(sKey As String)
        'Key format "key\key\key"
        Dim llBaseKey As Long
        Dim lsSubKeys As String
        Dim llRetval As Long
        Dim llCreate As Long
        Dim SA As SECURITY_ATTRIBUTES

        On Error GoTo EH

        llBaseKey = f_GetBaseKey(sKey)
        If llBaseKey = 0 Then
            'Err.Raise Number:=vbObjectError + ERR_WRONG_MAINKEY,
            ' Description:="Ingen, eller felaktig rotnyckel",
            ' Source:="clsRegistry_DeleteKey"
        Else
            lsSubKeys = f_GetSubKeys(sKey)
            If lsSubKeys = "" Then
                '     Err.Raise Number:=vbObjectError + ERR_DELETE_KEY,
                '     Description:="Kan inte ta bort rotnyckel " & sKey,
                '     Source:="clsRegistry_DeleteKey"
            Else

                llRetval = RegDeleteKey(llBaseKey, lsSubKeys)
                If llRetval <> ERROR_SUCCESS Then
                    '    Err.Raise Number:=vbObjectError + ERR_DELETE_KEY,
                    '   Description:="Fel vid delete av " & sKey,
                    '   Source:="clsRegistry_DeleteKey"
                End If

            End If

        End If

        Exit Sub

EH:
        'Err.Raise Number:=Err.Number,
        ' Description:=Err.Description,
        ' Source:="clsRegistry_DeleteKey"

    End Sub

    Public Sub AddValue(sKey As String, sValueName As String, sValue As String)
        'Key format "key\key\key"
        Dim llBaseKey As Long
        Dim lsSubKeys As String
        Dim llResult As Long
        Dim llRetval As Long

        On Error GoTo EH

        llBaseKey = f_GetBaseKey(sKey)
        If llBaseKey = 0 Then
            'Err.Raise Number:=vbObjectError + ERR_WRONG_MAINKEY,
            ' Description:="Ingen, eller felaktig rotnyckel",
            ' Source:="clsRegistry_AddValue"

        Else
            lsSubKeys = f_GetSubKeys(sKey)
            llRetval = RegOpenKeyEx(llBaseKey, lsSubKeys, 0, KEY_ALL_ACCESS, llResult)
            If llRetval <> ERROR_SUCCESS Then
                '    Err.Raise Number:=vbObjectError + ERR_OPEN_KEY,
                '    Description:="Fel vid öppning av " & sKey,
                '    Source:="clsRegistry_AddValue"
            End If

            'För att undvika krasch.
            If Len(sValue) = 0 Then sValue = ""

            llRetval = RegSetValueEx(llResult, sValueName, 0, REG_SZ,
      sValue, CLng(Len(sValue) + 1))

            If llRetval <> ERROR_SUCCESS Then
                'Err.Raise Number:=vbObjectError + ERR_WRITE_VALUE,
                ' Description:="Fel vid skrivning av värdet " & sValueName,
                ' Source:="clsRegistry_AddValue"
            End If

            RegCloseKey(llBaseKey)
            RegCloseKey(llResult)


        End If

        Exit Sub

EH:
        'Err.Raise Number:=Err.Number,
        ' Description:=Err.Description,
        ' Source:="clsRegistry_AddValue"



    End Sub

    Public Sub DeleteValue(sKey As String, sValueName As String)
        'Key format "key\key\key"
        Dim llBaseKey As Long
        Dim lsSubKeys As String
        Dim llResult As Long
        Dim llRetval As Long

        On Error GoTo EH

        llBaseKey = f_GetBaseKey(sKey)
        If llBaseKey = 0 Then
            'Err.Raise Number:=vbObjectError + ERR_WRONG_MAINKEY,
            ' Description:="Ingen, eller felaktig rotnyckel",
            ' Source:="clsRegistry_DeleteValue"

        Else
            lsSubKeys = f_GetSubKeys(sKey)
            llRetval = RegOpenKeyEx(llBaseKey, lsSubKeys, 0, KEY_ALL_ACCESS, llResult)
            If llRetval <> ERROR_SUCCESS Then
                '    Err.Raise Number:=vbObjectError + ERR_OPEN_KEY,
                '    Description:="Fel vid öppning av " & sKey,
                '    Source:="clsRegistry_DeleteValue"
            End If

            llRetval = RegDeleteValue(llResult, sValueName)

            If llRetval <> ERROR_SUCCESS Then
                'Err.Raise Number:=vbObjectError + ERR_DELETE_VALUE,
                ' Description:="Fel vid delete av värdet " & sValueName,
                ' Source:="clsRegistry_DeleteValue"
            End If

            RegCloseKey(llResult)


        End If

        Exit Sub

EH:
        'Err.Raise Number:=Err.Number,
        ' Description:=Err.Description,
        ' Source:="clsRegistry_DeleteValue"



    End Sub

    Public Function RetriveValue(sKey As String, sValueName As String) As String
        'Key format "key\key\key"
        Dim llBaseKey As Long
        Dim lsSubKeys As String
        Dim llResult As Long
        Dim llRetval As Long
        Dim lsBuffer As String

        On Error GoTo EH

        lsBuffer = Space(255)

        llBaseKey = f_GetBaseKey(sKey)
        If llBaseKey = 0 Then
            'Err.Raise Number:=vbObjectError + ERR_WRONG_MAINKEY,
            ' Description:="Ingen, eller felaktig rotnyckel",
            ' Source:="clsRegistry_RetriveValue"

        Else
            lsSubKeys = f_GetSubKeys(sKey)
            llRetval = RegOpenKeyEx(llBaseKey, lsSubKeys, 0, KEY_ALL_ACCESS, llResult)
            If llRetval <> ERROR_SUCCESS Then
                'Err.Raise Number:=vbObjectError + ERR_OPEN_KEY,
                ' Description:="Fel vid öppning av " & sKey,
                ' Source:="clsRegistry_RetriveValue"
            End If

            llRetval = RegQueryValueEx(llResult, sValueName, 0, 0, lsBuffer,
                 Len(lsBuffer) - 1)

            If llRetval <> ERROR_SUCCESS Then
                'Err.Raise Number:=vbObjectError + ERR_READ_VALUE,
                ' Description:="Fel vid läsning av värdet " & sValueName,
                ' Source:="clsRegistry_RetriveValue"
            End If

            RegCloseKey(llBaseKey)
            RegCloseKey(llResult)

            'plocka bor skräp innan.
            RetriveValue = f_RemoveSpaces(lsBuffer)

        End If

        Exit Function

EH:
        'Err.Raise Number:=Err.Number,
        ' Description:=Err.Description,
        ' Source:="clsRegistry_RetriveValue"



    End Function

    Private Function f_GetBaseKey(sKey As String) As Long
        Dim llPos As Long
        Dim llTemp As String

        If Len(sKey) = 0 Then
            f_GetBaseKey = False
        Else

            llPos = InStr(1, sKey, "\") - 1
            If llPos < 1 Then
                Select Case sKey

                    Case "HKEY_CLASSES_ROOT"
                        f_GetBaseKey = HKEY_CLASSES_ROOT
                    Case "HKEY_CURRENT_USER"
                        f_GetBaseKey = HKEY_CURRENT_USER
                    Case "HKEY_LOCAL_MACHINE"
                        f_GetBaseKey = HKEY_LOCAL_MACHINE
                    Case "HKEY_USERS"
                        f_GetBaseKey = HKEY_USERS
                    Case Else
                        f_GetBaseKey = False

                End Select


            Else
                llTemp = UCase(Left$(sKey, llPos))

                Select Case llTemp

                    Case "HKEY_CLASSES_ROOT"
                        f_GetBaseKey = HKEY_CLASSES_ROOT
                    Case "HKEY_CURRENT_USER"
                        f_GetBaseKey = HKEY_CURRENT_USER
                    Case "HKEY_LOCAL_MACHINE"
                        f_GetBaseKey = HKEY_LOCAL_MACHINE
                    Case "HKEY_USERS"
                        f_GetBaseKey = HKEY_USERS
                    Case Else
                        f_GetBaseKey = False

                End Select

            End If

        End If
    End Function

    Private Function f_GetSubKeys(sKey As String) As String
        Dim llPos As Long

        If Len(sKey) = 0 Then
            f_GetSubKeys = ""
        Else
            llPos = InStr(1, sKey, "\")
            If llPos > 0 Then
                f_GetSubKeys = Right$(sKey, Len(sKey) - llPos)
            Else
                f_GetSubKeys = ""
            End If
        End If

    End Function

    Private Function f_RemoveSpaces(sValue As String)
        Dim llPos As Long

        If Len(sValue) = 0 Then
            f_RemoveSpaces = ""
        Else
            llPos = InStr(1, sValue, vbNullChar) - 1
            If llPos > 0 Then
                f_RemoveSpaces = Left$(sValue, llPos)
            Else
                f_RemoveSpaces = ""
            End If
        End If

    End Function


End Class
