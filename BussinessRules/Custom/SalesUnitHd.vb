Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Partial Public Class SalesUnitHd
        Public Function GetNewNo() As String
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "dbo.[usp_SalesUnitHd_GetNewNo]"
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
        Public Function SelectBySTXnNo(ByVal TransactionDateFrom As String, ByVal TransactionDateTo As String, ByVal stxnNoFrom As String, ByVal stxnNoTo As String, Optional ByVal MaxRecord As String = "500", Optional ByVal CurrentUser As String = "") As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            If Not stxnNoFrom = String.Empty AndAlso Not stxnNoTo = String.Empty Then
                cmdToExecute.CommandText = "SELECT TOP " + MaxRecord.Trim() + " STxnNo,STxnDate, " +
                                           "isnull((select top 1 DetailDesc from commonsetting cs " +
                                                    "where cs.groupID = 'STxnStatus' and cs.DetailID = STxnStatusID),'') as Status " + _
                                           "FROM SalesUnitHd WHERE STxnNo >= @sStxnNoFrom AND " +
                                           "STxnNo <= @sStxnNoTo AND Convert(varchar(8),STxnDate,112) >= " + TransactionDateFrom.Trim + _
                                           " AND Convert(varchar(8),STxnDate,112) <= " + TransactionDateTo.Trim + _
                                           IIf(CurrentUser.Trim() <> "", " AND UserUpdate = '" + CurrentUser.Trim() + "' ", "") +
                                           " ORDER BY STxnNo desc"
            ElseIf Not stxnNoFrom = String.Empty Then
                cmdToExecute.CommandText = "SELECT TOP " + MaxRecord.Trim() + " STxnNo,STxnDate, " +
                                           "isnull((select top 1 DetailDesc from commonsetting cs " +
                                                    "where cs.groupID = 'STxnStatus' and cs.DetailID = STxnStatusID),'') as Status " +
                                           "FROM SalesUnitHd WHERE STxnNo like '%' + @sStxnNoFrom + '%' " +
                                           " AND Convert(varchar(8),STxnDate,112) >= " + TransactionDateFrom.Trim + _
                                           " AND Convert(varchar(8),STxnDate,112) <= " + TransactionDateTo.Trim + _
                                           IIf(CurrentUser.Trim() <> "", " AND UserUpdate = '" + CurrentUser.Trim() + "' ", "") +
                                           " ORDER BY STxnNo desc"
            Else
                cmdToExecute.CommandText = "SELECT TOP " + MaxRecord.Trim() + " STxnNo,STxnDate, " +
                                           "isnull((select top 1 DetailDesc from commonsetting cs " +
                                                    "where cs.groupID = 'STxnStatus' and cs.DetailID = STxnStatusID),'') as Status " +
                                           "FROM SalesUnitHd WHERE STxnNo = STxnNo " +
                                           " AND Convert(varchar(8),STxnDate,112) >= " + TransactionDateFrom.Trim + _
                                           " AND Convert(varchar(8),STxnDate,112) <= " + TransactionDateTo.Trim + _
                                           IIf(CurrentUser.Trim() <> "", " AND UserUpdate = '" + CurrentUser.Trim() + "' ", "") +
                                           " ORDER BY STxnNo desc "
            End If
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Sales")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                _mainConnection.Open()
                cmdToExecute.Parameters.AddWithValue("@sStxnNoFrom", stxnNoFrom)
                cmdToExecute.Parameters.AddWithValue("@sStxnNoTo", stxnNoTo)
                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function
        Public Function SelectSTXnNoByUserID(ByVal UserID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT STxnNo,STxnDate, STxnStatusID, isnull((select top 1 DetailDesc from commonsetting cs where cs.groupID = 'STxnStatus' and cs.DetailID = STxnStatusID),'') as Status FROM SalesUnitHd WHERE convert(varchar(8),UpdateDate,112) <= convert(varchar(8),Getdate(),112) And UserUpdate = @UserID "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Sales")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                _mainConnection.Open()
                cmdToExecute.Parameters.AddWithValue("@UserID", UserID)
                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function
        Public Function ResetDonationAmount(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Boolean
            Dim retval As Boolean = False
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "dbo.[usp_SalesUnitHd_ResetDonationAmount]"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            cmdToExecute.Connection = conn
            If (trans IsNot Nothing) Then
                cmdToExecute.Transaction = trans
            End If

            Try
                cmdToExecute.Parameters.AddWithValue("@sSTxnNo", _STxnNo)
                cmdToExecute.Parameters.AddWithValue("@sUserUpdate", _UserUpdate)
                
                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()
                retval = True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                cmdToExecute.Dispose()
            End Try
            Return retval
        End Function

        Public Function SelectByEntitiesSeqNoLastSTXnNo(ByVal EntitiesSeqNo As String, Optional ByVal MaxRecord As Integer = 10) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT suh.EntitiesSeqNo, isnull(e.EntitiesID,'') AS EntitiesID, isnull(e.EntitiesName,'') AS EntitiesName, suh.StxnDate as TransactionDate, SUH.STxnNo, " & _
                                        "sum(sud.Qty * (sud.Price - (sud.Disc1Amt + sud.Disc2Amt + sud.Disc3Amt))) AS TotalTransactionAmount " & _
                                        "FROM " & _
                                        "(SELECT TOP (@MaxRecord) * from SalesUnitHd " & _
                                        "WHERE IsDeleted = 0 AND STxnStatusID = 'C' " & _
                                        "AND EntitiesSeqNo = @EntitiesSeqNo " & _
                                        "ORDER BY STxnNo DESC) suh " & _
                                        "INNER JOIN SalesUnitDt sud ON sud.STxnNo = suh.STxnNo " & _
                                        "LEFT JOIN Entities e ON e.EntitiesSeqNo = suh.EntitiesSeqNo " & _
                                        "WHERE sud.IsDeleted = 0 " & _
                                        "GROUP BY suh.EntitiesSeqNo,e.EntitiesID,e.EntitiesName,suh.StxnDate,SUH.STxnNo " & _
                                        "order BY SUH.STxnNo desc "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Sales")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                _mainConnection.Open()
                cmdToExecute.Parameters.AddWithValue("@MaxRecord", MaxRecord)
                cmdToExecute.Parameters.AddWithValue("@EntitiesSeqNo", EntitiesSeqNo)
                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function
    End Class
End Namespace