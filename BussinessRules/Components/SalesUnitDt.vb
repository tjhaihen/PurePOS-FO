Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Partial Public Class SalesUnitDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _ID As String
        Private _STxnNo As String
        Private _ItemSeqNo As String
        Private _ItemUnitID As String
        Private _ItemFactor As Decimal
        Private _Qty As Decimal
        Private _Price As Decimal
        Private _Disc1Pct As Decimal
        Private _Disc1Amt As Decimal
        Private _Disc2Pct As Decimal
        Private _Disc2Amt As Decimal
        Private _Disc3Pct As Decimal
        Private _Disc3Amt As Decimal
        Private _UserInsert As String
        Private _InsertDate As datetime
        Private _UserUpdate As String
        Private _UpdateDate As datetime
        Private _UserDelete As String
        Private _DeleteDate As datetime
        Private _IsDeleted As Boolean
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
            cmdToExecute.CommandText = "dbo.[usp_SalesUnitDt_Insert]"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            cmdToExecute.Connection = conn


            cmdToExecute.Transaction = trans

            Try

                cmdToExecute.Parameters.AddWithValue("@sID", _ID)
                cmdToExecute.Parameters.AddWithValue("@sSTxnNo", _STxnNo)
                cmdToExecute.Parameters.AddWithValue("@sItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.AddWithValue("@sItemUnitID", _ItemUnitID)
                cmdToExecute.Parameters.AddWithValue("@sItemFactor", _ItemFactor)
                cmdToExecute.Parameters.AddWithValue("@sQty", _Qty)
                cmdToExecute.Parameters.AddWithValue("@sPrice", _Price)
                cmdToExecute.Parameters.AddWithValue("@sDisc1Pct", _Disc1Pct)
                cmdToExecute.Parameters.AddWithValue("@sDisc1Amt", _Disc1Amt)
                cmdToExecute.Parameters.AddWithValue("@sDisc2Pct", _Disc2Pct)
                cmdToExecute.Parameters.AddWithValue("@sDisc2Amt", _Disc2Amt)
                cmdToExecute.Parameters.AddWithValue("@sDisc3Pct", _Disc3Pct)
                cmdToExecute.Parameters.AddWithValue("@sDisc3Amt", _Disc3Amt)
                cmdToExecute.Parameters.AddWithValue("@sUserInsert", _UserInsert)
                cmdToExecute.Parameters.AddWithValue("@sUserUpdate", _UserUpdate)
                cmdToExecute.Parameters.AddWithValue("@sDescription", _Description)

                '' // Open connection.
                '_mainConnection.Open()

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                '_mainConnection.Close()
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
            cmdToExecute.CommandText = "dbo.[usp_SalesUnitDt_Update]"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            cmdToExecute.Connection = conn
            If (trans IsNot Nothing) Then
                cmdToExecute.Transaction = trans
            End If

            Try

                cmdToExecute.Parameters.AddWithValue("@sID", _ID)
                cmdToExecute.Parameters.AddWithValue("@sSTxnNo", _STxnNo)
                cmdToExecute.Parameters.AddWithValue("@sItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.AddWithValue("@sItemUnitID", _ItemUnitID)
                cmdToExecute.Parameters.AddWithValue("@sItemFactor", _ItemFactor)
                cmdToExecute.Parameters.AddWithValue("@sQty", _Qty)
                cmdToExecute.Parameters.AddWithValue("@sPrice", _Price)
                cmdToExecute.Parameters.AddWithValue("@sDisc1Pct", _Disc1Pct)
                cmdToExecute.Parameters.AddWithValue("@sDisc1Amt", _Disc1Amt)
                cmdToExecute.Parameters.AddWithValue("@sDisc2Pct", _Disc2Pct)
                cmdToExecute.Parameters.AddWithValue("@sDisc2Amt", _Disc2Amt)
                cmdToExecute.Parameters.AddWithValue("@sDisc3Pct", _Disc3Pct)
                cmdToExecute.Parameters.AddWithValue("@sDisc3Amt", _Disc3Amt)
                cmdToExecute.Parameters.AddWithValue("@sUserUpdate", _UserUpdate)
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
            cmdToExecute.CommandText = "dbo.[usp_SalesUnitDt_Delete]"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            cmdToExecute.Connection = conn
            If (trans IsNot Nothing) Then
                cmdToExecute.Transaction = trans
            End If

            Try

                cmdToExecute.Parameters.AddWithValue("@sID", _ID)

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
                    cmdToExecute.CommandText = "dbo.[usp_SalesUnitDt_SelectOne]"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "dbo.[usp_SalesUnitDt_SelectOneNext]"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "dbo.[usp_SalesUnitDt_SelectOnePrev]"
            End Select
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("SalesUnitDt")
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
                    _STxnNo = CType(row("STxnNo"), String)
                    _ItemSeqNo = CType(row("ItemSeqNo"), String)
                    _ItemUnitID = CType(row("ItemUnitID"), String)
                    _ItemFactor = CType(row("ItemFactor"), Decimal)
                    _Qty = CType(row("Qty"), Decimal)
                    _Price = CType(row("Price"), Decimal)
                    _Disc1Pct = CType(row("Disc1Pct"), Decimal)
                    _Disc1Amt = CType(row("Disc1Amt"), Decimal)
                    _Disc2Pct = CType(row("Disc2Pct"), Decimal)
                    _Disc2Amt = CType(row("Disc2Amt"), Decimal)
                    _Disc3Pct = CType(row("Disc3Pct"), Decimal)
                    _Disc3Amt = CType(row("Disc3Amt"), Decimal)
                    _UserInsert = CType(row("UserInsert"), String)
                    _InsertDate = CType(row("InsertDate"), datetime)
                    _UserUpdate = CType(row("UserUpdate"), String)
                    _UpdateDate = CType(row("UpdateDate"), datetime)
                    _UserDelete = CType(row("UserDelete"), String)
                    _DeleteDate = CType(row("DeleteDate"), datetime)
                    _IsDeleted = CType(row("IsDeleted"), Boolean)
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
            cmdToExecute.CommandText = "dbo.[usp_SalesUnitDt_SelectAll]"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("SalesUnitDt")
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

#Region " Class Property Declarations "

        Public Property [ID]() As String
            Get
                Return _ID
            End Get
            Set(ByVal Value As String)
                _ID = Value
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

        Public Property [ItemSeqNo]() As String
            Get
                Return _ItemSeqNo
            End Get
            Set(ByVal Value As String)
                _ItemSeqNo = Value
            End Set
        End Property

        Public Property [ItemUnitID]() As String
            Get
                Return _ItemUnitID
            End Get
            Set(ByVal Value As String)
                _ItemUnitID = Value
            End Set
        End Property

        Public Property [ItemFactor]() As Decimal
            Get
                Return _ItemFactor
            End Get
            Set(ByVal Value As Decimal)
                _ItemFactor = Value
            End Set
        End Property

        Public Property [Qty]() As Decimal
            Get
                Return _Qty
            End Get
            Set(ByVal Value As Decimal)
                _Qty = Value
            End Set
        End Property

        Public Property [Price]() As Decimal
            Get
                Return _Price
            End Get
            Set(ByVal Value As Decimal)
                _Price = Value
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

        Public Property [Disc1Amt]() As Decimal
            Get
                Return _Disc1Amt
            End Get
            Set(ByVal Value As Decimal)
                _Disc1Amt = Value
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

        Public Property [Disc2Amt]() As Decimal
            Get
                Return _Disc2Amt
            End Get
            Set(ByVal Value As Decimal)
                _Disc2Amt = Value
            End Set
        End Property

        Public Property [Disc3Pct]() As Decimal
            Get
                Return _Disc3Pct
            End Get
            Set(ByVal Value As Decimal)
                _Disc3Pct = Value
            End Set
        End Property

        Public Property [Disc3Amt]() As Decimal
            Get
                Return _Disc3Amt
            End Get
            Set(ByVal Value As Decimal)
                _Disc3Amt = Value
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

        Public Property [InsertDate]() As datetime
            Get
                Return _InsertDate
            End Get
            Set(ByVal Value As datetime)
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

        Public Property [UpdateDate]() As datetime
            Get
                Return _UpdateDate
            End Get
            Set(ByVal Value As datetime)
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

        Public Property [DeleteDate]() As datetime
            Get
                Return _DeleteDate
            End Get
            Set(ByVal Value As datetime)
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


#End Region

    End Class
End Namespace
