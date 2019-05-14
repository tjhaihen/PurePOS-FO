Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules

    Public Enum TxnType
        BeginningBalance = 0
        Receiving = 100
        StockOpname = 109
        PurchaseReturn = 101
        Distribution = 102
        Consumption = 103
        Production = 104
        SalesCashier = 105
        SalesCashierReturn = 106
        SalesOffice = 107
        SalesOfficeReturn = 108
        AdjustmentPlus = 110
        AdjustmentMinus = 111
    End Enum

    Public Class ItemHistory
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _ID, _TxnNo, _InventoryTxnID, _TxnDate, _WhID, _UnitID, _ItemSeqNo, _ItemLUnitID, _ItemSUnitID As String
        Private _ItemFactor, _QtySUnitBegin, _QtySUnitIn, _QtySUnitOut, _SUnitPrice, _SUnitCOGS, _SUnitCOGSPrev As Decimal
        Private _Description As String
        Private _UserInsert As String
        Private _InsertDate As String
#End Region


        Public Sub New()
            ' // Nothing for now.
        End Sub


        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub


#Region " -- UNPOSTING FUNCTION -- "
        Public Function DoUnposting(ByVal t As TxnType, ByVal transNo As String) As Boolean
            _TxnNo = Trim(transNo)
            Select Case t
                'Case TxnType.purchaseOrder
                '   unpostPurchaseOrder()
            End Select

            Return True
        End Function
#End Region

#Region " -- POSTING FUNCTION -- "

        Public Function DoApproval(ByVal t As TxnType) As Boolean
            Select Case t
                Case TxnType.Receiving
                    ApprovalReceiving(CStr(TxnType.Receiving), "Receiving")
                Case TxnType.PurchaseReturn
                    ApprovalPurchaseReturn(CStr(TxnType.PurchaseReturn), "Purchase Return")
                Case TxnType.StockOpname
                    ApprovalStockOpnameOrAdjustmentOrBeginningBalance(CStr(TxnType.StockOpname), "Stock Opname")
                Case TxnType.Distribution
                    ApprovalDistribution(CStr(TxnType.Distribution), "Distribution")
                Case TxnType.Consumption
                    ApprovalConsumption(CStr(TxnType.Consumption), "Consumption")
                Case TxnType.Production
                    ApprovalProduction(CStr(TxnType.Production), "Production")
                Case TxnType.AdjustmentPlus
                    ApprovalStockOpnameOrAdjustmentOrBeginningBalance(CStr(TxnType.AdjustmentPlus), "Adjustment Plus")
                Case TxnType.AdjustmentMinus
                    ApprovalStockOpnameOrAdjustmentOrBeginningBalance(CStr(TxnType.AdjustmentMinus), "Adjustment Minus")
                Case TxnType.BeginningBalance
                    ApprovalStockOpnameOrAdjustmentOrBeginningBalance(CStr(TxnType.BeginningBalance), "Beginning Balance")
                Case TxnType.SalesCashier
                    ApprovalSalesUnit(CStr(TxnType.SalesCashier), "Sales Unit")
                Case TxnType.SalesCashierReturn
                    ApprovalSalesReturn(CStr(TxnType.SalesCashierReturn), "Sales Return")
            End Select

            Return True
        End Function
#End Region

#Region "Main Function"
        Private Sub ApprovalStockOpnameOrAdjustmentOrBeginningBalance(ByVal TxnTypeValue As String, ByVal Description As String)
            Dim cn As New SqlConnection(HisConfiguration.ConnectionString)
            Dim cmdUpdateApproval As SqlCommand = New SqlCommand
            Dim strSQL_UpdateApproval As New Text.StringBuilder
            Dim strSQL_InsertItemHistory As New Text.StringBuilder
            Dim cmdInsertItemHistory As New SqlCommand

            Dim trans As SqlTransaction

            With strSQL_UpdateApproval
                .Append("Update MutationHd " & _
                        "Set IsApproval = 1, " & _
                        "UserApproval = @UserApproval, " & _
                        "ApprovalDate = getdate() " & _
                        "Where IsApproval = 0 and IsDeleted = 0 and TxnNo = @TxnNo ")
            End With
            With strSQL_InsertItemHistory
                .Append("Insert into ItemHistory " & _
                        "(ID, TxnNo, InventoryTxnID, TxnDate, WhID, UnitID, ItemSeqNo, " & _
                        "ItemLUnitID, ItemSUnitID, ItemFactor, QtySUnitBegin, QtySUnitIn, " & _
                        "QtySUnitOut, SUnitPrice, SUnitCOGS, SUnitCOGSPrev, UserInsert, " & _
                        "InsertDate, Description) " & _
                        "SELECT CAST((@IDMAX + ROW_NUMBER() OVER (order by dt.ItemSeqNo) - 1) as varchar) AS ID, " & _
                        "dt.ID AS TxnNo, " & _
                        "@inventoryTxnID AS inventoryTxnID, " & _
                        "hd.TxnDate, " & _
                        "hd.SourceWHID AS WhID, " & _
                        "hd.SourceUnitID AS UnitID, " & _
                        "dt.ItemSeqNo, " & _
                        "isnull(it.ItemLUnitID,'') AS ItemLUnitID, " & _
                        "isnull(it.ItemSUnitID,'') AS ItemSUnitID, " & _
                        "dt.ItemFactor, " & _
                        "isnull(itb.QtySUnit,0) AS QtySUnitBegin, " & _
                        "(case when dt.PlusOrMinus = '+' THEN dt.Qty ELSE 0 END) AS QtySUIn, " & _
                        "(case when dt.PlusOrMinus = '-' THEN dt.Qty ELSE 0 END) AS QtySUOut, " & _
                        "isnull(it.SUnitCOGSLast,0) AS SUnitPrice, " & _
                        "dbo.GetCOGSNow(isnull(it.SUnitCOGSLast, 0), isnull(itb.QtySUnit, 0), isnull(it.SUnitCOGSLast, 0), isnull(dt.Qty, 0), dt.PlusOrMinus) as SUnitCOGS, " & _
                        "isnull(it.SUnitCOGSLast,0) AS SUnitCOGSPrev, " & _
                        "@UserInsert AS UserInsert, " & _
                        "GETDATE() AS InsertDate, " & _
                        "left(@Description,500) AS [DESCRIPTION] " & _
                        "FROM MutationHd hd " & _
                        "INNER JOIN MutationDt dt ON dt.TxnNo = hd.TxnNo AND hd.IsApproval = 0 and hd.IsDeleted = 0 and dt.IsDeleted = 0 " & _
                        "LEFT JOIN ItemBalance itb ON itb.ItemSeqNo = dt.ItemSeqNo AND itb.WhID = hd.SourceWHID AND itb.UnitID = hd.SourceUnitID " & _
                        "LEFT JOIN Item it ON it.ItemSeqNo = dt.ItemSeqNo " & _
                        "WHERE hd.TxnNo = @txnNo order by dt.ItemSeqNo")
            End With

            ' // Open connection.
            cn.Open()
            trans = cn.BeginTransaction
            Try
                With cmdUpdateApproval
                    .CommandText = strSQL_UpdateApproval.ToString
                    .CommandType = CommandType.Text
                    .Transaction = trans
                    .Connection = cn
                    .Parameters.Add(New SqlParameter("@UserApproval", _UserInsert))
                    .Parameters.Add(New SqlParameter("@TxnNo", _TxnNo))
                End With

                With cmdInsertItemHistory
                    .CommandText = strSQL_InsertItemHistory.ToString
                    .CommandType = CommandType.Text
                    .Transaction = trans
                    .Connection = cn
                    .Parameters.Add(New SqlParameter("@TxnNo", _TxnNo))
                    .Parameters.Add(New SqlParameter("@IDMax", BussinessRules.ID.GenerateIDNumberWithBeginTransaction("ItemHistory", "ID", cn, trans)))
                    .Parameters.Add(New SqlParameter("@InventoryTxnID", TxnTypeValue.Trim))
                    .Parameters.Add(New SqlParameter("@Description", Description.Trim))
                    .Parameters.Add(New SqlParameter("@UserInsert", _UserInsert))
                End With

                ' // insert stock masuk ke history 
                cmdInsertItemHistory.ExecuteNonQuery()

                ' // update flag posting .
                cmdUpdateApproval.ExecuteNonQuery()

                ' //  Commit the transaction
                trans.Commit()
            Catch ex As Exception
                ' // Rollback all changes
                trans.Rollback()
                ExceptionManager.Publish(ex)
            Finally
                trans.Dispose()
                trans = Nothing

                If Not cn Is Nothing Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End If
                cn.Dispose()
                cn = Nothing
            End Try
        End Sub

        Private Sub ApprovalConsumption(ByVal TxnTypeValue As String, ByVal Description As String)
            Dim cn As New SqlConnection(HisConfiguration.ConnectionString)

            Dim strSQL_InsertHistory As New Text.StringBuilder
            Dim strSQL_SelectConsumptionTmp As New Text.StringBuilder
            Dim strSQL_ConsumptionUpdateApproval As New Text.StringBuilder

            Dim trans As SqlTransaction

            Dim cmdSelectConsumptionTmp As SqlCommand = New SqlCommand

            With strSQL_ConsumptionUpdateApproval
                .Append("Update MutationHd " & _
                        "Set IsApproval = 1, " & _
                        "UserApproval = @UserApproval, " & _
                        "ApprovalDate = getdate() " & _
                        "Where IsApproval = 0 and IsDeleted = 0 and TxnNo = @TxnNo ")
            End With

            ' // di insert ke table history ...
            With strSQL_SelectConsumptionTmp
                .Append("SELECT " & _
                        "dt.ID AS TxnNo, " & _
                        "@inventoryTxnID AS inventoryTxnID, " & _
                        "hd.TxnDate, " & _
                        "hd.SourceWHID AS WhID, " & _
                        "hd.SourceUnitID AS UnitID, " & _
                        "dt.ItemSeqNo, " & _
                        "isnull(it.ItemName,'') as ItemName, " & _
                        "isnull(it.ItemLUnitID,'') AS ItemLUnitID, " & _
                        "isnull(it.ItemSUnitID,'') AS ItemSUnitID, " & _
                        "dt.ItemFactor, " & _
                        "0 AS QtySUIn, " & _
                        "dt.Qty AS QtySUOut, " & _
                        "isnull(it.SUnitCOGSLast,0) AS SUnitPrice, " & _
                        "left(@Description,500) AS [DESCRIPTION] " & _
                        "FROM MutationHd hd " & _
                        "INNER JOIN MutationDt dt ON dt.TxnNo = hd.TxnNo AND hd.IsApproval = 0 and hd.IsDeleted = 0 and dt.IsDeleted = 0 " & _
                        "INNER JOIN Item it ON it.ItemSeqNo = dt.ItemSeqNo " & _
                        "WHERE hd.TxnNo = @txnNo order by dt.ItemSeqNo")
            End With

            ' // sql statement untuk insert ke table history ...
            With strSQL_InsertHistory
                .Append("Insert into ItemHistory" & _
                        "(ID, TxnNo, InventoryTxnID, TxnDate, WhID, UnitID, ItemSeqNo, " & _
                        "ItemLUnitID, ItemSUnitID, ItemFactor, QtySUnitBegin, QtySUnitIn, " & _
                        "QtySUnitOut, SUnitPrice, SUnitCOGS, SUnitCOGSPrev, UserInsert, " & _
                        "InsertDate, Description) " & _
                        "Values(@ID, @TxnNo, @InventoryTxnID, @TxnDate, @WhID, @UnitID, @ItemSeqNo, " & _
                        "@ItemLUnitID, @ItemSUnitID, @ItemFactor, @QtySUnitBegin, @QtySUnitIn, " & _
                        "@QtySUnitOut, @SUnitPrice, @SUnitCOGS, @SUnitCOGSPrev, @UserInsert, " & _
                        "Getdate(), left(@Description,500)) ")

            End With

            With cmdSelectConsumptionTmp
                .CommandText = strSQL_SelectConsumptionTmp.ToString
                .CommandType = CommandType.Text
                .Connection = cn
                .Parameters.Add(New SqlParameter("@TxnNo", _TxnNo))
                .Parameters.Add(New SqlParameter("@InventoryTxnID", TxnTypeValue.Trim))
                .Parameters.Add(New SqlParameter("@Description", Description))
            End With


            Dim tblDistributionTmp As DataTable = New DataTable("ConsumptionTmp")
            Dim adapterTrmTmp As SqlDataAdapter = New SqlDataAdapter(cmdSelectConsumptionTmp)

            ' // Open connection.
            cn.Open()

            trans = cn.BeginTransaction

            cmdSelectConsumptionTmp.Transaction = trans
            Try
                ' // loop untuk setiap record and insert ke table history ...!!
                adapterTrmTmp.Fill(tblDistributionTmp)
                Dim rowsTmp As DataRow() = tblDistributionTmp.Select
                Dim iRecCountTmp As Integer

                If rowsTmp.Length > 0 Then
                    iRecCountTmp = 1

                    While iRecCountTmp <= rowsTmp.Length
                        Dim drTmp As DataRow = rowsTmp(iRecCountTmp - 1)

                        _ID = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("ItemHistory", "ID", cn, trans)
                        Dim IDTxnNo As String = drTmp("TxnNo")
                        _InventoryTxnID = drTmp("inventoryTxnID")
                        _TxnDate = drTmp("TxnDate")
                        _WhID = drTmp("WHID")
                        _UnitID = drTmp("UnitID")
                        _ItemSeqNo = drTmp("ItemSeqNo")
                        Dim ItemName As String = drTmp("ItemName")
                        _ItemLUnitID = drTmp("ItemLUnitID")
                        _ItemSUnitID = drTmp("ItemSUnitID")
                        _ItemFactor = drTmp("ItemFactor")
                        _QtySUnitIn = drTmp("QtySUIn")
                        _QtySUnitOut = drTmp("QtySUOut")
                        _SUnitPrice = drTmp("SUnitPrice")
                        _Description = drTmp("Description")

                        Dim cmdItem As SqlCommand = New SqlCommand
                        With cmdItem
                            .CommandText = "SELECT * FROM Item WHERE ItemSeqNo = @ItemSeqNo "
                            .CommandType = CommandType.Text
                            .Connection = cn
                            .Transaction = trans
                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                        End With
                        Dim adpItem As SqlDataAdapter = New SqlDataAdapter(cmdItem)
                        Dim dtitem As DataTable = New DataTable
                        adpItem.Fill(dtitem)

                        _SUnitCOGSPrev = ProcessNull.GetDouble(dtitem.Rows(0)("SUnitCOGSLast"))

                        dtitem.Dispose()
                        dtitem = Nothing

                        Dim cmdQtySUnitBegin As SqlCommand = New SqlCommand
                        With cmdQtySUnitBegin
                            .CommandText = "SELECT * FROM ItemBalance WHERE ItemSeqNo = @ItemSeqNo AND WhID = @WhID AND UnitID = @UnitID "
                            .CommandType = CommandType.Text
                            .Connection = cn
                            .Transaction = trans
                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                            .Parameters.Add(New SqlParameter("@WhID", _WhID))
                            .Parameters.Add(New SqlParameter("@UnitID", _UnitID))
                        End With
                        Dim adpQtySUnitBegin As SqlDataAdapter = New SqlDataAdapter(cmdQtySUnitBegin)
                        Dim dtQtySUnitBegin As DataTable = New DataTable
                        adpQtySUnitBegin.Fill(dtQtySUnitBegin)

                        If dtQtySUnitBegin.Rows.Count > 0 Then
                            _QtySUnitBegin = ProcessNull.GetDouble(dtQtySUnitBegin.Rows(0)("QtySUnit"))
                        Else
                            _QtySUnitBegin = 0
                        End If

                        dtQtySUnitBegin.Dispose()
                        dtQtySUnitBegin = Nothing

                        If _QtySUnitBegin + (_QtySUnitIn * _ItemFactor) - (_QtySUnitOut * _ItemFactor) < 0 Then
                            Throw New Exception(ItemName.Trim + " Qty (" + Format((_QtySUnitOut * _ItemFactor), "#,##0.00") + ") must be equal or less than qty stock (" + Format(_QtySUnitBegin, "#,##0.00") + ")")
                            Exit Sub
                        End If

                        _SUnitCOGS = GetCOGSNowWithBeginTransaction(_SUnitCOGSPrev, _QtySUnitBegin, _SUnitPrice, (_QtySUnitOut * _ItemFactor), "-", cn, trans)


                        With New SqlCommand
                            .CommandText = strSQL_InsertHistory.ToString
                            .CommandType = CommandType.Text
                            .Transaction = trans
                            .Connection = cn

                            .Parameters.Add(New SqlParameter("@ID", _ID))
                            .Parameters.Add(New SqlParameter("@TxnNo", IDTxnNo))
                            .Parameters.Add(New SqlParameter("@InventoryTxnID", _InventoryTxnID))
                            .Parameters.Add(New SqlParameter("@TxnDate", _TxnDate))
                            .Parameters.Add(New SqlParameter("@WhID", _WhID))
                            .Parameters.Add(New SqlParameter("@UnitID", _UnitID))
                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                            .Parameters.Add(New SqlParameter("@ItemLUnitID", _ItemLUnitID))
                            .Parameters.Add(New SqlParameter("@ItemSUnitID", _ItemSUnitID))
                            .Parameters.Add(New SqlParameter("@ItemFactor", _ItemFactor))
                            .Parameters.Add(New SqlParameter("@QtySUnitBegin", _QtySUnitBegin))
                            .Parameters.Add(New SqlParameter("@QtySUnitIn", _QtySUnitIn))
                            .Parameters.Add(New SqlParameter("@QtySUnitOut", _QtySUnitOut))
                            .Parameters.Add(New SqlParameter("@SUnitPrice", _SUnitPrice))
                            .Parameters.Add(New SqlParameter("@SUnitCOGS", _SUnitCOGS))
                            .Parameters.Add(New SqlParameter("@SUnitCOGSPrev", _SUnitCOGSPrev))
                            .Parameters.Add(New SqlParameter("@UserInsert", _UserInsert))
                            .Parameters.Add(New SqlParameter("@Description", _Description))

                            .ExecuteNonQuery()
                        End With

                        iRecCountTmp += 1
                    End While 'While iRecCountTmp <= rowsTmp.Length

                    With New SqlCommand
                        .CommandText = strSQL_ConsumptionUpdateApproval.ToString
                        .CommandType = CommandType.Text
                        .Connection = cn
                        .Parameters.Add(New SqlParameter("@TxnNo", _TxnNo))
                        .Parameters.Add(New SqlParameter("@UserApproval", _UserInsert))
                        .Transaction = trans
                        .ExecuteNonQuery()
                    End With

                End If 'rowsTmp.Length > 0 Then

                ' //  Commit the transaction
                trans.Commit()
            Catch ex As Exception

                ' // Rollback all changes
                trans.Rollback()
                ExceptionManager.Publish(ex)

            Finally
                trans.Dispose()
                trans = Nothing

                If Not cn Is Nothing Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End If
                cn.Dispose()
                cn = Nothing
            End Try
        End Sub

        Private Sub ApprovalDistribution(ByVal TxnTypeValue As String, ByVal Description As String)
            Dim cn As New SqlConnection(HisConfiguration.ConnectionString)

            Dim strSQL_InsertHistory As New Text.StringBuilder
            Dim strSQL_SelectDistributionTmp As New Text.StringBuilder
            Dim strSQL_DistributionUpdateApproval As New Text.StringBuilder

            Dim trans As SqlTransaction

            Dim cmdSelectDistributionTmp As SqlCommand = New SqlCommand

            With strSQL_DistributionUpdateApproval
                .Append("Update MutationHd " & _
                        "Set IsApproval = 1, " & _
                        "UserApproval = @UserApproval, " & _
                        "ApprovalDate = getdate() " & _
                        "Where IsApproval = 0 and IsDeleted = 0 and TxnNo = @TxnNo ")
            End With

            ' // di insert ke table history ...
            With strSQL_SelectDistributionTmp
                .Append("SELECT " & _
                        "dt.ID as TxnNo, " & _
                        "@InventoryTxnID AS inventoryTxnID, " & _
                        "hd.TxnDate, " & _
                        "hd.SourceWHID AS WhID, " & _
                        "hd.SourceUnitID AS UnitID, " & _
                        "dt.ItemSeqNo, " & _
                        "isnull(it.ItemName,'') as ItemName, " & _
                        "isnull(it.ItemLUnitID,'') AS ItemLUnitID, " & _
                        "isnull(it.ItemSUnitID,'') AS ItemSUnitID, " & _
                        "dt.ItemFactor, " & _
                        "0 AS QtySUIn, " & _
                        "dt.Qty AS QtySUOut, " & _
                        "isnull(it.SUnitCOGSLast,0) AS SUnitPrice, " & _
                        "left(@Description,500) AS [DESCRIPTION] " & _
                        "FROM MutationHd hd " & _
                        "INNER JOIN MutationDt dt ON dt.TxnNo = hd.TxnNo AND hd.IsApproval = 0 and hd.IsDeleted = 0 and dt.IsDeleted = 0 " & _
                        "INNER JOIN Item it ON it.ItemSeqNo = dt.ItemSeqNo " & _
                        "WHERE hd.TxnNo = @TxnNo " & _
                        "UNION ALL " & _
                        "SELECT  " & _
                        "dt.ID as TxnNo, " & _
                        "@InventoryTxnID AS inventoryTxnID, " & _
                        "hd.TxnDate, " & _
                        "hd.DestinationWHID AS WhID, " & _
                        "hd.DestinationUnitID AS UnitID, " & _
                        "dt.ItemSeqNo, " & _
                        "isnull(it.ItemName,'') as ItemName, " & _
                        "isnull(it.ItemLUnitID,'') AS ItemLUnitID, " & _
                        "isnull(it.ItemSUnitID,'') AS ItemSUnitID, " & _
                        "dt.ItemFactor, " & _
                        "dt.Qty AS QtySUIn, " & _
                        "0 AS QtySUOut, " & _
                        "isnull(it.SUnitCOGSLast,0) AS SUnitPrice, " & _
                        "left(@Description,500) AS [DESCRIPTION] " & _
                        "FROM MutationHd hd " & _
                        "INNER JOIN MutationDt dt ON dt.TxnNo = hd.TxnNo AND hd.IsApproval = 0 and hd.IsDeleted = 0 and dt.IsDeleted = 0 " & _
                        "INNER JOIN Item it ON it.ItemSeqNo = dt.ItemSeqNo " & _
                        "WHERE hd.TxnNo = @TxnNo ")
            End With

            ' // sql statement untuk insert ke table history ...
            With strSQL_InsertHistory
                .Append("Insert into ItemHistory" & _
                        "(ID, TxnNo, InventoryTxnID, TxnDate, WhID, UnitID, ItemSeqNo, " & _
                        "ItemLUnitID, ItemSUnitID, ItemFactor, QtySUnitBegin, QtySUnitIn, " & _
                        "QtySUnitOut, SUnitPrice, SUnitCOGS, SUnitCOGSPrev, UserInsert, " & _
                        "InsertDate, Description) " & _
                        "Values(@ID, @TxnNo, @InventoryTxnID, @TxnDate, @WhID, @UnitID, @ItemSeqNo, " & _
                        "@ItemLUnitID, @ItemSUnitID, @ItemFactor, @QtySUnitBegin, @QtySUnitIn, " & _
                        "@QtySUnitOut, @SUnitPrice, @SUnitCOGS, @SUnitCOGSPrev, @UserInsert, " & _
                        "Getdate(), left(@Description,500)) ")

            End With

            With cmdSelectDistributionTmp
                .CommandText = strSQL_SelectDistributionTmp.ToString
                .CommandType = CommandType.Text
                .Connection = cn
                .Parameters.Add(New SqlParameter("@TxnNo", _TxnNo))
                .Parameters.Add(New SqlParameter("@InventoryTxnID", TxnTypeValue.Trim))
                .Parameters.Add(New SqlParameter("@Description", Description))
            End With


            Dim tblDistributionTmp As DataTable = New DataTable("DistributionTmp")
            Dim adapterTrmTmp As SqlDataAdapter = New SqlDataAdapter(cmdSelectDistributionTmp)

            ' // Open connection.
            cn.Open()

            trans = cn.BeginTransaction

            cmdSelectDistributionTmp.Transaction = trans
            Try
                ' // loop untuk setiap record and insert ke table history ...!!
                adapterTrmTmp.Fill(tblDistributionTmp)
                Dim rowsTmp As DataRow() = tblDistributionTmp.Select
                Dim iRecCountTmp As Integer

                If rowsTmp.Length > 0 Then
                    iRecCountTmp = 1

                    While iRecCountTmp <= rowsTmp.Length
                        Dim drTmp As DataRow = rowsTmp(iRecCountTmp - 1)

                        _ID = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("ItemHistory", "ID", cn, trans)
                        Dim IDTxnNo As String = drTmp("TxnNo")
                        _InventoryTxnID = drTmp("inventoryTxnID")
                        _TxnDate = drTmp("TxnDate")
                        _WhID = drTmp("WHID")
                        _UnitID = drTmp("UnitID")
                        _ItemSeqNo = drTmp("ItemSeqNo")
                        Dim ItemName As String = drTmp("ItemName")
                        _ItemLUnitID = drTmp("ItemLUnitID")
                        _ItemSUnitID = drTmp("ItemSUnitID")
                        _ItemFactor = drTmp("ItemFactor")
                        _QtySUnitIn = drTmp("QtySUIn")
                        _QtySUnitOut = drTmp("QtySUOut")
                        _SUnitPrice = drTmp("SUnitPrice")
                        _Description = drTmp("Description")

                        Dim cmdItem As SqlCommand = New SqlCommand
                        With cmdItem
                            .CommandText = "SELECT * FROM Item WHERE ItemSeqNo = @ItemSeqNo "
                            .CommandType = CommandType.Text
                            .Connection = cn
                            .Transaction = trans
                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                        End With
                        Dim adpItem As SqlDataAdapter = New SqlDataAdapter(cmdItem)
                        Dim dtitem As DataTable = New DataTable
                        adpItem.Fill(dtitem)

                        _SUnitCOGSPrev = ProcessNull.GetDouble(dtitem.Rows(0)("SUnitCOGSLast"))

                        dtitem.Dispose()
                        dtitem = Nothing

                        Dim cmdQtySUnitBegin As SqlCommand = New SqlCommand
                        With cmdQtySUnitBegin
                            .CommandText = "SELECT * FROM ItemBalance WHERE ItemSeqNo = @ItemSeqNo AND WhID = @WhID AND UnitID = @UnitID "
                            .CommandType = CommandType.Text
                            .Connection = cn
                            .Transaction = trans
                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                            .Parameters.Add(New SqlParameter("@WhID", _WhID))
                            .Parameters.Add(New SqlParameter("@UnitID", _UnitID))
                        End With
                        Dim adpQtySUnitBegin As SqlDataAdapter = New SqlDataAdapter(cmdQtySUnitBegin)
                        Dim dtQtySUnitBegin As DataTable = New DataTable
                        adpQtySUnitBegin.Fill(dtQtySUnitBegin)

                        If dtQtySUnitBegin.Rows.Count > 0 Then
                            _QtySUnitBegin = ProcessNull.GetDouble(dtQtySUnitBegin.Rows(0)("QtySUnit"))
                        Else
                            _QtySUnitBegin = 0
                        End If

                        dtQtySUnitBegin.Dispose()
                        dtQtySUnitBegin = Nothing

                        If _QtySUnitBegin + (_QtySUnitIn * _ItemFactor) - (_QtySUnitOut * _ItemFactor) < 0 Then
                            Throw New Exception(ItemName.Trim + " Qty (" + Format((_QtySUnitOut * _ItemFactor), "#,##0.00") + ") must be equal or less than qty stock (" + Format(_QtySUnitBegin, "#,##0.00") + ")")
                            Exit Sub
                        End If

                        _SUnitCOGS = GetCOGSNowWithBeginTransaction(_SUnitCOGSPrev, _QtySUnitBegin, _SUnitPrice, Math.Abs((_QtySUnitIn * _ItemFactor) - (_QtySUnitOut * _ItemFactor)), Math.Sign((_QtySUnitIn * _ItemFactor) - (_QtySUnitOut * _ItemFactor)), cn, trans)


                        With New SqlCommand
                            .CommandText = strSQL_InsertHistory.ToString
                            .CommandType = CommandType.Text
                            .Transaction = trans
                            .Connection = cn

                            .Parameters.Add(New SqlParameter("@ID", _ID))
                            .Parameters.Add(New SqlParameter("@TxnNo", IDTxnNo))
                            .Parameters.Add(New SqlParameter("@InventoryTxnID", _InventoryTxnID))
                            .Parameters.Add(New SqlParameter("@TxnDate", _TxnDate))
                            .Parameters.Add(New SqlParameter("@WhID", _WhID))
                            .Parameters.Add(New SqlParameter("@UnitID", _UnitID))
                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                            .Parameters.Add(New SqlParameter("@ItemLUnitID", _ItemLUnitID))
                            .Parameters.Add(New SqlParameter("@ItemSUnitID", _ItemSUnitID))
                            .Parameters.Add(New SqlParameter("@ItemFactor", _ItemFactor))
                            .Parameters.Add(New SqlParameter("@QtySUnitBegin", _QtySUnitBegin))
                            .Parameters.Add(New SqlParameter("@QtySUnitIn", _QtySUnitIn))
                            .Parameters.Add(New SqlParameter("@QtySUnitOut", _QtySUnitOut))
                            .Parameters.Add(New SqlParameter("@SUnitPrice", _SUnitPrice))
                            .Parameters.Add(New SqlParameter("@SUnitCOGS", _SUnitCOGS))
                            .Parameters.Add(New SqlParameter("@SUnitCOGSPrev", _SUnitCOGSPrev))
                            .Parameters.Add(New SqlParameter("@UserInsert", _UserInsert))
                            .Parameters.Add(New SqlParameter("@Description", _Description))

                            .ExecuteNonQuery()
                        End With

                        iRecCountTmp += 1
                    End While 'While iRecCountTmp <= rowsTmp.Length

                    With New SqlCommand
                        .CommandText = strSQL_DistributionUpdateApproval.ToString
                        .CommandType = CommandType.Text
                        .Connection = cn
                        .Parameters.Add(New SqlParameter("@TxnNo", _TxnNo))
                        .Parameters.Add(New SqlParameter("@UserApproval", _UserInsert))
                        .Transaction = trans
                        .ExecuteNonQuery()
                    End With

                End If 'rowsTmp.Length > 0 Then

                ' //  Commit the transaction
                trans.Commit()
            Catch ex As Exception

                ' // Rollback all changes
                trans.Rollback()
                ExceptionManager.Publish(ex)

            Finally
                trans.Dispose()
                trans = Nothing

                If Not cn Is Nothing Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End If
                cn.Dispose()
                cn = Nothing
            End Try
        End Sub

        Private Sub ApprovalProduction(ByVal TxnTypeValue As String, ByVal Description As String)
            Dim cn As New SqlConnection(HisConfiguration.ConnectionString)

            Dim strSQL_InsertHistory As New Text.StringBuilder
            Dim strSQL_SelectProductionTmp As New Text.StringBuilder
            Dim strSQL_ProductionUpdateApproval As New Text.StringBuilder

            Dim trans As SqlTransaction

            Dim cmdSelectProductionTmp As SqlCommand = New SqlCommand

            With strSQL_ProductionUpdateApproval
                .Append("Update ProductionHd " & _
                        "Set IsApproval = 1, " & _
                        "UserApproval = @UserApproval, " & _
                        "ApprovalDate = getdate() " & _
                        "Where IsApproval = 0 and IsDeleted = 0 and ProductionNo = @TxnNo ")
            End With

            ' // di insert ke table history ...
            With strSQL_SelectProductionTmp
                .Append("SELECT " & _
                        "dt.ID AS TxnNo, " & _
                        "@inventoryTxnID AS inventoryTxnID, " & _
                        "hd.ProductionDate as TxnDate, " & _
                        "hd.WHID , " & _
                        "hd.UnitID , " & _
                        "dt.ItemSeqNo, " & _
                        "isnull(it.ItemName,'') as ItemName, " & _
                        "isnull(it.ItemLUnitID,'') AS ItemLUnitID, " & _
                        "isnull(it.ItemSUnitID,'') AS ItemSUnitID, " & _
                        "dt.ItemFactor, " & _
                        "0 AS QtySUIn, " & _
                        "dt.Qty AS QtySUOut, " & _
                        "isnull(it.SUnitCOGSLast,0) AS SUnitPrice, " & _
                        "left(@Description,500) AS [DESCRIPTION] " & _
                        "FROM ProductionHd hd " & _
                        "INNER JOIN ProductionDt dt ON dt.ProductionNo = hd.ProductionNo AND hd.IsApproval = 0 and hd.IsDeleted = 0 and dt.IsDeleted = 0 " & _
                        "INNER JOIN Item it ON it.ItemSeqNo = dt.ItemSeqNo " & _
                        "WHERE hd.ProductionNo = @txnNo " & _
                        "UNION ALL " & _
                        "SELECT " & _
                        "hd.ProductionNo AS TxnNo, " & _
                        "@inventoryTxnID AS inventoryTxnID, " & _
                        "hd.ProductionDate as TxnDate, " & _
                        "hd.WHID , " & _
                        "hd.UnitID , " & _
                        "pfh.ItemSeqNo, " & _
                        "isnull(it.ItemName,'') as ItemName, " & _
                        "isnull(it.ItemLUnitID,'') AS ItemLUnitID, " & _
                        "isnull(it.ItemSUnitID,'') AS ItemSUnitID, " & _
                        "1 AS ItemFactor, " & _
                        "hd.QtySUnit AS QtySUIn, " & _
                        "0 AS QtySUOut, " & _
                        "isnull(it.SUnitCOGSLast,0) AS SUnitPrice, " & _
                        "left(@Description,500) AS [DESCRIPTION] " & _
                        "FROM ProductionHd hd " & _
                        "INNER JOIN ProductionFormulaHd pfh ON pfh.FormulaID = hd.FormulaID " & _
                        "INNER JOIN Item it ON it.ItemSeqNo = pfh.ItemSeqNo " & _
                        "WHERE hd.IsApproval = 0 and hd.isDeleted = 0 and hd.ProductionNo = @txnNo ")
            End With

            ' // sql statement untuk insert ke table history ...
            With strSQL_InsertHistory
                .Append("Insert into ItemHistory" & _
                        "(ID, TxnNo, InventoryTxnID, TxnDate, WhID, UnitID, ItemSeqNo, " & _
                        "ItemLUnitID, ItemSUnitID, ItemFactor, QtySUnitBegin, QtySUnitIn, " & _
                        "QtySUnitOut, SUnitPrice, SUnitCOGS, SUnitCOGSPrev, UserInsert, " & _
                        "InsertDate, Description) " & _
                        "Values(@ID, @TxnNo, @InventoryTxnID, @TxnDate, @WhID, @UnitID, @ItemSeqNo, " & _
                        "@ItemLUnitID, @ItemSUnitID, @ItemFactor, @QtySUnitBegin, @QtySUnitIn, " & _
                        "@QtySUnitOut, @SUnitPrice, @SUnitCOGS, @SUnitCOGSPrev, @UserInsert, " & _
                        "Getdate(), left(@Description,500)) ")

            End With

            With cmdSelectProductionTmp
                .CommandText = strSQL_SelectProductionTmp.ToString
                .CommandType = CommandType.Text
                .Connection = cn
                .Parameters.Add(New SqlParameter("@TxnNo", _TxnNo))
                .Parameters.Add(New SqlParameter("@InventoryTxnID", TxnTypeValue.Trim))
                .Parameters.Add(New SqlParameter("@Description", Description))
            End With


            Dim tblDistributionTmp As DataTable = New DataTable("ProductionTmp")
            Dim adapterTrmTmp As SqlDataAdapter = New SqlDataAdapter(cmdSelectProductionTmp)

            ' // Open connection.
            cn.Open()

            trans = cn.BeginTransaction

            cmdSelectProductionTmp.Transaction = trans
            Try
                ' // loop untuk setiap record and insert ke table history ...!!
                adapterTrmTmp.Fill(tblDistributionTmp)
                Dim rowsTmp As DataRow() = tblDistributionTmp.Select
                Dim iRecCountTmp As Integer

                If rowsTmp.Length > 0 Then
                    iRecCountTmp = 1

                    While iRecCountTmp <= rowsTmp.Length
                        Dim drTmp As DataRow = rowsTmp(iRecCountTmp - 1)

                        _ID = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("ItemHistory", "ID", cn, trans)
                        Dim IDTxnNo As String = drTmp("TxnNo")
                        _InventoryTxnID = drTmp("inventoryTxnID")
                        _TxnDate = drTmp("TxnDate")
                        _WhID = drTmp("WHID")
                        _UnitID = drTmp("UnitID")
                        _ItemSeqNo = drTmp("ItemSeqNo")
                        Dim ItemName As String = drTmp("ItemName")
                        _ItemLUnitID = drTmp("ItemLUnitID")
                        _ItemSUnitID = drTmp("ItemSUnitID")
                        _ItemFactor = drTmp("ItemFactor")
                        _QtySUnitIn = drTmp("QtySUIn")
                        _QtySUnitOut = drTmp("QtySUOut")
                        _SUnitPrice = drTmp("SUnitPrice")
                        _Description = drTmp("Description")

                        Dim cmdItem As SqlCommand = New SqlCommand
                        With cmdItem
                            .CommandText = "SELECT * FROM Item WHERE ItemSeqNo = @ItemSeqNo "
                            .CommandType = CommandType.Text
                            .Connection = cn
                            .Transaction = trans
                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                        End With
                        Dim adpItem As SqlDataAdapter = New SqlDataAdapter(cmdItem)
                        Dim dtitem As DataTable = New DataTable
                        adpItem.Fill(dtitem)

                        _SUnitCOGSPrev = ProcessNull.GetDouble(dtitem.Rows(0)("SUnitCOGSLast"))

                        dtitem.Dispose()
                        dtitem = Nothing

                        Dim cmdQtySUnitBegin As SqlCommand = New SqlCommand
                        With cmdQtySUnitBegin
                            .CommandText = "SELECT * FROM ItemBalance WHERE ItemSeqNo = @ItemSeqNo AND WhID = @WhID AND UnitID = @UnitID "
                            .CommandType = CommandType.Text
                            .Connection = cn
                            .Transaction = trans
                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                            .Parameters.Add(New SqlParameter("@WhID", _WhID))
                            .Parameters.Add(New SqlParameter("@UnitID", _UnitID))
                        End With
                        Dim adpQtySUnitBegin As SqlDataAdapter = New SqlDataAdapter(cmdQtySUnitBegin)
                        Dim dtQtySUnitBegin As DataTable = New DataTable
                        adpQtySUnitBegin.Fill(dtQtySUnitBegin)

                        If dtQtySUnitBegin.Rows.Count > 0 Then
                            _QtySUnitBegin = ProcessNull.GetDouble(dtQtySUnitBegin.Rows(0)("QtySUnit"))
                        Else
                            _QtySUnitBegin = 0
                        End If

                        dtQtySUnitBegin.Dispose()
                        dtQtySUnitBegin = Nothing

                        If _QtySUnitBegin + (_QtySUnitIn * _ItemFactor) - (_QtySUnitOut * _ItemFactor) < 0 Then
                            Throw New Exception(ItemName.Trim + " Qty (" + Format((_QtySUnitOut * _ItemFactor), "#,##0.00") + ") must be equal or less than qty stock (" + Format(_QtySUnitBegin, "#,##0.00") + ")")
                            Exit Sub
                        End If

                        _SUnitCOGS = GetCOGSNowWithBeginTransaction(_SUnitCOGSPrev, _QtySUnitBegin, _SUnitPrice, (_QtySUnitOut * _ItemFactor), "-", cn, trans)


                        With New SqlCommand
                            .CommandText = strSQL_InsertHistory.ToString
                            .CommandType = CommandType.Text
                            .Transaction = trans
                            .Connection = cn

                            .Parameters.Add(New SqlParameter("@ID", _ID))
                            .Parameters.Add(New SqlParameter("@TxnNo", IDTxnNo))
                            .Parameters.Add(New SqlParameter("@InventoryTxnID", _InventoryTxnID))
                            .Parameters.Add(New SqlParameter("@TxnDate", _TxnDate))
                            .Parameters.Add(New SqlParameter("@WhID", _WhID))
                            .Parameters.Add(New SqlParameter("@UnitID", _UnitID))
                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                            .Parameters.Add(New SqlParameter("@ItemLUnitID", _ItemLUnitID))
                            .Parameters.Add(New SqlParameter("@ItemSUnitID", _ItemSUnitID))
                            .Parameters.Add(New SqlParameter("@ItemFactor", _ItemFactor))
                            .Parameters.Add(New SqlParameter("@QtySUnitBegin", _QtySUnitBegin))
                            .Parameters.Add(New SqlParameter("@QtySUnitIn", _QtySUnitIn))
                            .Parameters.Add(New SqlParameter("@QtySUnitOut", _QtySUnitOut))
                            .Parameters.Add(New SqlParameter("@SUnitPrice", _SUnitPrice))
                            .Parameters.Add(New SqlParameter("@SUnitCOGS", _SUnitCOGS))
                            .Parameters.Add(New SqlParameter("@SUnitCOGSPrev", _SUnitCOGSPrev))
                            .Parameters.Add(New SqlParameter("@UserInsert", _UserInsert))
                            .Parameters.Add(New SqlParameter("@Description", _Description))

                            .ExecuteNonQuery()
                        End With

                        iRecCountTmp += 1
                    End While 'While iRecCountTmp <= rowsTmp.Length

                    With New SqlCommand
                        .CommandText = strSQL_ProductionUpdateApproval.ToString
                        .CommandType = CommandType.Text
                        .Connection = cn
                        .Parameters.Add(New SqlParameter("@TxnNo", _TxnNo))
                        .Parameters.Add(New SqlParameter("@UserApproval", _UserInsert))
                        .Transaction = trans
                        .ExecuteNonQuery()
                    End With

                End If 'rowsTmp.Length > 0 Then

                ' //  Commit the transaction
                trans.Commit()
            Catch ex As Exception

                ' // Rollback all changes
                trans.Rollback()
                ExceptionManager.Publish(ex)

            Finally
                trans.Dispose()
                trans = Nothing

                If Not cn Is Nothing Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End If
                cn.Dispose()
                cn = Nothing
            End Try
        End Sub

        Private Sub ApprovalReceiving(ByVal TxnTypeValue As String, ByVal Description As String)
            Dim cn As New SqlConnection(HisConfiguration.ConnectionString)

            Dim strSQL_InsertHistory As New Text.StringBuilder
            Dim strSQL_SelectPurchaseUnitTmp As New Text.StringBuilder
            Dim strSQL_PurchaseUnitUpdateApproval As New Text.StringBuilder
            Dim strSQL_UpdateItem As New Text.StringBuilder
            Dim strSQL_UpdatePORelease As New Text.StringBuilder

            Dim trans As SqlTransaction

            Dim cmdSelectPurchaseUnitTmp As SqlCommand = New SqlCommand

            With strSQL_PurchaseUnitUpdateApproval
                .Append("Update PurchaseUnitHD " & _
                        "Set IsApproval = 1, " & _
                        "UserApproval = @UserApproval, " & _
                        "ApprovalDate = getdate() " & _
                        "Where IsApproval = 0 and IsDeleted = 0 and PUnitNO = @PUnitNO ")
            End With

            ' // sql statement; select transaksi penerimaan ke table tmp, data yang disini yang
            ' // di insert ke table history ...
            With strSQL_SelectPurchaseUnitTmp
                .Append("SELECT " & _
                        "dt.ID AS IDPU, " & _
                        "dt.IDPO, " & _
                        "'" + TxnTypeValue.Trim + "' AS inventoryTxnID, " & _
                        "hd.PUnitDate, " & _
                        "hd.WHID, " & _
                        "hd.UnitID, " & _
                        "dt.ItemSeqNo, " & _
                        "isnull(it.ItemName,'') as ItemName, " & _
                        "isnull(it.ItemLUnitID,'') AS ItemLUnitID, " & _
                        "isnull(it.ItemSUnitID,'') AS ItemSUnitID, " & _
                        "dt.ItemFactor, " & _
                        "dt.Qty AS QtySUIn, " & _
                        "0 AS QtySUOut, " & _
                        "isnull(dt.Price,0) AS SUnitPrice, " & _
                        "left(@Description,500) AS [DESCRIPTION] " & _
                        "FROM PurchaseUnitHD hd " & _
                        "INNER JOIN PurchaseUnitDt dt ON dt.PUnitNO = hd.PUnitNO AND hd.IsApproval = 0 and hd.IsDeleted = 0 and dt.IsDeleted = 0 " & _
                        "INNER JOIN Item it ON it.ItemSeqNo = dt.ItemSeqNo " & _
                        "WHERE hd.PUnitNO = @PUnitNO ")
            End With

            ' // sql statement untuk insert ke table history ...
            With strSQL_InsertHistory
                .Append("Insert into ItemHistory" & _
                        "(ID, TxnNo, InventoryTxnID, TxnDate, WhID, UnitID, ItemSeqNo, " & _
                        "ItemLUnitID, ItemSUnitID, ItemFactor, QtySUnitBegin, QtySUnitIn, " & _
                        "QtySUnitOut, SUnitPrice, SUnitCOGS, SUnitCOGSPrev, UserInsert, " & _
                        "InsertDate, Description) " & _
                        "Values(@ID, @TxnNo, @InventoryTxnID, @TxnDate, @WhID, @UnitID, @ItemSeqNo, " & _
                        "@ItemLUnitID, @ItemSUnitID, @ItemFactor, @QtySUnitBegin, @QtySUnitIn, " & _
                        "@QtySUnitOut, @SUnitPrice, @SUnitCOGS, @SUnitCOGSPrev, @UserInsert, " & _
                        "Getdate(), left(@Description,500)) ")
            End With

            With strSQL_UpdateItem
                .Append("Update Item " & _
                        "Set SUnitCOGSLast = @SUnitCOGS " & _
                        "Where ItemSeqNo = @ItemSeqNo ")
            End With

            With strSQL_UpdatePORelease
                .Append("UPDATE PurchaseOrderDt " & _
                        "SET QtyReceived = (QtyReceived + (@QtySUIn * @ItemFactor)), " & _
                         "IsRelease = (CASE WHEN (QtyReceived + (@QtySUIn * @ItemFactor)) >= (Qty * ItemFactor) THEN 1 ELSE 0 END), " & _
                         "UserRelease = (CASE WHEN (QtyReceived + (@QtySUIn * @ItemFactor)) >= (Qty * ItemFactor) THEN @UserInsert ELSE '' END), " & _
                         "ReleaseDate = (CASE WHEN (QtyReceived + (@QtySUIn * @ItemFactor)) >= (Qty * ItemFactor) THEN Getdate() ELSE '' END) " & _
                        "WHERE ID = @IDPO ")
            End With


            With cmdSelectPurchaseUnitTmp
                .CommandText = strSQL_SelectPurchaseUnitTmp.ToString
                .CommandType = CommandType.Text
                .Connection = cn
                .Parameters.Add(New SqlParameter("@PUnitNO", _TxnNo))
                .Parameters.Add(New SqlParameter("@Description", Description))
            End With


            Dim tblPurchaseUnitTmp As DataTable = New DataTable("PurchaseUnitTmp")
            Dim adapterTrmTmp As SqlDataAdapter = New SqlDataAdapter(cmdSelectPurchaseUnitTmp)

            ' // Open connection.
            cn.Open()

            trans = cn.BeginTransaction

            cmdSelectPurchaseUnitTmp.Transaction = trans
            Try
                ' // loop untuk setiap record and insert ke table history ...!!
                adapterTrmTmp.Fill(tblPurchaseUnitTmp)
                Dim rowsTmp As DataRow() = tblPurchaseUnitTmp.Select
                Dim iRecCountTmp As Integer

                If rowsTmp.Length > 0 Then
                    iRecCountTmp = 1

                    While iRecCountTmp <= rowsTmp.Length
                        Dim drTmp As DataRow = rowsTmp(iRecCountTmp - 1)

                        _ID = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("ItemHistory", "ID", cn, trans)
                        Dim IDPU As String = drTmp("IDPU")
                        Dim IDPO As String = drTmp("IDPO")
                        _InventoryTxnID = drTmp("inventoryTxnID")
                        _TxnDate = drTmp("PUnitDate")
                        _WhID = drTmp("WHID")
                        _UnitID = drTmp("UnitID")
                        _ItemSeqNo = drTmp("ItemSeqNo")
                        Dim ItemName As String = drTmp("ItemName")
                        _ItemLUnitID = drTmp("ItemLUnitID")
                        _ItemSUnitID = drTmp("ItemSUnitID")
                        _ItemFactor = drTmp("ItemFactor")
                        _QtySUnitIn = drTmp("QtySUIn")
                        _QtySUnitOut = drTmp("QtySUOut")
                        _SUnitPrice = drTmp("SUnitPrice")
                        _Description = drTmp("Description")

                        Dim cmdItem As SqlCommand = New SqlCommand
                        With cmdItem
                            .CommandText = "SELECT * FROM Item WHERE ItemSeqNo = @ItemSeqNo "
                            .CommandType = CommandType.Text
                            .Connection = cn
                            .Transaction = trans
                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                        End With
                        Dim adpItem As SqlDataAdapter = New SqlDataAdapter(cmdItem)
                        Dim dtitem As DataTable = New DataTable
                        adpItem.Fill(dtitem)

                        _SUnitCOGSPrev = ProcessNull.GetDouble(dtitem.Rows(0)("SUnitCOGSLast"))

                        dtitem.Dispose()
                        dtitem = Nothing

                        Dim cmdQtySUnitBegin As SqlCommand = New SqlCommand
                        With cmdQtySUnitBegin
                            .CommandText = "SELECT * FROM ItemBalance WHERE ItemSeqNo = @ItemSeqNo AND WhID = @WhID AND UnitID = @UnitID "
                            .CommandType = CommandType.Text
                            .Connection = cn
                            .Transaction = trans
                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                            .Parameters.Add(New SqlParameter("@WhID", _WhID))
                            .Parameters.Add(New SqlParameter("@UnitID", _UnitID))
                        End With
                        Dim adpQtySUnitBegin As SqlDataAdapter = New SqlDataAdapter(cmdQtySUnitBegin)
                        Dim dtQtySUnitBegin As DataTable = New DataTable
                        adpQtySUnitBegin.Fill(dtQtySUnitBegin)

                        If dtQtySUnitBegin.Rows.Count > 0 Then
                            _QtySUnitBegin = ProcessNull.GetDouble(dtQtySUnitBegin.Rows(0)("QtySUnit"))
                        Else
                            _QtySUnitBegin = 0
                        End If

                        dtQtySUnitBegin.Dispose()
                        dtQtySUnitBegin = Nothing

                        _SUnitCOGS = GetCOGSNowWithBeginTransaction(_SUnitCOGSPrev, _QtySUnitBegin, _SUnitPrice, (_QtySUnitIn * _ItemFactor), "+", cn, trans)


                        With New SqlCommand
                            .CommandText = strSQL_InsertHistory.ToString
                            .CommandType = CommandType.Text
                            .Transaction = trans
                            .Connection = cn

                            .Parameters.Add(New SqlParameter("@ID", _ID))
                            .Parameters.Add(New SqlParameter("@TxnNo", IDPU))
                            .Parameters.Add(New SqlParameter("@InventoryTxnID", _InventoryTxnID))
                            .Parameters.Add(New SqlParameter("@TxnDate", _TxnDate))
                            .Parameters.Add(New SqlParameter("@WhID", _WhID))
                            .Parameters.Add(New SqlParameter("@UnitID", _UnitID))
                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                            .Parameters.Add(New SqlParameter("@ItemLUnitID", _ItemLUnitID))
                            .Parameters.Add(New SqlParameter("@ItemSUnitID", _ItemSUnitID))
                            .Parameters.Add(New SqlParameter("@ItemFactor", _ItemFactor))
                            .Parameters.Add(New SqlParameter("@QtySUnitBegin", _QtySUnitBegin))
                            .Parameters.Add(New SqlParameter("@QtySUnitIn", _QtySUnitIn))
                            .Parameters.Add(New SqlParameter("@QtySUnitOut", _QtySUnitOut))
                            .Parameters.Add(New SqlParameter("@SUnitPrice", _SUnitPrice))
                            .Parameters.Add(New SqlParameter("@SUnitCOGS", _SUnitCOGS))
                            .Parameters.Add(New SqlParameter("@SUnitCOGSPrev", _SUnitCOGSPrev))
                            .Parameters.Add(New SqlParameter("@UserInsert", _UserInsert))
                            .Parameters.Add(New SqlParameter("@Description", _Description))

                            .ExecuteNonQuery()
                        End With

                        With New SqlCommand
                            .CommandText = strSQL_UpdateItem.ToString
                            .CommandType = CommandType.Text
                            .Transaction = trans
                            .Connection = cn

                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                            .Parameters.Add(New SqlParameter("@SUnitCOGS", _SUnitCOGS))

                            .ExecuteNonQuery()
                        End With

                        With New SqlCommand
                            .CommandText = strSQL_UpdatePORelease.ToString
                            .CommandType = CommandType.Text
                            .Transaction = trans
                            .Connection = cn

                            .Parameters.Add(New SqlParameter("@IDPO", IDPO))
                            .Parameters.Add(New SqlParameter("@QtySUIn", _QtySUnitIn))
                            .Parameters.Add(New SqlParameter("@ItemFactor", _ItemFactor))
                            .Parameters.Add(New SqlParameter("@UserInsert", _UserInsert))

                            .ExecuteNonQuery()
                        End With

                        iRecCountTmp += 1
                    End While 'While iRecCountTmp <= rowsTmp.Length

                    With New SqlCommand
                        .CommandText = strSQL_PurchaseUnitUpdateApproval.ToString
                        .CommandType = CommandType.Text
                        .Connection = cn
                        .Parameters.Add(New SqlParameter("@PUnitNO", _TxnNo))
                        .Parameters.Add(New SqlParameter("@UserApproval", _UserInsert))
                        .Transaction = trans
                        .ExecuteNonQuery()
                    End With

                End If 'rowsTmp.Length > 0 Then

                ' //  Commit the transaction
                trans.Commit()
            Catch ex As Exception

                ' // Rollback all changes
                trans.Rollback()
                ExceptionManager.Publish(ex)

            Finally
                trans.Dispose()
                trans = Nothing

                If Not cn Is Nothing Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End If
                cn.Dispose()
                cn = Nothing
            End Try
        End Sub

        Private Sub ApprovalPurchaseReturn(ByVal TxnTypeValue As String, ByVal Description As String)
            Dim cn As New SqlConnection(HisConfiguration.ConnectionString)

            Dim strSQL_InsertHistory As New Text.StringBuilder
            Dim strSQL_SelectPurchaseReturnTmp As New Text.StringBuilder
            Dim strSQL_PurchaseReturnUpdateApproval As New Text.StringBuilder
            Dim strSQL_UpdateItem As New Text.StringBuilder

            Dim trans As SqlTransaction

            Dim cmdSelectPurchaseReturnTmp As SqlCommand = New SqlCommand

            With strSQL_PurchaseReturnUpdateApproval
                .Append("Update PurchaseReturnHd " & _
                        "Set IsApproval = 1, " & _
                        "UserApproval = @UserApproval, " & _
                        "ApprovalDate = getdate() " & _
                        "Where IsApproval = 0 and IsDeleted = 0 and PReturnNO = @PReturnNO ")
            End With

            ' // di insert ke table history ...
            With strSQL_SelectPurchaseReturnTmp
                .Append("SELECT " & _
                        "dt.ID AS IDPR, " & _
                        "'" + TxnTypeValue.Trim + "' AS inventoryTxnID, " & _
                        "hd.PReturnDate, " & _
                        "hd.WHID, " & _
                        "hd.UnitID, " & _
                        "dt.ItemSeqNo, " & _
                        "isnull(it.ItemName,'') as ItemName, " & _
                        "isnull(it.ItemLUnitID,'') AS ItemLUnitID, " & _
                        "isnull(it.ItemSUnitID,'') AS ItemSUnitID, " & _
                        "dt.ItemFactor, " & _
                        "0 AS QtySUIn, " & _
                        "dt.Qty AS QtySUOut, " & _
                        "isnull(dt.Price,0) AS SUnitPrice, " & _
                        "left(@Description,500) AS [DESCRIPTION] " & _
                        "FROM PurchaseReturnHd hd " & _
                        "INNER JOIN PurchaseReturndt dt ON dt.PReturnNO = hd.PReturnNO AND hd.IsApproval = 0 and hd.IsDeleted = 0 and dt.IsDeleted = 0 " & _
                        "INNER JOIN Item it ON it.ItemSeqNo = dt.ItemSeqNo " & _
                        "WHERE hd.PReturnNO = @PReturnNO ")
            End With

            ' // sql statement untuk insert ke table history ...
            With strSQL_InsertHistory
                .Append("Insert into ItemHistory" & _
                        "(ID, TxnNo, InventoryTxnID, TxnDate, WhID, UnitID, ItemSeqNo, " & _
                        "ItemLUnitID, ItemSUnitID, ItemFactor, QtySUnitBegin, QtySUnitIn, " & _
                        "QtySUnitOut, SUnitPrice, SUnitCOGS, SUnitCOGSPrev, UserInsert, " & _
                        "InsertDate, Description) " & _
                        "Values(@ID, @TxnNo, @InventoryTxnID, @TxnDate, @WhID, @UnitID, @ItemSeqNo, " & _
                        "@ItemLUnitID, @ItemSUnitID, @ItemFactor, @QtySUnitBegin, @QtySUnitIn, " & _
                        "@QtySUnitOut, @SUnitPrice, @SUnitCOGS, @SUnitCOGSPrev, @UserInsert, " & _
                        "Getdate(), left(@Description,500)) ")
            End With

            With strSQL_UpdateItem
                .Append("Update Item " & _
                        "Set SUnitCOGSLast = @SUnitCOGS " & _
                        "Where ItemSeqNo = @ItemSeqNo ")
            End With

            With cmdSelectPurchaseReturnTmp
                .CommandText = strSQL_SelectPurchaseReturnTmp.ToString
                .CommandType = CommandType.Text
                .Connection = cn
                .Parameters.Add(New SqlParameter("@PReturnNO", _TxnNo))
                .Parameters.Add(New SqlParameter("@Description", Description))
            End With


            Dim tblPurchaseReturnTmp As DataTable = New DataTable("PurchaseReturnTmp")
            Dim adapterTrmTmp As SqlDataAdapter = New SqlDataAdapter(cmdSelectPurchaseReturnTmp)

            ' // Open connection.
            cn.Open()

            trans = cn.BeginTransaction

            cmdSelectPurchaseReturnTmp.Transaction = trans
            Try
                ' // loop untuk setiap record and insert ke table history ...!!
                adapterTrmTmp.Fill(tblPurchaseReturnTmp)
                Dim rowsTmp As DataRow() = tblPurchaseReturnTmp.Select
                Dim iRecCountTmp As Integer

                If rowsTmp.Length > 0 Then
                    iRecCountTmp = 1

                    While iRecCountTmp <= rowsTmp.Length
                        Dim drTmp As DataRow = rowsTmp(iRecCountTmp - 1)

                        _ID = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("ItemHistory", "ID", cn, trans)
                        Dim IDPR As String = drTmp("IDPR")
                        _InventoryTxnID = drTmp("inventoryTxnID")
                        _TxnDate = drTmp("PReturnDate")
                        _WhID = drTmp("WHID")
                        _UnitID = drTmp("UnitID")
                        _ItemSeqNo = drTmp("ItemSeqNo")
                        Dim ItemName As String = drTmp("ItemName")
                        _ItemLUnitID = drTmp("ItemLUnitID")
                        _ItemSUnitID = (drTmp("ItemSUnitID"))
                        _ItemFactor = drTmp("ItemFactor")
                        _QtySUnitIn = drTmp("QtySUIn")
                        _QtySUnitOut = drTmp("QtySUOut")
                        _SUnitPrice = drTmp("SUnitPrice")
                        _Description = drTmp("Description")

                        Dim cmdItem As SqlCommand = New SqlCommand
                        With cmdItem
                            .CommandText = "SELECT * FROM Item WHERE ItemSeqNo = @ItemSeqNo "
                            .CommandType = CommandType.Text
                            .Connection = cn
                            .Transaction = trans
                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                        End With
                        Dim adpItem As SqlDataAdapter = New SqlDataAdapter(cmdItem)
                        Dim dtitem As DataTable = New DataTable
                        adpItem.Fill(dtitem)

                        _SUnitCOGSPrev = ProcessNull.GetDouble(dtitem.Rows(0)("SUnitCOGSLast"))

                        dtitem.Dispose()
                        dtitem = Nothing

                        Dim cmdQtySUnitBegin As SqlCommand = New SqlCommand
                        With cmdQtySUnitBegin
                            .CommandText = "SELECT * FROM ItemBalance WHERE ItemSeqNo = @ItemSeqNo AND WhID = @WhID AND UnitID = @UnitID "
                            .CommandType = CommandType.Text
                            .Connection = cn
                            .Transaction = trans
                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                            .Parameters.Add(New SqlParameter("@WhID", _WhID))
                            .Parameters.Add(New SqlParameter("@UnitID", _UnitID))
                        End With
                        Dim adpQtySUnitBegin As SqlDataAdapter = New SqlDataAdapter(cmdQtySUnitBegin)
                        Dim dtQtySUnitBegin As DataTable = New DataTable
                        adpQtySUnitBegin.Fill(dtQtySUnitBegin)

                        If dtQtySUnitBegin.Rows.Count > 0 Then
                            _QtySUnitBegin = ProcessNull.GetDouble(dtQtySUnitBegin.Rows(0)("QtySUnit"))
                        Else
                            _QtySUnitBegin = 0
                        End If

                        dtQtySUnitBegin.Dispose()
                        dtQtySUnitBegin = Nothing

                        If _QtySUnitBegin + (_QtySUnitIn * _ItemFactor) - (_QtySUnitOut * _ItemFactor) < 0 Then
                            Throw New Exception(ItemName.Trim + " Qty (" + Format((_QtySUnitOut * _ItemFactor), "#,##0.00") + ") must be equal or less than qty stock (" + Format(_QtySUnitBegin, "#,##0.00") + ")")
                            Exit Sub
                        End If

                        _SUnitCOGS = GetCOGSNowWithBeginTransaction(_SUnitCOGSPrev, _QtySUnitBegin, _SUnitPrice, (_QtySUnitOut * _ItemFactor), "-", cn, trans)


                        With New SqlCommand
                            .CommandText = strSQL_InsertHistory.ToString
                            .CommandType = CommandType.Text
                            .Transaction = trans
                            .Connection = cn

                            .Parameters.Add(New SqlParameter("@ID", _ID))
                            .Parameters.Add(New SqlParameter("@TxnNo", IDPR))
                            .Parameters.Add(New SqlParameter("@InventoryTxnID", _InventoryTxnID))
                            .Parameters.Add(New SqlParameter("@TxnDate", _TxnDate))
                            .Parameters.Add(New SqlParameter("@WhID", _WhID))
                            .Parameters.Add(New SqlParameter("@UnitID", _UnitID))
                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                            .Parameters.Add(New SqlParameter("@ItemLUnitID", _ItemLUnitID))
                            .Parameters.Add(New SqlParameter("@ItemSUnitID", _ItemSUnitID))
                            .Parameters.Add(New SqlParameter("@ItemFactor", _ItemFactor))
                            .Parameters.Add(New SqlParameter("@QtySUnitBegin", _QtySUnitBegin))
                            .Parameters.Add(New SqlParameter("@QtySUnitIn", _QtySUnitIn))
                            .Parameters.Add(New SqlParameter("@QtySUnitOut", _QtySUnitOut))
                            .Parameters.Add(New SqlParameter("@SUnitPrice", _SUnitPrice))
                            .Parameters.Add(New SqlParameter("@SUnitCOGS", _SUnitCOGS))
                            .Parameters.Add(New SqlParameter("@SUnitCOGSPrev", _SUnitCOGSPrev))
                            .Parameters.Add(New SqlParameter("@UserInsert", _UserInsert))
                            .Parameters.Add(New SqlParameter("@Description", _Description))

                            .ExecuteNonQuery()
                        End With

                        With New SqlCommand
                            .CommandText = strSQL_UpdateItem.ToString
                            .CommandType = CommandType.Text
                            .Transaction = trans
                            .Connection = cn

                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                            .Parameters.Add(New SqlParameter("@SUnitCOGS", _SUnitCOGS))

                            .ExecuteNonQuery()
                        End With

                        iRecCountTmp += 1
                    End While 'While iRecCountTmp <= rowsTmp.Length

                    With New SqlCommand
                        .CommandText = strSQL_PurchaseReturnUpdateApproval.ToString
                        .CommandType = CommandType.Text
                        .Connection = cn
                        .Parameters.Add(New SqlParameter("@PReturnNO", _TxnNo))
                        .Parameters.Add(New SqlParameter("@UserApproval", _UserInsert))
                        .Transaction = trans
                        .ExecuteNonQuery()
                    End With

                End If 'rowsTmp.Length > 0 Then

                ' //  Commit the transaction
                trans.Commit()
            Catch ex As Exception

                ' // Rollback all changes
                trans.Rollback()
                ExceptionManager.Publish(ex)

            Finally
                trans.Dispose()
                trans = Nothing

                If Not cn Is Nothing Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End If
                cn.Dispose()
                cn = Nothing
            End Try
        End Sub

        Private Sub ApprovalSalesUnit(ByVal TxnTypeValue As String, ByVal Description As String)
            Dim cn As New SqlConnection(HisConfiguration.ConnectionString)

            Dim strSQL_InsertHistory As New Text.StringBuilder
            Dim strSQL_InsertHistoryBO As New Text.StringBuilder
            Dim strSQL_SelectSalesUnitTmp As New Text.StringBuilder
            Dim strSQL_SalesUnitUpdateApproval As New Text.StringBuilder
            Dim strSQL_UpdateItem As New Text.StringBuilder
            Dim strSQL_UpdateDORelease As New Text.StringBuilder

            Dim trans As SqlTransaction

            Dim cmdSelectSalesUnitTmp As SqlCommand = New SqlCommand

            With strSQL_SalesUnitUpdateApproval
                .Append("Update SalesUnitHD " & _
                        "Set IsApproval = 1, " & _
                        "UserApproval = @UserApproval, " & _
                        "ApprovalDate = getdate() " & _
                        "Where IsApproval = 0 and IsDeleted = 0 and STxnNo = @TxnNo ")
            End With

            ' // sql statement; select transaksi penerimaan ke table tmp, data yang disini yang
            ' // di insert ke table history ...
            With strSQL_SelectSalesUnitTmp
                .Append("SELECT " & _
                        "dt.ID AS IDSU, " & _
                        "dt.IDDO, " & _
                        "'" + TxnTypeValue.Trim + "' AS inventoryTxnID, " & _
                        "hd.STxnDate, " & _
                        "hd.WHID, " & _
                        "hd.UnitID, " & _
                        "dt.ItemSeqNo, " & _
                        "isnull(it.ItemName,'') as ItemName, " & _
                        "isnull(it.ItemLUnitID,'') AS ItemLUnitID, " & _
                        "isnull(it.ItemSUnitID,'') AS ItemSUnitID, " & _
                        "dt.ItemFactor, " & _
                        "QtySUIn = CASE WHEN(dt.Qty < 0) THEN dt.Qty ELSE 0 END, " & _
                        "QtySUOut = CASE WHEN(dt.Qty >= 0) THEN dt.Qty ELSE 0 END, " & _
                        "isnull(dt.Price,0) AS SUnitPrice, " & _
                        "left(@Description,500) AS [DESCRIPTION] " & _
                        "FROM SalesUnitHd hd " & _
                        "INNER JOIN SalesUnitdt dt ON dt.STxnNo = hd.STxnNo AND hd.IsApproval = 0 and hd.IsDeleted = 0 and dt.IsDeleted = 0 " & _
                        "INNER JOIN Item it ON it.ItemSeqNo = dt.ItemSeqNo " & _
                        "WHERE hd.STxnNo = @TxnNo ")
            End With

            ' // sql statement untuk insert ke table history ...
            With strSQL_InsertHistory
                .Append("Insert into ItemHistory" & _
                        "(ID, TxnNo, InventoryTxnID, TxnDate, WhID, UnitID, ItemSeqNo, " & _
                        "ItemLUnitID, ItemSUnitID, ItemFactor, QtySUnitBegin, QtySUnitIn, " & _
                        "QtySUnitOut, SUnitPrice, SUnitCOGS, SUnitCOGSPrev, UserInsert, " & _
                        "InsertDate, Description) " & _
                        "Values(@ID, @TxnNo, @InventoryTxnID, @TxnDate, @WhID, @UnitID, @ItemSeqNo, " & _
                        "@ItemLUnitID, @ItemSUnitID, @ItemFactor, @QtySUnitBegin, @QtySUnitIn, " & _
                        "@QtySUnitOut, @SUnitPrice, @SUnitCOGS, @SUnitCOGSPrev, @UserInsert, " & _
                        "Getdate(), left(@Description,500)) ")
            End With

            Dim IsUseFOServer As Boolean = False
            Dim BOServerName As String = String.Empty
            Dim BODatabaseName As String = String.Empty
            Dim cs As New CommonSetting
            With cs
                .GroupID = "FOserver"
                .DetailID = "IsDiffer"
                If .SelecOneByGroupIDByDetailID.Rows.Count > 0 Then
                    IsUseFOServer = CBool(.DetailDesc.Trim)
                Else
                    IsUseFOServer = False
                End If

                If IsUseFOServer Then
                    .GroupID = "BOserver"
                    .DetailID = "ServerName"
                    If .SelecOneByGroupIDByDetailID.Rows.Count > 0 Then
                        BOServerName = .DetailDesc.Trim
                    Else
                        BOServerName = String.Empty
                    End If

                    .GroupID = "BOserver"
                    .DetailID = "DBName"
                    If .SelecOneByGroupIDByDetailID.Rows.Count > 0 Then
                        BODatabaseName = .DetailDesc.Trim
                    Else
                        BODatabaseName = String.Empty
                    End If
                End If
            End With
            cs.Dispose()
            cs = Nothing

            If IsUseFOServer Then
                With strSQL_InsertHistoryBO
                    .Append("Insert into " & BOServerName.Trim & BODatabaseName.Trim & ".dbo.ItemHistory" & _
                            "(ID, TxnNo, InventoryTxnID, TxnDate, WhID, UnitID, ItemSeqNo, " & _
                            "ItemLUnitID, ItemSUnitID, ItemFactor, QtySUnitBegin, QtySUnitIn, " & _
                            "QtySUnitOut, SUnitPrice, SUnitCOGS, SUnitCOGSPrev, UserInsert, " & _
                            "InsertDate, Description) " & _
                            "Values(@ID, @TxnNo, @InventoryTxnID, @TxnDate, @WhID, @UnitID, @ItemSeqNo, " & _
                            "@ItemLUnitID, @ItemSUnitID, @ItemFactor, @QtySUnitBegin, @QtySUnitIn, " & _
                            "@QtySUnitOut, @SUnitPrice, @SUnitCOGS, @SUnitCOGSPrev, @UserInsert, " & _
                            "Getdate(), left(@Description,500)) ")
                End With
            End If

            With strSQL_UpdateItem
                .Append("Update Item " & _
                        "Set SUnitCOGSLast = @SUnitCOGS " & _
                        "Where ItemSeqNo = @ItemSeqNo ")
            End With

            With strSQL_UpdateDORelease
                .Append("UPDATE DeliveryOrderDt " & _
                        "SET QtySale = (QtySale + (@QtySUOut * @ItemFactor)), " & _
                         "IsRelease = (CASE WHEN (QtySale + (@QtySUOut * @ItemFactor)) >= (Qty * ItemFactor) THEN 1 ELSE 0 END), " & _
                         "UserRelease = (CASE WHEN (QtySale + (@QtySUOut * @ItemFactor)) >= (Qty * ItemFactor) THEN @UserInsert ELSE '' END), " & _
                         "ReleaseDate = (CASE WHEN (QtySale + (@QtySUOut * @ItemFactor)) >= (Qty * ItemFactor) THEN Getdate() ELSE '' END) " & _
                        "WHERE ID = @IDDO ")
            End With


            With cmdSelectSalesUnitTmp
                .CommandText = strSQL_SelectSalesUnitTmp.ToString
                .CommandType = CommandType.Text
                .Connection = cn
                .Parameters.Add(New SqlParameter("@TxnNo", _TxnNo))
                .Parameters.Add(New SqlParameter("@Description", Description))
            End With


            Dim tblSalesUnitTmp As DataTable = New DataTable("SalesUnitTmp")
            Dim adapterTrmTmp As SqlDataAdapter = New SqlDataAdapter(cmdSelectSalesUnitTmp)

            ' // Open connection.
            cn.Open()

            trans = cn.BeginTransaction

            cmdSelectSalesUnitTmp.Transaction = trans
            Try
                ' // loop untuk setiap record and insert ke table history ...!!
                adapterTrmTmp.Fill(tblSalesUnitTmp)
                Dim rowsTmp As DataRow() = tblSalesUnitTmp.Select
                Dim iRecCountTmp As Integer

                If rowsTmp.Length > 0 Then
                    iRecCountTmp = 1

                    While iRecCountTmp <= rowsTmp.Length
                        Dim drTmp As DataRow = rowsTmp(iRecCountTmp - 1)

                        _ID = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("ItemHistory", "ID", cn, trans)
                        Dim IDSU As String = drTmp("IDSU")
                        Dim IDDO As String = drTmp("IDDO")
                        _InventoryTxnID = drTmp("inventoryTxnID")
                        _TxnDate = drTmp("STxnDate")
                        _WhID = drTmp("WHID")
                        _UnitID = drTmp("UnitID")
                        _ItemSeqNo = drTmp("ItemSeqNo")
                        Dim ItemName As String = drTmp("ItemName")
                        _ItemLUnitID = drTmp("ItemLUnitID")
                        _ItemSUnitID = drTmp("ItemSUnitID")
                        _ItemFactor = drTmp("ItemFactor")
                        _QtySUnitIn = drTmp("QtySUIn")
                        _QtySUnitOut = drTmp("QtySUOut")
                        _SUnitPrice = drTmp("SUnitPrice")
                        _Description = drTmp("Description")

                        Dim cmdItem As SqlCommand = New SqlCommand
                        With cmdItem
                            .CommandText = "SELECT * FROM Item WHERE ItemSeqNo = @ItemSeqNo "
                            .CommandType = CommandType.Text
                            .Connection = cn
                            .Transaction = trans
                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                        End With
                        Dim adpItem As SqlDataAdapter = New SqlDataAdapter(cmdItem)
                        Dim dtitem As DataTable = New DataTable
                        adpItem.Fill(dtitem)

                        _SUnitCOGSPrev = ProcessNull.GetDouble(dtitem.Rows(0)("SUnitCOGSLast"))

                        dtitem.Dispose()
                        dtitem = Nothing

                        Dim cmdQtySUnitBegin As SqlCommand = New SqlCommand
                        With cmdQtySUnitBegin
                            .CommandText = "SELECT * FROM ItemBalance WHERE ItemSeqNo = @ItemSeqNo AND WhID = @WhID AND UnitID = @UnitID "
                            .CommandType = CommandType.Text
                            .Connection = cn
                            .Transaction = trans
                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                            .Parameters.Add(New SqlParameter("@WhID", _WhID))
                            .Parameters.Add(New SqlParameter("@UnitID", _UnitID))
                        End With
                        Dim adpQtySUnitBegin As SqlDataAdapter = New SqlDataAdapter(cmdQtySUnitBegin)
                        Dim dtQtySUnitBegin As DataTable = New DataTable
                        adpQtySUnitBegin.Fill(dtQtySUnitBegin)

                        If dtQtySUnitBegin.Rows.Count > 0 Then
                            _QtySUnitBegin = ProcessNull.GetDouble(dtQtySUnitBegin.Rows(0)("QtySUnit"))
                        Else
                            _QtySUnitBegin = 0
                        End If

                        dtQtySUnitBegin.Dispose()
                        dtQtySUnitBegin = Nothing

                        _SUnitCOGS = GetCOGSNowWithBeginTransaction(_SUnitCOGSPrev, _QtySUnitBegin, _SUnitPrice, (_QtySUnitOut * _ItemFactor), "-", cn, trans)


                        With New SqlCommand
                            .CommandText = strSQL_InsertHistory.ToString
                            .CommandType = CommandType.Text
                            .Transaction = trans
                            .Connection = cn

                            .Parameters.Add(New SqlParameter("@ID", _ID))
                            .Parameters.Add(New SqlParameter("@TxnNo", IDSU))
                            .Parameters.Add(New SqlParameter("@InventoryTxnID", _InventoryTxnID))
                            .Parameters.Add(New SqlParameter("@TxnDate", _TxnDate))
                            .Parameters.Add(New SqlParameter("@WhID", _WhID))
                            .Parameters.Add(New SqlParameter("@UnitID", _UnitID))
                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                            .Parameters.Add(New SqlParameter("@ItemLUnitID", _ItemLUnitID))
                            .Parameters.Add(New SqlParameter("@ItemSUnitID", _ItemSUnitID))
                            .Parameters.Add(New SqlParameter("@ItemFactor", _ItemFactor))
                            .Parameters.Add(New SqlParameter("@QtySUnitBegin", _QtySUnitBegin))
                            .Parameters.Add(New SqlParameter("@QtySUnitIn", _QtySUnitIn))
                            .Parameters.Add(New SqlParameter("@QtySUnitOut", _QtySUnitOut))
                            .Parameters.Add(New SqlParameter("@SUnitPrice", _SUnitPrice))
                            .Parameters.Add(New SqlParameter("@SUnitCOGS", _SUnitCOGS))
                            .Parameters.Add(New SqlParameter("@SUnitCOGSPrev", _SUnitCOGSPrev))
                            .Parameters.Add(New SqlParameter("@UserInsert", _UserInsert))
                            .Parameters.Add(New SqlParameter("@Description", _Description))

                            .ExecuteNonQuery()
                        End With

                        If IsUseFOServer Then
                            With New SqlCommand
                                .CommandText = strSQL_InsertHistoryBO.ToString
                                .CommandType = CommandType.Text
                                .Transaction = trans
                                .Connection = cn

                                .Parameters.Add(New SqlParameter("@ID", _ID))
                                .Parameters.Add(New SqlParameter("@TxnNo", IDSU))
                                .Parameters.Add(New SqlParameter("@InventoryTxnID", _InventoryTxnID))
                                .Parameters.Add(New SqlParameter("@TxnDate", _TxnDate))
                                .Parameters.Add(New SqlParameter("@WhID", _WhID))
                                .Parameters.Add(New SqlParameter("@UnitID", _UnitID))
                                .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                                .Parameters.Add(New SqlParameter("@ItemLUnitID", _ItemLUnitID))
                                .Parameters.Add(New SqlParameter("@ItemSUnitID", _ItemSUnitID))
                                .Parameters.Add(New SqlParameter("@ItemFactor", _ItemFactor))
                                .Parameters.Add(New SqlParameter("@QtySUnitBegin", _QtySUnitBegin))
                                .Parameters.Add(New SqlParameter("@QtySUnitIn", _QtySUnitIn))
                                .Parameters.Add(New SqlParameter("@QtySUnitOut", _QtySUnitOut))
                                .Parameters.Add(New SqlParameter("@SUnitPrice", _SUnitPrice))
                                .Parameters.Add(New SqlParameter("@SUnitCOGS", _SUnitCOGS))
                                .Parameters.Add(New SqlParameter("@SUnitCOGSPrev", _SUnitCOGSPrev))
                                .Parameters.Add(New SqlParameter("@UserInsert", _UserInsert))
                                .Parameters.Add(New SqlParameter("@Description", _Description))

                                .ExecuteNonQuery()
                            End With
                        End If

                        With New SqlCommand
                            .CommandText = strSQL_UpdateItem.ToString
                            .CommandType = CommandType.Text
                            .Transaction = trans
                            .Connection = cn

                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                            .Parameters.Add(New SqlParameter("@SUnitCOGS", _SUnitCOGS))

                            .ExecuteNonQuery()
                        End With

                        With New SqlCommand
                            .CommandText = strSQL_UpdateDORelease.ToString
                            .CommandType = CommandType.Text
                            .Transaction = trans
                            .Connection = cn

                            .Parameters.Add(New SqlParameter("@IDDO", IDDO))
                            .Parameters.Add(New SqlParameter("@QtySUOut", _QtySUnitOut))
                            .Parameters.Add(New SqlParameter("@ItemFactor", _ItemFactor))
                            .Parameters.Add(New SqlParameter("@UserInsert", _UserInsert))

                            .ExecuteNonQuery()
                        End With

                        iRecCountTmp += 1
                    End While 'While iRecCountTmp <= rowsTmp.Length

                    With New SqlCommand
                        .CommandText = strSQL_SalesUnitUpdateApproval.ToString
                        .CommandType = CommandType.Text
                        .Connection = cn
                        .Parameters.Add(New SqlParameter("@TxnNo", _TxnNo))
                        .Parameters.Add(New SqlParameter("@UserApproval", _UserInsert))
                        .Transaction = trans
                        .ExecuteNonQuery()
                    End With

                End If 'rowsTmp.Length > 0 Then

                ' //  Commit the transaction
                trans.Commit()
            Catch ex As Exception

                ' // Rollback all changes
                trans.Rollback()
                ExceptionManager.Publish(ex)

            Finally
                trans.Dispose()
                trans = Nothing

                If Not cn Is Nothing Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End If
                cn.Dispose()
                cn = Nothing
            End Try
        End Sub

        Private Sub ApprovalSalesReturn(ByVal TxnTypeValue As String, ByVal Description As String)
            Dim cn As New SqlConnection(HisConfiguration.ConnectionString)

            Dim strSQL_InsertHistory As New Text.StringBuilder
            Dim strSQL_SelectSalesReturnTmp As New Text.StringBuilder
            Dim strSQL_SalesReturnUpdateApproval As New Text.StringBuilder
            Dim strSQL_UpdateItem As New Text.StringBuilder
            Dim strSQL_UpdateSUdt As New Text.StringBuilder

            Dim trans As SqlTransaction

            Dim cmdSelectSalesReturnTmp As SqlCommand = New SqlCommand

            With strSQL_SalesReturnUpdateApproval
                .Append("Update SalesReturnHd " & _
                        "Set IsApproval = 1, " & _
                        "UserApproval = @UserApproval, " & _
                        "ApprovalDate = getdate() " & _
                        "Where IsApproval = 0 and IsDeleted = 0 and SReturnNO = @SReturnNO ")
            End With

            ' // di insert ke table history ...
            With strSQL_SelectSalesReturnTmp
                .Append("SELECT " & _
                        "dt.ID AS IDSR, " & _
                        "dt.IDSU, " & _
                        "'" + TxnTypeValue.Trim + "' AS inventoryTxnID, " & _
                        "hd.SReturnDate, " & _
                        "hd.WHID, " & _
                        "hd.UnitID, " & _
                        "dt.ItemSeqNo, " & _
                        "isnull(it.ItemName,'') as ItemName, " & _
                        "isnull(it.ItemLUnitID,'') AS ItemLUnitID, " & _
                        "isnull(it.ItemSUnitID,'') AS ItemSUnitID, " & _
                        "dt.ItemFactor, " & _
                        "dt.Qty AS QtySUIn, " & _
                        "0 AS QtySUOut, " & _
                        "isnull(dt.Price,0) AS SUnitPrice, " & _
                        "left(@Description,500) AS [DESCRIPTION] " & _
                        "FROM SalesReturnHd hd " & _
                        "INNER JOIN SalesReturndt dt ON dt.SReturnNO = hd.SReturnNO AND hd.IsApproval = 0 and hd.IsDeleted = 0 and dt.IsDeleted = 0 " & _
                        "INNER JOIN Item it ON it.ItemSeqNo = dt.ItemSeqNo " & _
                        "WHERE hd.SReturnNO = @SReturnNO ")
            End With

            ' // sql statement untuk insert ke table history ...
            With strSQL_InsertHistory
                .Append("Insert into ItemHistory" & _
                        "(ID, TxnNo, InventoryTxnID, TxnDate, WhID, UnitID, ItemSeqNo, " & _
                        "ItemLUnitID, ItemSUnitID, ItemFactor, QtySUnitBegin, QtySUnitIn, " & _
                        "QtySUnitOut, SUnitPrice, SUnitCOGS, SUnitCOGSPrev, UserInsert, " & _
                        "InsertDate, Description) " & _
                        "Values(@ID, @TxnNo, @InventoryTxnID, @TxnDate, @WhID, @UnitID, @ItemSeqNo, " & _
                        "@ItemLUnitID, @ItemSUnitID, @ItemFactor, @QtySUnitBegin, @QtySUnitIn, " & _
                        "@QtySUnitOut, @SUnitPrice, @SUnitCOGS, @SUnitCOGSPrev, @UserInsert, " & _
                        "Getdate(), left(@Description,500)) ")
            End With

            With strSQL_UpdateItem
                .Append("Update Item " & _
                        "Set SUnitCOGSLast = @SUnitCOGS " & _
                        "Where ItemSeqNo = @ItemSeqNo ")
            End With

            With strSQL_UpdateSUdt
                .Append("UPDATE SalesUnitDt " & _
                        "SET QtyReturn = (QtyReturn + (@QtySUnitIn * @ItemFactor)) " & _
                        "WHERE ID = @IDSU ")
            End With


            With cmdSelectSalesReturnTmp
                .CommandText = strSQL_SelectSalesReturnTmp.ToString
                .CommandType = CommandType.Text
                .Connection = cn
                .Parameters.Add(New SqlParameter("@SReturnNO", _TxnNo))
                .Parameters.Add(New SqlParameter("@Description", Description))
            End With


            Dim tblSalesReturnTmp As DataTable = New DataTable("SalesReturnTmp")
            Dim adapterTrmTmp As SqlDataAdapter = New SqlDataAdapter(cmdSelectSalesReturnTmp)

            ' // Open connection.
            cn.Open()

            trans = cn.BeginTransaction

            cmdSelectSalesReturnTmp.Transaction = trans
            Try
                ' // loop untuk setiap record and insert ke table history ...!!
                adapterTrmTmp.Fill(tblSalesReturnTmp)
                Dim rowsTmp As DataRow() = tblSalesReturnTmp.Select
                Dim iRecCountTmp As Integer

                If rowsTmp.Length > 0 Then
                    iRecCountTmp = 1

                    While iRecCountTmp <= rowsTmp.Length
                        Dim drTmp As DataRow = rowsTmp(iRecCountTmp - 1)

                        _ID = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("ItemHistory", "ID", cn, trans)
                        Dim IDSR As String = drTmp("IDSR")
                        Dim IDSU As String = drTmp("IDSU")
                        _InventoryTxnID = drTmp("inventoryTxnID")
                        _TxnDate = drTmp("SReturnDate")
                        _WhID = drTmp("WHID")
                        _UnitID = drTmp("UnitID")
                        _ItemSeqNo = drTmp("ItemSeqNo")
                        Dim ItemName As String = drTmp("ItemName")
                        _ItemLUnitID = drTmp("ItemLUnitID")
                        _ItemSUnitID = (drTmp("ItemSUnitID"))
                        _ItemFactor = drTmp("ItemFactor")
                        _QtySUnitIn = drTmp("QtySUIn")
                        _QtySUnitOut = drTmp("QtySUOut")
                        _SUnitPrice = drTmp("SUnitPrice")
                        _Description = drTmp("Description")

                        Dim cmdItem As SqlCommand = New SqlCommand
                        With cmdItem
                            .CommandText = "SELECT * FROM Item WHERE ItemSeqNo = @ItemSeqNo "
                            .CommandType = CommandType.Text
                            .Connection = cn
                            .Transaction = trans
                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                        End With
                        Dim adpItem As SqlDataAdapter = New SqlDataAdapter(cmdItem)
                        Dim dtitem As DataTable = New DataTable
                        adpItem.Fill(dtitem)

                        _SUnitCOGSPrev = ProcessNull.GetDouble(dtitem.Rows(0)("SUnitCOGSLast"))

                        dtitem.Dispose()
                        dtitem = Nothing

                        Dim cmdQtySUnitBegin As SqlCommand = New SqlCommand
                        With cmdQtySUnitBegin
                            .CommandText = "SELECT * FROM ItemBalance WHERE ItemSeqNo = @ItemSeqNo AND WhID = @WhID AND UnitID = @UnitID "
                            .CommandType = CommandType.Text
                            .Connection = cn
                            .Transaction = trans
                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                            .Parameters.Add(New SqlParameter("@WhID", _WhID))
                            .Parameters.Add(New SqlParameter("@UnitID", _UnitID))
                        End With
                        Dim adpQtySUnitBegin As SqlDataAdapter = New SqlDataAdapter(cmdQtySUnitBegin)
                        Dim dtQtySUnitBegin As DataTable = New DataTable
                        adpQtySUnitBegin.Fill(dtQtySUnitBegin)

                        If dtQtySUnitBegin.Rows.Count > 0 Then
                            _QtySUnitBegin = ProcessNull.GetDouble(dtQtySUnitBegin.Rows(0)("QtySUnit"))
                        Else
                            _QtySUnitBegin = 0
                        End If

                        dtQtySUnitBegin.Dispose()
                        dtQtySUnitBegin = Nothing

                        If _QtySUnitBegin + (_QtySUnitIn * _ItemFactor) - (_QtySUnitOut * _ItemFactor) < 0 Then
                            Throw New Exception(ItemName.Trim + " Qty (" + Format((_QtySUnitOut * _ItemFactor), "#,##0.00") + ") must be equal or less than qty stock (" + Format(_QtySUnitBegin, "#,##0.00") + ")")
                            Exit Sub
                        End If

                        _SUnitCOGS = GetCOGSNowWithBeginTransaction(_SUnitCOGSPrev, _QtySUnitBegin, _SUnitPrice, (_QtySUnitIn * _ItemFactor), "+", cn, trans)


                        With New SqlCommand
                            .CommandText = strSQL_InsertHistory.ToString
                            .CommandType = CommandType.Text
                            .Transaction = trans
                            .Connection = cn

                            .Parameters.Add(New SqlParameter("@ID", _ID))
                            .Parameters.Add(New SqlParameter("@TxnNo", IDSR))
                            .Parameters.Add(New SqlParameter("@InventoryTxnID", _InventoryTxnID))
                            .Parameters.Add(New SqlParameter("@TxnDate", _TxnDate))
                            .Parameters.Add(New SqlParameter("@WhID", _WhID))
                            .Parameters.Add(New SqlParameter("@UnitID", _UnitID))
                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                            .Parameters.Add(New SqlParameter("@ItemLUnitID", _ItemLUnitID))
                            .Parameters.Add(New SqlParameter("@ItemSUnitID", _ItemSUnitID))
                            .Parameters.Add(New SqlParameter("@ItemFactor", _ItemFactor))
                            .Parameters.Add(New SqlParameter("@QtySUnitBegin", _QtySUnitBegin))
                            .Parameters.Add(New SqlParameter("@QtySUnitIn", _QtySUnitIn))
                            .Parameters.Add(New SqlParameter("@QtySUnitOut", _QtySUnitOut))
                            .Parameters.Add(New SqlParameter("@SUnitPrice", _SUnitPrice))
                            .Parameters.Add(New SqlParameter("@SUnitCOGS", _SUnitCOGS))
                            .Parameters.Add(New SqlParameter("@SUnitCOGSPrev", _SUnitCOGSPrev))
                            .Parameters.Add(New SqlParameter("@UserInsert", _UserInsert))
                            .Parameters.Add(New SqlParameter("@Description", _Description))

                            .ExecuteNonQuery()
                        End With

                        With New SqlCommand
                            .CommandText = strSQL_UpdateItem.ToString
                            .CommandType = CommandType.Text
                            .Transaction = trans
                            .Connection = cn

                            .Parameters.Add(New SqlParameter("@ItemSeqNo", _ItemSeqNo))
                            .Parameters.Add(New SqlParameter("@SUnitCOGS", _SUnitCOGS))

                            .ExecuteNonQuery()
                        End With

                        With New SqlCommand
                            .CommandText = strSQL_UpdateSUdt.ToString
                            .CommandType = CommandType.Text
                            .Transaction = trans
                            .Connection = cn

                            .Parameters.Add(New SqlParameter("@IDSU", IDSU))
                            .Parameters.Add(New SqlParameter("@QtySUnitIn", _QtySUnitIn))
                            .Parameters.Add(New SqlParameter("@ItemFactor", _ItemFactor))
                            .Parameters.Add(New SqlParameter("@UserInsert", _UserInsert))

                            .ExecuteNonQuery()
                        End With

                        iRecCountTmp += 1
                    End While 'While iRecCountTmp <= rowsTmp.Length

                    With New SqlCommand
                        .CommandText = strSQL_SalesReturnUpdateApproval.ToString
                        .CommandType = CommandType.Text
                        .Connection = cn
                        .Parameters.Add(New SqlParameter("@SReturnNO", _TxnNo))
                        .Parameters.Add(New SqlParameter("@UserApproval", _UserInsert))
                        .Transaction = trans
                        .ExecuteNonQuery()
                    End With

                End If 'rowsTmp.Length > 0 Then

                ' //  Commit the transaction
                trans.Commit()
            Catch ex As Exception

                ' // Rollback all changes
                trans.Rollback()
                ExceptionManager.Publish(ex)

            Finally
                trans.Dispose()
                trans = Nothing

                If Not cn Is Nothing Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End If
                cn.Dispose()
                cn = Nothing
            End Try
        End Sub

#End Region

#Region "Others Function"
        Private Function GetCOGSNowWithBeginTransaction(ByVal COGSLast As Double, ByVal QtyLast As Double, ByVal Price As Double, ByVal Qty As Double, ByVal PlusOrMinus As String, ByRef conn As SqlConnection, ByRef Trans As SqlTransaction) As String
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim _mainConnection As SqlConnection = New SqlConnection(HisConfiguration.ConnectionString)
            cmdToExecute.CommandText = "SELECT dbo.GetCOGSNow(@COGSLast,@QtyLast,@Price,@Qty,@PlusOrMinus) as COGS "
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("GetCOGS")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = conn
            cmdToExecute.Transaction = Trans

            Try
                cmdToExecute.Parameters.Add("@COGSLast", COGSLast)
                cmdToExecute.Parameters.Add("@QtyLast", QtyLast)
                cmdToExecute.Parameters.Add("@Price", Price)
                cmdToExecute.Parameters.Add("@Qty", Qty)
                cmdToExecute.Parameters.Add("@PlusOrMinus", PlusOrMinus)

                cmdToExecute.ExecuteNonQuery()

                ' // Execute query.
                adapter.Fill(toReturn)

                Return CType(Common.ProcessNull.GetString(toReturn.Rows(0)("COGS")), String)
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


#Region " Public Property "
        Public Property [ID]() As String
            Get
                Return _ID
            End Get
            Set(ByVal Value As String)
                _ID = Value
            End Set
        End Property
        Public Property [TxnNo]() As String
            Get
                Return _TxnNo
            End Get
            Set(ByVal Value As String)
                _TxnNo = Value
            End Set
        End Property
        Public Property [InventoryTxnID]() As String
            Get
                Return _InventoryTxnID
            End Get
            Set(ByVal Value As String)
                _InventoryTxnID = Value
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
        Public Property [ItemSeqNo]() As String
            Get
                Return _ItemSeqNo
            End Get
            Set(ByVal Value As String)
                _ItemSeqNo = Value
            End Set
        End Property
        Public Property [ItemLUnitID]() As String
            Get
                Return _ItemLUnitID
            End Get
            Set(ByVal Value As String)
                _ItemLUnitID = Value
            End Set
        End Property
        Public Property [ItemSUnitID]() As String
            Get
                Return _ItemSUnitID
            End Get
            Set(ByVal Value As String)
                _ItemSUnitID = Value
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
        Public Property [QtySUnitBegin]() As Decimal
            Get
                Return _QtySUnitBegin
            End Get
            Set(ByVal Value As Decimal)
                _QtySUnitBegin = Value
            End Set
        End Property
        Public Property [QtySUnitIn]() As Decimal
            Get
                Return _QtySUnitIn
            End Get
            Set(ByVal Value As Decimal)
                _QtySUnitIn = Value
            End Set
        End Property
        Public Property [QtySUnitOut]() As Decimal
            Get
                Return _QtySUnitOut
            End Get
            Set(ByVal Value As Decimal)
                _QtySUnitOut = Value
            End Set
        End Property
        Public Property [SUnitPrice]() As Decimal
            Get
                Return _SUnitPrice
            End Get
            Set(ByVal Value As Decimal)
                _SUnitPrice = Value
            End Set
        End Property
        Public Property [SUnitCOGS]() As Decimal
            Get
                Return _SUnitCOGS
            End Get
            Set(ByVal Value As Decimal)
                _SUnitCOGS = Value
            End Set
        End Property
        Public Property [SUnitCOGSPrev]() As Decimal
            Get
                Return _SUnitCOGSPrev
            End Get
            Set(ByVal Value As Decimal)
                _SUnitCOGSPrev = Value
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
