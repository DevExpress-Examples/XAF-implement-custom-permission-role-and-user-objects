using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.SystemModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MySolutionXPO.Module.Security {
    public class ExportPermission : IOperationPermission {
        public string Operation {
            get { return "Export"; }
        }
    }
    public class ExportPermissionRequest : IPermissionRequest {
        public object GetHashObject() {
            return this.GetType().FullName;
        }
    }
    public class ExportPermissionRequestProcessor :
    PermissionRequestProcessorBase<ExportPermissionRequest> {
        private IPermissionDictionary permissions;
        public ExportPermissionRequestProcessor(IPermissionDictionary permissions) {
            this.permissions = permissions;
        }
        public override bool IsGranted(ExportPermissionRequest permissionRequest) {
            return (permissions.FindFirst<ExportPermission>() != null);
        }
    }
    public class SecuredExportController : ViewController {
        protected override void OnActivated() {
            base.OnActivated();
            ExportController controller = Frame.GetController<ExportController>();
            if (controller != null) {
                controller.ExportAction.Executing += ExportAction_Executing;
                if (SecuritySystem.Instance is IRequestSecurity) {
                    controller.Active.SetItemValue("Security",
                        Application.GetSecurityStrategy().IsGranted(new ExportPermissionRequest()));
                }
            }
        }
        void ExportAction_Executing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (!Application.GetSecurityStrategy().IsGranted(new ExportPermissionRequest())) {
                throw new UserFriendlyException("Export operation is prohibited.");
            }
        }
    }
}
