Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class Entities
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _EntitiesSeqNo, _EntitiesID, _EntitiesName, _EntitiesTypeID, _MemberTypeID As String
        Private _ParentEntitiesSeqNo, _RelationshipID, _TIN As String
        Private _PrimaryAddress, _SecondaryAddress1, _SecondaryAddress2, _ZipCode As String
        Private _PrimaryPhoneNo, _FaxNo, _Email, _Website, _CountryID, _CityID As String
        Private _SecondaryPhoneNo1, _SecondaryPhoneNo2, _Description As String
        Private _Bank, _BankAccountNo, _BankBranch, _BankAddress As String
        Private _MaxPOrdAmount As Decimal
        Private _UserInsert, _UserUpdate As String
        Private _InsertDate, _UpdateDate As String
        Private _UserDelete, _DeleteDate As String
        Private _IsActive, _IsDeleted As Boolean
        Private _MemberNo As String
        Private _MemberSinceDate, _MemberValidThruDate As DateTime
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " Overrides Function(s) "
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO Entities " & _
                                        "(EntitiesSeqNo, EntitiesID, EntitiesName, EntitiesTypeID, " & _
                                        "ParentEntitiesSeqNo, RelationshipID, TIN, " & _
                                        "PrimaryAddress, SecondaryAddress1, SecondaryAddress2, ZipCode, " & _
                                        "CityID, CountryID, " & _
                                        "PrimaryPhoneNo, SecondaryPhoneNo1, SecondaryPhoneNo2, " & _
                                        "FaxNo, Email, Website, " & _
                                        "Bank, BankAccountNo, BankBranch, BankAddress, " & _
                                        "MaxPOrdAmount, MemberTypeID, Description, " & _
                                        "IsActive, IsDeleted, UserInsert, InsertDate, UserUpdate, UpdateDate, UserDelete, DeleteDate) VALUES " & _
                                        "(@EntitiesSeqNo, @EntitiesID, @EntitiesName, @EntitiesTypeID, " & _
                                        "@ParentEntitiesSeqNo, @RelationshipID, @TIN, " & _
                                        "@PrimaryAddress, @SecondaryAddress1, @SecondaryAddress2, @ZipCode, " & _
                                        "@CityID, @CountryID, " & _
                                        "@PrimaryPhoneNo, @SecondaryPhoneNo1, @SecondaryPhoneNo2, " & _
                                        "@FaxNo, @Email, @Website, " & _
                                        "@Bank, @BankAccountNo, @BankBranch, @BankAddress, " & _
                                        "@MaxPOrdAmount, @MemberTypeID, @Description, " & _
                                        "@IsActive, 0, @UserInsert, Getdate(), @UserUpdate, Getdate(), '', '')"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@EntitiesID", _EntitiesID)
                cmdToExecute.Parameters.Add("@EntitiesName", _EntitiesName)
                cmdToExecute.Parameters.Add("@EntitiesTypeID", _EntitiesTypeID)
                cmdToExecute.Parameters.Add("@ParentEntitiesSeqNo", _ParentEntitiesSeqNo)
                cmdToExecute.Parameters.Add("@RelationshipID", _RelationshipID)
                cmdToExecute.Parameters.Add("@TIN", _TIN)
                cmdToExecute.Parameters.Add("@PrimaryAddress", _PrimaryAddress)
                cmdToExecute.Parameters.Add("@SecondaryAddress1", _SecondaryAddress1)
                cmdToExecute.Parameters.Add("@SecondaryAddress2", _SecondaryAddress2)
                cmdToExecute.Parameters.Add("@ZipCode", _ZipCode)
                cmdToExecute.Parameters.Add("@CityID", _CityID)
                cmdToExecute.Parameters.Add("@CountryID", _CountryID)
                cmdToExecute.Parameters.Add("@PrimaryPhoneNo", _PrimaryPhoneNo)
                cmdToExecute.Parameters.Add("@SecondaryPhoneNo1", _SecondaryPhoneNo1)
                cmdToExecute.Parameters.Add("@SecondaryPhoneNo2", _SecondaryPhoneNo2)
                cmdToExecute.Parameters.Add("@FaxNo", _FaxNo)
                cmdToExecute.Parameters.Add("@Email", _Email)
                cmdToExecute.Parameters.Add("@Website", _Website)
                cmdToExecute.Parameters.Add("@Bank", _Bank)
                cmdToExecute.Parameters.Add("@BankAccountNo", _BankAccountNo)
                cmdToExecute.Parameters.Add("@BankBranch", _BankBranch)
                cmdToExecute.Parameters.Add("@BankAddress", _BankAddress)
                cmdToExecute.Parameters.Add("@MaxPOrdAmount", _MaxPOrdAmount)
                cmdToExecute.Parameters.Add("@MemberTypeID", _MemberTypeID)
                cmdToExecute.Parameters.Add("@Description", _Description)
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

            cmdToExecute.CommandText = "UPDATE Entities " & _
                                        "SET EntitiesID = @EntitiesID, " & _
                                        "EntitiesName = @EntitiesName, " & _
                                        "EntitiesTypeID = @EntitiesTypeID, " & _
                                        "ParentEntitiesSeqNo = @ParentEntitiesSeqNo, " & _
                                        "RelationshipID = @RelationshipID, " & _
                                        "TIN = @TIN, " & _
                                        "PrimaryAddress = @PrimaryAddress, " & _
                                        "SecondaryAddress1 = @SecondaryAddress1, " & _
                                        "SecondaryAddress2 = @SecondaryAddress2, " & _
                                        "ZipCode = @ZipCode, " & _
                                        "CityID = @CityID, " & _
                                        "CountryID = @CountryID, " & _
                                        "PrimaryPhoneNo = @PrimaryPhoneNo, " & _
                                        "SecondaryPhoneNo1 = @SecondaryPhoneNo1, " & _
                                        "SecondaryPhoneNo2 = @SecondaryPhoneNo2, " & _
                                        "FaxNo = @FaxNo, " & _
                                        "Email = @Email, " & _
                                        "Website = @Website, " & _
                                        "Bank = @Bank, " & _
                                        "BankAccountNo = @BankAccountNo, " & _
                                        "BankBranch = @BankBranch, " & _
                                        "BankAddress = @BankAddress, " & _
                                        "MaxPOrdAmount = @MaxPOrdAmount, " & _
                                        "MemberTypeID = @MemberTypeID, " & _
                                        "Description = @Description, " & _
                                        "IsActive = @IsActive, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate() " & _
                                        "WHERE EntitiesSeqNo = @EntitiesSeqNo"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@EntitiesID", _EntitiesID)
                cmdToExecute.Parameters.Add("@EntitiesName", _EntitiesName)
                cmdToExecute.Parameters.Add("@EntitiesTypeID", _EntitiesTypeID)
                cmdToExecute.Parameters.Add("@ParentEntitiesSeqNo", _ParentEntitiesSeqNo)
                cmdToExecute.Parameters.Add("@RelationshipID", _RelationshipID)
                cmdToExecute.Parameters.Add("@TIN", _TIN)
                cmdToExecute.Parameters.Add("@PrimaryAddress", _PrimaryAddress)
                cmdToExecute.Parameters.Add("@SecondaryAddress1", _SecondaryAddress1)
                cmdToExecute.Parameters.Add("@SecondaryAddress2", _SecondaryAddress2)
                cmdToExecute.Parameters.Add("@ZipCode", _ZipCode)
                cmdToExecute.Parameters.Add("@CityID", _CityID)
                cmdToExecute.Parameters.Add("@CountryID", _CountryID)
                cmdToExecute.Parameters.Add("@PrimaryPhoneNo", _PrimaryPhoneNo)
                cmdToExecute.Parameters.Add("@SecondaryPhoneNo1", _SecondaryPhoneNo1)
                cmdToExecute.Parameters.Add("@SecondaryPhoneNo2", _SecondaryPhoneNo2)
                cmdToExecute.Parameters.Add("@FaxNo", _FaxNo)
                cmdToExecute.Parameters.Add("@Email", _Email)
                cmdToExecute.Parameters.Add("@Website", _Website)
                cmdToExecute.Parameters.Add("@Bank", _Bank)
                cmdToExecute.Parameters.Add("@BankAccountNo", _BankAccountNo)
                cmdToExecute.Parameters.Add("@BankBranch", _BankBranch)
                cmdToExecute.Parameters.Add("@BankAddress", _BankAddress)
                cmdToExecute.Parameters.Add("@MaxPOrdAmount", _MaxPOrdAmount)
                cmdToExecute.Parameters.Add("@MemberTypeID", _MemberTypeID)
                cmdToExecute.Parameters.Add("@Description", _Description)
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

            cmdToExecute.CommandText = "SELECT E.*, isnull(cs.DetailDesc,'') as EntitiesTypeName FROM Entities E " & _
                                       "LEFT JOIN CommonSetting cs ON cs.GroupId = 'EntitiesType' AND cs.DetailID = E.EntitiesTypeID " & _
                                       "WHERE E.IsDeleted = 0 " & _
                                       "ORDER BY E.EntitiesID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Entities")
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

        Public Function SelectAllForEntitiesSeqNo(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord.Trim + " E.*, isnull(cs.DetailDesc,'') as EntitiesTypeName FROM Entities E " & _
                                       "LEFT JOIN CommonSetting cs ON cs.GroupId = 'EntitiesType' AND cs.DetailID = E.EntitiesTypeID " & _
                                       "WHERE E.IsDeleted = 0 " & _
                                       "and (EntitiesId LIKE '" + Filter.Trim + "%' OR EntitiesName LIKE '" + Filter.Trim + "%' OR EntitiesSeqNo LIKE '" + Filter.Trim + "') " & _
                                       "ORDER BY E.EntitiesID "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Entities")
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

        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Select Case recStatus
                Case RavenRecStatus.CurrentRecord
                    cmdToExecute.CommandText = "SELECT * FROM Entities WHERE EntitiesSeqNo = @EntitiesSeqNo"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM Entities WHERE EntitiesSeqNo > @EntitiesSeqNo ORDER BY EntitiesSeqNo ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM Entities WHERE EntitiesSeqNo < @EntitiesSeqNo ORDER BY EntitiesSeqNo DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("Entities")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _EntitiesSeqNo = CType(toReturn.Rows(0)("EntitiesSeqNo"), String)
                    _EntitiesID = CType(toReturn.Rows(0)("EntitiesID"), String)
                    _EntitiesName = CType(toReturn.Rows(0)("EntitiesName"), String)
                    _EntitiesTypeID = CType(toReturn.Rows(0)("EntitiesTypeID"), String)
                    _ParentEntitiesSeqNo = CType(toReturn.Rows(0)("ParentEntitiesSeqNo"), String)
                    _RelationshipID = CType(toReturn.Rows(0)("RelationshipID"), String)
                    _TIN = CType(toReturn.Rows(0)("TIN"), String)
                    _PrimaryAddress = CType(toReturn.Rows(0)("PrimaryAddress"), String)
                    _SecondaryAddress1 = CType(toReturn.Rows(0)("SecondaryAddress1"), String)
                    _SecondaryAddress2 = CType(toReturn.Rows(0)("SecondaryAddress2"), String)
                    _ZipCode = CType(toReturn.Rows(0)("ZipCode"), String)
                    _CityID = CType(toReturn.Rows(0)("CityID"), String)
                    _CountryID = CType(toReturn.Rows(0)("CountryID"), String)
                    _PrimaryPhoneNo = CType(toReturn.Rows(0)("PrimaryPhoneNo"), String)
                    _SecondaryPhoneNo1 = CType(toReturn.Rows(0)("SecondaryPhoneNo1"), String)
                    _SecondaryPhoneNo2 = CType(toReturn.Rows(0)("SecondaryPhoneNo2"), String)
                    _FaxNo = CType(toReturn.Rows(0)("FaxNo"), String)
                    _Email = CType(toReturn.Rows(0)("Email"), String)
                    _Website = CType(toReturn.Rows(0)("Website"), String)
                    _Bank = CType(toReturn.Rows(0)("Bank"), String)
                    _BankAccountNo = CType(toReturn.Rows(0)("BankAccountNo"), String)
                    _BankBranch = CType(toReturn.Rows(0)("BankBranch"), String)
                    _BankAddress = CType(toReturn.Rows(0)("BankAddress"), String)
                    _MaxPOrdAmount = CType(toReturn.Rows(0)("MaxPOrdAmount"), Decimal)
                    _MemberTypeID = CType(toReturn.Rows(0)("MemberTypeID"), String)
                    _MemberNo = CType(toReturn.Rows(0)("MemberNo"), String)
                    _MemberSinceDate = CType(ProcessNull.GetDateTimeTo19000101(toReturn.Rows(0)("MemberSinceDate")), DateTime)
                    _MemberValidThruDate = CType(ProcessNull.GetDateTimeTo19000101(toReturn.Rows(0)("MemberValidThruDate")), DateTime)
                    _Description = CType(toReturn.Rows(0)("Description"), String)
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

            cmdToExecute.CommandText = "SET XACT_ABORT ON " & _
                                       "BEGIN TRAN " & _
                                       "UPDATE Entities " & _
                                       "SET IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = Getdate() " & _
                                       "WHERE EntitiesSeqNo = @EntitiesSeqNo " & _
                                       "UPDATE EntitiesContact " & _
                                       "SET IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = GetDate() " & _
                                       "WHERE EntitiesSeqNo = @EntitiesSeqNo " & _
                                       "COMMIT TRAN"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
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
#End Region

#Region " Custom Function(s) "
        Public Function SelectOneByEntitiesID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT E.*, isnull(cs.DetailDesc,'') AS EntitiesTypeName FROM Entities E " & _
                                       "LEFT JOIN CommonSetting cs ON cs.GroupId = 'EntitiesType' AND cs.DetailID = E.EntitiesTypeID " & _
                                       "WHERE E.IsDeleted = 0 AND EntitiesID = @EntitiesID " & _
                                       "ORDER BY EntitiesID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Entities")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@EntitiesID", _EntitiesID)
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

        Public Function SelectByEntitiesTypeID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT * FROM Entities WHERE EntitiesTypeID = @EntitiesTypeID ORDER BY EntitiesID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Entities")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@EntitiesTypeID", _EntitiesTypeID)
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

        Public Function SelectOneByMemberNo() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT E.*, isnull(cs.DetailDesc,'') AS EntitiesTypeName  FROM Entities E " & _
                                       "LEFT JOIN CommonSetting cs ON cs.GroupId = 'EntitiesType' AND cs.DetailID = E.EntitiesTypeID " & _
                                       "WHERE E.IsActive = 1 AND E.IsDeleted = 0 AND E.MemberNo = @MemberNo " & _
                                       "ORDER BY EntitiesID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Entities")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@MemberNo", _MemberNo)
                _mainConnection.Open()

                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _EntitiesSeqNo = CType(toReturn.Rows(0)("EntitiesSeqNo"), String)
                    _EntitiesID = CType(toReturn.Rows(0)("EntitiesID"), String)
                    _EntitiesName = CType(toReturn.Rows(0)("EntitiesName"), String)
                    _EntitiesTypeID = CType(toReturn.Rows(0)("EntitiesTypeID"), String)
                    _ParentEntitiesSeqNo = CType(toReturn.Rows(0)("ParentEntitiesSeqNo"), String)
                    _RelationshipID = CType(toReturn.Rows(0)("RelationshipID"), String)
                    _TIN = CType(toReturn.Rows(0)("TIN"), String)
                    _PrimaryAddress = CType(toReturn.Rows(0)("PrimaryAddress"), String)
                    _SecondaryAddress1 = CType(toReturn.Rows(0)("SecondaryAddress1"), String)
                    _SecondaryAddress2 = CType(toReturn.Rows(0)("SecondaryAddress2"), String)
                    _ZipCode = CType(toReturn.Rows(0)("ZipCode"), String)
                    _CityID = CType(toReturn.Rows(0)("CityID"), String)
                    _CountryID = CType(toReturn.Rows(0)("CountryID"), String)
                    _PrimaryPhoneNo = CType(toReturn.Rows(0)("PrimaryPhoneNo"), String)
                    _SecondaryPhoneNo1 = CType(toReturn.Rows(0)("SecondaryPhoneNo1"), String)
                    _SecondaryPhoneNo2 = CType(toReturn.Rows(0)("SecondaryPhoneNo2"), String)
                    _FaxNo = CType(toReturn.Rows(0)("FaxNo"), String)
                    _Email = CType(toReturn.Rows(0)("Email"), String)
                    _Website = CType(toReturn.Rows(0)("Website"), String)
                    _Bank = CType(toReturn.Rows(0)("Bank"), String)
                    _BankAccountNo = CType(toReturn.Rows(0)("BankAccountNo"), String)
                    _BankBranch = CType(toReturn.Rows(0)("BankBranch"), String)
                    _BankAddress = CType(toReturn.Rows(0)("BankAddress"), String)
                    _MaxPOrdAmount = CType(toReturn.Rows(0)("MaxPOrdAmount"), Decimal)
                    _MemberTypeID = CType(toReturn.Rows(0)("MemberTypeID"), String)
                    _MemberNo = CType(toReturn.Rows(0)("MemberNo"), String)
                    _MemberSinceDate = CType(ProcessNull.GetDateTimeTo19000101(toReturn.Rows(0)("MemberSinceDate")), DateTime)
                    _MemberValidThruDate = CType(ProcessNull.GetDateTimeTo19000101(toReturn.Rows(0)("MemberValidThruDate")), DateTime)
                    _Description = CType(toReturn.Rows(0)("Description"), String)
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
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Function SelectByFilterEntitiesIDNameMemberNo(ByVal FilterValue As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT * FROM Entities " & _
                                       "WHERE MemberNo like '%" & FilterValue.Trim() & "%' or EntitiesID like '%" & FilterValue.Trim() & "%' or EntitiesName like '%" & FilterValue.Trim() & "%'" & _
                                       "ORDER BY EntitiesName"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Entities")
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

#End Region

#Region " Class Property Declarations "
        Public Property [EntitiesSeqNo]() As String
            Get
                Return _EntitiesSeqNo
            End Get
            Set(ByVal Value As String)
                _EntitiesSeqNo = Value
            End Set
        End Property

        Public Property [EntitiesID]() As String
            Get
                Return _EntitiesID
            End Get
            Set(ByVal Value As String)
                _EntitiesID = Value
            End Set
        End Property

        Public Property [EntitiesName]() As String
            Get
                Return _EntitiesName
            End Get
            Set(ByVal Value As String)
                _EntitiesName = Value
            End Set
        End Property

        Public Property [EntitiesTypeID]() As String
            Get
                Return _EntitiesTypeID
            End Get
            Set(ByVal Value As String)
                _EntitiesTypeID = Value
            End Set
        End Property

        Public Property [ParentEntitiesSeqNo]() As String
            Get
                Return _ParentEntitiesSeqNo
            End Get
            Set(ByVal Value As String)
                _ParentEntitiesSeqNo = Value
            End Set
        End Property

        Public Property [RelationshipID]() As String
            Get
                Return _RelationshipID
            End Get
            Set(ByVal Value As String)
                _RelationshipID = Value
            End Set
        End Property

        Public Property [TIN]() As String
            Get
                Return _TIN
            End Get
            Set(ByVal Value As String)
                _TIN = Value
            End Set
        End Property

        Public Property [PrimaryAddress]() As String
            Get
                Return _PrimaryAddress
            End Get
            Set(ByVal Value As String)
                _PrimaryAddress = Value
            End Set
        End Property

        Public Property [SecondaryAddress1]() As String
            Get
                Return _SecondaryAddress1
            End Get
            Set(ByVal Value As String)
                _SecondaryAddress1 = Value
            End Set
        End Property

        Public Property [SecondaryAddress2]() As String
            Get
                Return _SecondaryAddress2
            End Get
            Set(ByVal Value As String)
                _SecondaryAddress2 = Value
            End Set
        End Property

        Public Property [ZipCode]() As String
            Get
                Return _ZipCode
            End Get
            Set(ByVal Value As String)
                _ZipCode = Value
            End Set
        End Property

        Public Property [CityID]() As String
            Get
                Return _CityID
            End Get
            Set(ByVal Value As String)
                _CityID = Value
            End Set
        End Property

        Public Property [CountryID]() As String
            Get
                Return _CountryID
            End Get
            Set(ByVal Value As String)
                _CountryID = Value
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

        Public Property [FaxNo]() As String
            Get
                Return _FaxNo
            End Get
            Set(ByVal Value As String)
                _FaxNo = Value
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

        Public Property [Website]() As String
            Get
                Return _Website
            End Get
            Set(ByVal Value As String)
                _Website = Value
            End Set
        End Property

        Public Property [Bank]() As String
            Get
                Return _Bank
            End Get
            Set(ByVal Value As String)
                _Bank = Value
            End Set
        End Property

        Public Property [BankAccountNo]() As String
            Get
                Return _BankAccountNo
            End Get
            Set(ByVal Value As String)
                _BankAccountNo = Value
            End Set
        End Property

        Public Property [BankBranch]() As String
            Get
                Return _BankBranch
            End Get
            Set(ByVal Value As String)
                _BankBranch = Value
            End Set
        End Property

        Public Property [BankAddress]() As String
            Get
                Return _BankAddress
            End Get
            Set(ByVal Value As String)
                _BankAddress = Value
            End Set
        End Property

        Public Property [MaxPOrdAmount]() As Decimal
            Get
                Return _MaxPOrdAmount
            End Get
            Set(ByVal Value As Decimal)
                _MaxPOrdAmount = Value
            End Set
        End Property

        Public Property [MemberTypeID]() As String
            Get
                Return _MemberTypeID
            End Get
            Set(ByVal Value As String)
                _MemberTypeID = Value
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

        Public Property [MemberSinceDate]() As DateTime
            Get
                Return _MemberSinceDate
            End Get
            Set(ByVal Value As DateTime)
                _MemberSinceDate = Value
            End Set
        End Property

        Public Property [MemberValidThruDate]() As DateTime
            Get
                Return _MemberValidThruDate
            End Get
            Set(ByVal Value As DateTime)
                _MemberValidThruDate = Value
            End Set
        End Property

        Public Property [MemberNo]() As String
            Get
                Return _MemberNo
            End Get
            Set(ByVal Value As String)
                _MemberNo = Value
            End Set
        End Property

#End Region

    End Class
End Namespace
