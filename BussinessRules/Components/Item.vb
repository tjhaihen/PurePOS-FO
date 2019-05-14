Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Partial Public Class Item
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ItemSeqNo, _ItemID, _ItemName As String
        Private _ItemStatusID, _PrintName, _BrandNameID, _ItemSize As String
        Private _ItemCategoryID, _ItemSubCategoryID As String
        Private _IsFood, _IsFresh, _IsHalal, _IsLegal, _IsImport, _IsHouseBrand As Boolean
        Private _ManufacturerID, _ProducerID, _DistributorID, _CountryID As String
        Private _ItemSUnitID, _ItemMUnitID, _ItemLUnitID As String
        'Private _SalesPriceSUnit, _SalesPriceLUnit, _SalesPriceBS, _MarginPct As Decimal
        Private _MarginRangeID, _Description As String
        Private _UserInsert, _UserUpdate As String
        Private _InsertDate, _UpdateDate As String
        Private _IsActive As Boolean

        Private _ItemMUnitFactor, _ItemLUnitFactor As Decimal
        Private _ItemCurrentSUnitID, _ItemCurrentMUnitID, _ItemCurrentLUnitID As String
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " Overrides Function(s) "
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SET XACT_ABORT ON " & _
                                        "BEGIN TRAN " & _
                                        "INSERT INTO Item " & _
                                        "(ItemSeqNo, ItemID, ItemName, ItemStatusID, PrintName, BrandNameID, " & _
                                        "ItemSize, ItemCategoryID, ItemSubCategoryID, " & _
                                        "IsFood, IsFresh, IsHalal, IsLegal, IsImport, IsHouseBrand, " & _
                                        "ManufacturerID, ProducerID, DistributorID, CountryID, " & _
                                        "ItemSUnitID, ItemMUnitID, ItemLUnitID, " & _
                                        "MarginRangeID, Description, " & _
                                        "IsActive, UserInsert, InsertDate, UserUpdate, UpdateDate) VALUES " & _
                                        "(@ItemSeqNo, @ItemID, @ItemName, @ItemStatusID, @PrintName, @BrandNameID, " & _
                                        "@ItemSize, @ItemCategoryID, @ItemSubCategoryID, " & _
                                        "@IsFood, @IsFresh, @IsHalal, @IsLegal, @IsImport, @IsHouseBrand, " & _
                                        "@ManufacturerID, @ProducerID, @DistributorID, @CountryID, " & _
                                        "@ItemSUnitID, @ItemMUnitID, @ItemLUnitID, " & _
                                        "@MarginRangeID, @Description, " & _
                                        "@IsActive, @UserInsert, GetDate(), @UserUpdate, GetDate()) " & _
                                        "INSERT INTO ItemFactorTemplate " & _
                                        "(ItemSeqNo, ItemUnitID, ItemFactor, UserInsert, InsertDate, " & _
                                        "UserUpdate, UpdateDate) " & _
                                        "VALUES " & _
                                        "(@ItemSeqNo, @ItemSUnitID, 1, @UserInsert, GetDate(), " & _
                                        "@UserUpdate, GetDate()) " & _
                                        "IF @ItemMUnitID <> " & "'none'" & _
                                        "BEGIN " & _
                                        "INSERT INTO ItemFactorTemplate " & _
                                        "(ItemSeqNo, ItemUnitID, ItemFactor, UserInsert, InsertDate, " & _
                                        "UserUpdate, UpdateDate) " & _
                                        "VALUES " & _
                                        "(@ItemSeqNo, @ItemMUnitID, @ItemMUnitFactor, @UserInsert, GetDate(), " & _
                                        "@UserUpdate, GetDate()) " & _
                                        "END " & _
                                        "IF @ItemLUnitID <> " & "'none'" & _
                                        "BEGIN " & _
                                        "INSERT INTO ItemFactorTemplate " & _
                                        "(ItemSeqNo, ItemUnitID, ItemFactor, UserInsert, InsertDate, " & _
                                        "UserUpdate, UpdateDate) " & _
                                        "VALUES " & _
                                        "(@ItemSeqNo, @ItemLUnitID, @ItemLUnitFactor, @UserInsert, GetDate(), " & _
                                        "@UserUpdate, GetDate()) " & _
                                        "END " & _
                                        "COMMIT TRAN"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.Add("@ItemID", _ItemID)
                cmdToExecute.Parameters.Add("@ItemName", _ItemName)
                cmdToExecute.Parameters.Add("@ItemStatusID", _ItemStatusID)
                cmdToExecute.Parameters.Add("@PrintName", _PrintName)
                cmdToExecute.Parameters.Add("@BrandNameID", _BrandNameID)
                cmdToExecute.Parameters.Add("@ItemSize", _ItemSize)
                cmdToExecute.Parameters.Add("@ItemCategoryID", _ItemCategoryID)
                cmdToExecute.Parameters.Add("@ItemSubCategoryID", _ItemSubCategoryID)
                cmdToExecute.Parameters.Add("@IsFood", _IsFood)
                cmdToExecute.Parameters.Add("@IsFresh", _IsFresh)
                cmdToExecute.Parameters.Add("@IsHalal", _IsHalal)
                cmdToExecute.Parameters.Add("@IsLegal", _IsLegal)
                cmdToExecute.Parameters.Add("@IsImport", _IsImport)
                cmdToExecute.Parameters.Add("@IsHouseBrand", _IsHouseBrand)
                cmdToExecute.Parameters.Add("@ManufacturerID", _ManufacturerID)
                cmdToExecute.Parameters.Add("@ProducerID", _ProducerID)
                cmdToExecute.Parameters.Add("@DistributorID", _DistributorID)
                cmdToExecute.Parameters.Add("@CountryID", _CountryID)
                cmdToExecute.Parameters.Add("@ItemSUnitID", _ItemSUnitID)
                cmdToExecute.Parameters.Add("@ItemMUnitID", _ItemMUnitID)
                cmdToExecute.Parameters.Add("@ItemLUnitID", _ItemLUnitID)
                cmdToExecute.Parameters.Add("@MarginRangeID", _MarginRangeID)
                cmdToExecute.Parameters.Add("@Description", _Description)
                cmdToExecute.Parameters.Add("@IsActive", _IsActive)
                cmdToExecute.Parameters.Add("@UserInsert", _UserInsert)
                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)

                cmdToExecute.Parameters.Add("@ItemMUnitFactor", _ItemMUnitFactor)
                cmdToExecute.Parameters.Add("@ItemLUnitFactor", _ItemLUnitFactor)

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

            cmdToExecute.CommandText = "SET XACT_ABORT ON " & _
                                        "BEGIN TRAN " & _
                                        "UPDATE Item " & _
                                        "SET ItemID = @ItemID, " & _
                                        "ItemName = @ItemName, " & _
                                        "ItemStatusID = @ItemStatusID, " & _
                                        "PrintName = @PrintName, " & _
                                        "BrandNameID = @BrandNameID, " & _
                                        "ItemSize = @ItemSize, " & _
                                        "ItemCategoryID = @ItemCategoryID, " & _
                                        "ItemSubCategoryID = @ItemSubCategoryID, " & _
                                        "IsFood = @IsFood, " & _
                                        "IsFresh = @IsFresh, " & _
                                        "IsHalal = @IsHalal, " & _
                                        "IsLegal = @IsLegal, " & _
                                        "IsImport = @IsImport, " & _
                                        "IsHouseBrand = @IsHouseBrand, " & _
                                        "ManufacturerID = @ManufacturerID, " & _
                                        "ProducerID = @ProducerID, " & _
                                        "DistributorID = @DistributorID, " & _
                                        "CountryID = @CountryID, " & _
                                        "ItemSUnitID = @ItemSUnitID, " & _
                                        "ItemMUnitID = @ItemMUnitID, " & _
                                        "ItemLUnitID = @ItemLUnitID, " & _
                                        "MarginRangeID = @MarginRangeID, " & _
                                        "Description = @Description, " & _
                                        "IsActive = @IsActive, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate() " & _
                                        "WHERE ItemSeqNo = @ItemSeqNo " & _
                                        "IF EXISTS(SELECT * FROM ItemFactorTemplate WHERE ItemSeqNo = @ItemSeqNo AND ItemUnitID = @ItemCurrentSUnitID) " & _
                                        "BEGIN " & _
                                        "UPDATE ItemFactorTemplate " & _
                                        "SET ItemUnitID = @ItemSUnitID, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate() " & _
                                        "WHERE ItemSeqNo = @ItemSeqNo AND ItemUnitID = @ItemCurrentSUnitID " & _
                                        "END " & _
                                        "ELSE " & _
                                        "BEGIN " & _
                                        "INSERT INTO ItemFactorTemplate " & _
                                        "(ItemSeqNo, ItemUnitID, ItemFactor, UserInsert, InsertDate, " & _
                                        "UserUpdate, UpdateDate) " & _
                                        "VALUES " & _
                                        "(@ItemSeqNo, @ItemSUnitID, 1, @UserInsert, GetDate(), " & _
                                        "@UserUpdate, GetDate()) " & _
                                        "END " & _
                                        "IF EXISTS(SELECT * FROM ItemFactorTemplate WHERE ItemSeqNo = @ItemSeqNo AND ItemUnitID = @ItemCurrentMUnitID) " & _
                                        "BEGIN " & _
                                        "UPDATE ItemFactorTemplate " & _
                                        "SET ItemUnitID = @ItemMUnitID, " & _
                                        "ItemFactor = @ItemMUnitFactor, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate() " & _
                                        "WHERE ItemSeqNo = @ItemSeqNo AND ItemUnitID = @ItemCurrentMUnitID " & _
                                        "END " & _
                                        "ELSE " & _
                                        "BEGIN " & _
                                        "INSERT INTO ItemFactorTemplate " & _
                                        "(ItemSeqNo, ItemUnitID, ItemFactor, UserInsert, InsertDate, " & _
                                        "UserUpdate, UpdateDate) " & _
                                        "VALUES " & _
                                        "(@ItemSeqNo, @ItemMUnitID, @ItemMUnitFactor, @UserInsert, GetDate(), " & _
                                        "@UserUpdate, GetDate()) " & _
                                        "END " & _
                                        "IF EXISTS(SELECT * FROM ItemFactorTemplate WHERE ItemSeqNo = @ItemSeqNo AND ItemUnitID = @ItemCurrentLUnitID) " & _
                                        "BEGIN " & _
                                        "UPDATE ItemFactorTemplate " & _
                                        "SET ItemUnitID = @ItemLUnitID, " & _
                                        "ItemFactor = @ItemLUnitFactor, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate() " & _
                                        "WHERE ItemSeqNo = @ItemSeqNo AND ItemUnitID = @ItemCurrentLUnitID " & _
                                        "END " & _
                                        "ELSE " & _
                                        "BEGIN " & _
                                        "INSERT INTO ItemFactorTemplate " & _
                                        "(ItemSeqNo, ItemUnitID, ItemFactor, UserInsert, InsertDate, " & _
                                        "UserUpdate, UpdateDate) " & _
                                        "VALUES " & _
                                        "(@ItemSeqNo, @ItemLUnitID, @ItemLUnitFactor, @UserInsert, GetDate(), " & _
                                        "@UserUpdate, GetDate()) " & _
                                        "END " & _
                                        "COMMIT TRAN"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.Add("@ItemID", _ItemID)
                cmdToExecute.Parameters.Add("@ItemName", _ItemName)
                cmdToExecute.Parameters.Add("@ItemStatusID", _ItemStatusID)
                cmdToExecute.Parameters.Add("@PrintName", _PrintName)
                cmdToExecute.Parameters.Add("@BrandNameID", _BrandNameID)
                cmdToExecute.Parameters.Add("@ItemSize", _ItemSize)
                cmdToExecute.Parameters.Add("@ItemCategoryID", _ItemCategoryID)
                cmdToExecute.Parameters.Add("@ItemSubCategoryID", _ItemSubCategoryID)
                cmdToExecute.Parameters.Add("@IsFood", _IsFood)
                cmdToExecute.Parameters.Add("@IsFresh", _IsFresh)
                cmdToExecute.Parameters.Add("@IsHalal", _IsHalal)
                cmdToExecute.Parameters.Add("@IsLegal", _IsLegal)
                cmdToExecute.Parameters.Add("@IsImport", _IsImport)
                cmdToExecute.Parameters.Add("@IsHouseBrand", _IsHouseBrand)
                cmdToExecute.Parameters.Add("@ManufacturerID", _ManufacturerID)
                cmdToExecute.Parameters.Add("@ProducerID", _ProducerID)
                cmdToExecute.Parameters.Add("@DistributorID", _DistributorID)
                cmdToExecute.Parameters.Add("@CountryID", _CountryID)
                cmdToExecute.Parameters.Add("@ItemSUnitID", _ItemSUnitID)
                cmdToExecute.Parameters.Add("@ItemMUnitID", _ItemMUnitID)
                cmdToExecute.Parameters.Add("@ItemLUnitID", _ItemLUnitID)
                cmdToExecute.Parameters.Add("@MarginRangeID", _MarginRangeID)
                cmdToExecute.Parameters.Add("@Description", _Description)
                cmdToExecute.Parameters.Add("@IsActive", _IsActive)
                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)

                cmdToExecute.Parameters.Add("@ItemMUnitFactor", _ItemMUnitFactor)
                cmdToExecute.Parameters.Add("@ItemLUnitFactor", _ItemLUnitFactor)
                cmdToExecute.Parameters.Add("@ItemCurrentSUnitID", _ItemCurrentSUnitID)
                cmdToExecute.Parameters.Add("@ItemCurrentMUnitID", _ItemCurrentMUnitID)
                cmdToExecute.Parameters.Add("@ItemCurrentLUnitID", _ItemCurrentLUnitID)
                cmdToExecute.Parameters.Add("@UserInsert", _UserInsert)

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

            cmdToExecute.CommandText = "SELECT * FROM Item"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Item")
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

        Public Function SelectAllForItemSeqNo(ByVal Filter As String, Optional ByVal MaxRecord As String = "") As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT top " + MaxRecord.Trim + " * FROM Item " & _
                                       "Where IsActive = 1 " & _
                                       "and (ItemSeqNo LIKE '" + Filter.Trim + "%' OR ItemId LIKE '" + Filter.Trim + "%' OR ItemName LIKE '" + Filter.Trim + "%') " & _
                                       "order by ItemId"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Item")
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
                    cmdToExecute.CommandText = "SELECT i.*, " & _
                                                "ISNULL((SELECT ItemFactor FROM ItemFactorTemplate " & _
                                                "WHERE ItemSeqNo = i.ItemSeqNo AND ItemUnitID = i.ItemMUnitID),0) AS ItemMUnitFactor, " & _
                                                "ISNULL((SELECT ItemFactor FROM ItemFactorTemplate " & _
                                                "WHERE ItemSeqNo = i.ItemSeqNo AND ItemUnitID = i.ItemLUnitID),0) AS ItemLUnitFactor " & _
                                                "FROM Item i WHERE i.ItemSeqNo = @ItemSeqNo"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT i.*, " & _
                                                "ISNULL((SELECT ItemFactor FROM ItemFactorTemplate " & _
                                                "WHERE ItemSeqNo = i.ItemSeqNo AND ItemUnitID = i.ItemMUnitID),0) AS ItemMUnitFactor, " & _
                                                "ISNULL((SELECT ItemFactor FROM ItemFactorTemplate " & _
                                                "WHERE ItemSeqNo = i.ItemSeqNo AND ItemUnitID = i.ItemLUnitID),0) AS ItemLUnitFactor " & _
                                                "FROM Item i WHERE i.ItemSeqNo > @ItemSeqNo ORDER BY i.ItemSeqNo ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT i.*, " & _
                                                "ISNULL((SELECT ItemFactor FROM ItemFactorTemplate " & _
                                                "WHERE ItemSeqNo = i.ItemSeqNo AND ItemUnitID = i.ItemMUnitID),0) AS ItemMUnitFactor, " & _
                                                "ISNULL((SELECT ItemFactor FROM ItemFactorTemplate " & _
                                                "WHERE ItemSeqNo = i.ItemSeqNo AND ItemUnitID = i.ItemLUnitID),0) AS ItemLUnitFactor " & _
                                                "FROM Item i WHERE i.ItemSeqNo < @ItemSeqNo ORDER BY i.ItemSeqNo DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("Item")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _ItemSeqNo = CType(toReturn.Rows(0)("ItemSeqNo"), String)
                    _ItemID = CType(toReturn.Rows(0)("ItemID"), String)
                    _ItemName = CType(toReturn.Rows(0)("ItemName"), String)
                    _ItemStatusID = CType(toReturn.Rows(0)("ItemStatusID"), String)
                    _PrintName = CType(toReturn.Rows(0)("PrintName"), String)
                    _BrandNameID = CType(toReturn.Rows(0)("BrandNameID"), String)
                    _ItemSize = CType(toReturn.Rows(0)("ItemSize"), String)
                    _ItemCategoryID = CType(toReturn.Rows(0)("ItemCategoryID"), String)
                    _ItemSubCategoryID = CType(toReturn.Rows(0)("ItemSubCategoryID"), String)
                    _IsFood = CType(toReturn.Rows(0)("IsFood"), Boolean)
                    _IsFresh = CType(toReturn.Rows(0)("IsFresh"), Boolean)
                    _IsHalal = CType(toReturn.Rows(0)("IsHalal"), Boolean)
                    _IsLegal = CType(toReturn.Rows(0)("IsLegal"), Boolean)
                    _IsImport = CType(toReturn.Rows(0)("IsImport"), Boolean)
                    _IsHouseBrand = CType(toReturn.Rows(0)("IsHouseBrand"), Boolean)
                    _ManufacturerID = CType(toReturn.Rows(0)("ManufacturerID"), String)
                    _ProducerID = CType(toReturn.Rows(0)("ProducerID"), String)
                    _DistributorID = CType(toReturn.Rows(0)("DistributorID"), String)
                    _CountryID = CType(toReturn.Rows(0)("CountryID"), String)
                    _ItemSUnitID = CType(toReturn.Rows(0)("ItemSUnitID"), String)
                    _ItemMUnitID = CType(toReturn.Rows(0)("ItemMUnitID"), String)
                    _ItemLUnitID = CType(toReturn.Rows(0)("ItemLUnitID"), String)
                    _MarginRangeID = CType(toReturn.Rows(0)("MarginRangeID"), String)
                    _Description = CType(toReturn.Rows(0)("Description"), String)
                    _IsActive = CType(toReturn.Rows(0)("IsActive"), Boolean)
                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
                    _ItemMUnitFactor = CType(toReturn.Rows(0)("ItemMUnitFactor"), Decimal)
                    _ItemLUnitFactor = CType(toReturn.Rows(0)("ItemLUnitFactor"), Decimal)
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

            cmdToExecute.CommandText = "SET XACT_ABORT ON " & _
                                        "BEGIN TRAN " & _
                                        "DELETE FROM Item WHERE ItemSeqNo = @ItemSeqNo " & _
                                        "DELETE FROM ItemFactorTemplate WHERE ItemSeqNo = @ItemSeqNo " & _
                                        "COMMIT TRAN"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)

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
#End Region

#Region " Custom Function(s) "
        Public Function SelectOneByItemID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT ItemSeqNo, ItemID, ItemName FROM Item WHERE ItemID = @ItemID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Item")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ItemID", _ItemID)
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

        Public Function SelectAllItemUnitByItemSeqNo() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT i.ItemUnitID, ISNULL(iu.ItemUnitName,'') AS ItemUnitName  " & _
                                        "FROM (" & _
                                         "SELECT i.ItemSUnitID AS ItemUnitID FROM Item i WHERE i.ItemSeqNo = @ItemSeqNo AND i.ItemSUnitID <> '' " & _
                                         "UNION ALL " & _
                                         "SELECT i.ItemMUnitID AS ItemUnitID FROM Item i WHERE i.ItemSeqNo = @ItemSeqNo AND i.ItemMUnitID <> ''" & _
                                         "UNION ALL " & _
                                         "SELECT i.ItemLUnitID AS ItemUnitID FROM Item i WHERE i.ItemSeqNo = @ItemSeqNo AND i.ItemLUnitID <> '' " & _
                                        ") i " & _
                                        "LEFT JOIN ItemUnit iu ON iu.ItemUnitID = i.ItemUnitID "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Item")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)
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
        Public Property [ItemSeqNo]() As String
            Get
                Return _ItemSeqNo
            End Get
            Set(ByVal Value As String)
                _ItemSeqNo = Value
            End Set
        End Property

        Public Property [ItemID]() As String
            Get
                Return _ItemID
            End Get
            Set(ByVal Value As String)
                _ItemID = Value
            End Set
        End Property

        Public Property [ItemName]() As String
            Get
                Return _ItemName
            End Get
            Set(ByVal Value As String)
                _ItemName = Value
            End Set
        End Property

        Public Property [ItemStatusID]() As String
            Get
                Return _ItemStatusID
            End Get
            Set(ByVal Value As String)
                _ItemStatusID = Value
            End Set
        End Property

        Public Property [PrintName]() As String
            Get
                Return _PrintName
            End Get
            Set(ByVal Value As String)
                _PrintName = Value
            End Set
        End Property

        Public Property [BrandNameID]() As String
            Get
                Return _BrandNameID
            End Get
            Set(ByVal Value As String)
                _BrandNameID = Value
            End Set
        End Property

        Public Property [ItemSize]() As String
            Get
                Return _ItemSize
            End Get
            Set(ByVal Value As String)
                _ItemSize = Value
            End Set
        End Property

        Public Property [ItemCategoryID]() As String
            Get
                Return _ItemCategoryID
            End Get
            Set(ByVal Value As String)
                _ItemCategoryID = Value
            End Set
        End Property

        Public Property [ItemSubCategoryID]() As String
            Get
                Return _ItemSubCategoryID
            End Get
            Set(ByVal Value As String)
                _ItemSubCategoryID = Value
            End Set
        End Property

        Public Property [IsFood]() As Boolean
            Get
                Return _IsFood
            End Get
            Set(ByVal Value As Boolean)
                _IsFood = Value
            End Set
        End Property

        Public Property [IsFresh]() As Boolean
            Get
                Return _IsFresh
            End Get
            Set(ByVal Value As Boolean)
                _IsFresh = Value
            End Set
        End Property

        Public Property [IsHalal]() As Boolean
            Get
                Return _IsHalal
            End Get
            Set(ByVal Value As Boolean)
                _IsHalal = Value
            End Set
        End Property

        Public Property [IsLegal]() As Boolean
            Get
                Return _IsLegal
            End Get
            Set(ByVal Value As Boolean)
                _IsLegal = Value
            End Set
        End Property

        Public Property [IsImport]() As Boolean
            Get
                Return _IsImport
            End Get
            Set(ByVal Value As Boolean)
                _IsImport = Value
            End Set
        End Property

        Public Property [IsHouseBrand]() As Boolean
            Get
                Return _IsHouseBrand
            End Get
            Set(ByVal Value As Boolean)
                _IsHouseBrand = Value
            End Set
        End Property

        Public Property [ManufacturerID]() As String
            Get
                Return _ManufacturerID
            End Get
            Set(ByVal Value As String)
                _ManufacturerID = Value
            End Set
        End Property

        Public Property [ProducerID]() As String
            Get
                Return _ProducerID
            End Get
            Set(ByVal Value As String)
                _ProducerID = Value
            End Set
        End Property

        Public Property [DistributorID]() As String
            Get
                Return _DistributorID
            End Get
            Set(ByVal Value As String)
                _DistributorID = Value
            End Set
        End Property

        Public Property [CountryID]() As String
            Get
                Return _CountryID
            End Get
            Set(ByVal Value As String)
                _CountryID = Value
            End Set
        End Property

        Public Property [ItemSUnitID]() As String
            Get
                Return _ItemSUnitID
            End Get
            Set(ByVal Value As String)
                _ItemSUnitID = Value
            End Set
        End Property

        Public Property [ItemMUnitID]() As String
            Get
                Return _ItemMUnitID
            End Get
            Set(ByVal Value As String)
                _ItemMUnitID = Value
            End Set
        End Property

        Public Property [ItemLUnitID]() As String
            Get
                Return _ItemLUnitID
            End Get
            Set(ByVal Value As String)
                _ItemLUnitID = Value
            End Set
        End Property

        Public Property [MarginRangeID]() As String
            Get
                Return _MarginRangeID
            End Get
            Set(ByVal Value As String)
                _MarginRangeID = Value
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

        Public Property [IsActive]() As Boolean
            Get
                Return _IsActive
            End Get
            Set(ByVal Value As Boolean)
                _IsActive = Value
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

        Public Property [ItemMUnitFactor]() As Decimal
            Get
                Return _ItemMUnitFactor
            End Get
            Set(ByVal Value As Decimal)
                _ItemMUnitFactor = Value
            End Set
        End Property

        Public Property [ItemLUnitFactor]() As Decimal
            Get
                Return _ItemLUnitFactor
            End Get
            Set(ByVal Value As Decimal)
                _ItemLUnitFactor = Value
            End Set
        End Property

        Public Property [ItemCurrentSUnitID]() As String
            Get
                Return _ItemCurrentSUnitID
            End Get
            Set(ByVal Value As String)
                _ItemCurrentSUnitID = Value
            End Set
        End Property

        Public Property [ItemCurrentMUnitID]() As String
            Get
                Return _ItemCurrentMUnitID
            End Get
            Set(ByVal Value As String)
                _ItemCurrentMUnitID = Value
            End Set
        End Property

        Public Property [ItemCurrentLUnitID]() As String
            Get
                Return _ItemCurrentLUnitID
            End Get
            Set(ByVal Value As String)
                _ItemCurrentLUnitID = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
