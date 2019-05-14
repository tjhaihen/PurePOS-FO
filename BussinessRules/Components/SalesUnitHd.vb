Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Partial Public Class SalesUnitHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _STxnNo As String
        Private _StxnTypeID As String
        Private _EntitiesSeqNo As String
        Private _STxnDate As datetime
        Private _DueDate As datetime
        Private _BranchID As String
        Private _UserInsert As String
        Private _InsertDate As datetime
        Private _UserUpdate As String
        Private _UpdateDate As datetime
        Private _UserDelete As String
        Private _DeleteDate As datetime
        Private _IsDeleted As Boolean
        Private _Description As String
        Private _IsApproval As Boolean
        Private _UserApproval As String
        Private _ApprovalDate As DateTime
        Private _WhID As String
        Private _UnitID As String
        Private _Currency As String
        Private _CurrencyRate As Decimal
        Private _STxnStatusID As String
        Private _DonationAmt As Decimal
        Private _DonationType As String
        Private _GetVoucherAmount As Decimal


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
            cmdToExecute.CommandText = "dbo.[usp_SalesUnitHd_Insert]"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            cmdToExecute.Connection = conn

            cmdToExecute.Transaction = trans

            Try

                cmdToExecute.Parameters.AddWithValue("@sSTxnNo", _STxnNo)
                cmdToExecute.Parameters.AddWithValue("@sStxnTypeID", _StxnTypeID)
                cmdToExecute.Parameters.AddWithValue("@sEntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.AddWithValue("@sSTxnDate", _STxnDate)
                cmdToExecute.Parameters.AddWithValue("@sBranchID", _BranchID)
                cmdToExecute.Parameters.AddWithValue("@WhID", _WhID)
                cmdToExecute.Parameters.AddWithValue("@UnitID", _UnitID)
                cmdToExecute.Parameters.AddWithValue("@Currency", _Currency)
                cmdToExecute.Parameters.AddWithValue("@CurrencyRate", _CurrencyRate)
                cmdToExecute.Parameters.AddWithValue("@sUserInsert", _UserInsert)
                cmdToExecute.Parameters.AddWithValue("@sUserUpdate", _UserUpdate)
                cmdToExecute.Parameters.AddWithValue("@sDescription", _Description)
                cmdToExecute.Parameters.AddWithValue("@STxnStatusID", _STxnStatusID)

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
            cmdToExecute.CommandText = "dbo.[usp_SalesUnitHd_Update]"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            cmdToExecute.Connection = conn
            If (trans IsNot Nothing) Then
                cmdToExecute.Transaction = trans
            End If

            Try
                cmdToExecute.Parameters.AddWithValue("@sSTxnNo", _STxnNo)
                cmdToExecute.Parameters.AddWithValue("@sStxnTypeID", _StxnTypeID)
                cmdToExecute.Parameters.AddWithValue("@sEntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.AddWithValue("@sSTxnDate", _STxnDate)
                cmdToExecute.Parameters.AddWithValue("@sBranchID", _BranchID)
                cmdToExecute.Parameters.AddWithValue("@WhID", _WhID)
                cmdToExecute.Parameters.AddWithValue("@UnitID", _UnitID)
                cmdToExecute.Parameters.AddWithValue("@Currency", _Currency)
                cmdToExecute.Parameters.AddWithValue("@CurrencyRate", _CurrencyRate)
                cmdToExecute.Parameters.AddWithValue("@sUserUpdate", _UserUpdate)
                cmdToExecute.Parameters.AddWithValue("@sDescription", _Description)
                cmdToExecute.Parameters.AddWithValue("@STxnStatusID", _STxnStatusID)

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
            cmdToExecute.CommandText = "dbo.[usp_SalesUnitHd_Delete]"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            cmdToExecute.Connection = conn
            If (trans IsNot Nothing) Then
                cmdToExecute.Transaction = trans
            End If

            Try

                cmdToExecute.Parameters.AddWithValue("@sSTxnNo", _STxnNo)

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
                    cmdToExecute.CommandText = "dbo.[usp_SalesUnitHd_SelectOne]"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "dbo.[usp_SalesUnitHd_SelectOneNext]"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "dbo.[usp_SalesUnitHd_SelectOnePrev]"
            End Select
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("SalesUnitHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try

                cmdToExecute.Parameters.AddWithValue("@sSTxnNo", _STxnNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
                If toReturn.Rows.Count > 0 Then

                    Dim row As DataRow = toReturn.Rows(0)
                    _STxnNo = CType(row("STxnNo"), String)
                    _StxnTypeID = CType(row("StxnTypeID"), String)
                    _EntitiesSeqNo = CType(row("EntitiesSeqNo"), String)
                    _WhID = CType(row("WhID"), String)
                    _UnitID = CType(row("UnitID"), String)
                    _Currency = CType(row("Currency"), String)
                    _CurrencyRate = CType(row("CurrencyRate"), Decimal)
                    _DonationType = CType(row("DonationType"), String)
                    _DonationAmt = CType(row("DonationAmt"), Decimal)
                    _GetVoucherAmount = CType(row("GetVoucherAmount"), Decimal)
                    _STxnDate = CType(row("STxnDate"), datetime)
                    _BranchID = CType(row("BranchID"), String)
                    _UserInsert = CType(row("UserInsert"), String)
                    _InsertDate = CType(row("InsertDate"), datetime)
                    _UserUpdate = CType(row("UserUpdate"), String)
                    _UpdateDate = CType(row("UpdateDate"), datetime)
                    _UserDelete = CType(row("UserDelete"), String)
                    _DeleteDate = CType(row("DeleteDate"), datetime)
                    _IsDeleted = CType(row("IsDeleted"), Boolean)
                    _Description = CType(row("Description"), String)
                    _STxnStatusID = CType(row("STxnStatusID"), String)
                    _IsApproval = CType(row("IsApproval"), Boolean)
                    _UserApproval = CType(row("UserApproval"), String)
                    _ApprovalDate = CType(row("ApprovalDate"), datetime)
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
            cmdToExecute.CommandText = "dbo.[usp_SalesUnitHd_SelectAll]"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("SalesUnitHd")
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

#Region " Customs Function "
        Public Function InsertDonation(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Boolean
            Dim retval As Boolean = False
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "INSERT SalesUnitHd (STxnNo, StxnTypeID, EntitiesSeqNo, STxnDate, BranchID, " & _
                                       "WhID, UnitID, Currency, CurrencyRate, UserInsert, InsertDate, UserUpdate, " & _
                                       "UpdateDate, UserDelete, DeleteDate, IsDeleted, Description, STxnStatusID, " & _
                                       "IsApproval, UserApproval, ApprovalDate, VoucherNo, PPNPct, IsPPN, DiscFinalPct, " & _
                                       "DiscFinalAmt, DONo, DonationAmt, DonationType) " & _
                                       "VALUES ( @sSTxnNo, @sStxnTypeID, '', @sSTxnDate, @sBranchID, @WhID, " & _
                                       "@UnitID, @Currency, @CurrencyRate, @sUserInsert, GETDATE(), @sUserUpdate, GETDATE(), " & _
                                       "'', '', 0, '', @STxnStatusID, 0, '', '', '', 0, 0, 0, 0, '', @DonationAmt, @DonationType) "
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = conn

            cmdToExecute.Transaction = trans

            Try

                cmdToExecute.Parameters.AddWithValue("@sSTxnNo", _STxnNo)
                cmdToExecute.Parameters.AddWithValue("@sStxnTypeID", _StxnTypeID)
                cmdToExecute.Parameters.AddWithValue("@sSTxnDate", _STxnDate)
                cmdToExecute.Parameters.AddWithValue("@sBranchID", _BranchID)
                cmdToExecute.Parameters.AddWithValue("@WhID", _WhID)
                cmdToExecute.Parameters.AddWithValue("@UnitID", _UnitID)
                cmdToExecute.Parameters.AddWithValue("@Currency", _Currency)
                cmdToExecute.Parameters.AddWithValue("@CurrencyRate", _CurrencyRate)
                cmdToExecute.Parameters.AddWithValue("@sUserInsert", _UserInsert)
                cmdToExecute.Parameters.AddWithValue("@sUserUpdate", _UserUpdate)
                cmdToExecute.Parameters.AddWithValue("@STxnStatusID", _STxnStatusID)
                cmdToExecute.Parameters.AddWithValue("@DonationAmt", _DonationAmt)
                cmdToExecute.Parameters.AddWithValue("@DonationType", _DonationType)

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

        Public Function UpdateDonation(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Boolean
            Dim retval As Boolean = False
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "Update SalesUnitHd " & _
                                       "Set DonationAmt = @DonationAmt, " & _
                                       "DonationType = @DonationType, " & _
                                       "UserUpdate = @UserUpdate, " & _
                                       "UpdateDate = getdate() " & _
                                       "Where STxnNo = @STxnNo "
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = conn
            If (trans IsNot Nothing) Then
                cmdToExecute.Transaction = trans
            End If

            Try
                cmdToExecute.Parameters.AddWithValue("@STxnNo", _STxnNo)
                cmdToExecute.Parameters.AddWithValue("@DonationAmt", _DonationAmt)
                cmdToExecute.Parameters.AddWithValue("@DonationType", _DonationType)
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

        Public Function UpdateGetVoucherAmount(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Boolean
            Dim retval As Boolean = False
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "Update SalesUnitHd " & _
                                       "Set GetVoucherAmount = @GetVoucherAmount, " & _
                                       "UserUpdate = @UserUpdate, " & _
                                       "UpdateDate = getdate() " & _
                                       "Where STxnNo = @STxnNo "
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = conn
            If (trans IsNot Nothing) Then
                cmdToExecute.Transaction = trans
            End If

            Try
                cmdToExecute.Parameters.AddWithValue("@STxnNo", _STxnNo)
                cmdToExecute.Parameters.AddWithValue("@GetVoucherAmount", _GetVoucherAmount)
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

        Public Function FGetVoucherAmount(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, MemberNo As string) As Boolean
            Dim retval As Boolean = False
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sp_GetVoucherAmount"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("payment")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = conn
            If (trans IsNot Nothing) Then
                cmdToExecute.Transaction = trans
            End If

            Try
                cmdToExecute.Parameters.AddWithValue("@STxnNo", _STxnNo)
                cmdToExecute.Parameters.AddWithValue("@MemberNo", MemberNo)
                
                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _GetVoucherAmount = CType(toReturn.Rows(0)("TotalVoucherAmount"), Decimal)
                    retval = True
                End If

            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
            Return retval
        End Function
#End Region

#Region " Class Property Declarations "

        Public Property [STxnNo]() As String
            Get
                Return _STxnNo
            End Get
            Set(ByVal Value As String)
                _STxnNo = Value
            End Set
        End Property

        Public Property [StxnTypeID]() As String
            Get
                Return _StxnTypeID
            End Get
            Set(ByVal Value As String)
                _StxnTypeID = Value
            End Set
        End Property

        Public Property [WhID]() As String
            Get
                Return _WhID
            End Get
            Set(ByVal Value As String)
                _WhID = Value
            End Set
        End Property

        Public Property [UnitID]() As String
            Get
                Return _UnitID
            End Get
            Set(ByVal Value As String)
                _UnitID = Value
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

        Public Property [CurrencyRate]() As Decimal
            Get
                Return _CurrencyRate
            End Get
            Set(ByVal Value As Decimal)
                _CurrencyRate = Value
            End Set
        End Property

        Public Property [DonationAmt]() As Decimal
            Get
                Return _DonationAmt
            End Get
            Set(ByVal Value As Decimal)
                _DonationAmt = Value
            End Set
        End Property

        Public Property [DonationType]() As String
            Get
                Return _DonationType
            End Get
            Set(ByVal Value As String)
                _DonationType = Value
            End Set
        End Property

        Public Property [GetVoucherAmount]() As Decimal
            Get
                Return _GetVoucherAmount
            End Get
            Set(ByVal Value As Decimal)
                _GetVoucherAmount = Value
            End Set
        End Property


        Public Property [EntitiesSeqNo]() As String
            Get
                Return _EntitiesSeqNo
            End Get
            Set(ByVal Value As String)
                _EntitiesSeqNo = Value
            End Set
        End Property

        Public Property [STxnDate]() As DateTime
            Get
                Return _STxnDate
            End Get
            Set(ByVal Value As DateTime)
                _STxnDate = Value
            End Set
        End Property

        Public Property [BranchID]() As String
            Get
                Return _BranchID
            End Get
            Set(ByVal Value As String)
                _BranchID = Value
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

        Public Property [UserDelete]() As String
            Get
                Return _UserDelete
            End Get
            Set(ByVal Value As String)
                _UserDelete = Value
            End Set
        End Property

        Public Property [DeleteDate]() As DateTime
            Get
                Return _DeleteDate
            End Get
            Set(ByVal Value As DateTime)
                _DeleteDate = Value
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

        Public Property [Description]() As String
            Get
                Return _Description
            End Get
            Set(ByVal Value As String)
                _Description = Value
            End Set
        End Property

        Public Property [STxnStatusID]() As String
            Get
                Return _STxnStatusID
            End Get
            Set(ByVal Value As String)
                _STxnStatusID = Value
            End Set
        End Property

        Public Property [IsApproval]() As Boolean
            Get
                Return _IsApproval
            End Get
            Set(ByVal Value As Boolean)
                _IsApproval = Value
            End Set
        End Property

        Public Property [UserApproval]() As String
            Get
                Return _UserApproval
            End Get
            Set(ByVal Value As String)
                _UserApproval = Value
            End Set
        End Property

        Public Property [ApprovalDate]() As DateTime
            Get
                Return _ApprovalDate
            End Get
            Set(ByVal Value As DateTime)
                _ApprovalDate = Value
            End Set
        End Property


#End Region

    End Class
End Namespace
