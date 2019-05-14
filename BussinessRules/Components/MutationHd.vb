Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class MutationHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _TxnNo, _TxnDate, _InventoryTxnID, _SourceWHID, _SourceUnitID, _DestinationWHID, _DestinationUnitID, _AdjustmentReasonID, _Description As String
        Private _UserInsert, _UserUpdate, _UserApproval, _ApprovalDate, _UpdateDate, _InsertDate, _UserDelete, _DeleteDate As String
        Private _IsApproval, _IsDeleted As Boolean
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO MutationHd " & _
                                        "(TxnNo, TxnDate, InventoryTxnID, SourceWHID, SourceUnitID, DestinationWHID, DestinationUnitID, AdjustmentReasonID, Description, " & _
                                        "UserInsert, InsertDate, UserUpdate, UpdateDate, " & _
                                        "IsApproval, UserApproval, ApprovalDate, IsDeleted, UserDelete, DeleteDate) " & _
                                        "VALUES (@TxnNo, @TxnDate, @InventoryTxnID, @SourceWHID, @SourceUnitID, @DestinationWHID, @DestinationUnitID, @AdjustmentReasonID, @Description, " & _
                                        "@UserInsert, getdate(), @UserUpdate, getdate(), " & _
                                        "0, '', '', 0, '', '')"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@TxnNo", _TxnNo)
                cmdToExecute.Parameters.Add("@TxnDate", _TxnDate)
                cmdToExecute.Parameters.Add("@InventoryTxnID", _InventoryTxnID)
                cmdToExecute.Parameters.Add("@SourceWHID", _SourceWHID)
                cmdToExecute.Parameters.Add("@SourceUnitID", _SourceUnitID)
                cmdToExecute.Parameters.Add("@DestinationWHID", _DestinationWHID)
                cmdToExecute.Parameters.Add("@DestinationUnitID", _DestinationUnitID)
                cmdToExecute.Parameters.Add("@AdjustmentReasonID", _AdjustmentReasonID)
                cmdToExecute.Parameters.Add("@Description", _Description)
                cmdToExecute.Parameters.Add("@UserInsert", _UserInsert)
                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Overrides Function Update() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE MutationHd " & _
                                        "SET TxnDate = @TxnDate, " & _
                                        "InventoryTxnID = @InventoryTxnID, " & _
                                        "SourceWHID = @SourceWHID, " & _
                                        "SourceUnitID = @SourceUnitID, " & _
                                        "DestinationWHID = @DestinationWHID, " & _
                                        "DestinationUnitID = @DestinationUnitID, " & _
                                        "AdjustmentReasonID = @AdjustmentReasonID, " & _
                                        "Description = @Description, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = getdate() " & _
                                        "WHERE TxnNo = @TxnNo"

            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@TxnNo", _TxnNo)
                cmdToExecute.Parameters.Add("@TxnDate", _TxnDate)
                cmdToExecute.Parameters.Add("@InventoryTxnID", _InventoryTxnID)
                cmdToExecute.Parameters.Add("@SourceWHID", _SourceWHID)
                cmdToExecute.Parameters.Add("@SourceUnitID", _SourceUnitID)
                cmdToExecute.Parameters.Add("@DestinationWHID", _DestinationWHID)
                cmdToExecute.Parameters.Add("@DestinationUnitID", _DestinationUnitID)
                cmdToExecute.Parameters.Add("@AdjustmentReasonID", _AdjustmentReasonID)
                cmdToExecute.Parameters.Add("@Description", _Description)
                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Overrides Function SelectAll() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT * FROM MutationHd order by TxnNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("MutationHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                _mainConnection.Open()

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

        Public Function SelectAllForTxnNo(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " *,convert(varchar(10),TxnDate,105) as formatdate, " & _
                                       "(Case When IsApproval = 1 then 'Approved' else '' end) as Status FROM MutationHd " & _
                                       "Where IsDeleted = 0 and InventoryTxnID = @InventoryTxnID and (TxnNo LIKE '" + Filter.Trim + "%' OR convert(varchar(10),TxnDate,105) LIKE '" + Filter.Trim + "%') " & _
                                       "order by TxnNo desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("MutationHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@InventoryTxnID", _InventoryTxnID)
                _mainConnection.Open()

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

        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Select Case recStatus
                Case RavenRecStatus.CurrentRecord
                    cmdToExecute.CommandText = "SELECT * FROM MutationHd WHERE TxnNo = @TxnNo and InventoryTxnID = @InventoryTxnID and IsDeleted = 0 "
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM MutationHd WHERE TxnNo > @TxnNo and InventoryTxnID = @InventoryTxnID and IsDeleted = 0 ORDER BY TxnNo ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM MutationHd WHERE TxnNo < @TxnNo and InventoryTxnID = @InventoryTxnID and IsDeleted = 0 ORDER BY TxnNo DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("MutationHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@InventoryTxnID", _InventoryTxnID)
                cmdToExecute.Parameters.Add("@TxnNo", _TxnNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _TxnNo = CType(toReturn.Rows(0)("TxnNo"), String)
                    _TxnDate = CType(toReturn.Rows(0)("TxnDate"), DateTime)
                    _InventoryTxnID = CType(toReturn.Rows(0)("InventoryTxnID"), String)

                    _SourceWHID = CType(toReturn.Rows(0)("SourceWHID"), String)
                    _SourceUnitID = CType(toReturn.Rows(0)("SourceUnitID"), String)

                    _DestinationWHID = CType(toReturn.Rows(0)("DestinationWHID"), String)
                    _DestinationUnitID = CType(toReturn.Rows(0)("DestinationUnitID"), String)
                    _AdjustmentReasonID = CType(toReturn.Rows(0)("AdjustmentReasonID"), String)
                    _Description = CType(toReturn.Rows(0)("Description"), String)

                    _IsApproval = CType(toReturn.Rows(0)("IsApproval"), Boolean)
                    _UserApproval = CType(toReturn.Rows(0)("UserApproval"), String)
                    _ApprovalDate = CType(toReturn.Rows(0)("ApprovalDate"), DateTime)
                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)

                    _IsDeleted = CType(toReturn.Rows(0)("IsDeleted"), Boolean)
                    _UserDelete = CType(toReturn.Rows(0)("UserDelete"), String)
                    _DeleteDate = CType(toReturn.Rows(0)("DeleteDate"), DateTime)
                End If

                Return toReturn
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

        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "Update MutationHd " & _
                                       "Set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = Getdate() " & _
                                       "WHERE TxnNo = @TxnNo"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@TxnNo", _TxnNo)
                cmdToExecute.Parameters.Add("@UserDelete", _UserDelete)

                ' //Open Connection
                _mainConnection.Open()

                ' //Execute Query
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

#Region " Custom function "
        Public Function SelectBySTXnNo(ByVal InventoryTxnID As String, ByVal TransactionDateFrom As String, ByVal TransactionDateTo As String, ByVal stxnNoFrom As String, ByVal stxnNoTo As String, Optional ByVal MaxRecord As String = "500", Optional ByVal CurrentUser As String = "") As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            If Not stxnNoFrom = String.Empty AndAlso Not stxnNoTo = String.Empty Then
                cmdToExecute.CommandText = "SELECT TOP " + MaxRecord.Trim() + " TxnNo,TxnDate, case when IsApproval = 1 then 'Approved' else '' end as Status" +
                                           "FROM MutationHd WHERE IsDeleted = 0 TxnNo >= @txnNoFrom AND " +
                                           "TxnNo <= @txnNoTo AND Convert(varchar(8),TxnDate,112) >= " + TransactionDateFrom.Trim + _
                                           " AND Convert(varchar(8),TxnDate,112) <= " + TransactionDateTo.Trim + _
                                           " AND InventoryTxnID <= " + InventoryTxnID.Trim + _
                                           IIf(CurrentUser.Trim() <> "", " AND UserUpdate = '" + CurrentUser.Trim() + "' ", "") +
                                           " ORDER BY TxnNo desc"
            ElseIf Not stxnNoFrom = String.Empty Then
                cmdToExecute.CommandText = "SELECT TOP " + MaxRecord.Trim() + " TxnNo,TxnDate, case when IsApproval = 1 then 'Approved' else '' end as Status " +
                                           "FROM MutationHd WHERE IsDeleted = 0 TxnNo like '%' + @txnNoFrom + '%' " +
                                           " AND Convert(varchar(8),TxnDate,112) >= " + TransactionDateFrom.Trim + _
                                           " AND Convert(varchar(8),TxnDate,112) <= " + TransactionDateTo.Trim + _
                                           " AND InventoryTxnID <= " + InventoryTxnID.Trim + _
                                           IIf(CurrentUser.Trim() <> "", " AND UserUpdate = '" + CurrentUser.Trim() + "' ", "") +
                                           " ORDER BY TxnNo desc"
            Else
                cmdToExecute.CommandText = "SELECT TOP " + MaxRecord.Trim() + " TxnNo,TxnDate, case when IsApproval = 1 then 'Approved' else '' end as Status " +
                                           "FROM MutationHd WHERE IsDeleted = 0 " +
                                           " AND Convert(varchar(8),TxnDate,112) >= " + TransactionDateFrom.Trim + _
                                           " AND Convert(varchar(8),TxnDate,112) <= " + TransactionDateTo.Trim + _
                                           " AND InventoryTxnID <= " + InventoryTxnID.Trim + _
                                           IIf(CurrentUser.Trim() <> "", " AND UserUpdate = '" + CurrentUser.Trim() + "' ", "") +
                                           " ORDER BY TxnNo desc "
            End If
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("MutationHD")
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
#End Region

#Region " Class Property Declarations "
        Public Property [TxnNo]() As String
            Get
                Return _TxnNo
            End Get
            Set(ByVal Value As String)
                _TxnNo = Value
            End Set
        End Property

        Public Property [TxnDate]() As DateTime
            Get
                Return _TxnDate
            End Get
            Set(ByVal Value As DateTime)
                _TxnDate = Value
            End Set
        End Property

        Public Property [InventoryTxnID]() As String
            Get
                Return _InventoryTxnID
            End Get
            Set(ByVal Value As String)
                _InventoryTxnID = Value
            End Set
        End Property

        Public Property [SourceWHID]() As String
            Get
                Return _SourceWHID
            End Get
            Set(ByVal Value As String)
                _SourceWHID = Value
            End Set
        End Property

        Public Property [SourceUnitID]() As String
            Get
                Return _SourceUnitID
            End Get
            Set(ByVal Value As String)
                _SourceUnitID = Value
            End Set
        End Property

        Public Property [DestinationWHID]() As String
            Get
                Return _DestinationWHID
            End Get
            Set(ByVal Value As String)
                _DestinationWHID = Value
            End Set
        End Property

        Public Property [DestinationUnitID]() As String
            Get
                Return _DestinationUnitID
            End Get
            Set(ByVal Value As String)
                _DestinationUnitID = Value
            End Set
        End Property

        Public Property [AdjustmentReasonID]() As String
            Get
                Return _AdjustmentReasonID
            End Get
            Set(ByVal Value As String)
                _AdjustmentReasonID = Value
            End Set
        End Property

        Public Property [Description]() As String
            Get
                Return _Description
            End Get
            Set(ByVal Value As String)
                _Description = Value
            End Set
        End Property

        Public Property [IsApproval]() As Boolean
            Get
                Return _IsApproval
            End Get
            Set(ByVal Value As Boolean)
                _IsApproval = Value
            End Set
        End Property

        Public Property [UserApproval]() As String
            Get
                Return _UserApproval
            End Get
            Set(ByVal Value As String)
                _UserApproval = Value
            End Set
        End Property

        Public Property [ApprovalDate]() As DateTime
            Get
                Return _ApprovalDate
            End Get
            Set(ByVal Value As DateTime)
                _ApprovalDate = Value
            End Set
        End Property

        Public Property [UserInsert]() As String
            Get
                Return _UserInsert
            End Get
            Set(ByVal Value As String)
                _UserInsert = Value
            End Set
        End Property


        Public Property [InsertDate]() As DateTime
            Get
                Return _InsertDate
            End Get
            Set(ByVal Value As DateTime)
                _InsertDate = Value
            End Set
        End Property

        Public Property [UpdateDate]() As DateTime
            Get
                Return _UpdateDate
            End Get
            Set(ByVal Value As DateTime)
                _UpdateDate = Value
            End Set
        End Property

        Public Property [UserUpdate]() As String
            Get
                Return _UserUpdate
            End Get
            Set(ByVal Value As String)
                _UserUpdate = Value
            End Set
        End Property

        Public Property [UserDelete]() As String
            Get
                Return _UserDelete
            End Get
            Set(ByVal Value As String)
                _UserDelete = Value
            End Set
        End Property

#End Region
    End Class
End Namespace