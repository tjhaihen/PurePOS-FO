Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class InventoryTxn
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _InventoryTxnID, _InventoryTxnName As String
        Private _IsActive, _IsMutation As Boolean
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " Custom Functions "
        Public Function SelectInventoryTxnAuthorizationByUserGroupID(ByVal UserGroupID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT isnull(i.InventoryTxnID,'') as InventoryTxnID, " & _
                                        "i.InventoryTxnName, " & _
                                        "IsAuthorized = " & _
                                        "CASE " & _
                                        "WHEN(i.InventoryTxnID in (SELECT InventoryTxnID FROM UserGroupInventoryTxn WHERE UserGroupID = @UserGroupID)) THEN(1) " & _
                                        "ELSE " & _
                                        "0 " & _
                                        "END " & _
                                        "FROM InventoryTxn i " & _
                                        "LEFT JOIN UserGroupInventoryTxn g ON i.InventoryTxnID = g.InventoryTxnID AND g.UserGroupID = @UserGroupID"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("InventoryTxnAuthorizationByUserGroupID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@UserGroupID", UserGroupID)

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

        Public Function SelectAllInventoryTxnIsMutationByUserGroupID(ByVal UserGroupID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT ugi.UserGroupID, " & _
                                        "i.* " & _
                                        "FROM UserGroupInventoryTxn ugi " & _
                                        "INNER JOIN InventoryTxn i on i.InventoryTxnID = ugi.InventoryTxnID " & _
                                        "WHERE ugi.UserGroupID = @UserGroupID AND i.isActive = 1 AND i.isMutation = 1"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("InventoryTxnIsMutationByUserGroupID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@UserGroupID", UserGroupID)

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

        Public Overrides Function SelectAll() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT * FROM InventoryTxn " & _
                                       "order by InventoryTxnID "
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

        Public Function SelectAllForInventoryTxnID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT * FROM InventoryTxn where IsActive = 1 and IsMutation = @IsMutation " & _
                                       "order by InventoryTxnID "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("InventoryTxn")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@IsMutation", _IsMutation)
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
        Public Property [InventoryTxnID]() As String
            Get
                Return _InventoryTxnID
            End Get
            Set(ByVal Value As String)
                _InventoryTxnID = Value
            End Set
        End Property

        Public Property [InventoryTxnName]() As String
            Get
                Return _InventoryTxnName
            End Get
            Set(ByVal Value As String)
                _InventoryTxnName = Value
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

        Public Property [IsMutation]() As Boolean
            Get
                Return _IsMutation
            End Get
            Set(ByVal Value As Boolean)
                _IsMutation = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
