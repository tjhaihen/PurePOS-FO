Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class Promotiondt
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ID, _ItemSeqNo As String
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO Promotiondt " & _
                                        "(ID, ItemSeqNo) " & _
                                        "VALUES (@ID, @ItemSeqNo)"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)
                
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


        Public Function SelectAllByID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT dt.*,isnull(i.ItemId,'') as ItemId,isnull(i.ItemName,'') as ItemName FROM Promotiondt dt " & _
                                       "left join item i on i.ItemSeqNo = dt.ItemSeqNo " & _
                                       "where dt.ID = @ID "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PromotionDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
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

       

        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "DELETE FROM Promotiondt WHERE ID = @ID and ItemSeqNo = @ItemSeqNo"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
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
#Region " Others Function "
        Public Function SelectAllForGridItem() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT * FROM item i " & _
                                       "WHERE(i.IsActive = 1) " & _
                                       "AND i.ItemSeqNo NOT IN " & _
                                       "(SELECT dt.ItemSeqNo FROM PromotionDt dt " & _
                                                            "WHERE dt.ID IN ( " & _
                                                            "SELECT hdP.ID FROM PromotionHD hdP " & _
                                                            "WHERE hdP.IsActive = 1 " & _
                                                            "AND convert(varchar(8),hdP.StartDate,112) >= CONVERT(VARCHAR(8),(SELECT hdS.StartDate FROM PromotionHD hdS WHERE hdS.IsActive = 1 AND HdS.ID = @ID),112) " & _
                                                            "AND convert(varchar(8),hdP.EndDate,112) <= CONVERT(VARCHAR(8),(SELECT hdD.EndDate FROM PromotionHD hdD WHERE hdD.IsActive = 1 AND HdD.ID = @ID),112))) "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Item")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
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
        Public Property [ItemSeqNo]() As String
            Get
                Return _ItemSeqNo
            End Get
            Set(ByVal Value As String)
                _ItemSeqNo = Value
            End Set
        End Property


#End Region

    End Class
End Namespace
