using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.ExpressApp.Security;

namespace SecuredExportExample.Module.SecurityObjects {
    public class ExportPermission : IOperationPermission {
        public string Operation {
            get { return "Export"; }
        }
    }    
    public class ExportPermissionRequest : IPermissionRequest {
        public ExportPermissionRequest() {}
        public object GetHashObject() {
            return GetType().FullName;
        }
    }
    public class ExportPermissionRequestProcessor : PermissionRequestProcessorBase<ExportPermissionRequest> {
        private IPermissionDictionary permissions;
        public ExportPermissionRequestProcessor(IPermissionDictionary permissions) {
            this.permissions = permissions;
        }
        public override bool IsGranted(ExportPermissionRequest permissionRequest) {
            return (permissions.FindFirst<ExportPermission>() != null);
        }
    }
}
