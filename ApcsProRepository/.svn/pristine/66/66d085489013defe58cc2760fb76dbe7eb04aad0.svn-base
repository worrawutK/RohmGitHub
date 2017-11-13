Imports System.IO

Public Class FolderManager

    Private m_LogFolder As String
    Public ReadOnly Property LogFolder() As String
        Get
            Return m_LogFolder
        End Get
    End Property

    Private m_StateFolder As String
    Public ReadOnly Property StateFolder() As String
        Get
            Return m_StateFolder
        End Get
    End Property

    Private m_ModulesFolder As String
    Public ReadOnly Property ModulesFolder() As String
        Get
            Return m_ModulesFolder
        End Get
    End Property

    Private m_DataErrorFolder As String
    Public ReadOnly Property DataErrorFolder() As String
        Get
            Return m_DataErrorFolder
        End Get
    End Property

    Public Sub New(ByVal appDir As String)
        m_LogFolder = Path.Combine(appDir, "Log")
        m_StateFolder = Path.Combine(appDir, "State")
        m_ModulesFolder = Path.Combine(appDir, "Modules")
        m_DataErrorFolder = Path.Combine(appDir, "DataError")
    End Sub

    ''' <summary>
    ''' ตรวจสอบและสร้าง Folder ให้
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CompleteFolder()
        CheckAndCreateIfNotExits(m_LogFolder)
        CheckAndCreateIfNotExits(m_StateFolder)
        CheckAndCreateIfNotExits(m_ModulesFolder)
        CheckAndCreateIfNotExits(m_DataErrorFolder)
    End Sub

    Private Sub CheckAndCreateIfNotExits(ByVal path As String)
        If Not Directory.Exists(path) Then
            Directory.CreateDirectory(path)
        End If
    End Sub

End Class
