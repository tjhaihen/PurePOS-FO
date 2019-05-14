Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class Company
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ID, _CompanyName, _PrimaryAddress, _SecondaryAddress, _City, _Country, _ZipCode As String
        Private _PrimaryPhoneNo, _SecondaryPhoneNo1, _SecondaryPhoneNo2, _FaxNo, _Email, _Website, _TIN, _LegalNo, _DirectorName As String
        Private _CustomFooterText As String
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sp_Company"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("Company")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try                
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _ID = CType(toReturn.Rows(0)("ID"), String)
                    _CompanyName = CType(toReturn.Rows(0)("CompanyName"), String)
                    _PrimaryAddress = CType(toReturn.Rows(0)("PrimaryAddress"), String)
                    _SecondaryAddress = CType(toReturn.Rows(0)("SecondaryAddress"), String)
                    _City = CType(toReturn.Rows(0)("City"), String)
                    _Country = CType(toReturn.Rows(0)("Country"), String)
                    _ZipCode = CType(toReturn.Rows(0)("ZipCode"), String)
                    _PrimaryPhoneNo = CType(toReturn.Rows(0)("PrimaryPhoneNo"), String)
                    _SecondaryPhoneNo1 = CType(toReturn.Rows(0)("SecondaryPhoneNo1"), String)
                    _SecondaryPhoneNo2 = CType(toReturn.Rows(0)("SecondaryPhoneNo2"), String)
                    _FaxNo = CType(toReturn.Rows(0)("FaxNo"), String)
                    _Email = CType(toReturn.Rows(0)("Email"), String)
                    _Website = CType(toReturn.Rows(0)("Website"), String)
                    _TIN = CType(toReturn.Rows(0)("TIN"), String)
                    _LegalNo = CType(toReturn.Rows(0)("LegalNo"), String)
                    _DirectorName = CType(toReturn.Rows(0)("DirectorName"), String)
                    _CustomFooterText = CType(toReturn.Rows(0)("CustomFooterText"), String)
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

#Region " Class Property Declarations "
        Public Property [ID]() As String
            Get
                Return _ID
            End Get
            Set(ByVal Value As String)
                _ID = Value
            End Set
        End Property

        Public Property [CompanyName]() As String
            Get
                Return _CompanyName
            End Get
            Set(ByVal Value As String)
                _CompanyName = Value
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

        Public Property [SecondaryAddress]() As String
            Get
                Return _SecondaryAddress
            End Get
            Set(ByVal Value As String)
                _SecondaryAddress = Value
            End Set
        End Property

        Public Property [City]() As String
            Get
                Return _City
            End Get
            Set(ByVal Value As String)
                _City = Value
            End Set
        End Property

        Public Property [Country]() As String
            Get
                Return _Country
            End Get
            Set(ByVal Value As String)
                _Country = Value
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

        Public Property [TIN]() As String
            Get
                Return _TIN
            End Get
            Set(ByVal Value As String)
                _TIN = Value
            End Set
        End Property

        Public Property [LegalNo]() As String
            Get
                Return _LegalNo
            End Get
            Set(ByVal Value As String)
                _LegalNo = Value
            End Set
        End Property

        Public Property [DirectorName]() As String
            Get
                Return _DirectorName
            End Get
            Set(ByVal Value As String)
                _DirectorName = Value
            End Set
        End Property

        Public Property [CustomFooterText]() As String
            Get
                Return _CustomFooterText
            End Get
            Set(ByVal Value As String)
                _CustomFooterText = Value
            End Set
        End Property

#End Region

    End Class
End Namespace
