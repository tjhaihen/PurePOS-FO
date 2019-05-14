Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class EntitiesContact
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _EntitiesSeqNo, _ContactSeqNo, _FullName, _JobTitleID, _Address As String        
        Private _PrimaryPhoneNo, _SecondaryPhoneNo1, _SecondaryPhoneNo2, _Email As String
        Private _UserInsert, _UserUpdate As String
        Private _InsertDate, _UpdateDate As String
        Private _UserDelete, _DeleteDate As String
        Private _IsActive, _IsDeleted As Boolean
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO EntitiesContact " & _
                                        "(EntitiesSeqNo, ContactSeqNo, FullName, JobTitleID, Address, " & _
                                        "PrimaryPhoneNo, SecondaryPhoneNo1, SecondaryPhoneNo2, Email, " & _
                                        "IsActive, IsDeleted, UserInsert, InsertDate, UserUpdate, UpdateDate, UserDelete, DeleteDate) VALUES " & _
                                        "(@EntitiesSeqNo, @ContactSeqNo, @FullName, @JobTitleID, @Address, " & _
                                        "@PrimaryPhoneNo, @SecondaryPhoneNo1, @SecondaryPhoneNo2, @Email, " & _
                                        "@IsActive, 0, @UserInsert, Getdate(), @UserUpdate, Getdate(), '', '')"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@ContactSeqNo", _ContactSeqNo)
                cmdToExecute.Parameters.Add("@FullName", _FullName)
                cmdToExecute.Parameters.Add("@JobTitleID", _JobTitleID)
                cmdToExecute.Parameters.Add("@Address", _Address)
                cmdToExecute.Parameters.Add("@PrimaryPhoneNo", _PrimaryPhoneNo)
                cmdToExecute.Parameters.Add("@SecondaryPhoneNo1", _SecondaryPhoneNo1)
                cmdToExecute.Parameters.Add("@SecondaryPhoneNo2", _SecondaryPhoneNo2)
                cmdToExecute.Parameters.Add("@Email", _Email)
                cmdToExecute.Parameters.Add("@IsActive", _IsActive)
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

            cmdToExecute.CommandText = "UPDATE EntitiesContact " & _
                                        "SET FullName = @FullName, " & _
                                        "JobTitleID = @JobTitleID, " & _
                                        "Address = @Address, " & _
                                        "PrimaryPhoneNo = @PrimaryPhoneNo, " & _
                                        "SecondaryPhoneNo1 = @SecondaryPhoneNo1, " & _
                                        "SecondaryPhoneNo2 = @SecondaryPhoneNo2, " & _
                                        "Email = @Email, " & _
                                        "IsActive = @IsActive, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate() " & _
                                        "WHERE EntitiesSeqNo = @EntitiesSeqNo " & _
                                        "AND ContactSeqNo = @ContactSeqNo"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@ContactSeqNo", _ContactSeqNo)
                cmdToExecute.Parameters.Add("@FullName", _FullName)
                cmdToExecute.Parameters.Add("@JobTitleID", _JobTitleID)
                cmdToExecute.Parameters.Add("@Address", _Address)
                cmdToExecute.Parameters.Add("@PrimaryPhoneNo", _PrimaryPhoneNo)
                cmdToExecute.Parameters.Add("@SecondaryPhoneNo1", _SecondaryPhoneNo1)
                cmdToExecute.Parameters.Add("@SecondaryPhoneNo2", _SecondaryPhoneNo2)
                cmdToExecute.Parameters.Add("@Email", _Email)
                cmdToExecute.Parameters.Add("@IsActive", _IsActive)                
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

            cmdToExecute.CommandText = "SELECT E.*, isnull(cs.DetailDesc,'') as JobTitleName FROM EntitiesContact E " & _
                                       "LEFT JOIN CommonSetting cs ON cs.GroupId = 'JobTitle' AND cs.DetailID = E.JobTitleID " & _
                                       "WHERE E.IsDeleted = 0 " & _
                                       "ORDER BY E.EntitiesSeqNo, E.ContactSeqNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("EntitiesContact")
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

        Public Function SelectAllByEntitiesSeqNo() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT E.*, isnull(cs.DetailDesc,'') as JobTitleName FROM EntitiesContact E " & _
                                       "LEFT JOIN CommonSetting cs ON cs.GroupId = 'JobTitle' AND cs.DetailID = E.JobTitleID " & _
                                       "WHERE E.IsDeleted = 0 " & _
                                       "AND E.EntitiesSeqNo = @EntitiesSeqNo " & _
                                       "ORDER BY E.EntitiesSeqNo, E.ContactSeqNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("EntitiesContact")
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

        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Select Case recStatus
                Case RavenRecStatus.CurrentRecord
                    cmdToExecute.CommandText = "SELECT * FROM EntitiesContact WHERE EntitiesSeqNo = @EntitiesSeqNo AND ContactSeqNo = @ContactSeqNo"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM EntitiesContact WHERE EntitiesSeqNo > @EntitiesSeqNo OR ContactSeqNo > @ContactSeqNo ORDER BY EntitiesSeqNo, ContactSeqNo ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM EntitiesContact WHERE EntitiesSeqNo < @EntitiesSeqNo OR ContactSeqNo < @ContactSeqNo ORDER BY EntitiesSeqNo, ContactSeqNo DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("EntitiesContact")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@ContactSeqNo", _ContactSeqNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _EntitiesSeqNo = CType(toReturn.Rows(0)("EntitiesSeqNo"), String)
                    _ContactSeqNo = CType(toReturn.Rows(0)("ContactSeqNo"), String)
                    _FullName = CType(toReturn.Rows(0)("FullName"), String)
                    _JobTitleID = CType(toReturn.Rows(0)("JobTitleID"), String)
                    _Address = CType(toReturn.Rows(0)("Address"), String)
                    _PrimaryPhoneNo = CType(toReturn.Rows(0)("PrimaryPhoneNo"), String)
                    _SecondaryPhoneNo1 = CType(toReturn.Rows(0)("SecondaryPhoneNo1"), String)
                    _SecondaryPhoneNo2 = CType(toReturn.Rows(0)("SecondaryPhoneNo2"), String)
                    _Email = CType(toReturn.Rows(0)("Email"), String)
                    _IsActive = CType(toReturn.Rows(0)("IsActive"), Boolean)
                    _IsDeleted = CType(toReturn.Rows(0)("IsDeleted"), Boolean)
                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
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

            cmdToExecute.CommandText = "Update EntitiesContact " & _
                                       "Set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = Getdate() " & _
                                       "WHERE EntitiesSeqNo = @EntitiesSeqNo " & _
                                       "AND ContactSeqNo = @ContactSeqNo"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@ContactSeqNo", _ContactSeqNo)
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

#Region " Class Property Declarations "
        Public Property [EntitiesSeqNo]() As String
            Get
                Return _EntitiesSeqNo
            End Get
            Set(ByVal Value As String)
                _EntitiesSeqNo = Value
            End Set
        End Property

        Public Property [ContactSeqNo]() As String
            Get
                Return _ContactSeqNo
            End Get
            Set(ByVal Value As String)
                _ContactSeqNo = Value
            End Set
        End Property

        Public Property [FullName]() As String
            Get
                Return _FullName
            End Get
            Set(ByVal Value As String)
                _FullName = Value
            End Set
        End Property

        Public Property [JobTitleID]() As String
            Get
                Return _JobTitleID
            End Get
            Set(ByVal Value As String)
                _JobTitleID = Value
            End Set
        End Property

        Public Property [Address]() As String
            Get
                Return _Address
            End Get
            Set(ByVal Value As String)
                _Address = Value
            End Set
        End Property

        Public Property [PrimaryPhoneNo]() As String
            Get
                Return _PrimaryPhoneNo
            End Get
            Set(ByVal Value As String)
                _PrimaryPhoneNo = Value
            End Set
        End Property

        Public Property [SecondaryPhoneNo1]() As String
            Get
                Return _SecondaryPhoneNo1
            End Get
            Set(ByVal Value As String)
                _SecondaryPhoneNo1 = Value
            End Set
        End Property

        Public Property [SecondaryPhoneNo2]() As String
            Get
                Return _SecondaryPhoneNo2
            End Get
            Set(ByVal Value As String)
                _SecondaryPhoneNo2 = Value
            End Set
        End Property

        Public Property [Email]() As String
            Get
                Return _Email
            End Get
            Set(ByVal Value As String)
                _Email = Value
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

        Public Property [IsDeleted]() As Boolean
            Get
                Return _IsDeleted
            End Get
            Set(ByVal Value As Boolean)
                _IsDeleted = Value
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
#End Region

    End Class
End Namespace
