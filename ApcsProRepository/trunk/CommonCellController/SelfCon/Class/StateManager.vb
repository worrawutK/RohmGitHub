Imports System.IO
Imports System.Xml.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.ComponentModel

Public Class StateManager

    Private m_MachineXmlSerializer As XmlSerializer
    Private m_EchoWatchSerializer As XmlSerializer
    Private m_BinSerializer As BinaryFormatter
    Private m_PLog As Logger

    Private m_StateFolder As String
    Public ReadOnly Property StateFolder() As String
        Get
            Return m_StateFolder
        End Get
    End Property

    Public Sub New(ByVal stateFolder As String, ByVal logger As Logger)
        m_StateFolder = stateFolder
        m_MachineXmlSerializer = New XmlSerializer(GetType(Machine))
        m_EchoWatchSerializer = New XmlSerializer(GetType(List(Of EcoWatchClient)))
        m_BinSerializer = New BinaryFormatter()
        m_PLog = logger
    End Sub

    Public Function LoadMachineState(ByVal mcNo As String) As Machine
        Dim mc As Machine = Nothing
        Dim fileName As String = Path.Combine(m_StateFolder, mcNo & ".xml")
        If File.Exists(fileName) Then
            Using sr As StreamReader = New StreamReader(fileName)
                mc = CType(m_MachineXmlSerializer.Deserialize(sr.BaseStream), Machine)
                'fix bug xml serializer about reference type
                If mc.Alarms.Count > 0 Then
                    Dim lastAlarm As Alarm = mc.Alarms(mc.Alarms.Count - 1)
                    If Not lastAlarm.ClearTime.HasValue Then
                        mc.CurrentAlarm = lastAlarm
                    End If
                End If
            End Using
        End If
        Return mc
    End Function

    Public Sub Clear()
        Dim files As String() = Directory.GetFiles(m_StateFolder)
        For Each f As String In files
            Try
                File.Delete(f)
            Catch ex As Exception
            End Try
        Next
    End Sub

    Public Function LoadOPAlarmGrapDataList() As List(Of OPAlarmGraphData)
        Dim l As List(Of OPAlarmGraphData) = Nothing
        Dim fileName As String = Path.Combine(m_StateFolder, "OPAlarmGraphDataList.bin")
        If File.Exists(fileName) Then
            Using sr As StreamReader = New StreamReader(fileName)
                l = CType(m_BinSerializer.Deserialize(sr.BaseStream), List(Of OPAlarmGraphData))
            End Using
        End If
        Return l
    End Function


    Public Function LoadWorkTime() As WorkTime
        Dim l As WorkTime = WorkTime.Empty
        Dim fileName As String = Path.Combine(m_StateFolder, "WorkTime.bin")
        If File.Exists(fileName) Then
            Using sr As StreamReader = New StreamReader(fileName)
                l = CType(m_BinSerializer.Deserialize(sr.BaseStream), WorkTime)
            End Using
        End If
        Return l
    End Function

    Public Sub Save(ByVal mcList As List(Of Machine), ByVal alarmDataList As List(Of OPAlarmGraphData), ByVal wTime As WorkTime)
        Dim fileName As String = Nothing
        For Each mc As Machine In mcList
            Try
                fileName = Path.Combine(m_StateFolder, mc.MCNo & ".xml")
                Using sw As StreamWriter = New StreamWriter(fileName)
                    m_MachineXmlSerializer.Serialize(sw.BaseStream, mc)
                End Using
            Catch ex As Exception
                m_PLog.Write("StateManager.Save-001", ex.Message)
            End Try
        Next

        fileName = Path.Combine(m_StateFolder, "OPAlarmGraphDataList.bin")
        Try
            SaveAsBinaryFormat(fileName, alarmDataList)
        Catch ex As Exception
            m_PLog.Write("StateManager.Save-002", ex.Message)
        End Try

        fileName = Path.Combine(m_StateFolder, "WorkTime.bin")
        Try
            SaveAsBinaryFormat(fileName, wTime)
        Catch ex As Exception
            m_PLog.Write("StateManager.Save-003", ex.Message)
        End Try

    End Sub

    Public Function LoadEchoWatchState() As List(Of EcoWatchClient)
        Dim ret As List(Of EcoWatchClient) = Nothing
        Dim fileName As String = Path.Combine(m_StateFolder, "EchoWatch.xml")
        If File.Exists(fileName) Then
            Using sr As StreamReader = New StreamReader(fileName)
                ret = CType(m_EchoWatchSerializer.Deserialize(sr.BaseStream), List(Of EcoWatchClient))
            End Using
        End If
        Return ret
    End Function

    Public Sub SaveEchoWatchState(ByVal clientList As List(Of EcoWatchClient))
        Dim fileName As String = Path.Combine(m_StateFolder, "EchoWatch.xml")
        Using writer As StreamWriter = New StreamWriter(fileName)
            m_EchoWatchSerializer.Serialize(writer.BaseStream, clientList)
        End Using
    End Sub

    Private Sub SaveAsBinaryFormat(ByVal fileName As String, ByVal graph As Object)

        If graph Is Nothing Then
            If File.Exists(fileName) Then
                File.Delete(fileName)
            End If
        Else
            Using sw As StreamWriter = New StreamWriter(fileName)
                m_BinSerializer.Serialize(sw.BaseStream, graph)
            End Using
        End If
    End Sub

End Class
