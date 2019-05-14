Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Partial Public Class User
        Public Function LoadByPrimaryKey(ByVal userID As String) As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim retval As Boolean = False
            cmdToExecute.CommandText = "SELECT * FROM [User] WHERE UserID = @UserID"

            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("User")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UserID", userID)

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
                    retval = True
                End If

            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
            Return retval
        End Function

    End Class
End Namespace