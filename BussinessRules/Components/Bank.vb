Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class Bank
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _BankID, _BankTxnType, _BankName, _Branch, _AccountNo, _AccountTitle, _Address, _Currency As String
        Private _Description As String
        Private _UserInsert, _UserUpdate As String
        Private _InsertDate, _UpdateDate As String
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

            cmdToExecute.CommandText = "INSERT INTO BankAccount " & _
                                        "(BankID, BankTxnType, BankName, Branch, AccountNo, AccountTitle, Address, Currency, Description, isActive, UserInsert, InsertDate, UserUpdate, UpdateDate) " & _
                                        "VALUES (@BankID, @BankTxnType,@BankName, @Branch, @AccountNo, @AccountTitle, @Address, @Currency, @Description, @IsActive, @UserInsert, GetDate(), @UserUpdate, GetDate())"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@BankID", _BankID)
                cmdToExecute.Parameters.Add("@BankTxnType", _BankTxnType)
                cmdToExecute.Parameters.Add("@BankName", _BankName)
                cmdToExecute.Parameters.Add("@Branch", _Branch)
                cmdToExecute.Parameters.Add("@AccountNo", _AccountNo)
                cmdToExecute.Parameters.Add("@AccountTitle", _AccountTitle)
                cmdToExecute.Parameters.Add("@Address", _Address)
                cmdToExecute.Parameters.Add("@Currency", _Currency)
                cmdToExecute.Parameters.Add("@Description", _Description)
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

            cmdToExecute.CommandText = "UPDATE BankAccount " & _
                                        "SET BankName = @BankName, " & _
                                        "BankTxnType = @BankTxnType, " & _
                                        "Branch = @Branch, " & _
                                        "AccountNo = @AccountNo, " & _
                                        "AccountTitle = @AccountTitle, " & _
                                        "Address = @Address, " & _
                                        "Currency = @Currency, " & _
                                        "IsActive = @IsActive, " & _
                                        "Description = @Description, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate() " & _
                                        "WHERE BankID = @BankID"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@BankID", _BankID)
                cmdToExecute.Parameters.Add("@BankName", _BankName)
                cmdToExecute.Parameters.Add("@BankTxnType", _BankTxnType)
                cmdToExecute.Parameters.Add("@Branch", _Branch)
                cmdToExecute.Parameters.Add("@AccountNo", _AccountNo)
                cmdToExecute.Parameters.Add("@AccountTitle", _AccountTitle)
                cmdToExecute.Parameters.Add("@Address", _Address)
                cmdToExecute.Parameters.Add("@Currency", _Currency)
                cmdToExecute.Parameters.Add("@Description", _Description)
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

            cmdToExecute.CommandText = "SELECT b.*,isnull(cs.DetailDesc,'') as BankTxnTypeName,isnull(cs1.DetailDesc,'') as CurrencyName FROM BankAccount b " & _
                                       "left join CommonSetting cs on cs.GroupID = 'BankTxnType' and cs.DetailID = b.BankTxnType " & _
                                       "left join CommonSetting cs1 on cs1.GroupID = 'Currency' and cs1.DetailID = b.Currency order by b.BankId"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("BankAccount")
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

        Public Function SelectAllForBankID(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " b.*,isnull(cs.DetailDesc,'') as BankTxnTypeName,isnull(cs1.DetailDesc,'') as CurrencyName FROM BankAccount b " & _
                                       "left join CommonSetting cs on cs.GroupID = 'BankTxnType' and cs.DetailID = b.BankTxnType " & _
                                       "left join CommonSetting cs1 on cs1.GroupID = 'Currency' and cs1.DetailID = b.Currency " & _
                                       "where b.BankID LIKE '" + Filter.Trim + "%' OR b.BankName LIKE '" + Filter.Trim + "%' " & _
                                       "order by b.BankId"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("BankAccount")
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
                    cmdToExecute.CommandText = "SELECT * FROM BankAccount WHERE BankID = @BankID"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM BankAccount WHERE BankID > @BankID ORDER BY BankID ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM BankAccount WHERE BankID < @BankID ORDER BY BankID DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("BankAccount")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@BankID", _BankID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _BankID = CType(toReturn.Rows(0)("BankID"), String)
                    _BankTxnType = CType(toReturn.Rows(0)("BankTxnType"), String)
                    _BankName = CType(toReturn.Rows(0)("BankName"), String)
                    _Branch = CType(toReturn.Rows(0)("Branch"), String)
                    _AccountNo = CType(toReturn.Rows(0)("AccountNo"), String)
                    _AccountTitle = CType(toReturn.Rows(0)("AccountTitle"), String)
                    _Address = CType(toReturn.Rows(0)("Address"), String)
                    _Currency = CType(toReturn.Rows(0)("Currency"), String)
                    _Description = CType(toReturn.Rows(0)("Description"), String)
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

            cmdToExecute.CommandText = "DELETE FROM BankAccount WHERE BankID = @BankID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@BankID", _BankID)

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

#Region " Class Property Declarations "
        Public Property [BankID]() As String
            Get
                Return _BankID
            End Get
            Set(ByVal Value As String)
                _BankID = Value
            End Set
        End Property

        Public Property [BankTxnType]() As String
            Get
                Return _BankTxnType
            End Get
            Set(ByVal Value As String)
                _BankTxnType = Value
            End Set
        End Property

        Public Property [BankName]() As String
            Get
                Return _BankName
            End Get
            Set(ByVal Value As String)
                _BankName = Value
            End Set
        End Property
        Public Property [Branch]() As String
            Get
                Return _Branch
            End Get
            Set(ByVal Value As String)
                _Branch = Value
            End Set
        End Property
        Public Property [AccountNo]() As String
            Get
                Return _AccountNo
            End Get
            Set(ByVal Value As String)
                _AccountNo = Value
            End Set
        End Property
        Public Property [AccountTitle]() As String
            Get
                Return _AccountTitle
            End Get
            Set(ByVal Value As String)
                _AccountTitle = Value
            End Set
        End Property
        Public Property [Address]() As String
            Get
                Return _Address
            End Get
            Set(ByVal Value As String)
                _Address = Value
            End Set
        End Property
        Public Property [Currency]() As String
            Get
                Return _Currency
            End Get
            Set(ByVal Value As String)
                _Currency = Value
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
#End Region

    End Class
End Namespace
