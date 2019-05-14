Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Partial Public Class PaymentHd
        Public Function GetNewNo() As String
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "usp_PaymentHd_GetNewNo"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                ' // Open connection.
                _mainConnection.Open()
                Dim dtb As DataTable = New DataTable("dtb")
                ' // Execute query.
                adapter.Fill(dtb)

                Return dtb.Rows(0)(0).ToString
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
            Return Nothing
        End Function

        Public Function LoadBySTxnNo(ByVal stxnNo As String) As Boolean

            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT TOP 1 a.* FROM PaymentHd a WHERE a.STxnNo = @STxnNo and a.IsVoid = 0"

            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("payment")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)
            Dim retval As Boolean = False
            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@STxnNo", stxnNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _ReceiptNo = CType(ProcessNull.GetString(toReturn.Rows(0)("ReceiptNo")), String)
                    _STxnNo = CType(toReturn.Rows(0)("STxnNo"), String)
                    _ReceiptDate = CType(toReturn.Rows(0)("ReceiptDate"), DateTime)
                    _Rounding = CType(toReturn.Rows(0)("Rounding"), Decimal)
                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
                    _IsVoid = CType(toReturn.Rows(0)("IsVoid"), Boolean)
                    _UserVoid = CType(toReturn.Rows(0)("UserVoid"), String)
                    _VoidDate = CType(toReturn.Rows(0)("VoidDate"), DateTime)
                    _Description = CType(toReturn.Rows(0)("Description"), String)

                    retval = True
                End If

            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
            Return retval
        End Function

       
    End Class
End Namespace