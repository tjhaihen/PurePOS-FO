Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class PurchaseOrderHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _POrdNO, _WhID, _UnitID, _EntitiesSeqNo, _POrdTypeID, _PaymentTypeID, _TermOfPayment, _PPNPct, _DiscFinalPct, _Description As String
        Private _DiscFinalAmt, _DPAmt, _Currency, _CurrencyRate, _RevNo As String
        Private _UserInsert, _UserUpdate, _UserDelete, _UserApproval, _UserRev As String
        Private _POrdDate, _POrdExpiredDate, _InsertDate, _UpdateDate, _DeleteDate, _ApprovalDate, _RevDate As String
        Private _IsPPN, _IsDeleted, _IsApproval As Boolean
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO PurchaseOrderHD " & _
                                        "(POrdNO, WhID, UnitID, EntitiesSeqNo, POrdDate, POrdExpiredDate, POrdTypeID, PaymentTypeID, " & _
                                        "TermOfPayment, IsPPN, PPNPct, DiscFinalPct, DiscFinalAmt, DPAmt, Currency, CurrencyRate, " & _
                                        "UserInsert, InsertDate, UserUpdate, UpdateDate, UserDelete, DeleteDate, IsDeleted, Description, " & _
                                        "IsApproval, UserApproval, ApprovalDate, RevNo, UserRev, RevDate) " & _
                                        "VALUES (@POrdNO, @WhID, @UnitID, @EntitiesSeqNo, @POrdDate, @POrdExpiredDate, @POrdTypeID, @PaymentTypeID, " & _
                                        "@TermOfPayment, @IsPPN, @PPNPct, @DiscFinalPct, @DiscFinalAmt, @DPAmt, @Currency, @CurrencyRate, " & _
                                        "@UserInsert, getdate(), @UserUpdate, getdate(), '', '', 0, @Description, " & _
                                        "0, '', '', 0, '', '' )"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@POrdNO", _POrdNO)
                cmdToExecute.Parameters.Add("@WhID", _WhID)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@POrdDate", _POrdDate)
                cmdToExecute.Parameters.Add("@POrdExpiredDate", _POrdExpiredDate)
                cmdToExecute.Parameters.Add("@POrdTypeID", _POrdTypeID)
                cmdToExecute.Parameters.Add("@PaymentTypeID", _PaymentTypeID)

                cmdToExecute.Parameters.Add("@TermOfPayment", _TermOfPayment)
                cmdToExecute.Parameters.Add("@IsPPN", _IsPPN)
                cmdToExecute.Parameters.Add("@PPNPct", _PPNPct)
                cmdToExecute.Parameters.Add("@DiscFinalPct", _DiscFinalPct)
                cmdToExecute.Parameters.Add("@DiscFinalAmt", _DiscFinalAmt)
                cmdToExecute.Parameters.Add("@DPAmt", _DPAmt)
                cmdToExecute.Parameters.Add("@Currency", _Currency)
                cmdToExecute.Parameters.Add("@CurrencyRate", _CurrencyRate)

                cmdToExecute.Parameters.Add("@UserInsert", _UserInsert)
                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)
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
            cmdToExecute.CommandText = "UPDATE PurchaseOrderHD " & _
                                        "SET POrdNO = @POrdNO, " & _
                                        "WhID = @WhID, " & _
                                        "UnitID = @UnitID, " & _
                                        "EntitiesSeqNo = @EntitiesSeqNo, " & _
                                        "POrdDate = @POrdDate, " & _
                                        "POrdExpiredDate = @POrdExpiredDate, " & _
                                        "POrdTypeID = @POrdTypeID, " & _
                                        "PaymentTypeID = @PaymentTypeID, " & _
                                        "TermOfPayment = @TermOfPayment, " & _
                                        "IsPPN = @IsPPN, " & _
                                        "PPNPct = @PPNPct, " & _
                                        "DiscFinalPct = @DiscFinalPct, " & _
                                        "DiscFinalAmt = @DiscFinalAmt, " & _
                                        "DPAmt = @DPAmt, " & _
                                        "Currency = @Currency, " & _
                                        "CurrencyRate = @CurrencyRate, " & _
                                        "IsApproval = @IsApproval, " & _
                                        "UserApproval = CASE WHEN @IsApproval = 1 THEN @UserUpdate ELSE '' END, " & _
                                        "ApprovalDate = CASE WHEN @IsApproval = 1 THEN GETDATE() ELSE '' END, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate(), " & _
                                        "Description = @Description " & _
                                        "WHERE POrdNO = @POrdNO"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@POrdNO", _POrdNO)
                cmdToExecute.Parameters.Add("@WhID", _WhID)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@POrdDate", _POrdDate)
                cmdToExecute.Parameters.Add("@POrdExpiredDate", _POrdExpiredDate)
                cmdToExecute.Parameters.Add("@POrdTypeID", _POrdTypeID)
                cmdToExecute.Parameters.Add("@PaymentTypeID", _PaymentTypeID)

                cmdToExecute.Parameters.Add("@TermOfPayment", _TermOfPayment)
                cmdToExecute.Parameters.Add("@IsPPN", _IsPPN)
                cmdToExecute.Parameters.Add("@PPNPct", _PPNPct)
                cmdToExecute.Parameters.Add("@DiscFinalPct", _DiscFinalPct)
                cmdToExecute.Parameters.Add("@DiscFinalAmt", _DiscFinalAmt)
                cmdToExecute.Parameters.Add("@DPAmt", _DPAmt)
                cmdToExecute.Parameters.Add("@Currency", _Currency)
                cmdToExecute.Parameters.Add("@CurrencyRate", _CurrencyRate)

                cmdToExecute.Parameters.Add("@IsApproval", _IsApproval)

                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)
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

            cmdToExecute.CommandText = "SELECT *,convert(varchar(10),POrdDate,105) as formatdate FROM PurchaseOrderHD order by POrdNO"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseOrderHD")
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

        Public Function SelectAllForPOrdNO(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " *,convert(varchar(10),POrdDate,105) as formatdate, " & _
                                       "case when Isdeleted = 1 then 'Deleted' " & _
                                       "when IsApproval = 1 then 'Approved' else '' end as Status " & _
                                       "FROM PurchaseOrderHD " & _
                                       "Where IsDeleted = 0 and (POrdNO LIKE '" + Filter.Trim + "%' OR convert(varchar(10),POrdDate,105) LIKE '" + Filter.Trim + "%') " & _
                                       "order by POrdNO desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseOrderHD")
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
                    cmdToExecute.CommandText = "SELECT * FROM PurchaseOrderHD WHERE POrdNO = @POrdNO"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM PurchaseOrderHD WHERE POrdNO > @POrdNO ORDER BY POrdNO ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM PurchaseOrderHD WHERE POrdNO < @POrdNO ORDER BY POrdNO DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("PurchaseOrderHD")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@POrdNO", _POrdNO)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _POrdNO = CType(toReturn.Rows(0)("POrdNO"), String)
                    _WhID = CType(toReturn.Rows(0)("WhID"), String)
                    _UnitID = CType(toReturn.Rows(0)("UnitID"), String)
                    _PaymentTypeID = CType(toReturn.Rows(0)("PaymentTypeID"), String)
                    _EntitiesSeqNo = CType(toReturn.Rows(0)("EntitiesSeqNo"), String)
                    _POrdTypeID = CType(toReturn.Rows(0)("POrdTypeID"), String)
                    _TermOfPayment = CType(toReturn.Rows(0)("TermOfPayment"), String)
                    _Currency = CType(toReturn.Rows(0)("Currency"), String)
                    _Description = CType(toReturn.Rows(0)("Description"), String)

                    _PPNPct = CType(toReturn.Rows(0)("PPNPct"), Decimal)
                    _DiscFinalPct = CType(toReturn.Rows(0)("DiscFinalPct"), Decimal)
                    _DiscFinalAmt = CType(toReturn.Rows(0)("DiscFinalAmt"), Decimal)
                    _DPAmt = CType(toReturn.Rows(0)("DPAmt"), Decimal)
                    _CurrencyRate = CType(toReturn.Rows(0)("CurrencyRate"), Decimal)
                    _RevNo = CType(toReturn.Rows(0)("RevNo"), Decimal)

                    _POrdDate = CType(toReturn.Rows(0)("POrdDate"), DateTime)
                    _POrdExpiredDate = CType(toReturn.Rows(0)("POrdExpiredDate"), DateTime)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
                    _DeleteDate = CType(toReturn.Rows(0)("DeleteDate"), DateTime)
                    _ApprovalDate = CType(toReturn.Rows(0)("ApprovalDate"), DateTime)
                    _RevDate = CType(toReturn.Rows(0)("RevDate"), DateTime)

                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UserDelete = CType(toReturn.Rows(0)("UserDelete"), String)
                    _UserApproval = CType(toReturn.Rows(0)("UserApproval"), String)
                    _UserRev = CType(toReturn.Rows(0)("UserRev"), String)

                    _IsPPN = CType(toReturn.Rows(0)("IsPPN"), Boolean)
                    _IsDeleted = CType(toReturn.Rows(0)("IsDeleted"), Boolean)
                    _IsApproval = CType(toReturn.Rows(0)("IsApproval"), Boolean)
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

            cmdToExecute.CommandText = "Update PurchaseOrderHD " & _
                                       "set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = getdate() " & _
                                       "WHERE IsDeleted = 0 and POrdNO = @POrdNO"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@POrdNO", _POrdNO)
                cmdToExecute.Parameters.Add("@UserDelete", _UserDelete)

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
#Region "Others Function"
        Public Function SelectAllForEntitiesSeqNo(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Distinct Top " + MaxRecord + " hd.EntitiesSeqNo, " & _
                                       "isnull(En.EntitiesId,'') as EntitiesId, " & _
                                       "isnull(En.EntitiesName,'') as EntitiesName " & _
                                       "FROM PurchaseOrderHd hd " & _
                                       "inner join PurchaseOrderDt dt on Dt.POrdNO = hd.POrdNO and dt.IsRelease = 0 " & _
                                       "inner join Entities En on En.EntitiesSeqNo = hd.EntitiesSeqNo " & _
                                       "Where hd.IsDeleted = 0 and hd.IsApproval = 1 and En.IsDeleted = 0 and En.IsActive = 1 " & _
                                       "and (En.EntitiesId LIKE '" + Filter.Trim + "%' OR En.EntitiesName LIKE '" + Filter.Trim + "%' OR En.EntitiesSeqNo LIKE '" + Filter.Trim + "%') "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseUnitHd")
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

        Public Function SelectAllForCurrency() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Distinct hd.Currency, " & _
                                       "isnull(cs.DetailDesc,'') as CurrencyName " & _
                                       "FROM PurchaseOrderHd hd " & _
                                       "inner join PurchaseOrderDt dt on Dt.POrdNO = hd.POrdNO and dt.IsRelease = 0 " & _
                                       "LEFT join (select * from CommonSetting WHERE GroupID = 'Currency') cs on cs.DetailID = hd.Currency " & _
                                       "Where hd.IsDeleted = 0 and hd.IsApproval = 1 and cs.IsDeleted = 0 and cs.IsActive = 1 " & _
                                       "and hd.EntitiesSeqNo = @EntitiesSeqNo "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseUnitHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
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
        Public Property [POrdNO]() As String
            Get
                Return _POrdNO
            End Get
            Set(ByVal Value As String)
                _POrdNO = Value
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

        Public Property [EntitiesSeqNo]() As String
            Get
                Return _EntitiesSeqNo
            End Get
            Set(ByVal Value As String)
                _EntitiesSeqNo = Value
            End Set
        End Property

        Public Property [POrdTypeID]() As String
            Get
                Return _POrdTypeID
            End Get
            Set(ByVal Value As String)
                _POrdTypeID = Value
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

        Public Property [TermOfPayment]() As String
            Get
                Return _TermOfPayment
            End Get
            Set(ByVal Value As String)
                _TermOfPayment = Value
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

        Public Property [PPNPct]() As Decimal
            Get
                Return _PPNPct
            End Get
            Set(ByVal Value As Decimal)
                _PPNPct = Value
            End Set
        End Property

        Public Property [DiscFinalPct]() As Decimal
            Get
                Return _DiscFinalPct
            End Get
            Set(ByVal Value As Decimal)
                _DiscFinalPct = Value
            End Set
        End Property

        Public Property [DiscFinalAmt]() As Decimal
            Get
                Return _DiscFinalAmt
            End Get
            Set(ByVal Value As Decimal)
                _DiscFinalAmt = Value
            End Set
        End Property

        Public Property [DPAmt]() As Decimal
            Get
                Return _DPAmt
            End Get
            Set(ByVal Value As Decimal)
                _DPAmt = Value
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

        Public Property [RevNo]() As Decimal
            Get
                Return _RevNo
            End Get
            Set(ByVal Value As Decimal)
                _RevNo = Value
            End Set
        End Property

        Public Property [POrdDate]() As DateTime
            Get
                Return _POrdDate
            End Get
            Set(ByVal Value As DateTime)
                _POrdDate = Value
            End Set
        End Property

        Public Property [POrdExpiredDate]() As DateTime
            Get
                Return _POrdExpiredDate
            End Get
            Set(ByVal Value As DateTime)
                _POrdExpiredDate = Value
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

        Public Property [UpdateDate]() As DateTime
            Get
                Return _UpdateDate
            End Get
            Set(ByVal Value As DateTime)
                _UpdateDate = Value
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

        Public Property [ApprovalDate]() As DateTime
            Get
                Return _ApprovalDate
            End Get
            Set(ByVal Value As DateTime)
                _ApprovalDate = Value
            End Set
        End Property

        Public Property [RevDate]() As DateTime
            Get
                Return _RevDate
            End Get
            Set(ByVal Value As DateTime)
                _RevDate = Value
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

        Public Property [UserUpdate]() As String
            Get
                Return _UserUpdate
            End Get
            Set(ByVal Value As String)
                _UserUpdate = Value
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

        Public Property [UserApproval]() As String
            Get
                Return _UserApproval
            End Get
            Set(ByVal Value As String)
                _UserApproval = Value
            End Set
        End Property

        Public Property [UserRev]() As String
            Get
                Return _UserRev
            End Get
            Set(ByVal Value As String)
                _UserRev = Value
            End Set
        End Property

        Public Property [IsPPN]() As Boolean
            Get
                Return _IsPPN
            End Get
            Set(ByVal Value As Boolean)
                _IsPPN = Value
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

        Public Property [IsApproval]() As Boolean
            Get
                Return _IsApproval
            End Get
            Set(ByVal Value As Boolean)
                _IsApproval = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
