Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.ExpressApp.Security

Namespace SecuredExportExample.Module.SecurityObjects
    Public Class ExportPermission
        Implements IOperationPermission

        Public ReadOnly Property Operation() As String Implements IOperationPermission.Operation
            Get
                Return "Export"
            End Get
        End Property
    End Class
    Public Class ExportPermissionRequest
        Implements IPermissionRequest

        Public Sub New()
        End Sub
        Public Function GetHashObject() As Object Implements IPermissionRequest.GetHashObject
            Return Me.GetType().FullName
        End Function
    End Class
    Public Class ExportPermissionRequestProcessor
        Inherits PermissionRequestProcessorBase(Of ExportPermissionRequest)

        Private permissions As IPermissionDictionary
        Public Sub New(ByVal permissions As IPermissionDictionary)
            Me.permissions = permissions
        End Sub
        Public Overrides Function IsGranted(ByVal permissionRequest As ExportPermissionRequest) As Boolean
            Return (permissions.FindFirst(Of ExportPermission)() IsNot Nothing)
        End Function
    End Class
End Namespace
