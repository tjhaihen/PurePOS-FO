Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class Report
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ReportID, _ParentReportID As Integer
        Private _ReportCaption, _Url, _ReportFileName, _ReportSPName, _UserGroupID, _Description As String
        Private _IsActive As Boolean
        Private _PublishDate As DateTime
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " Custom Functions "
        Public Function SelectReportAuthorizationByUserGroupID(ByVal UserGroupID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT isnull(r.ReportID,'') as ReportID, " & _
                                        "r.ParentReportID, r.ReportCaption, " & _
                                        "IsAuthorized = " & _
                                        "CASE " & _
                                        "WHEN(r.ReportID in (SELECT ReportID FROM UserGroupReport WHERE UserGroupID = @UserGroupID)) THEN(1) " & _
                                        "ELSE " & _
                                        "0 " & _
                                        "END " & _
                                        "FROM Report r " & _
                                        "LEFT JOIN UserGroupReport g ON r.ReportID = g.ReportID AND g.UserGroupID = @UserGroupID"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ReportAuthorizationByUserGroupID")
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

        Public Function SelectByUserGroupID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT ugr.UserGroupID, " & _
                                        "r.* " & _
                                        "FROM UserGroupReport ugr " & _
                                        "INNER JOIN Report r on r.ReportID = ugr.ReportID " & _
                                        "WHERE ugr.UserGroupID = @UserGroupID AND r.isActive = 1 " & _
                                        "AND CONVERT(varchar(8),r.PublishDate,112) <= CONVERT(varchar(8),GETDATE(),112)"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ReportByUserGroupID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@UserGroupID", _UserGroupID)

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
        Public Property [UserGroupID]() As String
            Get
                Return _UserGroupID
            End Get
            Set(ByVal Value As String)
                _UserGroupID = Value
            End Set
        End Property

        Public Property [ReportID]() As Integer
            Get
                Return _ReportID
            End Get
            Set(ByVal Value As Integer)
                _ReportID = Value
            End Set
        End Property

        Public Property [ParentReportID]() As Integer
            Get
                Return _ParentReportID
            End Get
            Set(ByVal Value As Integer)
                _ParentReportID = Value
            End Set
        End Property

        Public Property [ReportCaption]() As String
            Get
                Return _ReportCaption
            End Get
            Set(ByVal Value As String)
                _ReportCaption = Value
            End Set
        End Property

        Public Property [Url]() As String
            Get
                Return _Url
            End Get
            Set(ByVal Value As String)
                _Url = Value
            End Set
        End Property

        Public Property [ReportFileName]() As String
            Get
                Return _ReportFileName
            End Get
            Set(ByVal Value As String)
                _ReportFileName = Value
            End Set
        End Property

        Public Property [ReportSPName]() As String
            Get
                Return _ReportSPName
            End Get
            Set(ByVal Value As String)
                _ReportSPName = Value
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

        Public Property [IsActive]() As Boolean
            Get
                Return _IsActive
            End Get
            Set(ByVal Value As Boolean)
                _IsActive = Value
            End Set
        End Property

        Public Property [PublishDate]() As DateTime
            Get
                Return _PublishDate
            End Get
            Set(ByVal Value As DateTime)
                _PublishDate = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
