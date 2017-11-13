Imports System.IO

Public Class Logger

    Private m_FileName As String
    Public ReadOnly Property FileName() As String
        Get
            Return m_FileName
        End Get
    End Property

    Private m_Pattern As String
    Public ReadOnly Property Pattern() As String
        Get
            Return m_Pattern
        End Get
    End Property

    Public Sub New(ByVal fileName As String, ByVal pattern As String)
        m_FileName = fileName
        m_Pattern = pattern
    End Sub

    Public Sub Write(ByVal ParamArray data As String())
        Using sw As StreamWriter = New StreamWriter(m_FileName, True)
            sw.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss") & vbTab & String.Format(m_Pattern, data))
        End Using
    End Sub

End Class
