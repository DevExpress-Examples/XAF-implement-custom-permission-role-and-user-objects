using DevExpress.ExpressApp.Security;
using System;
using System.Linq;

namespace MySolutionXPO.Module.Security {
    public class ExportPermissionRequest : IPermissionRequest {
        public object GetHashObject() {
            return GetType().FullName;
        }
    }
}
