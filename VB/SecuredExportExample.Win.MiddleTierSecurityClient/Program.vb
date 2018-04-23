Imports System
Imports System.Configuration
Imports System.Windows.Forms

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Win
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports SecuredExportExample.Module.SecurityObjects
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.ExpressApp.Security.ClientServer.Wcf
Imports DevExpress.ExpressApp.Security.ClientServer
Imports System.ServiceModel

Namespace SecuredExportExample.Win
    Friend NotInheritable Class Program

        Private Sub New()
        End Sub

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread> _
        Shared Sub Main()
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached
            Dim winApplication As New SecuredExportExampleWindowsFormsApplication()
#If EASYTEST Then
            DevExpress.ExpressApp.Win.EasyTest.EasyTestRemotingRegistration.Register()
            Dim serverProcess = New System.Diagnostics.Process()
            serverProcess.StartInfo.FileName = "..\..\..\SecuredExportExample.MiddleTierSecurityServer\bin\EasyTest\SecuredExportExample.MiddleTierSecurityServer.exe"
            serverProcess.Start()
            System.Threading.Thread.Sleep(5000)
#End If
            Try

                WcfDataServerHelper.AddKnownType(GetType(ExportPermissionRequest))
                winApplication.ConnectionString = "net.tcp://127.0.0.1:1451/DataServer"
                winApplication.DatabaseUpdateMode = DatabaseUpdateMode.Never
                Dim wcfSecuredClient As New WcfSecuredClient(WcfDataServerHelper.CreateNetTcpBinding(), New EndpointAddress(winApplication.ConnectionString))
                Dim securityClient As New MiddleTierClientSecurity(wcfSecuredClient)
                securityClient.IsSupportChangePassword = True
                winApplication.ApplicationName = "SecuredExportExample"
                winApplication.Security = securityClient
                AddHandler winApplication.CreateCustomObjectSpaceProvider, Sub(s, e)
                    e.ObjectSpaceProvider = New MiddleTierServerObjectSpaceProvider(wcfSecuredClient)
                End Sub
                winApplication.Setup()
                winApplication.Start()
                wcfSecuredClient.Dispose()
            Catch e As Exception
                winApplication.HandleException(e)
            End Try
        End Sub

    End Class
End Namespace
