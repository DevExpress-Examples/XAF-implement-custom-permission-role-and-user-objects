Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.ExpressApp.Security.ClientServer
Imports DevExpress.ExpressApp.Security

Namespace SecuredExportExample.Web
    Partial Public Class SecuredExportExampleAspNetApplication
        Inherits WebApplication

        Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
        Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
        Private module3 As SecuredExportExample.Module.SecuredExportExampleModule
        Private securityModule1 As DevExpress.ExpressApp.Security.SecurityModule
        Private module6 As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
        Private sqlConnection1 As System.Data.SqlClient.SqlConnection
        Private authenticationStandard1 As DevExpress.ExpressApp.Security.AuthenticationStandard
        Private securityStrategyComplex1 As DevExpress.ExpressApp.Security.SecurityStrategyComplex
        Private module5 As DevExpress.ExpressApp.Validation.ValidationModule

        Public Sub New()
            InitializeComponent()
        End Sub
        Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
            args.ObjectSpaceProvider = New SecuredObjectSpaceProvider(CType(Security, SecurityStrategy), ConnectionString, Connection)
        End Sub
        Private Sub SecuredExportExampleAspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles Me.DatabaseVersionMismatch
            e.Updater.Update()
            e.Handled = True
        End Sub

        Private Sub InitializeComponent()
            Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
            Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
            Me.module3 = New SecuredExportExample.Module.SecuredExportExampleModule()
            Me.module5 = New DevExpress.ExpressApp.Validation.ValidationModule()
            Me.module6 = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
            Me.securityModule1 = New DevExpress.ExpressApp.Security.SecurityModule()
            Me.sqlConnection1 = New System.Data.SqlClient.SqlConnection()
            Me.authenticationStandard1 = New DevExpress.ExpressApp.Security.AuthenticationStandard()
            Me.securityStrategyComplex1 = New DevExpress.ExpressApp.Security.SecurityStrategyComplex()
            DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            ' 
            ' module5
            ' 
            Me.module5.AllowValidationDetailsAccess = True
            ' 
            ' sqlConnection1
            ' 
            Me.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=SecuredExportExample;Integrated Security=SSPI" & ";Pooling=false"
            Me.sqlConnection1.FireInfoMessageEventOnUserErrors = False
            ' 
            ' authenticationStandard1
            ' 
            Me.authenticationStandard1.LogonParametersType = GetType(DevExpress.ExpressApp.Security.AuthenticationStandardLogonParameters)
            ' 
            ' securityStrategyComplex1
            ' 
            Me.securityStrategyComplex1.Authentication = Me.authenticationStandard1
            Me.securityStrategyComplex1.RoleType = GetType(SecuredExportExample.Module.SecurityObjects.ExtendedSecurityRole)
            Me.securityStrategyComplex1.UserType = GetType(SecuredExportExample.Module.BusinessObjects.Employee)
            ' 
            ' SecuredExportExampleAspNetApplication
            ' 
            Me.ApplicationName = "SecuredExportExample"
            Me.Connection = Me.sqlConnection1
            Me.Modules.Add(Me.module1)
            Me.Modules.Add(Me.module2)
            Me.Modules.Add(Me.module6)
            Me.Modules.Add(Me.securityModule1)
            Me.Modules.Add(Me.module3)
            Me.Modules.Add(Me.module5)
            Me.Security = Me.securityStrategyComplex1
            DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
    End Class
End Namespace
