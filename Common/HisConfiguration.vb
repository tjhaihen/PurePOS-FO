
Option Strict On
Option Explicit On 

Imports System
Imports System.Collections
Imports System.Configuration

Imports Raven.SystemFramework
Imports System.Collections.Specialized

Namespace Raven.Common

    ' Description: This class handles Hospital Information System-specific configuration settings in Config.Web.
    Public Class HisConfiguration
        Implements IConfigurationSectionHandler

        Private Const WEB_ENABLEPAGECACHE As String = "Raven.Web.EnablePageCache"
        Private Const WEB_PAGECACHEEXPIRESINSECONDS As String = "Raven.Web.PageCacheExpiresInSeconds"
        Private Const WEB_ENABLESSL As String = "Raven.Web.EnableSsl"
        Private Const DATAACCESS_CONNECTIONSTRING As String = "Raven.DataAccess.ConnectionString"
        Private Const DATAACCESS_CONFIGURATION_CONNECTIONSTRING As String = "Raven.DataAccess.ConnectionString"
        Private Const KODE_CABANG As String = "Raven.Web.KodeCabang"
        Private Const APP_ID As String = "Raven.Web.AppId"
        Private Const REPORTS_FOLDER As String = "Raven.Web.ReportsFolder"
        Private Const MODULE_APPL As String = "Raven.Web.ModuleAppl"
        Private Const MODULE_APPLCL As String = "Raven.Web.ModuleApplCl"

        Private Const WEB_SETTINGVARIABLE_FONTSIZE As String = "Raven.Web.SetVar.FontSize"
        Private Const WEB_SETTINGVARIABLE_FONTNAME As String = "Raven.Web.SetVar.FontName"
        Private Const WEB_SETTINGVARIABLE_CETAKKWITANSIOTOMATIS As String = "Raven.Web.SetVar.CetakKwitansiOtomatis"

        Private Const WEB_SETTINGVARIABLE_URLLABMD As String = "Raven.Web.SetVar.UrlLabMD"

        Private Const WEB_SETTINGVARIABLE_STBAYARPELUNASAN As String = "Raven.Web.SetVar.StBayarPelunasan"
        Private Const WEB_SETTINGVARIABLE_STBAYARPP As String = "Raven.Web.SetVar.StBayarPP"
        Private Const WEB_SETTINGVARIABLE_STBAYARPI As String = "Raven.Web.SetVar.StBayarPI"

        Private Shared fieldConnectionString As String
        Private Shared fieldConfigurationConnectionString As String
        Private Shared fieldPageCacheExpiresInSeconds As Integer
        Private Shared fieldEnablePageCache As Boolean
        Private Shared fieldEnableSsl As Boolean
        Private Shared fieldKodeCabang As String
        Private Shared fieldReportsFolder As String
        Private Shared fieldAppId As String
        Private Shared fieldModuleAppl As String
        Private Shared fieldModuleApplCl As String
        Private Shared fieldSetVarReportsAppl As String

        Private Shared fieldSetVarFontSize As String
        Private Shared fieldSetVarFontName As String
        Private Shared fieldSetVarCetakKwitansiOtomatis As Boolean
        Private Shared fieldSetVarUrlLabMD As String
        Private Shared fieldSetVarStBayarPelunasan As String
        Private Shared fieldSetVarStBayarPP As String
        Private Shared fieldSetVarStBayarPI As String
        ' Constant values for all of the default settings.
        '
        Private Const WEB_ENABLEPAGECACHE_DEFAULT As Boolean = True
        Private Const WEB_PAGECACHEEXPIRESINSECONDS_DEFAULT As Integer = 3600
        Private Const DATAACCESS_CONNECTIONSTRING_DEFAULT As String = "server=.\SQLSVR2008; User ID=sa;pwd=p455w0rd.;database=POS"
        Private Const DATAACCESS_CONFIGURATION_CONNECTIONSTRING_DEFAULT As String = "server=.\SQLSVR2K8; User ID=sa;pwd=p455w0rd.;database=temp"
        Private Const WEB_ENABLESSL_DEFAULT As Boolean = False
        Private Const KODE_CABANG_DEFAULT As String = ""
        Private Const REPORTS_FOLDER_DEFAULT As String = "/Reports/RSV2/"
        Private Const APP_ID_DEFAULT As String = "AT_"
        Private Const MODULE_APPL_DEFAULT As String = "/RSV2/rj_/"
        Private Const MODULE_APPLCL_DEFAULT As String = "/RSV2/rj_/"

        Private Const WEB_SETTINGVARIABLE_FONTSIZE_DEFAULT As String = "10"
        Private Const WEB_SETTINGVARIABLE_FONTNAME_DEFAULT As String = "Arial"
        Private Const WEB_SETTINGVARIABLE_CETAKKWITANSIOTOMATIS_DEFAULT As Boolean = False
        Private Const WEB_SETTINGVARIABLE_URLLABMD_DEFAULT As String = "RawatJalanKasir/Transaksi.htm"

        Private Const WEB_SETTINGVARIABLE_STBAYARPELUNASAN_DEFAULT As String = "01"
        Private Const WEB_SETTINGVARIABLE_STBAYARPP_DEFAULT As String = "03"
        Private Const WEB_SETTINGVARIABLE_STBAYARPI_DEFAULT As String = "04"

        '
        ' overloaded from IConfigurationSectionHandler
        '
        Public Function Create(ByVal parent As Object, ByVal configContext As Object, ByVal input As Xml.XmlNode) As Object _
        Implements IConfigurationSectionHandler.Create

            Dim settings As NameValueCollection

            Try
                Dim baseHandler As NameValueSectionHandler
                baseHandler = New NameValueSectionHandler
                settings = CType(baseHandler.Create(parent, configContext, input), NameValueCollection)
            Catch
            End Try

            If settings Is Nothing Then
                fieldConnectionString = DATAACCESS_CONNECTIONSTRING_DEFAULT
                fieldConfigurationConnectionString = DATAACCESS_CONFIGURATION_CONNECTIONSTRING_DEFAULT
                fieldPageCacheExpiresInSeconds = WEB_PAGECACHEEXPIRESINSECONDS_DEFAULT
                fieldEnablePageCache = WEB_ENABLEPAGECACHE_DEFAULT
                fieldEnableSsl = WEB_ENABLESSL_DEFAULT
                fieldKodeCabang = KODE_CABANG_DEFAULT
                fieldReportsFolder = REPORTS_FOLDER_DEFAULT
                fieldAppId = APP_ID_DEFAULT
                fieldModuleAppl = MODULE_APPL_DEFAULT
                fieldModuleApplCl = MODULE_APPLCL_DEFAULT

                fieldSetVarStBayarPelunasan = WEB_SETTINGVARIABLE_STBAYARPELUNASAN_DEFAULT
                fieldSetVarStBayarPP = WEB_SETTINGVARIABLE_STBAYARPP_DEFAULT
                fieldSetVarStBayarPI = WEB_SETTINGVARIABLE_STBAYARPI_DEFAULT

                fieldSetVarFontSize = WEB_SETTINGVARIABLE_FONTSIZE_DEFAULT
                fieldSetVarFontName = WEB_SETTINGVARIABLE_FONTNAME_DEFAULT
                fieldSetVarCetakKwitansiOtomatis = WEB_SETTINGVARIABLE_CETAKKWITANSIOTOMATIS_DEFAULT
                fieldSetVarUrlLabMD = WEB_SETTINGVARIABLE_URLLABMD_DEFAULT
            Else
                fieldConnectionString = ApplicationConfiguration.ReadSetting(settings, DATAACCESS_CONNECTIONSTRING, DATAACCESS_CONNECTIONSTRING_DEFAULT)
                fieldConfigurationConnectionString = ApplicationConfiguration.ReadSetting(settings, DATAACCESS_CONFIGURATION_CONNECTIONSTRING, DATAACCESS_CONFIGURATION_CONNECTIONSTRING_DEFAULT)
                fieldPageCacheExpiresInSeconds = ApplicationConfiguration.ReadSetting(settings, WEB_PAGECACHEEXPIRESINSECONDS, WEB_PAGECACHEEXPIRESINSECONDS_DEFAULT)
                fieldEnablePageCache = ApplicationConfiguration.ReadSetting(settings, WEB_ENABLEPAGECACHE, WEB_ENABLEPAGECACHE_DEFAULT)
                fieldEnableSsl = ApplicationConfiguration.ReadSetting(settings, WEB_ENABLESSL, WEB_ENABLESSL_DEFAULT)
                fieldKodeCabang = ApplicationConfiguration.ReadSetting(settings, KODE_CABANG, KODE_CABANG_DEFAULT)
                fieldReportsFolder = ApplicationConfiguration.ReadSetting(settings, REPORTS_FOLDER, REPORTS_FOLDER_DEFAULT)
                fieldAppId = ApplicationConfiguration.ReadSetting(settings, APP_ID, APP_ID_DEFAULT)
                fieldModuleAppl = ApplicationConfiguration.ReadSetting(settings, MODULE_APPL, MODULE_APPL_DEFAULT)
                fieldModuleApplCl = ApplicationConfiguration.ReadSetting(settings, MODULE_APPLCL, MODULE_APPLCL_DEFAULT)

                fieldSetVarStBayarPelunasan = ApplicationConfiguration.ReadSetting(settings, WEB_SETTINGVARIABLE_STBAYARPELUNASAN, WEB_SETTINGVARIABLE_STBAYARPELUNASAN_DEFAULT)
                fieldSetVarStBayarPP = ApplicationConfiguration.ReadSetting(settings, WEB_SETTINGVARIABLE_STBAYARPP, WEB_SETTINGVARIABLE_STBAYARPP_DEFAULT)
                fieldSetVarStBayarPI = ApplicationConfiguration.ReadSetting(settings, WEB_SETTINGVARIABLE_STBAYARPI, WEB_SETTINGVARIABLE_STBAYARPI_DEFAULT)

                fieldSetVarFontSize = ApplicationConfiguration.ReadSetting(settings, WEB_SETTINGVARIABLE_FONTSIZE, WEB_SETTINGVARIABLE_FONTSIZE_DEFAULT)
                fieldSetVarFontName = ApplicationConfiguration.ReadSetting(settings, WEB_SETTINGVARIABLE_FONTNAME, WEB_SETTINGVARIABLE_FONTNAME_DEFAULT)
                fieldSetVarCetakKwitansiOtomatis = ApplicationConfiguration.ReadSetting(settings, WEB_SETTINGVARIABLE_CETAKKWITANSIOTOMATIS, WEB_SETTINGVARIABLE_CETAKKWITANSIOTOMATIS_DEFAULT)

                fieldSetVarUrlLabMD = ApplicationConfiguration.ReadSetting(settings, WEB_SETTINGVARIABLE_URLLABMD, WEB_SETTINGVARIABLE_URLLABMD_DEFAULT)
            End If


        End Function

        Public Shared ReadOnly Property EnablePageCache() As Boolean
            Get
                EnablePageCache = fieldEnablePageCache
            End Get
        End Property

        Public Shared ReadOnly Property PageCacheExpiresInSeconds() As Integer
            Get
                PageCacheExpiresInSeconds = fieldPageCacheExpiresInSeconds
            End Get
        End Property

        Public Shared ReadOnly Property SetVar_ReportsAppl() As String
            Get
                SetVar_ReportsAppl = fieldSetVarReportsAppl
            End Get
        End Property

        '
        '   The database connection string 
        '
        Public Shared ReadOnly Property ConnectionString() As String
            Get
                ConnectionString = fieldConnectionString
            End Get
        End Property
        Public Shared ReadOnly Property ConfigurationConnectionString() As String
            Get
                ConfigurationConnectionString = fieldConfigurationConnectionString
            End Get
        End Property


        Public Shared ReadOnly Property EnableSsl() As Boolean
            Get
                EnableSsl = fieldEnableSsl
            End Get
        End Property

        Public Shared ReadOnly Property KodeCabang() As String
            Get
                KodeCabang = fieldKodeCabang
            End Get
        End Property

        Public Shared ReadOnly Property ReportsFolder() As String
            Get
                ReportsFolder = fieldReportsFolder
            End Get
        End Property

        Public Shared ReadOnly Property AppId() As String
            Get
                AppId = fieldAppId
            End Get
        End Property

        Public Shared ReadOnly Property ModuleAppl() As String
            Get
                ModuleAppl = fieldModuleAppl
            End Get
        End Property

        Public Shared ReadOnly Property ModuleApplCl() As String
            Get
                ModuleApplCl = fieldModuleApplCl
            End Get
        End Property

        Public Shared ReadOnly Property SetVar_StBayarPelunasan() As String
            Get
                SetVar_StBayarPelunasan = fieldSetVarStBayarPelunasan
            End Get
        End Property

        Public Shared ReadOnly Property SetVar_StBayarPP() As String
            Get
                SetVar_StBayarPP = fieldSetVarStBayarPP
            End Get
        End Property

        Public Shared ReadOnly Property SetVar_StBayarPI() As String
            Get
                SetVar_StBayarPI = fieldSetVarStBayarPI
            End Get
        End Property

        Public Shared ReadOnly Property SetVar_FontSize() As String
            Get
                SetVar_FontSize = fieldSetVarFontSize
            End Get
        End Property

        Public Shared ReadOnly Property SetVar_Fontname() As String
            Get
                SetVar_Fontname = fieldSetVarFontName
            End Get
        End Property


        Public Shared ReadOnly Property SetVar_CetakKwitansiOtomatis() As Boolean
            Get
                Return fieldSetVarCetakKwitansiOtomatis
            End Get
        End Property

        Public Shared ReadOnly Property SetVar_UrlLabMD() As String
            Get
                Return fieldSetVarUrlLabMD
            End Get
        End Property
    End Class

End Namespace
