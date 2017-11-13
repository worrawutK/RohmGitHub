<Serializable()> _
Public Structure WorkTime

    Public Shared Empty As WorkTime

    Shared Sub New()
        Empty = New WorkTime()
    End Sub

    Public Sub New(ByVal startTime As Date, ByVal endTime As Date)
        m_StartTime = startTime
        m_EndTime = endTime
    End Sub

    Private m_StartTime As Date
    Public Property StartTime() As Date
        Get
            Return m_StartTime
        End Get
        Set(ByVal value As Date)
            m_StartTime = value
        End Set
    End Property

    Private m_EndTime As Date
    Public Property EndTime() As Date
        Get
            Return m_EndTime
        End Get
        Set(ByVal value As Date)
            m_EndTime = value
        End Set
    End Property

    Public Shared Function GetCurrent() As WorkTime

        Dim tmp As DateTime = Now

        If tmp.Hour >= 8 AndAlso tmp.Hour <= 20 Then
            Return New WorkTime(tmp.Date.AddHours(8), tmp.Date.AddHours(20))
        Else
            Return New WorkTime(tmp.Date.AddHours(20), tmp.Date.AddDays(1).AddHours(8))
        End If

    End Function

    Public Shared Operator =(ByVal workTime1 As WorkTime, ByVal workTime2 As WorkTime) As Boolean
        Return workTime1.StartTime = workTime2.StartTime AndAlso workTime1.EndTime = workTime2.EndTime
    End Operator

    Public Shared Operator <>(ByVal workTime1 As WorkTime, ByVal workTime2 As WorkTime) As Boolean
        Return workTime1.StartTime <> workTime2.StartTime OrElse workTime1.EndTime <> workTime2.EndTime
    End Operator

End Structure