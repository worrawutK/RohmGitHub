Imports System.Data.SqlClient

Module DBAccess

    Public Function ExecuteScalar(ByVal strSQL As String) As Object
        Return ExecuteScalar(strSQL, Nothing)
    End Function

    Public Function ExecuteScalar(ByVal strSQL As String, ByVal ParamArray params As SqlParameter()) As Object
        Dim ret As Object = 0
        Using con As SqlConnection = New SqlConnection()
            con.ConnectionString = My.Settings.DBxConnectionString
            Using cmd As SqlCommand = New SqlCommand()
                con.Open()
                cmd.Connection = con
                cmd.CommandText = strSQL
                If params IsNot Nothing Then
                    For Each p As SqlParameter In params
                        cmd.Parameters.Add(p)
                    Next
                End If
                ret = cmd.ExecuteScalar()
                cmd.Parameters.Clear()
            End Using
        End Using
        Return ret
    End Function

    Public Function ExecuteDataTable(ByVal strSQL As String) As DataTable
        Return ExecuteDataTable(strSQL, Nothing)
    End Function

    Public Function ExecuteDataTable(ByVal strSQL As String, ByVal ParamArray params As SqlParameter()) As DataTable
        Dim dt As DataTable = New DataTable()
        Using con As SqlConnection = New SqlConnection()
            con.ConnectionString = My.Settings.DBxConnectionString
            Using cmd As SqlCommand = New SqlCommand()
                con.Open()
                cmd.Connection = con
                cmd.CommandText = strSQL
                If params IsNot Nothing Then
                    For Each p As SqlParameter In params
                        cmd.Parameters.Add(p)
                    Next
                End If
                dt.Load(cmd.ExecuteReader())
                cmd.Parameters.Clear()
            End Using
        End Using
        Return dt
    End Function

    Public Function ExecuteNoneQuery(ByVal strSQl As String, ByVal ParamArray params() As SqlParameter) As Integer
        Dim ret As Integer = 0
        Using con As SqlConnection = New SqlConnection()
            con.ConnectionString = My.Settings.DBxConnectionString
            con.Open()
            Using cmd As SqlCommand = New SqlCommand()
                cmd.Connection = con
                cmd.CommandText = strSQl
                If params IsNot Nothing Then
                    For Each p As SqlParameter In params
                        cmd.Parameters.Add(p)
                    Next
                End If
                ret = cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
            End Using
        End Using
        Return ret
    End Function

End Module
