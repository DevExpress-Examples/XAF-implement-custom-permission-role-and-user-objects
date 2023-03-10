using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySolutionXPO.Module.Security {
    [DefaultClassOptions, ImageName("BO_Role")]
    public class ExtendedSecurityRole : PermissionPolicyRole {
        public ExtendedSecurityRole(Session session) : base(session) { }
        public bool CanExport {
            get { return GetPropertyValue<bool>(nameof(CanExport)); }
            set { SetPropertyValue<bool>(nameof(CanExport), value); }
        }
    }
}
