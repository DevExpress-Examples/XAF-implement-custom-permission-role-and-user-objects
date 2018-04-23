Imports System
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Web

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Web
Imports DevExpress.Web
Imports SecuredExportExample.Module.SecurityObjects
Imports System.Collections.Generic
Imports SecuredExportExample.Module.BusinessObjects

Namespace SecuredExportExample.Web
    Public Class [Global]
        Inherits System.Web.HttpApplication

        Public Sub New()
            InitializeComponent()
        End Sub
        Protected Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
            AddHandler ASPxWebControl.CallbackError, AddressOf Application_Error
#If EASYTEST Then
            DevExpress.ExpressApp.Web.TestScripts.TestScriptsManager.EasyTestEnabled = True
#End If
        End Sub
        Protected Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
            WebApplication.SetInstance(Session, New SecuredExportExampleAspNetApplication())
            InMemoryDataStoreProvider.Register()
            WebApplication.Instance.ConnectionString = InMemoryDataStoreProvider.ConnectionString
            AddHandler CType(WebApplication.Instance.Security, SecurityStrategy).CustomizeRequestProcessors, Sub(s As Object, args As CustomizeRequestProcessorsEventArgs)
                    Dim result As New List(Of IOperationPermission)()
                    Dim security As SecurityStrategyComplex = TryCast(s, SecurityStrategyComplex)
                    If security IsNot Nothing Then
                        Dim user As Employee = TryCast(security.User, Employee)
                        If user IsNot Nothing Then
                            For Each role As ExtendedSecurityRole In user.Roles
                                If role.CanExport Then
                                    result.Add(New ExportPermission())
                                End If
                            Next role
                        End If
                    End If
                    Dim permissionDictionary As IPermissionDictionary = New PermissionDictionary(DirectCast(result, IEnumerable(Of IOperationPermission)))
                    args.Processors.Add(GetType(ExportPermissionRequest), New ExportPermissionRequestProcessor(permissionDictionary))
            End Sub
            WebApplication.Instance.Setup()
            WebApplication.Instance.Start()
        End Sub
        Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
            Dim filePath As String = HttpContext.Current.Request.PhysicalPath
            If Not String.IsNullOrEmpty(filePath) AndAlso (filePath.IndexOf("Images") >= 0) AndAlso Not System.IO.File.Exists(filePath) Then
                HttpContext.Current.Response.End()
            End If
        End Sub
        Protected Sub Application_EndRequest(ByVal sender As Object, ByVal e As EventArgs)
        End Sub
        Protected Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        End Sub
        Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
            ErrorHandling.Instance.ProcessApplicationError()
        End Sub
        Protected Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
            WebApplication.LogOff(Session)
            WebApplication.DisposeInstance(Session)
        End Sub
        Protected Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        End Sub
        #Region "Web Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
        End Sub
        #End Region
    End Class
End Namespace
