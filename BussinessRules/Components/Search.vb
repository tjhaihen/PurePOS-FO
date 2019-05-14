Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class Search
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _SearchID, _SearchCaption, _SearchProcedure As String
#End Region


        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " Main Function "
        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM Search WHERE SearchID = @SearchID"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("Search")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@SearchID", _SearchID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _SearchID = CType(toReturn.Rows(0)("SearchID"), String)
                    _SearchCaption = CType(toReturn.Rows(0)("SearchCaption"), String)
                    _SearchProcedure = CType(toReturn.Rows(0)("SearchProcedure"), String)
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

        Public Function SelectSearchList() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Me.SelectOne(RavenRecStatus.CurrentRecord)
            cmdToExecute.CommandText = "dbo.[" + Me.SearchProcedure.Trim + "]"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.CommandTimeout = 3600
            Dim toReturn As DataTable = New DataTable("Search")
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
#End Region

#Region " Class Property Declarations "
        Public Property [SearchID]() As String
            Get
                Return _SearchID
            End Get
            Set(ByVal Value As String)
                _SearchID = Value
            End Set
        End Property

        Public Property [SearchCaption]() As String
            Get
                Return _SearchCaption
            End Get
            Set(ByVal Value As String)
                _SearchCaption = Value
            End Set
        End Property

        Public Property [SearchProcedure]() As String
            Get
                Return _SearchProcedure
            End Get
            Set(ByVal Value As String)
                _SearchProcedure = Value
            End Set
        End Property

#End Region

    End Class
End Namespace
