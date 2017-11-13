Imports System.Text
Imports System.IO

Public MustInherit Class Operation

    Private m_OperatorNo As String
    Public Property OperatorNo() As String
        Get
            Return m_OperatorNo
        End Get
        Set(ByVal value As String)
            m_OperatorNo = value
        End Set
    End Property

    Protected m_LogFolder As String
    Private m_SB As StringBuilder
    Protected m_IsExecuting As Boolean

    Private m_Message As String
    Public Property Message() As String
        Get
            Return m_Message
        End Get
        Protected Set(ByVal value As String)
            m_Message = value
        End Set
    End Property

    Private m_IsCompleted As Boolean
    Public Property IsCompleted() As Boolean
        Get
            Return m_IsCompleted
        End Get
        Protected Set(ByVal value As Boolean)
            m_IsCompleted = value
        End Set
    End Property

    Public Sub New()
        m_SB = New StringBuilder()
        m_LogFolder = Path.Combine(My.Application.Info.DirectoryPath, "Log")
        m_IsExecuting = False
    End Sub

    Public Function Execute(ByVal mc As Machine) As Boolean
        'check executing
        If m_IsExecuting Then
            Return False  'or throw an error
        End If
        'blocking
        m_IsExecuting = True
        'clear string builder
        m_SB.Remove(0, m_SB.Length)
        'clear flag
        m_IsCompleted = False
        'clear message
        m_Message = String.Empty
        'keep type
        AppendLog(mc.MCNo & " was [Execute] As " & Me.GetType().ToString())
        'check parameters
        AppendLog("[VerifyParameter]")
        If VerifyParameter(mc) Then
            'perform operation
            AppendLog("[Perform]")
            Perform(mc)
        Else
            AppendLog("Operation was cancelled")
        End If
        'keep logging
        WriteLog(mc)
        'un blocking
        m_IsExecuting = False

        Return True
    End Function

    Private Sub WriteLog(ByVal mc As Machine)
        Using sw As StreamWriter = New StreamWriter(Path.Combine(m_LogFolder, mc.MCNo & "_Operation.log"), True)
            sw.WriteLine(m_SB.ToString())
        End Using
    End Sub

    Protected Sub AppendLog(ByVal data As String)
        m_SB.AppendLine(Now.ToString("yyyy/MM/dd HH:mm:ss") & vbTab & data)
    End Sub

    Protected MustOverride Function VerifyParameter(ByVal mc As Machine) As Boolean
    Protected MustOverride Sub Perform(ByVal mc As Machine)

End Class
