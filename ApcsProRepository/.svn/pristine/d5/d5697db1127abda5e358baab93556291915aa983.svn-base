
Public Class Formatter

    Public Shared Function Format(ByVal timeSpan As TimeSpan) As String
        Dim ret As String = timeSpan.Days.ToString() & " Day(s) " & timeSpan.Hours.ToString("D2") & ":" & timeSpan.Minutes.ToString("D2") & ":" & timeSpan.Seconds.ToString("D2")
        Return ret
    End Function

    Public Shared Function Format2(ByVal timeSpan As TimeSpan) As String
        Dim ret As String = CInt(Math.Floor(timeSpan.TotalHours)).ToString("D2") & ":" & timeSpan.Minutes.ToString("D2") & ":" & timeSpan.Seconds.ToString("D2")
        Return ret
    End Function

End Class
