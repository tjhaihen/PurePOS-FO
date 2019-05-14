Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class PurchaseUnitDt
        Inherits BRInteractionBase
#Region " Class Member Declarations "
        Private _IDPO, _PUnitNO, _POrdNO, _ItemSeqNo, _ItemUnitID, _ItemFactor, _Qty, _Price, _Disc1Pct, _Disc1Amt, _Disc2Pct, _Disc2Amt As String
        Private _ID As String
        Private _Disc3Pct, _Disc3Amt, _QtyReturn, _Description As String
        Private _UserInsert, _UserUpdate, _UserDelete As String
        Private _InsertDate, _UpdateDate, _DeleteDate As String
        Private _IsBonus, _IsDeleted, _IsRelease As Boolean
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

            cmdToExecute.CommandText = "INSERT INTO PurchaseUnitdt " & _
                                       "(ID, PUnitNO, POrdNO, ItemSeqNo, ItemUnitID, ItemFactor, Qty, Price, Disc1Pct, " & _
                                       "Disc1Amt, Disc2Pct, Disc2Amt, Disc3Pct, Disc3Amt, QtyReturn, IsBonus, UserInsert, InsertDate, " & _
                                       "UserUpdate, UpdateDate, UserDelete, DeleteDate, IsDeleted, Description) " & _
                                       "VALUES (@ID, @PUnitNO, @POrdNO, @ItemSeqNo, @ItemUnitID, @ItemFactor, @Qty, @Price, @Disc1Pct, " & _
                                       "@Disc1Amt, @Disc2Pct, @Disc2Amt, @Disc3Pct, @Disc3Amt, 0, @IsBonus, @UserInsert, getdate(), " & _
                                       "@UserUpdate, getdate(), '', '', 0, @Description) "
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try

                cmdToExecute.Parameters.AddWithValue("@ID", _ID)
                cmdToExecute.Parameters.AddWithValue("@PUnitNO", _PUnitNO)
                cmdToExecute.Parameters.AddWithValue("@POrdNO", _POrdNO)
                cmdToExecute.Parameters.AddWithValue("@ItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.AddWithValue("@ItemUnitID", _ItemUnitID)
                cmdToExecute.Parameters.AddWithValue("@ItemFactor", _ItemFactor)
                cmdToExecute.Parameters.AddWithValue("@Qty", _Qty)
                cmdToExecute.Parameters.AddWithValue("@Price", _Price)
                cmdToExecute.Parameters.AddWithValue("@Disc1Pct", _Disc1Pct)
                cmdToExecute.Parameters.AddWithValue("@Disc1Amt", _Disc1Amt)
                cmdToExecute.Parameters.AddWithValue("@Disc2Pct", _Disc2Pct)
                cmdToExecute.Parameters.AddWithValue("@Disc2Amt", _Disc2Amt)
                cmdToExecute.Parameters.AddWithValue("@Disc3Pct", _Disc3Pct)
                cmdToExecute.Parameters.AddWithValue("@Disc3Amt", _Disc3Amt)
                cmdToExecute.Parameters.AddWithValue("@IsBonus", _IsBonus)
                cmdToExecute.Parameters.AddWithValue("@UserInsert", _UserInsert)
                cmdToExecute.Parameters.AddWithValue("@UserUpdate", _UserUpdate)
                cmdToExecute.Parameters.AddWithValue("@Description", _Description)

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

            cmdToExecute.CommandText = "UPDATE PurchaseUnitdt " & _
                                        "SET ItemSeqNo = @ItemSeqNo, " & _
                                        "ItemUnitID = @ItemUnitID, " & _
                                        "ItemFactor = @ItemFactor, " & _
                                        "Qty = @Qty, " & _
                                        "Price = @Price, " & _
                                        "Disc1Pct = @Disc1Pct, " & _
                                        "Disc1Amt = @Disc1Amt, " & _
                                        "Disc2Pct = @Disc2Pct, " & _
                                        "Disc2Amt = @Disc2Amt, " & _
                                        "Disc3Pct = @Disc3Pct, " & _
                                        "Disc3Amt = @Disc3Amt, " & _
                                        "IsBonus = @IsBonus, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate(), " & _
                                        "Description = @Description " & _
                                        "WHERE ID = @ID"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ID", _ID)
                cmdToExecute.Parameters.AddWithValue("@ItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.AddWithValue("@ItemUnitID", _ItemUnitID)
                cmdToExecute.Parameters.AddWithValue("@ItemFactor", _ItemFactor)
                cmdToExecute.Parameters.AddWithValue("@Qty", _Qty)
                cmdToExecute.Parameters.AddWithValue("@Price", _Price)
                cmdToExecute.Parameters.AddWithValue("@Disc1Pct", _Disc1Pct)
                cmdToExecute.Parameters.AddWithValue("@Disc1Amt", _Disc1Amt)
                cmdToExecute.Parameters.AddWithValue("@Disc2Pct", _Disc2Pct)
                cmdToExecute.Parameters.AddWithValue("@Disc2Amt", _Disc2Amt)
                cmdToExecute.Parameters.AddWithValue("@Disc3Pct", _Disc3Pct)
                cmdToExecute.Parameters.AddWithValue("@Disc3Amt", _Disc3Amt)
                cmdToExecute.Parameters.AddWithValue("@IsBonus", _IsBonus)
                cmdToExecute.Parameters.AddWithValue("@UserUpdate", _UserUpdate)
                cmdToExecute.Parameters.AddWithValue("@Description", _Description)

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

            cmdToExecute.CommandText = "SELECT * FROM PurchaseUnitdt where IsDeleted = 0 order by ID desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseUnitdt")
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
                    cmdToExecute.CommandText = "SELECT * FROM PurchaseUnitdt WHERE ID = @ID"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM PurchaseUnitdt WHERE ID > @ID ORDER BY ID ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM PurchaseUnitdt WHERE ID < @ID ORDER BY ID DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("PurchaseUnitdt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ID", _ID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _ID = CType(toReturn.Rows(0)("ID"), String)
                    _PUnitNO = CType(toReturn.Rows(0)("PUnitNO"), String)
                    _POrdNO = CType(toReturn.Rows(0)("POrdNO"), String)
                    _ItemSeqNo = CType(toReturn.Rows(0)("ItemSeqNo"), String)
                    _ItemUnitID = CType(toReturn.Rows(0)("ItemUnitID"), String)

                    _ItemFactor = CType(toReturn.Rows(0)("ItemFactor"), Decimal)
                    _Qty = CType(toReturn.Rows(0)("Qty"), Decimal)
                    _Price = CType(toReturn.Rows(0)("Price"), Decimal)
                    _Disc1Pct = CType(toReturn.Rows(0)("Disc1Pct"), Decimal)
                    _Disc1Amt = CType(toReturn.Rows(0)("Disc1Amt"), Decimal)
                    _Disc2Pct = CType(toReturn.Rows(0)("Disc2Pct"), Decimal)
                    _Disc2Amt = CType(toReturn.Rows(0)("Disc2Amt"), Decimal)
                    _Disc3Pct = CType(toReturn.Rows(0)("Disc3Pct"), Decimal)
                    _Disc3Amt = CType(toReturn.Rows(0)("Disc3Amt"), Decimal)
                    _QtyReturn = CType(toReturn.Rows(0)("QtyReturn"), Decimal)

                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
                    _UserDelete = CType(toReturn.Rows(0)("UserDelete"), String)
                    _DeleteDate = CType(toReturn.Rows(0)("DeleteDate"), DateTime)

                    _IsBonus = CType(toReturn.Rows(0)("IsBonus"), Boolean)
                    _IsDeleted = CType(toReturn.Rows(0)("IsDeleted"), Boolean)

                    _Description = CType(toReturn.Rows(0)("Description"), String)
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

            cmdToExecute.CommandText = "Update PurchaseUnitdt " & _
                                       "set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = getdate() " & _
                                       "WHERE ID = @ID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ID", _ID)
                cmdToExecute.Parameters.AddWithValue("@UserDelete", _UserDelete)

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
        Public Function DeleteAllByPUnitNO() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "Update PurchaseUnitdt " & _
                                       "set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = getdate() " & _
                                       "WHERE IsDeleted = 0 and PUnitNO = @PUnitNO "
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PUnitNO", _PUnitNO)
                cmdToExecute.Parameters.AddWithValue("@UserDelete", _UserDelete)

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
        Public Function SelectForViewGrid() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT dt.ID, " + _
                                       "dt.PordNo , " + _
                                       "dt.ItemSeqNo , " + _
                                       "isnull(it.ItemID,'') as ItemID, " + _
                                       "isnull(it.ItemName,'') as ItemName , " + _
                                       "dt.Qty , " + _
                                       "dt.ItemFactor , " + _
                                       "dt.Price , " + _
                                       "dt.Disc1Pct , " + _
                                       "dt.Disc1Amt , " + _
                                       "dt.Disc2Pct , " + _
                                       "dt.Disc2Amt , " + _
                                       "dt.Disc3Pct , " + _
                                       "dt.Disc3Amt , " + _
                                       "isnull(pohd.CurrencyRate,1) as CurrencyRate , " + _
                                       "dt.IsBonus " + _
                                       "FROM PurchaseUnitHd hd " + _
                                       "inner join PurchaseUnitdt dt ON dt.PUnitNO = hd.PUnitNO " + _
                                       "Left join PurchaseOrderHd pohd ON pohd.POrdNO = dt.POrdNO and pohd.isDeleted = 0 " + _
                                       "left join item it ON it.ItemSeqNo = dt.ItemSeqNo " + _
                                       "WHERE dt.IsDeleted = 0 AND hd.IsDeleted = 0 AND dt.PUnitNO = @PUnitNO "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseUnitdt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PUnitNO", _PUnitNO)
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

        Public Function InsertItemPO(ByVal detilRow As DataTable, ByVal UserUpdate As String) As Boolean
            Dim conn As SqlConnection = New SqlConnection(ConnectionString)
            Dim trans As SqlTransaction
            Dim retVal As Boolean

            If detilRow Is Nothing Then
                Return False
            Else
                If detilRow.Rows.Count = 0 Then
                    Return False
                End If
            End If

            ' // Insert Detil 
            Dim strSQLInsertDT As New Text.StringBuilder
            With strSQLInsertDT
                .Append("INSERT INTO PurchaseUnitdt " & _
                        "(ID,IDPO, PUnitNO, POrdNO, ItemSeqNo, ItemUnitID, ItemFactor, Qty, Price, Disc1Pct, " & _
                        "Disc1Amt, Disc2Pct, Disc2Amt, Disc3Pct, Disc3Amt, QtyReturn, IsBonus, UserInsert, InsertDate, " & _
                        "UserUpdate, UpdateDate, UserDelete, DeleteDate, IsDeleted, Description) " & _
                        "VALUES (@ID, @IDPO, @PUnitNO, @POrdNO, @ItemSeqNo, @ItemUnitID, @ItemFactor, @Qty, @Price, @Disc1Pct, " & _
                        "@Disc1Amt, @Disc2Pct, @Disc2Amt, @Disc3Pct, @Disc3Amt, 0, @IsBonus, @UserInsert, getdate(), " & _
                        "@UserUpdate, getdate(), '', '', 0, @Description) ")
            End With
            conn.Open()
            Try
                ' // begin the transaction
                trans = conn.BeginTransaction
                ' // detil 
                With detilRow

                    Dim iRecCount As Integer = 0
                    While .Rows.Count > iRecCount
                        Dim cmdInsertDT As New SqlCommand
                        With cmdInsertDT
                            .CommandText = strSQLInsertDT.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn
                            .Transaction = trans
                        End With

                        _ID = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("PurchaseUnitDt", "ID", conn, trans, "PN")
                        _IDPO = CType(.Rows(iRecCount)("IDPO"), String)
                        _ItemSeqNo = CType(.Rows(iRecCount)("ItemSeqNo"), String)
                        _ItemUnitID = CType(.Rows(iRecCount)("ItemUnitID"), String)
                        _ItemFactor = CType(.Rows(iRecCount)("ItemFactor"), Double)
                        _Qty = CType(.Rows(iRecCount)("QtyReceived"), Double)
                        _Price = CType(.Rows(iRecCount)("Price"), Double)
                        _Disc1Pct = CType(.Rows(iRecCount)("Disc1Pct"), Double)
                        _Disc1Amt = CType(.Rows(iRecCount)("Disc1Amt"), Double)
                        _Disc2Pct = CType(.Rows(iRecCount)("Disc2Pct"), Double)
                        _Disc2Amt = CType(.Rows(iRecCount)("Disc2Amt"), Double)
                        _Disc3Pct = CType(.Rows(iRecCount)("Disc3Pct"), Double)
                        _Disc3Amt = CType(.Rows(iRecCount)("Disc3Amt"), Double)
                        _POrdNO = CType(.Rows(iRecCount)("POrdNO"), String)
                        _IsBonus = CType(.Rows(iRecCount)("IsBonus"), Boolean)

                        With cmdInsertDT.Parameters
                            .AddWithValue("@ID", _ID)
                            .AddWithValue("@IDPO", _IDPO)
                            .AddWithValue("@PUnitNO", _PUnitNO)
                            .AddWithValue("@ItemSeqNo", _ItemSeqNo)
                            .AddWithValue("@ItemUnitID", _ItemUnitID)
                            .AddWithValue("@ItemFactor", _ItemFactor)
                            .AddWithValue("@Qty", _Qty)
                            .AddWithValue("@Price", _Price)
                            .AddWithValue("@Disc1Pct", _Disc1Pct)
                            .AddWithValue("@Disc1Amt", _Disc1Amt)
                            .AddWithValue("@Disc2Pct", _Disc2Pct)
                            .AddWithValue("@Disc2Amt", _Disc2Amt)
                            .AddWithValue("@Disc3Pct", _Disc3Pct)
                            .AddWithValue("@Disc3Amt", _Disc3Amt)
                            .AddWithValue("@POrdNO", _POrdNO)
                            .AddWithValue("@IsBonus", _IsBonus)
                            .AddWithValue("@UserInsert", UserUpdate)
                            .AddWithValue("@UserUpdate", UserUpdate)
                            .AddWithValue("@Description", "")
                        End With

                        ' // insert detil
                        cmdInsertDT.ExecuteNonQuery()
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

                trans.Dispose()
                trans = Nothing

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

        Public Function SelectAllByPONo() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT * FROM PurchaseUnitdt where IsDeleted = 0 and PordNo = @PordNo order by ID desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseUnitdt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@PordNo", _POrdNO)

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

        Public Function SelectAllByPUnitNOForItemSeqNo(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " " & _
                                       "dt.ItemSeqNo, " & _
                                       "isnull(it.ItemID,'') as ItemID, " & _
                                       "isnull(it.ItemName,'') as ItemName, " & _
                                       "sum(dt.Qty * dt.ItemFactor) AS Qty " & _
                                       "FROM PurchaseUnitHd hd " & _
                                       "INNER join PurchaseUnitdt dt ON dt.PUnitNO = hd.PUnitNO " & _
                                       "left join item it ON it.ItemSeqNo = dt.ItemSeqNo " & _
                                       "WHERE dt.IsDeleted = 0 AND hd.IsDeleted = 0 AND hd.IsApproval = 1 AND hd.PUnitNO = @PUnitNO " & _
                                       "and (hd.PUnitNO LIKE '" + Filter.Trim + "%' OR convert(varchar(10),hd.PUnitDate,105) LIKE '" + Filter.Trim + "%') " & _
                                       "GROUP BY dt.ItemSeqNo, it.ItemID, it.ItemName " & _
                                       "HAVING sum(dt.Qty) > " & _
                                       "isnull((SELECT sum(prd.Qty * prd.ItemFactor) " & _
                                       "FROM PurchaseReturnHd prh " & _
                                       "INNER JOIN PurchaseReturnDt prd ON prh.PReturnNO = prd.PReturnNO " & _
                                       "WHERE prh.Isdeleted = 0 AND prd.Isdeleted = 0 AND prd.ItemSeqNo = dt.ItemSeqNo AND prh.PUnitNO = @PUnitNO),0) "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseUnitdt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PUnitNO", _PUnitNO)
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

        Public Function SelectForViewGridPR() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT dt.ID, " & _
                                        "dt.ItemSeqNo , " & _
                                        "isnull(it.ItemID,'') as ItemID, " & _
                                        "isnull(it.ItemName,'') as ItemName , " & _
                                        "dt.ItemUnitID, " & _
                                        "isnull(iu.ItemUnitName,'') AS ItemUnitName, " & _
                                        "dt.ItemFactor, " & _
                                        "dt.Qty , " & _
                                        "dt.QtyReturn , " & _
                                        "isnull(purt.QtyPURT,0) AS QtyPURT, " & _
                                        "dt.Price , " & _
                                        "dt.Disc1Pct , " & _
                                        "dt.Disc1Amt , " & _
                                        "dt.Disc2Pct , " & _
                                        "dt.Disc2Amt , " & _
                                        "dt.Disc3Pct , " & _
                                        "dt.Disc3Amt , " & _
                                        "dt.IsBonus " & _
                                        "FROM PurchaseUnitHd hd " & _
                                        "inner join PurchaseUnitdt dt ON dt.PUnitNO = hd.PUnitNO And dt.Qty > dt.QtyReturn " & _
                                        "LEFT JOIN " & _
                                        "( " & _
                                         "SELECT prd.IDPU, sum(prd.Qty * prd.ItemFactor) AS QtyPURT " & _
                                         "FROM PurchaseReturnHd prh " & _
                                         "INNER JOIN PurchaseReturnDt prd ON prd.PReturnNO = prh.PReturnNO AND prh.IsDeleted = 0 AND prd.IsDeleted = 0 AND prh.IsApproval = 0 " & _
                                         "GROUP BY prd.IDPU " & _
                                        ") purt ON purt.IDPU = dt.ID " & _
                                        "left join item it ON it.ItemSeqNo = dt.ItemSeqNo " & _
                                        "LEFT JOIN ItemUnit iu ON iu.ItemUnitID = dt.ItemUnitID " & _
                                        "WHERE dt.IsDeleted = 0 AND hd.IsDeleted = 0 AND hd.IsApproval = 1 AND dt.PUnitNO = @PUnitNO " & _
                                        "And ((dt.Qty * dt.ItemFactor) - dt.QtyReturn - isnull(purt.QtyPURT,0)) > 0 "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseUnitdt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@PUnitNO", _PUnitNO)
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

        Public Function ValidateGetItemPU() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT dt.ID, " & _
                                        "dt.ItemSeqNo , " & _
                                        "isnull(it.ItemID,'') as ItemID, " & _
                                        "isnull(it.ItemName,'') as ItemName , " & _
                                        "dt.ItemUnitID, " & _
                                        "isnull(iu.ItemUnitName,'') AS ItemUnitName, " & _
                                        "dt.ItemFactor, " & _
                                        "dt.Qty , " & _
                                        "dt.QtyReturn , " & _
                                        "isnull(purt.QtyPURT,0) AS QtyPURT, " & _
                                        "dt.Price , " & _
                                        "dt.Disc1Pct , " & _
                                        "dt.Disc1Amt , " & _
                                        "dt.Disc2Pct , " & _
                                        "dt.Disc2Amt , " & _
                                        "dt.Disc3Pct , " & _
                                        "dt.Disc3Amt , " & _
                                        "dt.IsBonus " & _
                                        "FROM PurchaseUnitHd hd " & _
                                        "inner join PurchaseUnitdt dt ON dt.PUnitNO = hd.PUnitNO And dt.Qty > dt.QtyReturn " & _
                                        "LEFT JOIN " & _
                                        "( " & _
                                         "SELECT prd.IDPU, sum(prd.Qty * prd.ItemFactor) AS QtyPURT " & _
                                         "FROM PurchaseReturnHd prh " & _
                                         "INNER JOIN PurchaseReturnDt prd ON prd.PReturnNO = prh.PReturnNO AND prh.IsDeleted = 0 AND prd.IsDeleted = 0 AND prh.IsApproval = 0 " & _
                                         "GROUP BY prd.IDPU " & _
                                        ") purt ON purt.IDPU = dt.ID " & _
                                        "left join item it ON it.ItemSeqNo = dt.ItemSeqNo " & _
                                        "LEFT JOIN ItemUnit iu ON iu.ItemUnitID = dt.ItemUnitID " & _
                                        "WHERE dt.IsDeleted = 0 AND hd.IsDeleted = 0 AND hd.IsApproval = 1 AND dt.PUnitNO = @PUnitNO " & _
                                        "And dt.ID = @ID "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseUnitdt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PUnitNO", _PUnitNO)
                cmdToExecute.Parameters.AddWithValue("@ID", _ID)
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
        Public Property [PUnitNO]() As String
            Get
                Return _PUnitNO
            End Get
            Set(ByVal Value As String)
                _PUnitNO = Value
            End Set
        End Property
        Public Property [POrdNO]() As String
            Get
                Return _POrdNO
            End Get
            Set(ByVal Value As String)
                _POrdNO = Value
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

        Public Property [Price]() As Decimal
            Get
                Return _Price
            End Get
            Set(ByVal Value As Decimal)
                _Price = Value
            End Set
        End Property

        Public Property [Disc1Pct]() As Decimal
            Get
                Return _Disc1Pct
            End Get
            Set(ByVal Value As Decimal)
                _Disc1Pct = Value
            End Set
        End Property

        Public Property [Disc1Amt]() As Decimal
            Get
                Return _Disc1Amt
            End Get
            Set(ByVal Value As Decimal)
                _Disc1Amt = Value
            End Set
        End Property

        Public Property [Disc2Pct]() As Decimal
            Get
                Return _Disc2Pct
            End Get
            Set(ByVal Value As Decimal)
                _Disc2Pct = Value
            End Set
        End Property
        Public Property [Disc2Amt]() As Decimal
            Get
                Return _Disc2Amt
            End Get
            Set(ByVal Value As Decimal)
                _Disc2Amt = Value
            End Set
        End Property
        Public Property [Disc3Pct]() As Decimal
            Get
                Return _Disc3Pct
            End Get
            Set(ByVal Value As Decimal)
                _Disc3Pct = Value
            End Set
        End Property
        Public Property [Disc3Amt]() As Decimal
            Get
                Return _Disc3Amt
            End Get
            Set(ByVal Value As Decimal)
                _Disc3Amt = Value
            End Set
        End Property
        Public Property [QtyReturn]() As Decimal
            Get
                Return _QtyReturn
            End Get
            Set(ByVal Value As Decimal)
                _QtyReturn = Value
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

        Public Property [IsBonus]() As Boolean
            Get
                Return _IsBonus
            End Get
            Set(ByVal Value As Boolean)
                _IsBonus = Value
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
        Public Property [IsRelease]() As Boolean
            Get
                Return _IsRelease
            End Get
            Set(ByVal Value As Boolean)
                _IsRelease = Value
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
#End Region

    End Class
End Namespace
