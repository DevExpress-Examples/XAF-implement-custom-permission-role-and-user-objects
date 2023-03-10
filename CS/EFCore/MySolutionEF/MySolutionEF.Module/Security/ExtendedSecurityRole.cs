using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;

using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySolutionXPO.Module.Security {
    [DefaultClassOptions, ImageName("BO_Role")]
    public class ExtendedSecurityRole : PermissionPolicyRole {
        public virtual bool CanExport { get; set; }
    }
}
