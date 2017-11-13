Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Data.Common

Public Class OPAlarmGraphGenerator

#Region "Public Properties"

    Private m_MTTRSeriesName As String
    Public Property MTTRSeriesName() As String
        Get
            Return m_MTTRSeriesName
        End Get
        Set(ByVal value As String)
            m_MTTRSeriesName = value
        End Set
    End Property

    Private m_AlarmCountSeriesName As String
    Public Property AlarmCountSeriesName() As String
        Get
            Return m_AlarmCountSeriesName
        End Get
        Set(ByVal value As String)
            m_AlarmCountSeriesName = value
        End Set
    End Property

    Private m_DurationSeriesName As String
    Public Property DurationSeriesName() As String
        Get
            Return m_DurationSeriesName
        End Get
        Set(ByVal value As String)
            m_DurationSeriesName = value
        End Set
    End Property

    Private m_OPChart As Chart
    Public Property OPChart() As Chart
        Get
            Return m_OPChart
        End Get
        Set(ByVal value As Chart)
            If Not Object.ReferenceEquals(m_OPChart, value) Then
                m_OPChart = value
                If m_OPChart IsNot Nothing Then
                    InitChart(m_OPChart)
                End If
            End If
        End Set
    End Property

    Private m_MTTRChart As Chart
    Public Property MTTRChart() As Chart
        Get
            Return m_MTTRChart
        End Get
        Set(ByVal value As Chart)
            If Not Object.ReferenceEquals(m_MTTRChart, value) Then
                m_MTTRChart = value
                If m_MTTRChart IsNot Nothing Then
                    InitChart(m_MTTRChart)
                End If
            End If
        End Set
    End Property

    Private m_WorkTime As WorkTime
    Public Property WorkTime() As WorkTime
        Get
            Return m_WorkTime
        End Get
        Set(ByVal value As WorkTime)
            If value <> WorkTime Then
                m_WorkTime = value
                OnWorktimeChanged()
            End If
        End Set
    End Property


    Private m_EnableLoadAfterWorkTimeChanged As Boolean
    Public Property EnableLoadAfterWorkTimeChanged() As Boolean
        Get
            Return m_EnableLoadAfterWorkTimeChanged
        End Get
        Set(ByVal value As Boolean)
            m_EnableLoadAfterWorkTimeChanged = value
        End Set
    End Property


#End Region

#Region "Private variables"

    ''' <summary>
    ''' 'keep lblX as Key X as value
    ''' </summary>
    ''' <remarks></remarks>
    Private m_XLabelHash As Hashtable

    ''' <summary>
    ''' 'keep X as key lblX as value
    ''' </summary>
    ''' <remarks></remarks>
    Private m_XValueHash As Hashtable
    Private m_DisableInvalidate As Boolean
    Private m_Data As List(Of OPAlarmGraphData)
    Private m_IsDirty As Boolean

    Public ReadOnly Property Data() As List(Of OPAlarmGraphData)
        Get
            Return m_Data
        End Get
    End Property


#End Region

#Region "Public Methods"

    Sub New()
        m_XLabelHash = New Hashtable()
        m_XValueHash = New Hashtable()
        m_IsDirty = False
        m_DisableInvalidate = True
        m_WorkTime = WorkTime.Empty
        m_EnableLoadAfterWorkTimeChanged = False
        m_Data = New List(Of OPAlarmGraphData)
    End Sub

    Public Sub CollectData(ByVal alarm As Alarm)
        If m_WorkTime = WorkTime.Empty Then
            Exit Sub
        End If
        PrivateCollectData(alarm)
        If Not m_DisableInvalidate Then
            Invalidate()
        End If
    End Sub

    Public Sub LoadData(ByVal data As List(Of OPAlarmGraphData))
        If m_WorkTime = WorkTime.Empty Then
            Exit Sub
        End If
        PrepareHashTables()
        m_Data = data
        m_IsDirty = True
        If Not m_DisableInvalidate Then
            Invalidate()
        End If
    End Sub

    Public Sub BeginInit()
        m_DisableInvalidate = True
    End Sub

    Public Sub EndInit()
        m_DisableInvalidate = False
        If m_IsDirty Then
            Invalidate()
        End If
    End Sub

    Private Function GetOPAlarmGraphDataByLabel(ByVal lblText As String) As OPAlarmGraphData
        Dim ret As OPAlarmGraphData = Nothing
        For Each o As OPAlarmGraphData In m_Data
            If o.LabelX = lblText Then
                ret = o
            End If
        Next
        Return ret
    End Function

    Public Sub Invalidate()

        If Not m_IsDirty Then
            Exit Sub
        End If

        Dim currentP As HHMM = GetCurrentPeriod()
        Dim key As String = currentP.ToString()
        Dim currentX As Double = 0
        If m_XLabelHash.ContainsKey(key) Then
            currentX = DirectCast(m_XLabelHash(key), Double)
        End If
        Dim ax As Axis
        Dim sr As Series
        Dim d As OPAlarmGraphData

        If m_MTTRChart IsNot Nothing Then
            m_MTTRChart.BeginInit()
            sr = m_MTTRChart.Series(m_MTTRSeriesName)
            ax = m_MTTRChart.ChartAreas(0).AxisY2
            For Each p As DataPoint In sr.Points
                d = GetOPAlarmGraphDataByLabel(p.AxisLabel)
                p.IsEmpty = p.XValue > currentX
                If d IsNot Nothing Then
                    p.YValues(0) = d.MTTR
                    If d.MTTR > ax.Maximum Then
                        ax.Maximum = Math.Ceiling(d.MTTR)
                    End If
                End If
            Next
            ax.Maximum = Math.Ceiling(ax.Maximum / 5) * 5
            m_MTTRChart.EndInit()
        End If

        If m_OPChart IsNot Nothing Then
            m_OPChart.BeginInit()
            sr = m_OPChart.Series(m_AlarmCountSeriesName)
            ax = m_OPChart.ChartAreas(0).AxisY
            For Each p As DataPoint In sr.Points
                d = GetOPAlarmGraphDataByLabel(p.AxisLabel)
                p.IsEmpty = p.XValue > currentX
                If d IsNot Nothing Then
                    p.YValues(0) = d.AlarmCount
                    If d.AlarmCount > ax.Maximum Then
                        ax.Maximum = Math.Ceiling(d.AlarmCount)
                    End If
                End If
            Next
            ax.Maximum = Math.Ceiling(ax.Maximum / 5) * 5
            sr = m_OPChart.Series(m_DurationSeriesName)
            ax = m_OPChart.ChartAreas(0).AxisY2
            For Each p As DataPoint In sr.Points
                d = GetOPAlarmGraphDataByLabel(p.AxisLabel)
                p.IsEmpty = p.XValue > currentX
                If d IsNot Nothing Then
                    p.YValues(0) = d.Duration
                    If d.Duration > ax.Maximum Then
                        ax.Maximum = Math.Ceiling(d.Duration)
                    End If
                End If
            Next
            ax.Maximum = Math.Ceiling(ax.Maximum / 5) * 5
            m_OPChart.EndInit()
        End If
        m_IsDirty = False
    End Sub

#End Region

#Region "Private methods"

    Private Function GetCurrentPeriod() As HHMM
        Return GetPeriod(Now)
    End Function

    Private Function GetPeriod(ByVal dateTime As Date) As HHMM
        Dim ret As HHMM
        Dim h As Integer = dateTime.Hour
        Dim m As Integer = dateTime.Minute
        If m = 0 Then
            ret.Hour = h
            ret.Minute = m
        ElseIf m <= 30 Then
            ret.Hour = h
            ret.Minute = 30
        ElseIf m > 30 Then
            ret.Hour = h + 1
            ret.Minute = 0
        End If
        If ret.Hour = 24 Then
            ret.Hour = 0
        End If
        Return ret
    End Function

    Private Sub PrepareHashTables()

        Dim date1 As Date = m_WorkTime.StartTime
        Dim date2 As Date = m_WorkTime.EndTime
        Dim tmp As Date = date1
        Dim p As HHMM
        'must begin at 0 , relate with init chart 1st point begin at x = 0
        'and must be double
        Dim i As Double = 0
        Dim lblX As String
        m_XLabelHash.Clear()
        m_XValueHash.Clear()

        If m_WorkTime = WorkTime.Empty Then
            Exit Sub
        End If

        Do
            p = GetPeriod(tmp)
            lblX = p.ToString()
            m_XLabelHash.Add(lblX, i)
            m_XValueHash.Add(i, lblX)
            tmp = tmp.AddMinutes(30)
            i += 1
        Loop Until tmp > date2
    End Sub

    Private Sub OnWorktimeChanged()
        PrepareHashTables()
        If m_MTTRChart IsNot Nothing Then
            InitChart(m_MTTRChart)
        End If
        If m_OPChart IsNot Nothing Then
            InitChart(m_OPChart)
        End If
        If m_EnableLoadAfterWorkTimeChanged Then
            If m_WorkTime = WorkTime.Empty Then
                Exit Sub
            End If
            'PrivateLoadData()
        Else
            m_Data.Clear()
            m_IsDirty = True
        End If

        If Not m_DisableInvalidate Then
            Invalidate()
        End If

    End Sub

    Private Sub InitChart(ByVal c As Chart)
        c.BeginInit()
        Dim ca As ChartArea = c.ChartAreas(0)
        ca.AxisX.Maximum = m_XLabelHash.Keys.Count
        ca.AxisX.Minimum = -1
        ca.AxisY.Maximum = 10
        ca.AxisY.Minimum = 0
        ca.AxisY2.Maximum = 100
        ca.AxisY2.Minimum = 0
        Dim p1 As DataPoint
        Dim max As Double = ca.AxisX.Maximum
        Dim lblX As String
        For Each s As Series In c.Series
            s.Points.Clear()
            For i As Double = ca.AxisX.Minimum To max
                p1 = New DataPoint(i, 0)
                lblX = TryCast(m_XValueHash(i), String)
                If String.IsNullOrEmpty(lblX) Then
                    p1.AxisLabel = " "
                Else
                    p1.AxisLabel = lblX
                End If
                s.Points.Add(p1)
            Next
        Next
        c.EndInit()
        'after chart was invalidated if set IsEmpty property of all data point are True
        'there is an error occure when you change its value or change IsEmpty Property
        'then i must change IsEmpty property to True after EndInit() to hide all point when it is intialed
        c.BeginInit()
        For Each s As Series In c.Series
            For Each p As DataPoint In s.Points
                p.IsEmpty = True
            Next
        Next
        c.EndInit()
    End Sub

    Private Sub PrivateCollectData(ByVal alarm As Alarm)
        If Not alarm.ClearTime.HasValue Then
            Exit Sub
        End If
        m_IsDirty = True
        Dim p As HHMM = GetPeriod(alarm.RecordTime)
        Dim lblX As String = p.ToString()
        Dim d As OPAlarmGraphData = GetOPAlarmGraphDataByLabel(lblX)
        If d Is Nothing Then
            d = New OPAlarmGraphData()
            d.LabelX = lblX
            d.AlarmCount = 1
            d.Duration = alarm.RecordTime.Subtract(alarm.ClearTime.Value).Duration().TotalMinutes()
            m_Data.Add(d)
        Else
            d.AlarmCount += 1
            d.Duration += alarm.RecordTime.Subtract(alarm.ClearTime.Value).Duration().TotalMinutes()
        End If
        d.MTTR = d.Duration / d.AlarmCount
    End Sub

#End Region


End Class