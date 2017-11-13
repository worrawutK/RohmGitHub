Public Class EcoWatch

    Public Event EcoTimeLimit(ByVal mcNo As String)
    Public Event EcoClientRemoved(ByVal mcNo As String)

    Private m_OneSecTimer As Timer

    Private m_WatchDuration As TimeSpan = New TimeSpan(6, 0, 0)
    Public Property WatchDuration() As TimeSpan
        Get
            Return m_WatchDuration
        End Get
        Set(ByVal value As TimeSpan)
            m_WatchDuration = value
        End Set
    End Property

    Public Sub New()
        m_Clients = New List(Of EcoWatchClient)
        m_OneSecTimer = New Timer()
        m_OneSecTimer.Interval = 1000
    End Sub


    Private Sub OneSecTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        m_OneSecTimer.Stop()

        Dim removeList As List(Of EcoWatchClient) = New List(Of EcoWatchClient)

        For Each c As EcoWatchClient In m_Clients
            If c.TimeStamp.Subtract(Now).Duration() > m_WatchDuration Then
                RaiseEvent EcoTimeLimit(c.MCNo)
                removeList.Add(c)
            End If
        Next

        For Each c As EcoWatchClient In removeList
            m_Clients.Remove(c)
        Next

        removeList.Clear()
        removeList = Nothing

        m_OneSecTimer.Start()
    End Sub

    Public Sub Add(ByVal mcNo As String)

        For Each c As EcoWatchClient In m_Clients
            If c.MCNo = mcNo Then
                c.TimeStamp = Now
                Exit Sub
            End If
        Next

        Dim newClient As EcoWatchClient = New EcoWatchClient()
        newClient.MCNo = mcNo
        newClient.TimeStamp = Now

        m_Clients.Add(newClient)

    End Sub

    Public Sub Remove(ByVal mcNo As String)
        Dim removeClient As EcoWatchClient = Nothing
        For Each c As EcoWatchClient In m_Clients
            If c.MCNo = mcNo Then
                removeClient = c
                Exit For
            End If
        Next

        If removeClient Is Nothing Then
            Exit Sub
        End If

        m_Clients.Remove(removeClient)

        RaiseEvent EcoClientRemoved(removeClient.MCNo)

    End Sub

    Public Sub StartWatch()
        If Not m_OneSecTimer.Enabled Then
            AddHandler m_OneSecTimer.Tick, AddressOf OneSecTimer_Tick
            m_OneSecTimer.Start()
        End If
    End Sub

    Public Sub StopWatch()
        If m_OneSecTimer.Enabled Then
            RemoveHandler m_OneSecTimer.Tick, AddressOf OneSecTimer_Tick
            m_OneSecTimer.Stop()
        End If
    End Sub

    Private m_Clients As List(Of EcoWatchClient)
    Public Property Clients() As List(Of EcoWatchClient)
        Get
            Return m_Clients
        End Get
        Set(ByVal value As List(Of EcoWatchClient))
            m_Clients = value
        End Set
    End Property

End Class
