Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class ItemBalance
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ItemSeqNo, _ItemLUnitID, _ItemSUnitID, _ItemFactor, _WhID, _UnitID, _QtySUnit, _ItemHistoryID As String
        Private _UserUpdate As String
        Private _UpdateDate As String
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        'Public Overrides Function Insert() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "INSERT INTO ItemCategory " & _
        '                                "(ItemCategoryID, ItemCategoryName, Description, SalesDiscountPct, SalesDiscountAmt, isActive, UserInsert, InsertDate, UserUpdate, UpdateDate) " & _
        '                                "VALUES (@ItemCategoryID, @ItemCategoryName, @Description, @SalesDiscountPct, @SalesDiscountAmt, @IsActive, @UserInsert, GetDate(), @UserUpdate, GetDate())"
        '    cmdToExecute.CommandType = CommandType.Text

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add("@ItemCategoryID", _ItemCategoryID)
        '        cmdToExecute.Parameters.Add("@ItemCategoryName", _ItemCategoryName)
        '        cmdToExecute.Parameters.Add("@Description", _Description)
        '        cmdToExecute.Parameters.Add("@SalesDiscountPct", _SalesDiscountPct)
        '        cmdToExecute.Parameters.Add("@SalesDiscountAmt", _SalesDiscountAmt)
        '        cmdToExecute.Parameters.Add("@IsActive", _IsActive)
        '        cmdToExecute.Parameters.Add("@UserInsert", _UserInsert)
        '        cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()

        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '    End Try
        'End Function

        'Public Overrides Function Update() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "UPDATE ItemCategory " & _
        '                                "SET ItemCategoryName = @ItemCategoryName, " & _
        '                                "IsActive = @IsActive, " & _
        '                                "Description = @Description, " & _
        '                                "SalesDiscountPct = @SalesDiscountPct, " & _
        '                                "SalesDiscountAmt = @SalesDiscountAmt, " & _
        '                                "UserUpdate = @UserUpdate, " & _
        '                                "UpdateDate = GetDate() " & _
        '                                "WHERE ItemCategoryID = @ItemCategoryID"
        '    cmdToExecute.CommandType = CommandType.Text

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add("@ItemCategoryID", _ItemCategoryID)
        '        cmdToExecute.Parameters.Add("@ItemCategoryName", _ItemCategoryName)
        '        cmdToExecute.Parameters.Add("@Description", _Description)
        '        cmdToExecute.Parameters.Add("@SalesDiscountPct", _SalesDiscountPct)
        '        cmdToExecute.Parameters.Add("@SalesDiscountAmt", _SalesDiscountAmt)
        '        cmdToExecute.Parameters.Add("@IsActive", _IsActive)
        '        cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()

        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '    End Try
        'End Function

        'Public Overrides Function SelectAll() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "SELECT * FROM ItemCategory"
        '    cmdToExecute.CommandType = CommandType.Text

        '    Dim toReturn As DataTable = New DataTable("ItemCategory")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        _mainConnection.Open()

        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    Select Case recStatus
        '        Case RavenRecStatus.CurrentRecord
        '            cmdToExecute.CommandText = "SELECT * FROM ItemCategory WHERE ItemCategoryID = @ItemCategoryID"
        '        Case RavenRecStatus.NextRecord
        '            cmdToExecute.CommandText = "SELECT * FROM ItemCategory WHERE ItemCategoryID > @ItemCategoryID ORDER BY ItemCategoryID ASC"
        '        Case RavenRecStatus.PreviousRecord
        '            cmdToExecute.CommandText = "SELECT * FROM ItemCategory WHERE ItemCategoryID < @ItemCategoryID ORDER BY ItemCategoryID DESC"
        '    End Select
        '    cmdToExecute.CommandType = CommandType.Text
        '    Dim toReturn As DataTable = New DataTable("ItemCategory")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add("@ItemCategoryID", _ItemCategoryID)

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        adapter.Fill(toReturn)

        '        If toReturn.Rows.Count > 0 Then
        '            _ItemCategoryID = CType(toReturn.Rows(0)("ItemCategoryID"), String)
        '            _ItemCategoryName = CType(toReturn.Rows(0)("ItemCategoryName"), String)
        '            _Description = CType(toReturn.Rows(0)("Description"), String)
        '            _SalesDiscountPct = CType(toReturn.Rows(0)("SalesDiscountPct"), Decimal)
        '            _SalesDiscountAmt = CType(toReturn.Rows(0)("SalesDiscountAmt"), Decimal)
        '            _IsActive = CType(toReturn.Rows(0)("IsActive"), Boolean)
        '            _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
        '            _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
        '            _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
        '            _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
        '        End If

        '        Return toReturn
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Overrides Function Delete() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "DELETE FROM ItemCategory WHERE ItemCategoryID = @ItemCategoryID"
        '    cmdToExecute.CommandType = CommandType.Text

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add("@ItemCategoryID", _ItemCategoryID)

        '        ' //Open Connection
        '        _mainConnection.Open()

        '        ' //Execute Query
        '        cmdToExecute.ExecuteNonQuery()

        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '    End Try
        'End Function
#Region "Others Function"
        Public Function SelectAllByWhIDUnitIDForItemSeqNo(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " ib.*, " + _
                                       "isnull(it.ItemID,'') as ItemID, " + _
                                       "isnull(it.ItemName,'') as ItemName " + _
                                       "FROM ItemBalance ib " + _
                                       "left join item it ON it.ItemSeqNo = ib.ItemSeqNo " + _
                                       "WHERE ib.WhID = @WhID and ib.UnitID = @UnitID " + _
                                       "and (it.ItemID LIKE '" + Filter.Trim + "%' OR it.ItemName LIKE '" + Filter.Trim + "%' OR ib.ItemSeqNo LIKE '" + Filter.Trim + "%') "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ItemBalance")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@WhID", _WhID)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID)
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

        Public Function SelectAllByWhIDUnitIDForItemSeqNoMutation(ByVal TxnNo As String, ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " ib.ItemSeqNo,ib.WhID,ib.UnitID,(ib.QtySUnit - isnull(MT.QtyMT,0)) as QtySUnit,ib.ItemHistoryID,ib.UserUpdate,ib.UpdateDate, " + _
                                       "isnull(it.ItemID,'') as ItemID, " + _
                                       "isnull(it.ItemName,'') as ItemName " + _
                                       "FROM ItemBalance ib " + _
                                       "left join " & _
                                       "( " & _
                                            "SELECT hd.SourceWHID,hd.SourceUnitID,dt.ItemSeqNo,sum(dt.Qty) AS QtyMT " & _
                                            "FROM Mutationhd hd " & _
                                            "INNER JOIN MutationDt dt ON dt.TxnNo = hd.TxnNo AND hd.IsDeleted = 0 AND dt.IsDeleted = 0 AND hd.IsApproval = 0 " & _
                                            "WHERE hd.TxnNo = @TxnNo " & _
                                            "GROUP BY hd.SourceWHID,hd.SourceUnitID,dt.ItemSeqNo " & _
                                       ") MT ON MT.SourceWHID = ib.WhID AND MT.SourceUnitID = ib.UnitID AND MT.ItemSeqNo = ib.ItemSeqNo " & _
                                       "left join item it ON it.ItemSeqNo = ib.ItemSeqNo " + _
                                       "WHERE ib.WhID = @WhID and ib.UnitID = @UnitID " + _
                                       "and (it.ItemID LIKE '" + Filter.Trim + "%' OR it.ItemName LIKE '" + Filter.Trim + "%' OR ib.ItemSeqNo LIKE '" + Filter.Trim + "%') "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ItemBalance")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@TxnNo", TxnNo)
                cmdToExecute.Parameters.Add("@WhID", _WhID)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID)
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
        Public Function SelectAllByWhIDUnitIDForItemSeqNoBeginBalance(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + "  " & _
                                       "it.ItemSeqNo, it.ItemID, it.ItemName, isnull(itb.QtySUnit,0) as QtySUnit " & _
                                       "FROM item it " & _
                                       "Left Join ItemBalance itb On it.ItemSeqNo = itb.ItemSeqNo And WhID = @WhID And UnitID = @UnitID " & _
                                       "WHERE it.IsActive = 1 " & _
                                       "AND itb.ItemSeqNo Is Null " & _
                                       "and (it.ItemID LIKE '" + Filter.Trim + "%' OR it.ItemName LIKE '" + Filter.Trim + "%' OR it.ItemSeqNo LIKE '" + Filter.Trim + "%') "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ItemBalance")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@WhID", _WhID)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID)
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
        'Public Property [ItemCategoryID]() As String
        '    Get
        '        Return _ItemCategoryID
        '    End Get
        '    Set(ByVal Value As String)
        '        _ItemCategoryID = Value
        '    End Set
        'End Property

        Public Property [WhID]() As String
            Get
                Return _WhID
            End Get
            Set(ByVal Value As String)
                _WhID = Value
            End Set
        End Property

        Public Property [UnitID]() As String
            Get
                Return _UnitID
            End Get
            Set(ByVal Value As String)
                _UnitID = Value
            End Set
        End Property

        'Public Property [SalesDiscountPct]() As Decimal
        '    Get
        '        Return _SalesDiscountPct
        '    End Get
        '    Set(ByVal Value As Decimal)
        '        _SalesDiscountPct = Value
        '    End Set
        'End Property

        'Public Property [SalesDiscountAmt]() As Decimal
        '    Get
        '        Return _SalesDiscountAmt
        '    End Get
        '    Set(ByVal Value As Decimal)
        '        _SalesDiscountAmt = Value
        '    End Set
        'End Property

        'Public Property [IsActive]() As Boolean
        '    Get
        '        Return _IsActive
        '    End Get
        '    Set(ByVal Value As Boolean)
        '        _IsActive = Value
        '    End Set
        'End Property

        'Public Property [UserInsert]() As String
        '    Get
        '        Return _UserInsert
        '    End Get
        '    Set(ByVal Value As String)
        '        _UserInsert = Value
        '    End Set
        'End Property

        'Public Property [InsertDate]() As DateTime
        '    Get
        '        Return _InsertDate
        '    End Get
        '    Set(ByVal Value As DateTime)
        '        _InsertDate = Value
        '    End Set
        'End Property

        'Public Property [UserUpdate]() As String
        '    Get
        '        Return _UserUpdate
        '    End Get
        '    Set(ByVal Value As String)
        '        _UserUpdate = Value
        '    End Set
        'End Property

        'Public Property [UpdateDate]() As DateTime
        '    Get
        '        Return _UpdateDate
        '    End Get
        '    Set(ByVal Value As DateTime)
        '        _UpdateDate = Value
        '    End Set
        'End Property
#End Region

    End Class
End Namespace
