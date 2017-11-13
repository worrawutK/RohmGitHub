Public Class IE
    Private Sub New()
    End Sub

    Public Shared Sub OpenUrl(ByVal url As String)
        Using p As Process = Process.Start(My.Settings.InternetExplorerProgramFileName, url)
            p.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
        End Using
    End Sub

End Class
