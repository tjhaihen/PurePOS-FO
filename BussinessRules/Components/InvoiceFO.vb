Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class InvoiceFO
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _STxnNo, _ItemSeqNo, _ItemID, _ItemName, _ReceiptNo, _UserUpdate As String
        Private _STxnDate, _ReceiptDate As Date
        Private _Qty, _Price, _ItemFactor, _Disc1Pct, _Disc1Amt, _Disc2Pct, _Disc2Amt, _Disc3Pct, _Disc3Amt As Decimal
        Private _GrossTotal, _DiscountTotal, _Total, _Rounding, _PaymentAmount, _PrintCounts, _VoucherAmount, _DonationAmt, _GetVoucherAmount As Decimal

#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Function GetInvoiceFOData() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "sprpt_Invoice"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("InvoiceFO")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try

                cmdToExecute.Parameters.AddWithValue("@STxnNo", _STxnNo)

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

        Public Function GetBillReceiptWithPaymentData(ByVal _UserID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "sppf_BillReceipt"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("BillReceipt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try

                cmdToExecute.Parameters.AddWithValue("@STxnNo", _STxnNo)
                cmdToExecute.Parameters.AddWithValue("@UserID", _UserID)

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

        'Public Function GetPrescriptionOrder() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand()
        '    cmdToExecute.CommandText = "SELECT * FROM md_worklistDT WHERE kdlayan='99.001' AND isOrderTextSentToPrinter=0"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure
        '    Dim toReturn As DataTable = New DataTable("PrescriptionOrder")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try

        '        'cmdToExecute.Parameters.AddWithValue("@STxnNo", _STxnNo)
        '        'cmdToExecute.Parameters.AddWithValue("@UserID", _UserID)

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

#Region " Class Property Declarations "

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

        Public Property [ItemID]() As String
            Get
                Return _ItemID
            End Get
            Set(ByVal Value As String)
                _ItemID = Value
            End Set
        End Property

        Public Property [ItemName]() As String
            Get
                Return _ItemName
            End Get
            Set(ByVal Value As String)
                _ItemName = Value
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

        Public Property [UserUpdate]() As String
            Get
                Return _UserUpdate
            End Get
            Set(ByVal Value As String)
                _UserUpdate = Value
            End Set
        End Property

        Public Property [STxnDate]() As Date
            Get
                Return _STxnDate
            End Get
            Set(ByVal Value As Date)
                _STxnDate = Value
            End Set
        End Property

        Public Property [ReceiptDate]() As Date
            Get
                Return _ReceiptDate
            End Get
            Set(ByVal Value As Date)
                _ReceiptDate = Value
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

        Public Property [ItemFactor]() As Decimal
            Get
                Return _ItemFactor
            End Get
            Set(ByVal Value As Decimal)
                _ItemFactor = Value
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

        Public Property [GrossTotal]() As Decimal
            Get
                Return _GrossTotal
            End Get
            Set(ByVal Value As Decimal)
                _GrossTotal = Value
            End Set
        End Property

        Public Property [DiscountTotal]() As Decimal
            Get
                Return _DiscountTotal
            End Get
            Set(ByVal Value As Decimal)
                _DiscountTotal = Value
            End Set
        End Property

        Public Property [Total]() As Decimal
            Get
                Return _Total
            End Get
            Set(ByVal Value As Decimal)
                _Total = Value
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

        Public Property [PaymentAmount]() As Decimal
            Get
                Return _PaymentAmount
            End Get
            Set(ByVal Value As Decimal)
                _PaymentAmount = Value
            End Set
        End Property

        Public Property [PrintCounts]() As Decimal
            Get
                Return _PrintCounts
            End Get
            Set(ByVal Value As Decimal)
                _PrintCounts = Value
            End Set
        End Property

        Public Property [VoucherAmount]() As Decimal
            Get
                Return _VoucherAmount
            End Get
            Set(ByVal Value As Decimal)
                _VoucherAmount = Value
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

        Public Property [GetVoucherAmount]() As Decimal
            Get
                Return _GetVoucherAmount
            End Get
            Set(ByVal Value As Decimal)
                _GetVoucherAmount = Value
            End Set
        End Property

#End Region

    End Class
End Namespace
