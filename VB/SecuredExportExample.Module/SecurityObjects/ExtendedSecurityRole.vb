Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.Security
Imports System.Collections.Generic
Imports DevExpress.Persistent.BaseImpl.PermissionPolicy

Namespace SecuredExportExample.Module.SecurityObjects
    <DefaultClassOptions, ImageName("BO_Role")> _
    Public Class ExtendedSecurityRole
        Inherits PermissionPolicyRole

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Property CanExport() As Boolean
            Get
                Return GetPropertyValue(Of Boolean)("CanExport")
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("CanExport", value)
            End Set
        End Property
'        
'        protected override IEnumerable<IOperationPermission> GetPermissionsCore() {
'            List<IOperationPermission> result = new List<IOperationPermission>();
'            result.AddRange(base.GetPermissionsCore());
'            if (CanExport) result.Add(new ExportPermission());
'            return result;
'        }
    End Class
End Namespace
