Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class ItemSubCategory
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ItemSubCategoryID, _ItemCategoryID, _ItemSubCategoryName, _Description As String
        Private _UserInsert, _UserUpdate As String
        Private _InsertDate, _UpdateDate As String
        Private _SalesDiscountPct, _SalesDiscountAmt As Decimal
        Private _IsActive As Boolean
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO ItemSubCategory " & _
                                        "(ItemSubCategoryID, ItemCategoryID, ItemSubCategoryName, Description, SalesDiscountPct, SalesDiscountAmt, isActive, UserInsert, InsertDate, UserUpdate, UpdateDate) " & _
                                        "VALUES (@ItemSubCategoryID, @ItemCategoryID, @ItemSubCategoryName, @Description, @SalesDiscountPct, @SalesDiscountAmt, @IsActive, @UserInsert, GetDate(), @UserUpdate, GetDate())"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ItemSubCategoryID", _ItemSubCategoryID)
                cmdToExecute.Parameters.Add("@ItemCategoryID", _ItemCategoryID)
                cmdToExecute.Parameters.Add("@ItemSubCategoryName", _ItemSubCategoryName)
                cmdToExecute.Parameters.Add("@Description", _Description)
                cmdToExecute.Parameters.Add("@SalesDiscountPct", _SalesDiscountPct)
                cmdToExecute.Parameters.Add("@SalesDiscountAmt", _SalesDiscountAmt)
                cmdToExecute.Parameters.Add("@IsActive", _IsActive)
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

            cmdToExecute.CommandText = "UPDATE ItemSubCategory " & _
                                        "SET ItemSubCategoryName = @ItemSubCategoryName, " & _
                                        "IsActive = @IsActive, " & _
                                        "Description = @Description, " & _
                                        "SalesDiscountPct = @SalesDiscountPct, " & _
                                        "SalesDiscountAmt = @SalesDiscountAmt, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate() " & _
                                        "WHERE ItemCategoryID = @ItemCategoryID " & _
                                        "AND ItemSubCategoryID = @ItemSubCategoryID"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ItemSubCategoryID", _ItemSubCategoryID)
                cmdToExecute.Parameters.Add("@ItemCategoryID", _ItemCategoryID)
                cmdToExecute.Parameters.Add("@ItemSubCategoryName", _ItemSubCategoryName)
                cmdToExecute.Parameters.Add("@Description", _Description)
                cmdToExecute.Parameters.Add("@SalesDiscountPct", _SalesDiscountPct)
                cmdToExecute.Parameters.Add("@SalesDiscountAmt", _SalesDiscountAmt)
                cmdToExecute.Parameters.Add("@IsActive", _IsActive)
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

            cmdToExecute.CommandText = "SELECT * FROM ItemSubCategory"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ItemSubCategory")
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
                    cmdToExecute.CommandText = "SELECT * FROM ItemSubCategory WHERE ItemCategoryID = @ItemCategoryID AND ItemSubCategoryID = @ItemSubCategoryID"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM ItemSubCategory WHERE ItemCategoryID = @ItemCategoryID AND ItemSubCategoryID > @ItemSubCategoryID ORDER BY ItemCategoryID, ItemSubCategoryID ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM ItemSubCategory WHERE ItemCategoryID = @ItemCategoryID AND ItemSubCategoryID < @ItemSubCategoryID ORDER BY ItemCategoryID, ItemSubCategoryID DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ItemSubCategory")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ItemSubCategoryID", _ItemSubCategoryID)
                cmdToExecute.Parameters.Add("@ItemCategoryID", _ItemCategoryID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _ItemSubCategoryID = CType(toReturn.Rows(0)("ItemSubCategoryID"), String)
                    _ItemCategoryID = CType(toReturn.Rows(0)("ItemCategoryID"), String)
                    _ItemSubCategoryName = CType(toReturn.Rows(0)("ItemSubCategoryName"), String)
                    _Description = CType(toReturn.Rows(0)("Description"), String)
                    _SalesDiscountPct = CType(toReturn.Rows(0)("SalesDiscountPct"), Decimal)
                    _SalesDiscountAmt = CType(toReturn.Rows(0)("SalesDiscountAmt"), Decimal)
                    _IsActive = CType(toReturn.Rows(0)("IsActive"), Boolean)
                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
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

            cmdToExecute.CommandText = "DELETE FROM ItemSubCategory WHERE ItemCategoryID = @ItemCategoryID AND ItemSubCategoryID = @ItemSubCategoryID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ItemSubCategoryID", _ItemSubCategoryID)
                cmdToExecute.Parameters.Add("@ItemCategoryID", _ItemCategoryID)

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

        Public Function SelectByItemCategoryID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT * FROM ItemSubCategory WHERE ItemCategoryID = @ItemCategoryID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ItemSubCategory")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ItemCategoryID", _ItemCategoryID)

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

#Region " Class Property Declarations "
        Public Property [ItemSubCategoryID]() As String
            Get
                Return _ItemSubCategoryID
            End Get
            Set(ByVal Value As String)
                _ItemSubCategoryID = Value
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

        Public Property [ItemSubCategoryName]() As String
            Get
                Return _ItemSubCategoryName
            End Get
            Set(ByVal Value As String)
                _ItemSubCategoryName = Value
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

        Public Property [SalesDiscountPct]() As Decimal
            Get
                Return _SalesDiscountPct
            End Get
            Set(ByVal Value As Decimal)
                _SalesDiscountPct = Value
            End Set
        End Property

        Public Property [SalesDiscountAmt]() As Decimal
            Get
                Return _SalesDiscountAmt
            End Get
            Set(ByVal Value As Decimal)
                _SalesDiscountAmt = Value
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
#End Region

    End Class
End Namespace
