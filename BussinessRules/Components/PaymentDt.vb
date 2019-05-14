Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Partial Public Class PaymentDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _ID As String
        Private _ReceiptNo As String
        Private _PaymentTypeID As String
        Private _EDCID As String
        Private _CardTypeID As String
        Private _CardFee As Decimal
        Private _PaymentTypeNo As String
        Private _CardHolderName As String
        Private _Amount As Decimal
        Private _UserInsert As String
        Private _InsertDate As datetime
        Private _UserUpdate As String
        Private _UpdateDate As datetime
        Private _IsVoid As Boolean
        Private _UserVoid As String
        Private _VoidDate As datetime
        Private _Description As String
        Private _CardReaderText As String

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
            cmdToExecute.CommandText = "dbo.[usp_PaymentDt_Insert]"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            cmdToExecute.Connection = conn

            cmdToExecute.Transaction = trans

            Try

                cmdToExecute.Parameters.AddWithValue("@sID", _ID)
                cmdToExecute.Parameters.AddWithValue("@sReceiptNo", _ReceiptNo)
                cmdToExecute.Parameters.AddWithValue("@sPaymentTypeID", _PaymentTypeID)
                cmdToExecute.Parameters.AddWithValue("@sEDCID", _EDCID)
                cmdToExecute.Parameters.AddWithValue("@sCardTypeID", _CardTypeID)
                cmdToExecute.Parameters.AddWithValue("@sCardFee", _CardFee)
                cmdToExecute.Parameters.AddWithValue("@sPaymentTypeNo", _PaymentTypeNo)
                cmdToExecute.Parameters.AddWithValue("@sCardHolderName", _CardHolderName)
                cmdToExecute.Parameters.AddWithValue("@sCardReaderText", _CardReaderText)
                cmdToExecute.Parameters.AddWithValue("@sAmount", _Amount)
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
            cmdToExecute.CommandText = "dbo.[usp_PaymentDt_Update]"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            cmdToExecute.Connection = conn
            If (trans IsNot Nothing) Then
                cmdToExecute.Transaction = trans
            End If

            Try

                cmdToExecute.Parameters.AddWithValue("@sID", _ID)
                cmdToExecute.Parameters.AddWithValue("@sReceiptNo", _ReceiptNo)
                cmdToExecute.Parameters.AddWithValue("@sPaymentTypeID", _PaymentTypeID)
                cmdToExecute.Parameters.AddWithValue("@sEDCID", _EDCID)
                cmdToExecute.Parameters.AddWithValue("@sCardTypeID", _CardTypeID)
                cmdToExecute.Parameters.AddWithValue("@sCardFee", _CardFee)
                cmdToExecute.Parameters.AddWithValue("@sPaymentTypeNo", _PaymentTypeNo)
                cmdToExecute.Parameters.AddWithValue("@sCardHolderName", _CardHolderName)
                cmdToExecute.Parameters.AddWithValue("@sAmount", _Amount)
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
            cmdToExecute.CommandText = "dbo.[usp_PaymentDt_Delete]"
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
                    cmdToExecute.CommandText = "dbo.[usp_PaymentDt_SelectOne]"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "dbo.[usp_PaymentDt_SelectOneNext]"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "dbo.[usp_PaymentDt_SelectOnePrev]"
            End Select
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("PaymentDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try

                cmdToExecute.Parameters.AddWithValue("@sID", _ID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
                If toReturn.Rows.Count > 0 Then

                    Dim row As DataRow = toReturn.Rows(0)
                    _ID = CType(row("ID"), String)
                    _ReceiptNo = CType(row("ReceiptNo"), String)
                    _PaymentTypeID = CType(row("PaymentTypeID"), String)
                    If row("EDCID") Is DBNull.Value Then
                        _EDCID = Nothing
                    Else
                        _EDCID = CType(row("EDCID"), String)
                    End If
                    _CardTypeID = CType(row("CardTypeID"), String)
                    _CardFee = CType(row("CardFee"), Decimal)
                    _PaymentTypeNo = CType(row("PaymentTypeNo"), String)
                    _CardHolderName = CType(row("CardHolderName"), String)
                    _CardReaderText = CType(row("CardReaderText"), String)
                    _Amount = CType(row("Amount"), Decimal)
                    _UserInsert = CType(row("UserInsert"), String)
                    _InsertDate = CType(row("InsertDate"), DateTime)
                    _UserUpdate = CType(row("UserUpdate"), String)
                    _UpdateDate = CType(row("UpdateDate"), DateTime)
                    _IsVoid = CType(row("IsVoid"), Boolean)
                    _UserVoid = CType(row("UserVoid"), String)
                    _VoidDate = CType(row("VoidDate"), DateTime)
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
            cmdToExecute.CommandText = "dbo.[usp_PaymentDt_SelectAll]"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("PaymentDt")
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
#Region "Customs Function"
        Public Function SelectAllSearchQuickPayment() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "dbo.[sp_getID_SearchQuickPayment]"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("PaymentDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ID", _ID)
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

        Public Function SelectAllPaymentMethod(ByVal p_Date As DateTime, ByVal p_UserID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand()

            cmdToExecute.CommandText = "sp_selectAllPaymentMethod "
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("PaymentDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@Date", p_Date)
                cmdToExecute.Parameters.AddWithValue("@UserUpdate", p_UserID)
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

        Public Property [ReceiptNo]() As String
            Get
                Return _ReceiptNo
            End Get
            Set(ByVal Value As String)
                _ReceiptNo = Value
            End Set
        End Property

        Public Property [PaymentTypeID]() As String
            Get
                Return _PaymentTypeID
            End Get
            Set(ByVal Value As String)
                _PaymentTypeID = Value
            End Set
        End Property

        Public Property EDCID As String
            Get
                Return _EDCID
            End Get
            Set(ByVal Value As String)
                _EDCID = Value
            End Set
        End Property

        Public Property [CardTypeID]() As String
            Get
                Return _CardTypeID
            End Get
            Set(ByVal Value As String)
                _CardTypeID = Value
            End Set
        End Property

        Public Property [CardFee]() As Decimal
            Get
                Return _CardFee
            End Get
            Set(ByVal Value As Decimal)
                _CardFee = Value
            End Set
        End Property

        Public Property [PaymentTypeNo]() As String
            Get
                Return _PaymentTypeNo
            End Get
            Set(ByVal Value As String)
                _PaymentTypeNo = Value
            End Set
        End Property

        Public Property [CardHolderName]() As String
            Get
                Return _CardHolderName
            End Get
            Set(ByVal Value As String)
                _CardHolderName = Value
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

        Public Property [CardReaderText]() As String
            Get
                Return _CardReaderText
            End Get
            Set(ByVal Value As String)
                _CardReaderText = Value
            End Set
        End Property

#End Region

    End Class
End Namespace
