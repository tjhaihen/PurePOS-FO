Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules

    Partial Public Class User : Inherits BRInteractionBase

        Private _UserID, _UserName, _UserGroupID, _Password, _NewPassword, _AuthorizePassword As String
        Private _JobTitleID, _PrimaryPhoneNo, _SecondaryPhoneNo1, _SecondaryPhoneNo2, _Email, _Address As String
        Private _UserInsert, _UserUpdate As String
        Private _isActive As Boolean

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cn As New SqlConnection(HisConfiguration.ConfigurationConnectionString)
            Dim cmdToExecute As SqlCommand = New SqlCommand
            With cmdToExecute
                .CommandText = "INSERT INTO [User] " & _
                                "(UserID, UserName, UserGroupID, Password, AuthorizePassword, JobTitleID, PrimaryPhoneNo, " & _
                                "SecondaryPhoneNo1, SecondaryPhoneNo2, Email, Address, IsActive, UserInsert, UserUpdate, InsertDate, UpdateDate) " & _
                                "VALUES " & _
                                "(@UserID, @UserName, @UserGroupID, @Password, @AuthorizePassword, @JobTitleID, @PrimaryPhoneNo, " & _
                                "@SecondaryPhoneNo1, @SecondaryPhoneNo2, @Email, @Address, @IsActive, @UserInsert, @UserUpdate, GetDate(), GetDate())"
                .CommandType = CommandType.Text
                .Connection = cn
            End With

            Try
                cmdToExecute.Parameters.Add("@UserID", _UserID)
                cmdToExecute.Parameters.Add("@UserName", _UserName)
                cmdToExecute.Parameters.Add("@UserGroupID", _UserGroupID)
                cmdToExecute.Parameters.Add("@Password", _Password)
                cmdToExecute.Parameters.Add("@AuthorizePassword", _AuthorizePassword)
                cmdToExecute.Parameters.Add("@JobTitleID", _JobTitleID)
                cmdToExecute.Parameters.Add("@PrimaryPhoneNo", _PrimaryPhoneNo)
                cmdToExecute.Parameters.Add("@SecondaryPhoneNo1", _SecondaryPhoneNo1)
                cmdToExecute.Parameters.Add("@SecondaryPhoneNo2", _SecondaryPhoneNo2)
                cmdToExecute.Parameters.Add("@Email", _Email)
                cmdToExecute.Parameters.Add("@Address", _Address)
                cmdToExecute.Parameters.Add("@IsActive", _isActive)
                cmdToExecute.Parameters.Add("@UserInsert", _UserInsert)
                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)

                cn.Open()

                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                cn.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Overrides Function Update() As Boolean
            Dim cn As New SqlConnection(HisConfiguration.ConfigurationConnectionString)
            Dim cmdToExecute As SqlCommand = New SqlCommand
            With cmdToExecute
                .CommandText = "UPDATE [User] " & _
                                "SET " & _
                                "UserName = @UserName, " & _
                                "UserGroupID = @UserGroupID, " & _
                                "JobTitleID = @JobTitleID, " & _
                                "PrimaryPhoneNo = @PrimaryPhoneNo, " & _
                                "SecondaryPhoneNo1 = @SecondaryPhoneNo1, " & _
                                "SecondaryPhoneNo2 = @SecondaryPhoneNo2, " & _
                                "Email = @Email, " & _
                                "Address = @Address, " & _
                                "IsActive = @IsActive, " & _
                                "UserUpdate = @UserUpdate, " & _
                                "UpdateDate = GetDate() " & _
                                "WHERE UserID = @UserID"
                .CommandType = CommandType.Text
                .Connection = cn
            End With

            Try
                cmdToExecute.Parameters.Add("@UserID", _UserID)
                cmdToExecute.Parameters.Add("@UserName", _UserName)
                cmdToExecute.Parameters.Add("@UserGroupID", _UserGroupID)
                cmdToExecute.Parameters.Add("@JobTitleID", _JobTitleID)
                cmdToExecute.Parameters.Add("@PrimaryPhoneNo", _PrimaryPhoneNo)
                cmdToExecute.Parameters.Add("@SecondaryPhoneNo1", _SecondaryPhoneNo1)
                cmdToExecute.Parameters.Add("@SecondaryPhoneNo2", _SecondaryPhoneNo2)
                cmdToExecute.Parameters.Add("@Email", _Email)
                cmdToExecute.Parameters.Add("@Address", _Address)
                cmdToExecute.Parameters.Add("@IsActive", _isActive)
                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)

                cn.Open()

                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                cn.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Overrides Function SelectAll() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT u.*, " & _
                                        "(SELECT UserGroupName FROM UserGroup WHERE UserGroupID = u.UserGroupID) AS UserGroupName, " & _
                                        "(SELECT DetailDesc FROM CommonSetting WHERE GroupID = 'JobTitle' and DetailID = u.JobTitleID) AS JobTitleName " & _
                                        "FROM [User] u"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("User")
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

        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Select Case recStatus
                Case RavenRecStatus.CurrentRecord
                    cmdToExecute.CommandText = "SELECT * FROM [User] WHERE UserID = @UserID"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM [User] WHERE UserID > @UserID ORDER BY UserID ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM [User] WHERE UserID < @UserID ORDER BY UserID DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("User")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@UserID", _UserID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _UserID = CType(toReturn.Rows(0)("UserID"), String)
                    _UserName = CType(toReturn.Rows(0)("UserName"), String)
                    _Password = CType(toReturn.Rows(0)("Password"), String)
                    _UserGroupID = CType(toReturn.Rows(0)("UserGroupID"), String)
                    _AuthorizePassword = CType(toReturn.Rows(0)("AuthorizePassword"), String)
                    _JobTitleID = CType(toReturn.Rows(0)("JobTitleID"), String)
                    _PrimaryPhoneNo = CType(toReturn.Rows(0)("PrimaryPhoneNo"), String)
                    _SecondaryPhoneNo1 = CType(toReturn.Rows(0)("SecondaryPhoneNo1"), String)
                    _SecondaryPhoneNo2 = CType(toReturn.Rows(0)("SecondaryPhoneNo2"), String)
                    _Email = CType(toReturn.Rows(0)("Email"), String)
                    _Address = CType(toReturn.Rows(0)("Address"), String)
                    _isActive = CType(toReturn.Rows(0)("isActive"), Boolean)
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

        Public Function UpdateAll(ByVal IsResetPassword As Boolean, ByVal IsResetAuthorizePassword As Boolean) As Boolean
            Dim cn As New SqlConnection(HisConfiguration.ConfigurationConnectionString)
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim strSQLUpdatePassword As String = String.Empty
            If IsResetPassword = True Then
                strSQLUpdatePassword += "Password = @Password, "
            End If
            If IsResetAuthorizePassword = True Then
                strSQLUpdatePassword += "AuthorizePassword = @AuthorizePassword, "
            End If

            cmdToExecute.CommandText = "UPDATE [User] " & _
                                        "SET " & _
                                        "UserName = @UserName, " & _
                                        "UserGroupID = @UserGroupID, " & _
                                        strSQLUpdatePassword.Trim & _
                                        "JobTitleID = @JobTitleID, " & _
                                        "PrimaryPhoneNo = @PrimaryPhoneNo, " & _
                                        "SecondaryPhoneNo1 = @SecondaryPhoneNo1, " & _
                                        "SecondaryPhoneNo2 = @SecondaryPhoneNo2, " & _
                                        "Email = @Email, " & _
                                        "Address = @Address, " & _
                                        "IsActive = @IsActive, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate() " & _
                                        "WHERE UserID = @UserID"

            With cmdToExecute
                .CommandType = CommandType.Text
                .Connection = cn
            End With

            Try
                cmdToExecute.Parameters.Add("@UserID", _UserID)
                cmdToExecute.Parameters.Add("@UserName", _UserName)
                cmdToExecute.Parameters.Add("@UserGroupID", _UserGroupID)
                cmdToExecute.Parameters.Add("@JobTitleID", _JobTitleID)
                cmdToExecute.Parameters.Add("@PrimaryPhoneNo", _PrimaryPhoneNo)
                cmdToExecute.Parameters.Add("@SecondaryPhoneNo1", _SecondaryPhoneNo1)
                cmdToExecute.Parameters.Add("@SecondaryPhoneNo2", _SecondaryPhoneNo2)
                cmdToExecute.Parameters.Add("@Email", _Email)
                cmdToExecute.Parameters.Add("@Address", _Address)
                cmdToExecute.Parameters.Add("@IsActive", _isActive)
                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)
                If IsResetPassword = True Then
                    cmdToExecute.Parameters.Add("@Password", _Password)
                End If
                If IsResetAuthorizePassword = True Then
                    cmdToExecute.Parameters.Add("@AuthorizePassword", _AuthorizePassword)
                End If

                cn.Open()

                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                cn.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Function UpdatePassword() As Boolean
            Dim cn As New SqlConnection(HisConfiguration.ConfigurationConnectionString)
            Dim cmdToExecute As SqlCommand = New SqlCommand
            With cmdToExecute
                .CommandText = "UPDATE [User] " & _
                                "SET Password = @NewPassword " & _
                                "WHERE UserID = @UserID"
                .CommandType = CommandType.Text
                .Connection = cn
            End With

            Try
                cmdToExecute.Parameters.Add("@UserID", _UserID)
                cmdToExecute.Parameters.Add("@NewPassword", _NewPassword)

                cn.Open()

                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                cn.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Function SelectByUserGroupID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT * " & _
                                        "FROM [User] " & _
                                        "WHERE UserGroupID = @UserGroupID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("User")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@UserGroupID", _UserGroupID)

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

        Public Function CheckAuthorizePassword() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "Select * from [User] where IsActive = 1 and AuthorizePassword = @AuthorizePassword and ltrim(rtrim(AuthorizePassword)) <> '' "
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("User")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@AuthorizePassword", _AuthorizePassword)

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

        Public Property [UserID]() As String
            Get
                Return _UserID
            End Get
            Set(ByVal Value As String)
                _UserID = Value
            End Set
        End Property

        Public Property [UserName]() As String
            Get
                Return _UserName
            End Get
            Set(ByVal Value As String)
                _UserName = Value
            End Set
        End Property

        Public Property [UserGroupID]() As String
            Get
                Return _UserGroupID
            End Get
            Set(ByVal Value As String)
                _UserGroupID = Value
            End Set
        End Property

        Public Property [Password]() As String
            Get
                Return _Password
            End Get
            Set(ByVal Value As String)
                _Password = Value
            End Set
        End Property

        Public Property [AuthorizePassword]() As String
            Get
                Return _AuthorizePassword
            End Get
            Set(ByVal Value As String)
                _AuthorizePassword = Value
            End Set
        End Property

        Public Property [NewPassword]() As String
            Get
                Return _NewPassword
            End Get
            Set(ByVal Value As String)
                _NewPassword = Value
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

        Public Property [Address]() As String
            Get
                Return _Address
            End Get
            Set(ByVal Value As String)
                _Address = Value
            End Set
        End Property

        Public Property [isActive]() As Boolean
            Get
                Return _isActive
            End Get
            Set(ByVal Value As Boolean)
                _isActive = Value
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

    End Class

End Namespace