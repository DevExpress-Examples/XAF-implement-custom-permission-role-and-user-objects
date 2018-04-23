using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Security;
using System.Collections.Generic;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;

namespace SecuredExportExample.Module.SecurityObjects {
    [DefaultClassOptions, ImageName("BO_Role")]
    public class ExtendedSecurityRole : PermissionPolicyRole {
        public ExtendedSecurityRole(Session session) : base(session) { }
        public bool CanExport {
            get { return GetPropertyValue<bool>("CanExport"); }
            set { SetPropertyValue<bool>("CanExport", value); }
        }
        /*
        protected override IEnumerable<IOperationPermission> GetPermissionsCore() {
            List<IOperationPermission> result = new List<IOperationPermission>();
            result.AddRange(base.GetPermissionsCore());
            if (CanExport) result.Add(new ExportPermission());
            return result;
        }*/
    }
}
