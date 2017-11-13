Imports System.IO
Imports Rohm
Imports System.ComponentModel
Imports System.Runtime.InteropServices 'for DLLImport
Imports System.Net
Imports System.ServiceModel

Module ModGlobal

    Private m_Hash1 As Hashtable
    'use to check output pieces match with value of the array below
    Public YIELD_MONITOR_OUTPUTS As Integer() = {100, 500, 1000, 2000, 3000, 5000, 7000, 9000, 12000, 15000, 18000}
    Public Function MatchCaptureCondition(ByVal output As Integer) As Boolean
        Return m_Hash1.ContainsKey(output)
    End Function

    Private m_SelfConIP As String
    Public Property SelfConIP() As String
        Get
            Return m_SelfConIP
        End Get
        Set(ByVal value As String)
            m_SelfConIP = value
        End Set
    End Property

    Sub New()
        m_Hash1 = New Hashtable()
        For Each value As Integer In YIELD_MONITOR_OUTPUTS
            m_Hash1.Add(value, value)
        Next
    End Sub

    Public Function WorkRecordIsNotComplete(ByVal row As DBxDataSet.FTDataRow) As Boolean
        Return row.IsEndOPNoNull() OrElse _
            row.IsFirstGoodBin1QtyNull() OrElse _
            row.IsFirstGoodBin2QtyNull() OrElse _
            row.IsFirstNGQtyNull() OrElse _
            row.IsFirstMeka1QtyNull() OrElse _
            row.IsFirstMeka2QtyNull() OrElse _
            row.IsFirstUnknowQtyNull() OrElse _
            row.IsSecondGoodBin1QtyNull() OrElse _
            row.IsSecondGoodBin2QtyNull() OrElse _
            row.IsSecondNGQtyNull() OrElse _
            row.IsSecondMeka1QtyNull() OrElse _
            row.IsSecondMeka4QtyNull() OrElse _
            row.IsSecondUnknowQtyNull() OrElse _
            row.IsTotalGoodBin1QtyNull() OrElse _
            row.IsTotalGoodBin2QtyNull() OrElse _
            row.IsTotalNGQtyNull() OrElse _
            row.IsTotalMeka1QtyNull() OrElse _
            row.IsTotalMeka2QtyNull() OrElse _
            row.IsTotalMeka4QtyNull() OrElse _
            row.IsTotalUnknowQtyNull() OrElse _
            row.IsHandlerCounterQtyNull() OrElse _
            row.IsTesterACounterQtyNull() OrElse _
            row.IsTesterBCounterQtyNull() OrElse _
            row.IsTestTemperatureNull() OrElse _
            (row.IsChannelATesterNoNull() AndAlso row.IsChannelBTesterNoNull()) OrElse _
            row.IsMarkingInspectionNull() OrElse _
            row.IsLotStartVisualInspectNGQtyNull() OrElse _
            row.IsLotStartVisualInspectTotalQtyNull() OrElse _
            row.IsLotEndVisualInspectNGQtyNull() OrElse _
            row.IsLotEndVisualInspectTotalQtyNull() OrElse _
            row.IsDuringProductionCheckNull() OrElse _
            row.IsInitialYieldNull() OrElse _
            row.IsFirstEndYieldNull() OrElse _
            row.IsFinalYieldNull() OrElse _
            (row.IsChannelATestBoxNoNull() AndAlso row.IsChannelBTestBoxNoNull()) OrElse _
            row.IsFirstAutoAsiCheckNull() OrElse _
            row.IsSecondAutoAsiCheckNull() OrElse _
            row.IsSocketCheckNull() OrElse _
            row.IsSocketChangeNull() OrElse _
            row.IsGoodSampleQtyNull() OrElse _
            row.IsNGSampleQtyNull() OrElse _
            row.IsLotJudgementNull()
    End Function

End Module
