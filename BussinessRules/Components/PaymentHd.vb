Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Partial Public Class PaymentHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _ReceiptNo As String
        Private _STxnNo As String
        Private _ReceiptDate As datetime
        Private _Rounding As Decimal
        Private _UserInsert As String
        Private _InsertDate As datetime
        Private _UserUpdate As String
        Private _UpdateDate As datetime
        Private _IsVoid As Boolean
        Private _UserVoid As String
        Private _VoidDate As datetime
        Private _Description As String

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
            cmdToExecute.CommandText = "dbo.[usp_PaymentHd_Insert]"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            cmdToExecute.Connection = conn

            cmdToExecute.Transaction = trans

            Try

                cmdToExecute.Parameters.AddWithValue("@sReceiptNo", _ReceiptNo)
                cmdToExecute.Parameters.AddWithValue("@sSTxnNo", _STxnNo)
                cmdToExecute.Parameters.AddWithValue("@sReceiptDate", _ReceiptDate)
                cmdToExecute.Parameters.AddWithValue("@sRounding", _Rounding)
                cmdToExecute.Parameters.AddWithValue("@sUserInsert", _UserInsert)
                cmdToExecute.Parameters.AddWithValue("@sUserUpdate", _UserUpdate)
                cmdToExecute.Parameters.AddWithValue("@sDescription", _Description)

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
            cmdToExecute.CommandText = "dbo.[usp_PaymentHd_Update]"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            cmdToExecute.Connection = conn
            If (trans IsNot Nothing) Then
                cmdToExecute.Transaction = trans
            End If

            Try

                cmdToExecute.Parameters.AddWithValue("@sReceiptNo", _ReceiptNo)
                cmdToExecute.Parameters.AddWithValue("@sSTxnNo", _STxnNo)
                cmdToExecute.Parameters.AddWithValue("@sReceiptDate", _ReceiptDate)
                cmdToExecute.Parameters.AddWithValue("@sRounding", _Rounding)
                cmdToExecute.Parameters.AddWithValue("@sUserUpdate", _UserUpdate)
                cmdToExecute.Parameters.AddWithValue("@sUpdateDate", _UpdateDate)
                cmdToExecute.Parameters.AddWithValue("@sDescription", _Description)


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
            cmdToExecute.CommandText = "dbo.[usp_PaymentHd_Delete]"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            cmdToExecute.Connection = conn
            If (trans IsNot Nothing) Then
                cmdToExecute.Transaction = trans
            End If

            Try

                cmdToExecute.Parameters.AddWithValue("@sReceiptNo", _ReceiptNo)
                cmdToExecute.Parameters.AddWithValue("@sUserVoid", _UserVoid)

                ' // Open connection.
                _mainConnection.Open()

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


        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            Select Case recStatus
                Case RavenRecStatus.CurrentRecord
                    cmdToExecute.CommandText = "dbo.[usp_PaymentHd_SelectOne]"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "dbo.[usp_PaymentHd_SelectOneNext]"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "dbo.[usp_PaymentHd_SelectOnePrev]"
            End Select
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("PaymentHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try

                cmdToExecute.Parameters.AddWithValue("@sReceiptNo", _ReceiptNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
                If toReturn.Rows.Count > 0 Then

                    Dim row As DataRow = toReturn.Rows(0)
                    _ReceiptNo = CType(row("ReceiptNo"), String)
                    _STxnNo = CType(row("STxnNo"), String)
                    _ReceiptDate = CType(row("ReceiptDate"), datetime)
                    _Rounding = CType(row("Rounding"), Decimal)
                    _UserInsert = CType(row("UserInsert"), String)
                    _InsertDate = CType(row("InsertDate"), datetime)
                    _UserUpdate = CType(row("UserUpdate"), String)
                    _UpdateDate = CType(row("UpdateDate"), datetime)
                    _IsVoid = CType(row("IsVoid"), Boolean)
                    _UserVoid = CType(row("UserVoid"), String)
                    _VoidDate = CType(row("VoidDate"), datetime)
                    _Description = CType(row("Description"), String)


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

        Public Overrides Function SelectAll() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "dbo.[usp_PaymentHd_SelectAll]"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("PaymentHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try

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
#Region "Custom Function"
        Public Function UpdatePrintCounts() As Boolean
            Dim retval As Boolean = False
            Try
                ' // Open connection.
                _mainConnection.Open()
                retval = UpdatePrintCounts(_mainConnection, Nothing)
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
            End Try
            Return retval
        End Function

        Public Function UpdatePrintCounts(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Boolean
            Dim retval As Boolean = False
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "Update PaymentHD " & _
                                       "Set PrintCounts = PrintCounts + 1, " & _
                                       "UserUpdate = @UserUpdate, " & _
                                       "UpdateDate = getdate() " & _
                                       "Where ReceiptNo = @ReceiptNo "
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = conn
            If (trans IsNot Nothing) Then
                cmdToExecute.Transaction = trans
            End If

            Try
                cmdToExecute.Parameters.AddWithValue("@ReceiptNo", _ReceiptNo)
                cmdToExecute.Parameters.AddWithValue("@UserUpdate", _UserUpdate)
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

#End Region


#Region " Class Property Declarations "

        Public Property [ReceiptNo]() As String
            Get
                Return _ReceiptNo
            End Get
            Set(ByVal Value As String)
                _ReceiptNo = Value
            End Set
        End Property

        Public Property [STxnNo]() As String
            Get
                Return _STxnNo
            End Get
            Set(ByVal Value As String)
                _STxnNo = Value
            End Set
        End Property

        Public Property [ReceiptDate]() As DateTime
            Get
                Return _ReceiptDate
            End Get
            Set(ByVal Value As DateTime)
                _ReceiptDate = Value
            End Set
        End Property

        Public Property [Rounding]() As Decimal
            Get
                Return _Rounding
            End Get
            Set(ByVal Value As Decimal)
                _Rounding = Value
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

        Public Property [IsVoid]() As Boolean
            Get
                Return _IsVoid
            End Get
            Set(ByVal Value As Boolean)
                _IsVoid = Value
            End Set
        End Property

        Public Property [UserVoid]() As String
            Get
                Return _UserVoid
            End Get
            Set(ByVal Value As String)
                _UserVoid = Value
            End Set
        End Property

        Public Property [VoidDate]() As DateTime
            Get
                Return _VoidDate
            End Get
            Set(ByVal Value As DateTime)
                _VoidDate = Value
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
