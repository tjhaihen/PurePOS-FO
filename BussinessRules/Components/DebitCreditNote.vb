Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class DebitCreditNote
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _DCNoteNo, _DCNoteDate, _EntitiesSeqNo, _ReferenceNo, _DCNoteID, _Description, _TaxPct As String
        Private _Amount, _AmtDifferences As Decimal
        Private _UserInsert, _UserUpdate, _UserApproval, _ApprovalDate, _UpdateDate, _InsertDate, _UserDelete, _DeleteDate As String
        Private _IsApproval, _IsDeleted, _IsTax As Boolean
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO DebitCreditNote " & _
                                        "(DCNoteNo, DCNoteDate, EntitiesSeqNo, DCNoteID, ReferenceNo, IsTax, TaxPct, AmtDifferences, " & _
                                        "Amount, Description, UserInsert, InsertDate, UserUpdate, UpdateDate, " & _
                                        "IsApproval, UserApproval, ApprovalDate, IsDeleted, UserDelete, DeleteDate) " & _
                                        "VALUES (@DCNoteNo, @DCNoteDate, @EntitiesSeqNo, @DCNoteID, @ReferenceNo, @IsTax, @TaxPct, @AmtDifferences, " & _
                                        "@Amount, @Description, @UserInsert, getdate(), @UserUpdate, getdate(), " & _
                                        "0, '', '', 0, '', '')"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DCNoteNo", _DCNoteNo)
                cmdToExecute.Parameters.Add("@DCNoteDate", _DCNoteDate)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@DCNoteID", _DCNoteID)
                cmdToExecute.Parameters.Add("@ReferenceNo", _ReferenceNo)
                cmdToExecute.Parameters.Add("@IsTax", _IsTax)
                cmdToExecute.Parameters.Add("@TaxPct", _TaxPct)
                cmdToExecute.Parameters.Add("@AmtDifferences", _AmtDifferences)
                cmdToExecute.Parameters.Add("@Amount", _Amount)
                cmdToExecute.Parameters.Add("@Description", _Description)
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
            cmdToExecute.CommandText = "UPDATE DebitCreditNote " & _
                                        "SET DCNoteDate = @DCNoteDate, " & _
                                        "EntitiesSeqNo = @EntitiesSeqNo, " & _
                                        "DCNoteID = @DCNoteID, " & _
                                        "ReferenceNo = @ReferenceNo, " & _
                                        "IsTax = @IsTax, " & _
                                        "TaxPct = @TaxPct, " & _
                                        "AmtDifferences = @AmtDifferences, " & _
                                        "Amount = @Amount, " & _
                                        "Description = @Description, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = getdate() " & _
                                        "WHERE DCNoteNo = @DCNoteNo"

            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DCNoteNo", _DCNoteNo)
                cmdToExecute.Parameters.Add("@DCNoteDate", _DCNoteDate)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@DCNoteID", _DCNoteID)
                cmdToExecute.Parameters.Add("@ReferenceNo", _ReferenceNo)
                cmdToExecute.Parameters.Add("@IsTax", _IsTax)
                cmdToExecute.Parameters.Add("@TaxPct", _TaxPct)
                cmdToExecute.Parameters.Add("@AmtDifferences", _AmtDifferences)
                cmdToExecute.Parameters.Add("@Amount", _Amount)
                cmdToExecute.Parameters.Add("@Description", _Description)
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

            cmdToExecute.CommandText = "SELECT * FROM DebitCreditNote order by DCNoteNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DebitCreditNote")
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

        Public Function SelectAllForDCNoteNo(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " *,convert(varchar(10),DCNoteDate,105) as formatdate, " & _
                                       "(Case When IsApproval = 1 then 'Approved' else '' end) as Status FROM DebitCreditNote " & _
                                       "Where IsDeleted = 0 and DCNoteID = @DCNoteID and (DCNoteNo LIKE '" + Filter.Trim + "%' OR convert(varchar(10),DCNoteDate,105) LIKE '" + Filter.Trim + "%') " & _
                                       "order by DCNoteNo desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DebitCreditNote")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DCNoteID", _DCNoteID)
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

        Public Function SelectOneByReferenceNo() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT * FROM DebitCreditNote where IsDeleted = 0 and ReferenceNo = @ReferenceNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DebitCreditNote")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ReferenceNo", _ReferenceNo)
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
                    cmdToExecute.CommandText = "SELECT * FROM DebitCreditNote WHERE DCNoteNo = @DCNoteNo"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM DebitCreditNote WHERE DCNoteNo > @DCNoteNo ORDER BY DCNoteNo ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM DebitCreditNote WHERE DCNoteNo < @DCNoteNo ORDER BY DCNoteNo DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("DebitCreditNote")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DCNoteNo", _DCNoteNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _DCNoteNo = CType(toReturn.Rows(0)("DCNoteNo"), String)
                    _DCNoteDate = CType(toReturn.Rows(0)("DCNoteDate"), DateTime)
                    _EntitiesSeqNo = CType(toReturn.Rows(0)("EntitiesSeqNo"), String)

                    _DCNoteID = CType(toReturn.Rows(0)("DCNoteID"), String)

                    _ReferenceNo = CType(toReturn.Rows(0)("ReferenceNo"), String)
                    _IsTax = CType(toReturn.Rows(0)("IsTax"), Boolean)

                    _TaxPct = CType(toReturn.Rows(0)("TaxPct"), String)
                    _AmtDifferences = CType(toReturn.Rows(0)("AmtDifferences"), Decimal)
                    _Amount = CType(toReturn.Rows(0)("Amount"), Decimal)
                    _Description = CType(toReturn.Rows(0)("Description"), String)

                    _IsApproval = CType(toReturn.Rows(0)("IsApproval"), Boolean)
                    _UserApproval = CType(toReturn.Rows(0)("UserApproval"), String)
                    _ApprovalDate = CType(toReturn.Rows(0)("ApprovalDate"), DateTime)
                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)

                    _IsDeleted = CType(toReturn.Rows(0)("IsDeleted"), Boolean)
                    _UserDelete = CType(toReturn.Rows(0)("UserDelete"), String)
                    _DeleteDate = CType(toReturn.Rows(0)("DeleteDate"), DateTime)
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

            cmdToExecute.CommandText = "Update DebitCreditNote " & _
                                       "Set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = Getdate() " & _
                                       "WHERE DCNoteNo = @DCNoteNo"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DCNoteNo", _DCNoteNo)
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
        Public Function SelectAllForReferenceNo(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " hd.PReturnNO as ReferenceNo,convert(varchar(10),hd.PReturnDate,105) as formatdate " & _
                                       "from PurchaseReturnHd hd " & _
                                       "Where hd.IsDeleted = 0 and hd.IsApproval = 1 " & _
                                       "and (select top 1 dc.DCNoteNo from DebitCreditNote dc where dc.isDeleted = 0 and dc.ReferenceNo = hd.PReturnNO) is null " & _
                                       "and hd.EntitiesSeqNo = @EntitiesSeqNo and (hd.PReturnNO LIKE '" + Filter.Trim + "%' OR convert(varchar(10),hd.PReturnDate,105) LIKE '" + Filter.Trim + "%') " & _
                                       "order by hd.PReturnNO desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DebitCreditNote")
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

        Public Function SelectAllForEntitiesSeqNo(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Distinct Top " + MaxRecord + " hd.EntitiesSeqNo, " & _
                                       "isnull(En.EntitiesId,'') as EntitiesId, " & _
                                       "isnull(En.EntitiesName,'') as EntitiesName " & _
                                       "FROM PurchaseReturnHd hd " & _
                                       "inner join PurchaseReturndt dt on Dt.PReturnNO = hd.PReturnNO " & _
                                       "inner join Entities En on En.EntitiesSeqNo = hd.EntitiesSeqNo " & _
                                       "Where hd.IsDeleted = 0 and hd.IsApproval = 1 and En.IsDeleted = 0 and En.IsActive = 1 " & _
                                       "and (select top 1 dc.DCNoteNo from DebitCreditNote dc where dc.isDeleted = 0 and dc.ReferenceNo = hd.PReturnNO) is null " & _
                                       "and (En.EntitiesId LIKE '" + Filter.Trim + "%' OR En.EntitiesName LIKE '" + Filter.Trim + "%' OR En.EntitiesSeqNo LIKE '" + Filter.Trim + "%') "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DebitCreditNote")
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

        Public Function SelectOneForReferenceNo() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT hd.PReturnNO as DCNoteNo, dt.TotalDetail , (dt.TotalDetail * (hd.IsPPN * hd.PPNPct)) AS Tax, " & _
                                       "hd.ReturnFeeAmt , (dt.TotalDetail + (dt.TotalDetail * (hd.IsPPN * hd.PPNPct)) - hd.ReturnFeeAmt) AS Amount " & _
                                       "FROM PurchaseReturnHd hd " & _
                                       "inner Join " & _
                                       "( " & _
                                         "SELECT t.PReturnNO, sum((t.Qty * t.ItemFactor * t.price) - t.Disc1Amt - t.Disc2Amt - t.Disc3Amt - t.ReturnFeeAmt) AS TotalDetail " & _
                                         "FROM PurchaseReturndt t WHERE IsDeleted = 0 " & _
                                         "GROUP BY t.PReturnNO " & _
                                       ") dt ON dt.PReturnNO = hd.PReturnNO " & _
                                       "Where hd.IsDeleted = 0 AND hd.IsApproval = 1 and hd.PReturnNO = @PReturnNO  "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DebitCreditNote")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@PReturnNO", _ReferenceNo)
                _mainConnection.Open()

                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _DCNoteNo = CType(toReturn.Rows(0)("DCNoteNo"), String)
                    _Amount = CType(toReturn.Rows(0)("Amount"), Decimal)
                End If

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
        Public Property [DCNoteNo]() As String
            Get
                Return _DCNoteNo
            End Get
            Set(ByVal Value As String)
                _DCNoteNo = Value
            End Set
        End Property

        Public Property [DCNoteDate]() As DateTime
            Get
                Return _DCNoteDate
            End Get
            Set(ByVal Value As DateTime)
                _DCNoteDate = Value
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

        Public Property [DCNoteID]() As String
            Get
                Return _DCNoteID
            End Get
            Set(ByVal Value As String)
                _DCNoteID = Value
            End Set
        End Property

        Public Property [ReferenceNo]() As String
            Get
                Return _ReferenceNo
            End Get
            Set(ByVal Value As String)
                _ReferenceNo = Value
            End Set
        End Property

        Public Property [IsTax]() As Boolean
            Get
                Return _IsTax
            End Get
            Set(ByVal Value As Boolean)
                _IsTax = Value
            End Set
        End Property

        Public Property [TaxPct]() As String
            Get
                Return _TaxPct
            End Get
            Set(ByVal Value As String)
                _TaxPct = Value
            End Set
        End Property

        Public Property [AmtDifferences]() As Decimal
            Get
                Return _AmtDifferences
            End Get
            Set(ByVal Value As Decimal)
                _AmtDifferences = Value
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


        Public Property [Description]() As String
            Get
                Return _Description
            End Get
            Set(ByVal Value As String)
                _Description = Value
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

        Public Property [UpdateDate]() As DateTime
            Get
                Return _UpdateDate
            End Get
            Set(ByVal Value As DateTime)
                _UpdateDate = Value
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

#End Region
    End Class
End Namespace