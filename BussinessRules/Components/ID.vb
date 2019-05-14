Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class ID
        Inherits BRInteractionBase

#Region " Class Member Declarations "

#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " Function Global "
        Public Shared Function GetHashStringSQL(ByVal Password As String, Optional ByVal TypeHashString As String = "SHA1") As String
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim _mainConnection As SqlConnection = New SqlConnection(HisConfiguration.ConnectionString)
            cmdToExecute.CommandText = "sp_GetHashStringSQL"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("GetHashStringFromSQL")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@TypeHashString", TypeHashString)
                cmdToExecute.Parameters.Add("@Password", Password)
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                Return Common.ProcessNull.GetString(toReturn.Rows(0)("EncriptionPassword"))
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Shared Function GetDateDBServer() As DateTime
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim _mainConnection As SqlConnection = New SqlConnection(HisConfiguration.ConnectionString)
            cmdToExecute.CommandText = "select getdate() as getdate"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("GetDateFromServer")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                Return Common.ProcessNull.GetDateTime(toReturn.Rows(0)("getdate"))
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function


        Public Shared Function GenerateIDNumber(ByVal TableName As String, ByVal ColumnName As String, Optional ByVal Prefix As String = "", Optional ByVal TextFilterForIDMax As String = "") As String
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim _mainConnection As SqlConnection = New SqlConnection(HisConfiguration.ConnectionString)
            cmdToExecute.CommandText = _
            "declare @IDMax VARCHAR(15), " & _
            "@prefix varchar(4), " & _
            "@PrefixLength int, " & _
            "@IDLength int, " & _
            "@ColumnMaxLength int, " & _
            "@Zero varchar(50) " & _
            "SET @prefix = '" + Prefix.Trim + "' " & _
            "SET @Zero = '' " & _
            "SET @PrefixLength = len(ltrim(rtrim(@prefix))) " & _
            "SET @ColumnMaxLength = (SELECT Character_Maximum_Length FROM INFORMATION_SCHEMA.Columns WHERE table_name = '" + TableName.Trim + "' AND column_name = '" + ColumnName.Trim + "') " & _
            "SET @IDLength = @ColumnMaxLength - @PrefixLength - 8 " & _
            "WHILE len(@Zero) < @IDLength " & _
            "BEGIN " & _
             "SET @Zero = @Zero + '0' " & _
            "End " & _
            "select @IDMax= isnull(max(" + ColumnName.Trim + "),0) FROM " + TableName.Trim + " " + IIf(TextFilterForIDMax.Trim = "", "", TextFilterForIDMax.Trim) & _
            "if @PrefixLength = 0 " & _
            "begin " & _
                "if isnumeric(left(@IDMax,@PrefixLength)) = 0 " & _
                    "set @IDMax = right(@IDMax,(@ColumnMaxLength - @PrefixLength)) " & _
                "SELECT " & _
                "(CASE " & _
                    "WHEN convert(varchar(8),getdate(),112) = LEFT(@IDMax,8) THEN " & _
                        "(convert(varchar(8),getdate(),112) + right((@Zero + cast((cast(right(@IDMax,@IDLength) as int) + 1)as varchar)),@IDLength)) " & _
                    "ELSE " & _
                        "(convert(varchar(8),getdate(),112) + right(@Zero,@IDLength)) " & _
                "END) as ID " & _
            "End " & _
            "else " & _
            "begin " & _
                "set @IDMax = right(@IDMax,(@ColumnMaxLength - @PrefixLength)) " & _
                "SELECT " & _
                "(CASE " & _
                    "WHEN convert(varchar(8),getdate(),112) = LEFT(@IDMax,8) THEN " & _
                        "@prefix + (convert(varchar(8),getdate(),112) + right((@Zero + cast((cast(right(@IDMax,@IDLength) as int) + 1)as varchar)),@IDLength)) " & _
                    "ELSE " & _
                        "@prefix + (convert(varchar(8),getdate(),112) + right(@Zero,@IDLength)) " & _
                "END) as ID " & _
            "End "
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("GenerateIDNumber")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                Return CType(Common.ProcessNull.GetString(toReturn.Rows(0)("ID")), String)
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Shared Function GenerateIDNumberWithBeginTransaction(ByVal TableName As String, ByVal ColumnName As String, _
                                                                    ByVal conn As SqlConnection, _
                                                                    ByVal Trans As SqlTransaction, _
                                                                    Optional ByVal Prefix As String = "", _
                                                                    Optional ByVal TextFilterForIDMax As String = "") As String
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim _mainConnection As SqlConnection = New SqlConnection(HisConfiguration.ConnectionString)
            cmdToExecute.CommandText = _
            "declare @IDMax VARCHAR(15), " & _
            "@prefix varchar(4), " & _
            "@PrefixLength int, " & _
            "@IDLength int, " & _
            "@ColumnMaxLength int, " & _
            "@Zero varchar(50) " & _
            "SET @prefix = '" + Prefix.Trim + "' " & _
            "SET @Zero = '' " & _
            "SET @PrefixLength = len(ltrim(rtrim(@prefix))) " & _
            "SET @ColumnMaxLength = (SELECT Character_Maximum_Length FROM INFORMATION_SCHEMA.Columns WHERE table_name = '" + TableName.Trim + "' AND column_name = '" + ColumnName.Trim + "') " & _
            "SET @IDLength = @ColumnMaxLength - @PrefixLength - 8 " & _
            "WHILE len(@Zero) < @IDLength " & _
            "BEGIN " & _
             "SET @Zero = @Zero + '0' " & _
            "End " & _
            "select @IDMax= isnull(max(" + ColumnName.Trim + "),0) FROM " + TableName.Trim + " " + IIf(TextFilterForIDMax.Trim = "", "", TextFilterForIDMax.Trim) & _
            "if @PrefixLength = 0 " & _
            "begin " & _
                "if isnumeric(left(@IDMax,@PrefixLength)) = 0 " & _
                    "set @IDMax = right(@IDMax,(@ColumnMaxLength - @PrefixLength)) " & _
                "SELECT " & _
                "(CASE " & _
                    "WHEN convert(varchar(8),getdate(),112) = LEFT(@IDMax,8) THEN " & _
                        "(convert(varchar(8),getdate(),112) + right((@Zero + cast((cast(right(@IDMax,@IDLength) as int) + 1)as varchar)),@IDLength)) " & _
                    "ELSE " & _
                        "(convert(varchar(8),getdate(),112) + right(@Zero,@IDLength)) " & _
                "END) as ID " & _
            "End " & _
            "else " & _
            "begin " & _
                "set @IDMax = right(@IDMax,(@ColumnMaxLength - @PrefixLength)) " & _
                "SELECT " & _
                "(CASE " & _
                    "WHEN convert(varchar(8),getdate(),112) = LEFT(@IDMax,8) THEN " & _
                        "@prefix + (convert(varchar(8),getdate(),112) + right((@Zero + cast((cast(right(@IDMax,@IDLength) as int) + 1)as varchar)),@IDLength)) " & _
                    "ELSE " & _
                        "@prefix + (convert(varchar(8),getdate(),112) + right(@Zero,@IDLength)) " & _
                "END) as ID " & _
            "End "
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("GenerateIDNumber")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = conn
            cmdToExecute.Transaction = Trans

            Try
                cmdToExecute.ExecuteNonQuery()

                ' // Execute query.
                adapter.Fill(toReturn)

                Return CType(Common.ProcessNull.GetString(toReturn.Rows(0)("ID")), String)
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function
#End Region
        


#Region " Class Property Declarations "

#End Region

    End Class
End Namespace
