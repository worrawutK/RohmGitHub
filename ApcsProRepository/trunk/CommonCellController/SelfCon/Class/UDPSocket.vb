Imports System.Text
Imports System.Net
Imports System.Net.Sockets

Public Class UDPSocket

    Public Event ListeningStatusChanged(ByVal e As Boolean)

    Private m_SendBuff As Byte()
    Private m_RecvSck As UdpClient
    Private m_SendSck As UdpClient
    Private m_GroupEP As IPEndPoint
    Private m_RecvBuff As Byte()

    Private m_LocalPort As Integer
    Public Property LocalPort() As Integer
        Get

            Return Me.m_LocalPort
        End Get
        Set(ByVal value As Integer)
            Me.m_LocalPort = value
        End Set
    End Property

    Private m_RemotePort As Integer
    Public Property RemotePort() As Integer
        Get
            Return Me.m_RemotePort
        End Get
        Set(ByVal value As Integer)
            Me.m_RemotePort = value
        End Set
    End Property

    Private m_RemoteHost As String
    Public Property RemoteHost() As String
        Get
            Return Me.m_RemoteHost
        End Get
        Set(ByVal value As String)
            Me.m_RemoteHost = value
        End Set
    End Property

    Public Function GetUDPMessage() As UDPMessage

        Dim ret As UDPMessage = Nothing

        Me.m_RecvBuff = Nothing

        'call block
        'waiting for message from network .....
        Me.m_RecvBuff = m_RecvSck.Receive(m_GroupEP)
        ret = New UDPMessage(m_GroupEP.Address.ToString, Encoding.ASCII.GetString(m_RecvBuff, 0, m_RecvBuff.Length))

        Return ret

    End Function

    Sub New(ByVal port As Integer)

        Me.m_RemoteHost = Nothing
        Me.m_RemotePort = port
        Me.m_LocalPort = port

        'we must not set the localport to this object
        Me.m_SendSck = New UdpClient()
        Me.m_RecvSck = New UdpClient(Me.LocalPort) 'port is open after do this line
        Me.m_GroupEP = New IPEndPoint(IPAddress.Any, Me.LocalPort)
        'เราจะไม่ประกาศ LocalPort ให้ ตัวส่งเนื่องจากจะทำให้ตัวรับเปิด port ไม่ได้
        'และที่ต้องมี แยกทั้งตัวรับและตัวส่งนั้น เพราะว่า หากใช้คำสั่ง obj.Close() จะทำให้ Object นั้นถุก Dispose
        'มีผลเมื่อตอนเราเรียกคำสั่ง Send จะเกิด Error : Can not access dispose object
    End Sub

    Public Sub Send(ByVal message As String)
        Me.m_SendBuff = Encoding.ASCII.GetBytes(message)
        Me.m_SendSck.Send(Me.m_SendBuff, Me.m_SendBuff.Length, Me.RemoteHost, Me.RemotePort)
    End Sub

End Class

Public Structure UDPMessage

    Public FromIP As String
    Public Message As String

    Public Sub New(ByVal fromIP As String, ByVal message As String)
        Me.FromIP = fromIP
        Me.Message = message
    End Sub

End Structure
