Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Partial Public Class Item
        Public Function LoadByItemID(ByVal itemID As String) As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * " & _
                                       "FROM Item i WHERE i.ItemID = @ItemID"

            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("Item")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)
            Dim retval As Boolean = False
            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ItemID", itemID)

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
                    '_SalesPriceSUnit = CType(toReturn.Rows(0)("SalesPriceSUnit"), Decimal)
                    '_SalesPriceLUnit = CType(toReturn.Rows(0)("SalesPriceLUnit"), Decimal)
                    '_SalesPriceBS = CType(toReturn.Rows(0)("SalesPriceBS"), Decimal)
                    '_MarginPct = CType(toReturn.Rows(0)("MarginPct"), Decimal)
                    _MarginRangeID = CType(toReturn.Rows(0)("MarginRangeID"), String)
                    _Description = CType(toReturn.Rows(0)("Description"), String)
                    _IsActive = CType(toReturn.Rows(0)("IsActive"), Boolean)
                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
                    '_ItemMUnitFactor = CType(toReturn.Rows(0)("ItemMUnitFactor"), Decimal)
                    '_ItemLUnitFactor = CType(toReturn.Rows(0)("ItemLUnitFactor"), Decimal)
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

        Public Function SelectByIdOrName(ByVal searchText As String, Optional ByVal MaxRecord As String = "500") As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand


            cmdToExecute.CommandText = "SELECT top " + MaxRecord + " i.ItemID,i.ItemName,b.QtySUnit AS Balance,i.ItemSUnitID FROM Item i " +
                "LEFT JOIN ItemBalance b ON i.ItemSeqNo=b.ItemSeqNo " +
                "WHERE (i.ItemName LIKE @sSearchTextIn OR i.ItemID=@sSearchText) " +
                "AND b.WhID=(SELECT DetailID FROM CommonSetting WHERE GroupID='WhIDPos') " +
                "AND b.UnitID=(SELECT DetailID FROM CommonSetting WHERE GroupID='UnitIDPos') " +
                "ORDER BY i.ItemName"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Item")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                _mainConnection.Open()
                cmdToExecute.Parameters.AddWithValue("@sSearchTextIn", String.Format("%{0}%", searchText))
                cmdToExecute.Parameters.AddWithValue("@sSearchText", searchText)
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