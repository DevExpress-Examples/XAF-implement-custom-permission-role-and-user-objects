using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.SystemModule;
using System;
using System.Linq;

namespace MySolutionXPO.Module.Security {
    public class SecuredExportController : ViewController {
        protected override void OnActivated() {
            base.OnActivated();
            ExportController controller = Frame.GetController<ExportController>();
            if (controller != null) {
                controller.ExportAction.Executing += ExportAction_Executing;
                IRequestSecurity requestSecurity = (IRequestSecurity)Application.Security;
                controller.Active.SetItemValue("Security",
                    requestSecurity.IsGranted(new ExportPermissionRequest()));
            }
        }
        void ExportAction_Executing(object sender, System.ComponentModel.CancelEventArgs e) {
            IRequestSecurity requestSecurity = (IRequestSecurity)Application.Security;
            if (!requestSecurity.IsGranted(new ExportPermissionRequest())) {
                throw new UserFriendlyException("Export operation is prohibited.");
            }
        }
    }
}
