Imports System.ComponentModel

<Serializable()> _
Public Class Alarm
    Implements INotifyPropertyChanged

    Public Shared Function CreateUnknow(ByVal alarmNo As String) As Alarm
        Dim ret As Alarm = New Alarm()
        ret.m_AlarmID = -1
        ret.m_AlarmMessage = ""
        ret.m_AlarmNo = alarmNo
        ret.m_AlarmType = AlarmCategoryType.Unknow
        ret.m_RecordTime = Now
        Return ret
    End Function

    Public Enum AlarmCategoryType
        Normal = 0
        Major = 1
        Information = 2
        Unknow = 3
    End Enum

    Private m_AlarmID As Integer
    Public Property AlarmID() As Integer
        Get
            Return m_AlarmID
        End Get
        Set(ByVal value As Integer)
            m_AlarmID = value
        End Set
    End Property

    Private m_AlarmNo As String
    Public Property AlarmNo() As String
        Get
            Return m_AlarmNo
        End Get
        Set(ByVal value As String)
            'have to do this for XML serializer
            m_AlarmNo = value
        End Set
    End Property

    Private m_AlarmMessage As String
    Public Property AlarmMessage() As String
        Get
            Return m_AlarmMessage
        End Get
        Set(ByVal value As String)
            'have to do this for XML serializer
            m_AlarmMessage = value
        End Set
    End Property

    Private m_AlarmType As AlarmCategoryType
    Public Property AlarmType() As AlarmCategoryType
        Get
            Return m_AlarmType
        End Get
        Set(ByVal value As AlarmCategoryType)
            'have to do this for XML serializer
            m_AlarmType = value
        End Set
    End Property

    Private m_RecordTime As DateTime
    Public Property RecordTime() As DateTime
        Get
            Return m_RecordTime
        End Get
        Set(ByVal value As DateTime)
            'have to do this for XML serializer
            m_RecordTime = value
        End Set
    End Property

    Private m_ClearTime As DateTime?
    Public Property ClearTime() As DateTime?
        Get
            Return m_ClearTime
        End Get
        Set(ByVal value As DateTime?)
            If Not value.Equals(m_ClearTime) Then
                m_ClearTime = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("ClearTime"))
            End If
        End Set
    End Property

    Private Sub New()
    End Sub

    Public Sub New(ByVal row As DBxDataSet.FTAlarmTableRow)
        m_RecordTime = Now
        m_AlarmID = row.ID
        m_AlarmNo = row.AlarmNo
        m_AlarmMessage = row.AlarmMessage
        m_IsSaved = False
        Select Case row.AlarmType
            Case "1"
                m_AlarmType = AlarmCategoryType.Major
            Case "2"
                m_AlarmType = AlarmCategoryType.Information
                m_ClearTime = Now
            Case Else
                m_AlarmType = AlarmCategoryType.Normal
        End Select
    End Sub

    '2017-06-29 Fixed bug that alarm was saved more than 1 time
    Private m_IsSaved As Boolean
    Public Property IsSaved() As Boolean
        Get
            Return m_IsSaved
        End Get
        Set(ByVal value As Boolean)
            m_IsSaved = value
        End Set
    End Property


    Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

End Class
