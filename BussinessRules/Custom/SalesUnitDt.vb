Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules

    Partial Public Class SalesUnitDt
        Public Function SelectByNo(ByVal STxnNo As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "dbo.[usp_SalesUnitDt_SelectBySTxnNo]"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("SalesUnitDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@sSTxnNo", STxnNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
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
            Return Nothing
        End Function

        Public Function SelectByNoForCancelItem(ByVal STxnNo As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "dbo.[usp_SalesUnitDt_SelectBySTxnNo_ForCancelItem]"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("SalesUnitDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@sSTxnNo", STxnNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
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
            Return Nothing
        End Function

        Public Function SelectGetPriceItemDOorSales(ByVal TypeGetPrice As String, _
                                                    ByVal ItemSeqNo As String, _
                                                    ByVal ItemUnitID As String, _
                                                    ByVal ItemFactor As Decimal, _
                                                    ByVal CurrencyRate As Decimal, _
                                                    ByVal MemberNo As String, _
                                                    ByVal STxnNo As String, _
                                                    ByVal CurrentQty As Decimal
                                                    ) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "dbo.[sp_GetPriceItemDOorSales]"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("SalesUnitDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@TypeGetPrice", TypeGetPrice)
                cmdToExecute.Parameters.AddWithValue("@ItemSeqNo", ItemSeqNo)
                cmdToExecute.Parameters.AddWithValue("@ItemUnitID", ItemUnitID)
                cmdToExecute.Parameters.AddWithValue("@ItemFactor", ItemFactor)
                cmdToExecute.Parameters.AddWithValue("@CurrencyRate", CurrencyRate)
                cmdToExecute.Parameters.AddWithValue("@MemberNo", MemberNo)
                cmdToExecute.Parameters.AddWithValue("@STxnNo", STxnNo)
                cmdToExecute.Parameters.AddWithValue("@CurrentQty", CurrentQty)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
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
            Return Nothing
        End Function

        Public Function SelectGetPriceItemSalesFOAllByItemSeqNo(ByVal ItemSeqNo As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "dbo.[sp_GetPriceItemSalesFOAllByItemSeqNo]"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("sp_GetPriceItemSalesFOAllByItemSeqNo")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ItemSeqNo", ItemSeqNo)
                
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
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
            Return Nothing
        End Function
    End Class
End Namespace