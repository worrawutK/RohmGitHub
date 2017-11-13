Imports System.Net
Imports System.IO

Public Class HttpDownload

    Private Sub New()
    End Sub

    Public Shared Function GetImageFromUrl(ByVal url As String) As Image
        Dim ret As Image
        If String.IsNullOrEmpty(url) Then
            ret = My.Resources.noimage
            GoTo LBL001
        End If
        Try
            Using wc As WebClient = New WebClient()
                Dim byteData As Byte() = wc.DownloadData(url)
                Using ms As MemoryStream = New MemoryStream(byteData)
                    ret = Image.FromStream(ms)
                End Using
            End Using
        Catch ex As Exception
            ret = My.Resources.noimage
        End Try
LBL001:
        Return ret
    End Function


End Class
