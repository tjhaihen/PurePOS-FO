Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class UserGroupMenu
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _UserGroupID, _MenuID As String
        Private _isAllowRead, _isAllowEdit, _isAllowDelete As Boolean
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO UserGroupMenu " & _
                                        "(UserGroupID, MenuID, isAllowRead, isAllowEdit, isAllowDelete) " & _
                                        "VALUES (@UserGroupID, @MenuID, @isAllowRead, @isAllowEdit, @isAllowDelete)"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UserGroupID", _UserGroupID)
                cmdToExecute.Parameters.AddWithValue("@MenuID", _MenuID)
                cmdToExecute.Parameters.AddWithValue("@isAllowRead", _isAllowRead)
                cmdToExecute.Parameters.AddWithValue("@isAllowEdit", _isAllowEdit)
                cmdToExecute.Parameters.AddWithValue("@isAllowDelete", _isAllowDelete)

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

            cmdToExecute.CommandText = "UPDATE UserGroupMenu " & _
                                        "SET isAllowRead = @isAllowRead, " & _
                                        "isAllowEdit = @isAllowEdit, " & _
                                        "isAllowDelete = @isAllowDelete " & _
                                        "WHERE UserGroupID = @UserGroupID " & _
                                        "AND MenuID = @MenuID"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UserGroupID", _UserGroupID)
                cmdToExecute.Parameters.AddWithValue("@MenuID", _MenuID)
                cmdToExecute.Parameters.AddWithValue("@isAllowRead", _isAllowRead)
                cmdToExecute.Parameters.AddWithValue("@isAllowEdit", _isAllowEdit)
                cmdToExecute.Parameters.AddWithValue("@isAllowDelete", _isAllowDelete)

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

        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "DELETE FROM UserGroupMenu " & _
                                        "WHERE UserGroupID = @UserGroupID " & _
                                        "AND MenuID = @MenuID "
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UserGroupID", _UserGroupID)
                cmdToExecute.Parameters.AddWithValue("@MenuID", _MenuID)

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

        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM UserGroupMenu " & _
                                        "WHERE UserGroupID = @UserGroupID " & _
                                        "AND MenuID = @MenuID"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("UserGroupMenu")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UserGroupID", _UserGroupID)
                cmdToExecute.Parameters.AddWithValue("@MenuID", _MenuID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _UserGroupID = CType(toReturn.Rows(0)("UserGroupID"), String)
                    _MenuID = CType(toReturn.Rows(0)("MenuID"), String)
                    _isAllowRead = CType(toReturn.Rows(0)("isAllowRead"), Boolean)
                    _isAllowEdit = CType(toReturn.Rows(0)("isAllowEdit"), Boolean)
                    _isAllowDelete = CType(toReturn.Rows(0)("isAllowDelete"), Boolean)
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

#Region " Custom Functions "
        Public Function SelectByUserGroupID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM UserGroupMenu " & _
                                        "WHERE UserGroupID = @UserGroupID"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("UserGroupMenu")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UserGroupID", _UserGroupID)

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

        Public Function DeleteByUserGroupID() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "DELETE FROM UserGroupMenu " & _
                                        "WHERE UserGroupID = @UserGroupID"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UserGroupID", _UserGroupID)

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
#End Region

#Region " Class Property Declarations "
        Public Property [UserGroupID]() As String
            Get
                Return _UserGroupID
            End Get
            Set(ByVal Value As String)
                _UserGroupID = Value
            End Set
        End Property

        Public Property [MenuID]() As String
            Get
                Return _MenuID
            End Get
            Set(ByVal Value As String)
                _MenuID = Value
            End Set
        End Property

        Public Property [isAllowRead]() As Boolean
            Get
                Return _isAllowRead
            End Get
            Set(ByVal Value As Boolean)
                _isAllowRead = Value
            End Set
        End Property

        Public Property [isAllowEdit]() As Boolean
            Get
                Return _isAllowEdit
            End Get
            Set(ByVal Value As Boolean)
                _isAllowEdit = Value
            End Set
        End Property

        Public Property [isAllowDelete]() As Boolean
            Get
                Return _isAllowDelete
            End Get
            Set(ByVal Value As Boolean)
                _isAllowDelete = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
