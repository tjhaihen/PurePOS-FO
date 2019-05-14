'-----------------------------------------------------------
' FileName: UserManagement.vb
' Implementation file for user management
'
' Namespace:    Raven.Security
' Class:        UserModule
'               UserData
'
' Author:       hendy@Raven.com
'-----------------------------------------------------------
Option Explicit On 
Option Strict On

Imports System
Imports System.Xml
Imports System.Data
Imports System.Security
Imports System.Data.SqlClient
Imports System.Security.Permissions

Imports Raven
Imports Raven.Common
Imports Raven.SystemFramework

Namespace Raven.Security

    <StrongNameIdentityPermissionAttribute(SecurityAction.LinkDemand, PublicKey:="0024000004800000940000000602000000240000525341310004000001000100B5C8DAC10359BBDC968B03CC7972D770032BFCCDCE4324E01E728E0C982320E3B723CDC1C6CE9D02288D5D9225590FAD94A05E7F650281A614ED2D53FB37AFB84AFEF5D0491CF4C6B464D68565FF6CFAE3F7FB13FACD533C26D67AFC21EC7ECE6AAC5127A4043EA23D0889CF93ABD21F73B897BE75679AE6F0423EF436FC1FEB")> _
    Public Class UserManagement
        Inherits MarshalByRefObject

        Public Sub New()
        End Sub

#Region "Methods - return dataset"
        Public Overloads Function GetUserDataset(ByVal UserID As String, ByVal Password As String) As DataSet
            '
            '   validate User Name and Password
            '
            ApplicationAssert.CheckCondition(Len(UserID) > 0, "User name is required", ApplicationAssert.LineNumber)
            ApplicationAssert.CheckCondition(Len(Password) > 0, "Password is required", ApplicationAssert.LineNumber)

            '// Declare connection
            Dim cnn As SqlConnection = New SqlConnection(HisConfiguration.ConfigurationConnectionString)

            Dim UserGroupID As String

            ' // Create New Dataset
            Dim ds As New DataSet
            ds.Tables.Add(New DataTable("User"))
            ds.Tables.Add(New DataTable("UserGroupMenu"))

            Try

                '// Get User data
                Dim cmdUser As New SqlCommand

                cmdUser.CommandText = "SELECT UserID, " & _
                                        "Password, UserName, UserGroupID, isActive " & _
                                        "FROM [User] " & _
                                        "WHERE UserID = @UserID"
                cmdUser.CommandType = CommandType.Text
                cmdUser.Connection = cnn

                cmdUser.Parameters.AddWithValue("@UserID", UserID)

                Dim adapterUser As SqlDataAdapter = New SqlDataAdapter(cmdUser)
                adapterUser.Fill(ds.Tables("User"))

                cmdUser.Dispose()
                cmdUser = Nothing
                adapterUser.Dispose()
                adapterUser = Nothing

                '//   verify the user's password
                With ds.Tables("User")
                    If (.Rows.Count = 1) Then
                        If CType(.Rows(0)("Password"), String).Equals(Password) Then

                            ApplicationAssert.CheckCondition(Common.ProcessNull.GetBoolean(.Rows(0)("isActive")) = True, "Sorry, your account is currently disabled. Please contact your System Administrator.; Account disabled.", ApplicationAssert.LineNumber)

                            '// Get UserGroupID from Users
                            UserGroupID = Common.ProcessNull.GetString(.Rows(0)("UserGroupID"))

                            '
                            '//  Get user's modules
                            '
                            Dim cmdUserGroupMenu As New SqlCommand

                            cmdUserGroupMenu.CommandText = "SELECT ugm.UserGroupID, " & _
                                                            "ugm.IsAllowRead, ugm.IsAllowEdit, " & _
                                                            "ugm.IsAllowDelete, m.* " & _
                                                            "FROM UserGroupMenu ugm " & _
                                                            "INNER JOIN Menu m on m.MenuID = ugm.MenuID " & _
                                                            "WHERE ugm.UserGroupID = @UserGroupID AND m.isActive = 1"
                            cmdUserGroupMenu.CommandType = CommandType.Text
                            cmdUserGroupMenu.Connection = cnn

                            Dim adapterModules As SqlDataAdapter = New SqlDataAdapter(cmdUserGroupMenu)

                            cmdUserGroupMenu.Parameters.Add(New SqlParameter("@UserGroupID", UserGroupID))
                            adapterModules.Fill(ds.Tables("UserGroupMenu"))

                            cmdUserGroupMenu.Dispose()
                            cmdUserGroupMenu = Nothing
                            adapterModules.Dispose()
                            adapterModules = Nothing

                            Return ds
                        End If
                    End If
                End With

            Catch e As Exception
                ExceptionManager.Publish(e)
            End Try

        End Function
#End Region

    End Class

End Namespace