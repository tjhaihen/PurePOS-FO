Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class MutationDt
        Inherits BRInteractionBase
#Region " Class Member Declarations "
        Private _ID, _TxnNo, _ItemSeqNo, _ItemUnitID, _ItemFactor, _PlusOrMinus, _InventoryTxnID As String
        Private _Qty As Decimal
        Private _UserInsert, _UserUpdate, _UserDelete As String
        Private _InsertDate, _UpdateDate, _DeleteDate As String
        Private _IsDeleted As Boolean
        Private _Ex As Exception
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO Mutationdt " & _
                                       "(ID, TxnNo, ItemSeqNo, ItemUnitID, ItemFactor, Qty, PlusOrMinus, " & _
                                       "UserInsert, InsertDate, UserUpdate, UpdateDate, UserDelete, DeleteDate, IsDeleted) " & _
                                       "VALUES (@ID, @TxnNo, @ItemSeqNo, @ItemUnitID, @ItemFactor, ABS(@Qty), (Case When @Qty < 0 then '-' else '+' end), " & _
                                       "@UserInsert, getdate(), @UserUpdate, getdate(), '', '', 0) "
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@TxnNo", _TxnNo)
                cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.Add("@ItemUnitID", _ItemUnitID)
                cmdToExecute.Parameters.Add("@ItemFactor", _ItemFactor)
                cmdToExecute.Parameters.Add("@Qty", _Qty)
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

            cmdToExecute.CommandText = "UPDATE Mutationdt " & _
                                        "SET TxnNo = @TxnNo, " & _
                                        "ItemSeqNo = @ItemSeqNo, " & _
                                        "ItemUnitID = @ItemUnitID, " & _
                                        "ItemFactor = @ItemFactor, " & _
                                        "Qty = @Qty, " & _
                                        "PlusOrMinus = (Case When @Qty < 0 then '-' else '+' end), " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate() " & _
                                        "WHERE ID = @ID"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@TxnNo", _TxnNo)
                cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.Add("@ItemUnitID", _ItemUnitID)
                cmdToExecute.Parameters.Add("@ItemFactor", _ItemFactor)
                cmdToExecute.Parameters.Add("@Qty", _Qty)
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

            cmdToExecute.CommandText = "SELECT * FROM Mutationdt where IsDeleted = 0 order by ID desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Mutationdt")
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

        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Select Case recStatus
                Case RavenRecStatus.CurrentRecord
                    cmdToExecute.CommandText = "SELECT dt.* FROM Mutationdt dt WHERE dt.ID = @ID and (select hd.InventoryTxnID from MutationHd hd where TxnNo = dt.TxnNo) = @InventoryTxnID and dt.IsDeleted = 0 "
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT dt.* FROM Mutationdt dt WHERE dt.ID > @ID and (select hd.InventoryTxnID from MutationHd hd where TxnNo = dt.TxnNo) = @InventoryTxnID and dt.IsDeleted = 0 ORDER BY dt.ID ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT dt.* FROM Mutationdt dt WHERE dt.ID < @ID and (select hd.InventoryTxnID from MutationHd hd where TxnNo = dt.TxnNo) = @InventoryTxnID and dt.IsDeleted = 0 ORDER BY dt.ID DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("Mutationdt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@InventoryTxnID", _InventoryTxnID)
                cmdToExecute.Parameters.Add("@ID", _ID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _ID = CType(toReturn.Rows(0)("ID"), String)
                    _TxnNo = CType(toReturn.Rows(0)("TxnNo"), String)
                    _ItemSeqNo = CType(toReturn.Rows(0)("ItemSeqNo"), String)
                    _ItemUnitID = CType(toReturn.Rows(0)("ItemUnitID"), String)
                    _ItemFactor = CType(toReturn.Rows(0)("ItemFactor"), Decimal)
                    _Qty = CType(toReturn.Rows(0)("Qty"), Decimal)
                    _PlusOrMinus = CType(toReturn.Rows(0)("PlusOrMinus"), String)
                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
                    _UserDelete = CType(toReturn.Rows(0)("UserDelete"), String)
                    _DeleteDate = CType(toReturn.Rows(0)("DeleteDate"), DateTime)
                    _IsDeleted = CType(toReturn.Rows(0)("IsDeleted"), Boolean)
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

            cmdToExecute.CommandText = "Update Mutationdt " & _
                                       "Set UserDelete = @UserDelete, " & _
                                       "DeleteDate = Getdate(), " & _
                                       "IsDeleted = 1 " & _
                                       "WHERE ID = @ID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
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
        Public Function DeleteAllByTxnNo() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "Update Mutationdt " & _
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
#Region "Others Function"
        Public Function SelectForViewGrid(Optional ByVal min As String = "", Optional ByVal max As String = "") As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "WITH subquery AS ( " & _
                                       "SELECT ROW_NUMBER() OVER (ORDER BY it.ItemID ) AS Number, " & _
                                       "dt.ID, " & _
                                       "Hd.TxnNo , " & _
                                       "dt.ItemSeqNo , " & _
                                       "isnull(it.ItemID,'') as ItemID, " & _
                                       "isnull(it.ItemName,'') as ItemName , " & _
                                       "dt.ItemUnitID , " & _
                                       "isnull(itun.ItemUnitName,'') as ItemUnitName, " & _
                                       "dt.ItemFactor , " & _
                                       "dt.Qty , " & _
                                       "isnull(itb.QtyNow,0) AS QtyNow, " & _
                                       "dt.PlusOrMinus, " & _
                                       "Hd.IsApproval " & _
                                       "FROM MutationHd hd " & _
                                       "INNER JOIN Mutationdt dt ON dt.TxnNo = hd.TxnNo " & _
                                       "Left JOIN (SELECT ItemSeqNo, WhID, UnitID, sum(QtySUnit) AS QtyNow from ItemBalance GROUP BY ItemSeqNo, WhID, UnitID) itb ON itb.ItemSeqNo = dt.ItemSeqNo And itb.WhID = hd.SourceWHID And itb.UnitID = hd.SourceUnitID " & _
                                       "INNER JOIN item it ON it.ItemSeqNo = dt.ItemSeqNo " & _
                                       "INNER JOIN itemunit itun ON itun.ItemUnitID = dt.ItemUnitID " & _
                                       "WHERE dt.IsDeleted = 0 and hd.IsDeleted = 0 and hd.TxnNo = @TxnNo) " & _
                                       IIf(Trim(min) <> "" And Trim(max) <> "", "SELECT * FROM subquery WHERE Number >= @min AND Number <= @max ORDER BY ItemID ", "SELECT * FROM subquery ORDER BY ItemID")

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Mutationdt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@TxnNo", _TxnNo)
                cmdToExecute.Parameters.Add("@min", min)
                cmdToExecute.Parameters.Add("@max", max)

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

        Public Function InsertMutationDtFromItemBalance(ByVal StockOpnameID As String, ByVal WHID As String, ByVal UnitID As String, ByVal User As String) As Boolean
            Dim cn As New SqlConnection(HisConfiguration.ConnectionString)
            Dim trans As SqlTransaction
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO Mutationdt " & _
                                       "SELECT left(@IDMax,2) + cast((cast(right(@IDMax,13) as numeric(18,0)) + ROW_NUMBER() OVER (order by ib.ItemSeqNo) - 1) as varchar) AS ID, " & _
                                       "@StockOpnameID AS TxnNo, " & _
                                       "ib.ItemSeqNo, " & _
                                       "isnull(i.ItemSUnitID,'') as ItemSUnitID, " & _
                                       "isnull(ift.ItemFactor,1) as ItemFactor, " & _
                                       "0 as Qty, " & _
                                       "'+' AS PlusOrMinus, " & _
                                       "@User AS UserInsert, " & _
                                       "GETDATE() AS insertDate, " & _
                                       "@User AS UserUpdate, " & _
                                       "GETDATE() AS UpdateDate, " & _
                                       "'' AS UserDelete, " & _
                                       "'' AS DeleteDate, " & _
                                       "0  AS IsDelete " & _
                                       "FROM ItemBalance ib " & _
                                       "LEFT JOIN Item i ON i.ItemSeqNo = ib.ItemSeqNo " & _
                                       "LEFT JOIN ItemFactorTemplate ift ON ift.ItemSeqNo = ib.ItemSeqNo and ift.ItemUnitID = i.ItemSUnitID " & _
                                       "WHERE ib.WhID = @WhID AND ib.UnitID = @UnitID order by ib.ItemSeqNo "

            cmdToExecute.CommandType = CommandType.Text

            cn.Open()
            trans = cn.BeginTransaction
            Try
                cmdToExecute.Transaction = trans
                cmdToExecute.Connection = cn
                cmdToExecute.Parameters.Add("@WhID", WHID)
                cmdToExecute.Parameters.Add("@UnitID", UnitID)
                cmdToExecute.Parameters.Add("@StockOpnameID", StockOpnameID)
                cmdToExecute.Parameters.Add("@IDMax", BussinessRules.ID.GenerateIDNumberWithBeginTransaction("MutationDt", "ID", cn, trans, "SP", "Where TxnNo in (SELECT TxnNo FROM Mutationhd WHERE InventoryTxnID = '" + CStr(BussinessRules.TxnType.StockOpname) + "')"))
                cmdToExecute.Parameters.Add("@User", User)

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()

                ' //  Commit the transaction
                trans.Commit()
                Return True
            Catch ex As Exception
                ' // Rollback all changes
                trans.Rollback()

                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                trans.Dispose()
                trans = Nothing

                If Not cn Is Nothing Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End If
                cn.Dispose()
                cn = Nothing
            End Try
        End Function

        Public Function SelectAllByTxnNo() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT dt.*,isnull(it.ItemID,'') as ItemID,isnull(it.ItemName,'') as ItemName FROM Mutationdt dt " & _
                                       "left join Item it on it.ItemSeqNo = dt.ItemSeqNo " & _
                                       "where dt.IsDeleted = 0 and dt.TxnNo = @TxnNo " & _
                                       "order by dt.ID desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Mutationdt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@TxnNo", _TxnNo)

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

        Public Function UpdateQtySP(ByVal detilRow As DataTable, ByVal User As String) As Boolean
            Dim conn As SqlConnection = New SqlConnection(ConnectionString)
            Dim da As SqlDataAdapter
            Dim trans As SqlTransaction
            Dim retVal As Boolean

            If detilRow Is Nothing Then
                Return False
            Else
                If detilRow.Rows.Count = 0 Then
                    Return False
                End If
            End If

            ' // Update Detil 
            Dim strSQLUpdateDT As New Text.StringBuilder
            With strSQLUpdateDT
                .Append("UPDATE Mutationdt " & _
                        "SET Qty = ABS(@Qty), " & _
                        "PlusOrMinus = (case when @Qty < 0 then '-' else '+' end), " & _
                        "UserUpdate = @UserUpdate, " & _
                        "UpdateDate = GetDate() " & _
                        "WHERE ID = @ID")
            End With

            conn.Open()

            Try
                '
                ' // begin the transaction
                '
                trans = conn.BeginTransaction

                ' // detil 
                With detilRow
                    Dim iRecCount As Integer = 0
                    While .Rows.Count > iRecCount
                        Dim cmdUpdateDT As New SqlCommand
                        With cmdUpdateDT
                            .CommandText = strSQLUpdateDT.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn
                            .Transaction = trans
                        End With
                        With cmdUpdateDT.Parameters
                            .Add(New SqlParameter("@ID", New SqlString(CStr(detilRow.Rows(iRecCount)("ID")))))
                            .Add(New SqlParameter("@Qty", New SqlDouble(CDbl(detilRow.Rows(iRecCount)("Qty")))))
                            .Add(New SqlParameter("@UserUpdate", User.Trim))
                        End With
                        ' // update detil
                        cmdUpdateDT.ExecuteNonQuery()
                        iRecCount += 1
                    End While

                End With

                trans.Commit()
                retVal = True
            Catch ex As Exception
                trans.Rollback()
                ' // do not throw an exception, just return ..!!
                '_Ex = ex
                ExceptionManager.Publish(ex)
            Finally
                If Not detilRow Is Nothing Then
                    detilRow.Dispose()
                End If
                detilRow = Nothing

                If Not conn Is Nothing Then
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                End If
                conn.Dispose()
                conn = Nothing
            End Try

            Return retVal
        End Function
#End Region

#Region " Class Property Declarations "
        Public Property [ID]() As String
            Get
                Return _ID
            End Get
            Set(ByVal Value As String)
                _ID = Value
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
        Public Property [TxnNo]() As String
            Get
                Return _TxnNo
            End Get
            Set(ByVal Value As String)
                _TxnNo = Value
            End Set
        End Property
        Public Property [ItemSeqNo]() As String
            Get
                Return _ItemSeqNo
            End Get
            Set(ByVal Value As String)
                _ItemSeqNo = Value
            End Set
        End Property

        Public Property [ItemUnitID]() As String
            Get
                Return _ItemUnitID
            End Get
            Set(ByVal Value As String)
                _ItemUnitID = Value
            End Set
        End Property

        Public Property [ItemFactor]() As Decimal
            Get
                Return _ItemFactor
            End Get
            Set(ByVal Value As Decimal)
                _ItemFactor = Value
            End Set
        End Property

        Public Property [Qty]() As Decimal
            Get
                Return _Qty
            End Get
            Set(ByVal Value As Decimal)
                _Qty = Value
            End Set
        End Property

        Public Property [PlusOrMinus]() As String
            Get
                Return _PlusOrMinus
            End Get
            Set(ByVal Value As String)
                _PlusOrMinus = Value
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

        Public Property [UserUpdate]() As String
            Get
                Return _UserUpdate
            End Get
            Set(ByVal Value As String)
                _UserUpdate = Value
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

        Public Property [UserDelete]() As String
            Get
                Return _UserDelete
            End Get
            Set(ByVal Value As String)
                _UserDelete = Value
            End Set
        End Property

        Public Property [DeleteDate]() As DateTime
            Get
                Return _DeleteDate
            End Get
            Set(ByVal Value As DateTime)
                _DeleteDate = Value
            End Set
        End Property
        Public Property [IsDeleted]() As Boolean
            Get
                Return _IsDeleted
            End Get
            Set(ByVal Value As Boolean)
                _IsDeleted = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
