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
Imports System.Collections.Generic
Imports SecuredExportExample.Module.BusinessObjects

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
#End If
            Try
                InMemoryDataStoreProvider.Register()
                winApplication.ConnectionString = InMemoryDataStoreProvider.ConnectionString
                AddHandler CType(winApplication.Security, SecurityStrategy).CustomizeRequestProcessors, Sub(sender As Object, e As CustomizeRequestProcessorsEventArgs)
                        Dim result As New List(Of IOperationPermission)()
                        Dim security As SecurityStrategyComplex = TryCast(sender, SecurityStrategyComplex)
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
                        e.Processors.Add(GetType(ExportPermissionRequest), New ExportPermissionRequestProcessor(permissionDictionary))
                End Sub
                winApplication.Setup()
                winApplication.Start()
            Catch e As Exception
                winApplication.HandleException(e)
            End Try
        End Sub

    End Class
End Namespace
