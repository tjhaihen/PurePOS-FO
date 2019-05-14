Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class Settlement
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ID, _UserID, _PaymentMethodID As String
        Private _Amount As Decimal
        Private _Date As DateTime
        Private _IsDeleted As Boolean
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim retval As Boolean = False
            Try
                ' // Open connection.
                _mainConnection.Open()
                retval = Insert(_mainConnection, Nothing)
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
            End Try
            Return retval
        End Function

        Public Overrides Function Insert(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Boolean
            Dim retval As Boolean = False
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "INSERT INTO Settlement " & _
                                        "(ID, UserID, Date, PaymentMethodID, Amount, IsDeleted) " & _
                                        "VALUES (@ID, @UserID, @Date, @PaymentMethodID, @Amount, @IsDeleted)"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = conn

            cmdToExecute.Transaction = trans

            Try

                cmdToExecute.Parameters.AddWithValue("@ID", _ID)
                cmdToExecute.Parameters.AddWithValue("@UserID", _UserID)
                cmdToExecute.Parameters.AddWithValue("@Date", _Date)
                cmdToExecute.Parameters.AddWithValue("@PaymentMethodID", _PaymentMethodID)
                cmdToExecute.Parameters.AddWithValue("@Amount", _Amount)
                cmdToExecute.Parameters.AddWithValue("@IsDeleted", _IsDeleted)

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
            Return retval
        End Function

        Public Overrides Function Update() As Boolean
            Dim retval As Boolean = False
            Try
                ' // Open connection.
                _mainConnection.Open()
                retval = Update(_mainConnection, Nothing)
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
            End Try
            Return retval
        End Function

        Public Overrides Function Update(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Boolean
            Dim retval As Boolean = False
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "UPDATE Settlement " & _
                                        "SET UserID = @UserID, " & _
                                        "Date = @Date, " & _
                                        "PaymentMethodID = @PaymentMethodID, " & _
                                        "Amount = @Amount, " & _
                                        "IsDeleted = @IsDeleted " & _
                                        "WHERE ID = @ID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = conn
            If (trans IsNot Nothing) Then
                cmdToExecute.Transaction = trans
            End If

            Try
                  cmdToExecute.Parameters.AddWithValue("@ID", _ID)
                cmdToExecute.Parameters.AddWithValue("@UserID", _UserID)
                cmdToExecute.Parameters.AddWithValue("@Date", _Date)
                cmdToExecute.Parameters.AddWithValue("@PaymentMethodID", _PaymentMethodID)
                cmdToExecute.Parameters.AddWithValue("@Amount", _Amount)
                cmdToExecute.Parameters.AddWithValue("@IsDeleted", _IsDeleted)

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()
                retval = True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                cmdToExecute.Dispose()
            End Try
            Return retval
        End Function

        Public Overrides Function SelectAll() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT * FROM Settlement where order by SettlementId"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Settlement")
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
                    cmdToExecute.CommandText = "SELECT * FROM Settlement WHERE ID = @ID"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM Settlement WHERE ID > @ID ORDER BY ID ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM Settlement WHERE ID < @ID ORDER BY ID DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("Settlement")
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
                    _UserID = CType(toReturn.Rows(0)("UserID"), String)
                    _Date = CType(toReturn.Rows(0)("Date"), DateTime)
                    _PaymentMethodID = CType(toReturn.Rows(0)("PaymentMethodID"), String)
                    _Amount = CType(toReturn.Rows(0)("Amount"), Decimal)
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
            Dim retval As Boolean = False
            Try
                ' // Open connection.
                _mainConnection.Open()
                retval = Delete(_mainConnection, Nothing)
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
            End Try
            Return retval
        End Function

        Public Overrides Function Delete(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Boolean
            Dim retval As Boolean = False
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "Update Settlement " & _
                                       "Set IsDeleted = 1 " & _
                                       "WHERE IsDeleted = 0 and UserID = @UserID and Convert(varchar(8),Date,112) = Convert(varchar(8),@Date,112) " & _
                                       "and PaymentMethodID = @PaymentMethodID "
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = conn
            If (trans IsNot Nothing) Then
                cmdToExecute.Transaction = trans
            End If

            Try

                cmdToExecute.Parameters.AddWithValue("@UserID", _UserID)
                cmdToExecute.Parameters.AddWithValue("@Date", _Date)
                cmdToExecute.Parameters.AddWithValue("@PaymentMethodID", _PaymentMethodID)

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()
                retval = True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                cmdToExecute.Dispose()
            End Try
            Return retval
        End Function

#Region "Customs Function"
        Public Function SelectOneByUserIDDatePaymentmethodAmount(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "select * from Settlement " & _
                                       "WHERE IsDeleted = 0 and UserID = @UserID and Convert(varchar(8),Date,112) = Convert(varchar(8),@Date,112) " & _
                                       "and PaymentMethodID = @PaymentMethodID "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Settlement")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = conn
            If (trans IsNot Nothing) Then
                cmdToExecute.Transaction = trans
            End If

            Try
                cmdToExecute.Parameters.AddWithValue("@UserID", _UserID)
                cmdToExecute.Parameters.AddWithValue("@Date", _Date)
                cmdToExecute.Parameters.AddWithValue("@PaymentMethodID", _PaymentMethodID)

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

        Public Function GetSettlementData() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "sprpt_settlement"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("sprpt_settlement")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try

                cmdToExecute.Parameters.AddWithValue("@UserID", _UserID)
                cmdToExecute.Parameters.AddWithValue("@date", _Date)

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

        Public Property [UserID]() As String
            Get
                Return _UserID
            End Get
            Set(ByVal Value As String)
                _UserID = Value
            End Set
        End Property

        Public Property [Date]() As DateTime
            Get
                Return _Date
            End Get
            Set(ByVal Value As DateTime)
                _Date = Value
            End Set
        End Property
        Public Property [PaymentMethodID]() As String
            Get
                Return _PaymentMethodID
            End Get
            Set(ByVal Value As String)
                _PaymentMethodID = Value
            End Set
        End Property
        Public Property [Amount]() As Decimal
            Get
                Return _Amount
            End Get
            Set(ByVal Value As Decimal)
                _Amount = Value
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
