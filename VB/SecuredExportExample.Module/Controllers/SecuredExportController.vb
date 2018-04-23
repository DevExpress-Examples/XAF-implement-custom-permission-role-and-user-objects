Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.SystemModule
Imports SecuredExportExample.Module.SecurityObjects

Namespace SecuredExportExample.Module.Controllers
    Public Class SecuredExportController
        Inherits ViewController

        Protected Overrides Sub OnActivated()
            MyBase.OnActivated()
            Dim controller As ExportController = Frame.GetController(Of ExportController)()
            If controller IsNot Nothing Then
                AddHandler controller.ExportAction.Executing, AddressOf ExportAction_Executing
                If TypeOf SecuritySystem.Instance Is IRequestSecurity Then
                    controller.Active.SetItemValue("Security", SecuritySystem.IsGranted(New ExportPermissionRequest()))
                End If
            End If
        End Sub
        Private Sub ExportAction_Executing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
            SecuritySystem.Demand(New ExportPermissionRequest())
        End Sub
    End Class
End Namespace
