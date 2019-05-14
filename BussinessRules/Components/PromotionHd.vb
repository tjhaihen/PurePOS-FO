Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class PromotionHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ID, _PromotionName, _PromotionTypeID, _Description As String
        Private _SpecialPrice, _BuyQty, _GetQty, _Disc1Pct, _Disc2Pct, _BuyAmt, _GetVoucherAmt, _nPurchase As Decimal
        Private _UserInsert, _UserUpdate As String
        Private _StartDate, _EndDate, _InsertDate, _UpdateDate As String
        Private _IsMultipleApplied, _IsActive As Boolean
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO PromotionHd " & _
                                        "(ID, PromotionName, StartDate, EndDate, PromotionTypeID, SpecialPrice, BuyQty, GetQty, " & _
                                        " Disc1Pct, Disc2Pct, BuyAmt, IsMultipleApplied, GetVoucherAmt, nPurchase, " & _
                                        " UserInsert, InsertDate, UserUpdate, UpdateDate, isActive, Description) " & _
                                        "VALUES (@ID, @PromotionName, @StartDate, @EndDate, @PromotionTypeID, @SpecialPrice, @BuyQty, @GetQty, " & _
                                        " @Disc1Pct, @Disc2Pct, @BuyAmt, @IsMultipleApplied, @GetVoucherAmt, @nPurchase, " & _
                                        " @UserInsert, getdate(), @UserUpdate, getdate(), @isActive, @Description)"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@PromotionName", _PromotionName)
                cmdToExecute.Parameters.Add("@StartDate", _StartDate)
                cmdToExecute.Parameters.Add("@EndDate", _EndDate)
                cmdToExecute.Parameters.Add("@PromotionTypeID", _PromotionTypeID)
                cmdToExecute.Parameters.Add("@SpecialPrice", _SpecialPrice)
                cmdToExecute.Parameters.Add("@BuyQty", _BuyQty)
                cmdToExecute.Parameters.Add("@GetQty", _GetQty)
                cmdToExecute.Parameters.Add("@Disc1Pct", _Disc1Pct)
                cmdToExecute.Parameters.Add("@Disc2Pct", _Disc2Pct)
                cmdToExecute.Parameters.Add("@BuyAmt", _BuyAmt)
                cmdToExecute.Parameters.Add("@IsMultipleApplied", _IsMultipleApplied)
                cmdToExecute.Parameters.Add("@GetVoucherAmt", _GetVoucherAmt)
                cmdToExecute.Parameters.Add("@nPurchase", _nPurchase)
                cmdToExecute.Parameters.Add("@UserInsert", _UserInsert)
                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)
                cmdToExecute.Parameters.Add("@isActive", _IsActive)
                cmdToExecute.Parameters.Add("@Description", _Description)

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

            cmdToExecute.CommandText = "UPDATE PromotionHd " & _
                                        "SET PromotionName = @PromotionName, " & _
                                        "StartDate = @StartDate, " & _
                                        "EndDate = @EndDate, " & _
                                        "PromotionTypeID = @PromotionTypeID, " & _
                                        "SpecialPrice = @SpecialPrice, " & _
                                        "BuyQty = @BuyQty, " & _
                                        "GetQty = @GetQty, " & _
                                        "Disc1Pct = @Disc1Pct, " & _
                                        "Disc2Pct = @Disc2Pct, " & _
                                        "BuyAmt = @BuyAmt, " & _
                                        "IsMultipleApplied = @IsMultipleApplied, " & _
                                        "GetVoucherAmt = @GetVoucherAmt, " & _
                                        "nPurchase = @nPurchase, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "isActive = @isActive, " & _
                                        "Description = @Description " & _
                                        "WHERE ID = @ID"

            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@PromotionName", _PromotionName)
                cmdToExecute.Parameters.Add("@StartDate", _StartDate)
                cmdToExecute.Parameters.Add("@EndDate", _EndDate)
                cmdToExecute.Parameters.Add("@PromotionTypeID", _PromotionTypeID)
                cmdToExecute.Parameters.Add("@SpecialPrice", _SpecialPrice)
                cmdToExecute.Parameters.Add("@BuyQty", _BuyQty)
                cmdToExecute.Parameters.Add("@GetQty", _GetQty)
                cmdToExecute.Parameters.Add("@Disc1Pct", _Disc1Pct)
                cmdToExecute.Parameters.Add("@Disc2Pct", _Disc2Pct)
                cmdToExecute.Parameters.Add("@BuyAmt", _BuyAmt)
                cmdToExecute.Parameters.Add("@IsMultipleApplied", _IsMultipleApplied)
                cmdToExecute.Parameters.Add("@GetVoucherAmt", _GetVoucherAmt)
                cmdToExecute.Parameters.Add("@nPurchase", _nPurchase)
                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)
                cmdToExecute.Parameters.Add("@isActive", _IsActive)
                cmdToExecute.Parameters.Add("@Description", _Description)

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

            cmdToExecute.CommandText = "SELECT hd.*, isnull(cs.DetailDesc,'') as PromotionTypeName FROM PromotionHd hd " + _
                                       "left join CommonSetting cs on cs.GroupID = 'PromotionType' and cs.DetailID = hd.PromotionTypeID order by hd.ID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PromotionHd")
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

        Public Function SelectAllForID(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " hd.*, isnull(cs.DetailDesc,'') as PromotionTypeName FROM PromotionHd hd " + _
                                       "left join CommonSetting cs on cs.GroupID = 'PromotionType' and cs.DetailID = hd.PromotionTypeID " + _
                                       "Where hd.ID LIKE '" + Filter.Trim + "%' OR hd.PromotionName LIKE '" + Filter.Trim + "%' " + _
                                       "order by hd.ID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PromotionHd")
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
                    cmdToExecute.CommandText = "SELECT * FROM PromotionHd WHERE ID = @ID"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM PromotionHd WHERE ID > @ID ORDER BY ID ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM PromotionHd WHERE ID < @ID ORDER BY ID DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("PromotionHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _ID = CType(toReturn.Rows(0)("ID"), String)
                    _PromotionName = CType(toReturn.Rows(0)("PromotionName"), String)
                    _StartDate = CType(toReturn.Rows(0)("StartDate"), DateTime)
                    _EndDate = CType(toReturn.Rows(0)("EndDate"), DateTime)
                    _PromotionTypeID = CType(toReturn.Rows(0)("PromotionTypeID"), String)
                    _SpecialPrice = CType(toReturn.Rows(0)("SpecialPrice"), Decimal)
                    _BuyQty = CType(toReturn.Rows(0)("BuyQty"), Decimal)
                    _GetQty = CType(toReturn.Rows(0)("GetQty"), Decimal)
                    _Disc1Pct = CType(toReturn.Rows(0)("Disc1Pct"), Decimal)
                    _Disc2Pct = CType(toReturn.Rows(0)("Disc2Pct"), Decimal)
                    _BuyAmt = CType(toReturn.Rows(0)("BuyAmt"), Decimal)
                    _IsMultipleApplied = CType(toReturn.Rows(0)("IsMultipleApplied"), Boolean)
                    _GetVoucherAmt = CType(toReturn.Rows(0)("GetVoucherAmt"), Decimal)
                    _nPurchase = CType(toReturn.Rows(0)("nPurchase"), Decimal)
                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
                    _IsActive = CType(toReturn.Rows(0)("IsActive"), Boolean)
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

            cmdToExecute.CommandText = "DELETE FROM PromotionHd WHERE ID = @ID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)

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

#Region "Custom function"
        Public Function SelectInformationPromotion(ByVal FromDate As DateTime, ByVal thruDate As DateTime) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "sp_GetInformationPromotion"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("PromotionHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@FromDate", FromDate)
                cmdToExecute.Parameters.Add("@ThruDate", thruDate)
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

        Public Property [PromotionName]() As String
            Get
                Return _PromotionName
            End Get
            Set(ByVal Value As String)
                _PromotionName = Value
            End Set
        End Property

        Public Property [StartDate]() As DateTime
            Get
                Return _StartDate
            End Get
            Set(ByVal Value As DateTime)
                _StartDate = Value
            End Set
        End Property

        Public Property [EndDate]() As DateTime
            Get
                Return _EndDate
            End Get
            Set(ByVal Value As DateTime)
                _EndDate = Value
            End Set
        End Property

        Public Property [PromotionTypeID]() As String
            Get
                Return _PromotionTypeID
            End Get
            Set(ByVal Value As String)
                _PromotionTypeID = Value
            End Set
        End Property

        Public Property [SpecialPrice]() As Decimal
            Get
                Return _SpecialPrice
            End Get
            Set(ByVal Value As Decimal)
                _SpecialPrice = Value
            End Set
        End Property

        Public Property [BuyQty]() As Decimal
            Get
                Return _BuyQty
            End Get
            Set(ByVal Value As Decimal)
                _BuyQty = Value
            End Set
        End Property

        Public Property [GetQty]() As Decimal
            Get
                Return _GetQty
            End Get
            Set(ByVal Value As Decimal)
                _GetQty = Value
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

        Public Property [Disc2Pct]() As Decimal
            Get
                Return _Disc2Pct
            End Get
            Set(ByVal Value As Decimal)
                _Disc2Pct = Value
            End Set
        End Property

        Public Property [BuyAmt]() As Decimal
            Get
                Return _BuyAmt
            End Get
            Set(ByVal Value As Decimal)
                _BuyAmt = Value
            End Set
        End Property

        Public Property [IsMultipleApplied]() As Boolean
            Get
                Return _IsMultipleApplied
            End Get
            Set(ByVal Value As Boolean)
                _IsMultipleApplied = Value
            End Set
        End Property

        Public Property [GetVoucherAmt]() As Decimal
            Get
                Return _GetVoucherAmt
            End Get
            Set(ByVal Value As Decimal)
                _GetVoucherAmt = Value
            End Set
        End Property

        Public Property [nPurchase]() As Decimal
            Get
                Return _nPurchase
            End Get
            Set(ByVal Value As Decimal)
                _nPurchase = Value
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

        Public Property [IsActive]() As Boolean
            Get
                Return _IsActive
            End Get
            Set(ByVal Value As Boolean)
                _IsActive = Value
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
