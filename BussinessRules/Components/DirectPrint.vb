Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class DirectPrint
        Inherits BRInteractionBase

        Public Enum myPaperOrientation
            Portrait = 0
            Landscape = 1
        End Enum

#Region " Class Member Declarations "
        Private _PrinterName As String
#End Region

        '        Public Sub New()
        '            ' // Nothing for now.
        '        End Sub

        '        Public Sub New(ByVal strConnectionString As String)
        '            ConnectionString = strConnectionString
        '        End Sub

        Public Function DirectPrintCR(ByVal ds As DataSet, ByVal ReportPath As String,
        ByVal mPaperSize As String,
        Optional ByVal NumberOFCopies As Integer = 1,
        Optional ByVal Collated As Boolean = False,
        Optional ByVal StartPage As Integer = 0,
        Optional ByVal EndPage As Integer = 0,
        Optional ByVal mPaperOrientation As myPaperOrientation = myPaperOrientation.Portrait) As Boolean
            Try
                'Dim oRpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                'Dim repOptions As CrystalDecisions.CrystalReports.Engine.PrintOptions
                'With oRpt
                '    repOptions = .PrintOptions
                '    With repOptions
                '        .PrinterName = PrinterName
                '        Select Case mPaperOrientation
                '            Case myPaperOrientation.Landscape
                '                .PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
                '            Case myPaperOrientation.Portrait
                '                .PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
                '        End Select
                '        .PaperSize = GetPapersizeID(Me.PrinterName, mPaperSize)
                '    End With
                '    .Load(ReportPath, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                '    .SetDataSource(ds.Tables(0))
                '    .PrintToPrinter(NumberOFCopies, Collated, StartPage, EndPage)
                'End With

                Return True
            Catch ex As Exception
                ' Just do nothing here
                Return False
            End Try
        End Function

        Private Function GetPapersizeID(ByVal PrinterName As String, ByVal PaperSizeName As String) As Integer
            Dim doctoprint As New System.Drawing.Printing.PrintDocument()
            Dim PaperSizeID As Integer = 0
            Dim ppname As String = ""
            Dim s As String = ""
            doctoprint.PrinterSettings.PrinterName = PrinterName '(ex."EpsonSQ-1170ESC/P2")
            For i As Integer = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
                Dim rawKind As Integer
                ppname = PaperSizeName
                If doctoprint.PrinterSettings.PaperSizes(i).PaperName = ppname Then
                    rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", _
                    Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
                    PaperSizeID = rawKind
                    Exit For
                End If
            Next
            Return PaperSizeID
        End Function

#Region " Class Property Declarations "
        Public Property [PrinterName]() As String
            Get
                Return _PrinterName
            End Get
            Set(value As String)
                _PrinterName = value
            End Set
        End Property
#End Region

    End Class
End Namespace
