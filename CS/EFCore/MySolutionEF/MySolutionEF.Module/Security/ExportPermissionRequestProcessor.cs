using DevExpress.ExpressApp.Security;
using System;
using System.Linq;

namespace MySolutionXPO.Module.Security {
    public class ExportPermissionRequestProcessor :
    PermissionRequestProcessorBase<ExportPermissionRequest> {
        private IPermissionDictionary permissions;
        public ExportPermissionRequestProcessor(IPermissionDictionary permissions) {
            this.permissions = permissions;
        }
        public override bool IsGranted(ExportPermissionRequest permissionRequest) {
            return permissions.FindFirst<ExportPermission>() != null;
        }
    }
}
