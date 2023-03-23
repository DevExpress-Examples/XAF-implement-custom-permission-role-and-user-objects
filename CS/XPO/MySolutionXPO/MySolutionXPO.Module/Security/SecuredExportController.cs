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
                IRequestSecurity requestSecurity = SecuritySystem.Instance as IRequestSecurity;

                if (requestSecurity != null) {
                    controller.Active.SetItemValue("Security",
                       requestSecurity.IsGranted(new ExportPermissionRequest()));
                }
            }
        }
        void ExportAction_Executing(object sender, System.ComponentModel.CancelEventArgs e) {
            IRequestSecurity requestSecurity = SecuritySystem.Instance as IRequestSecurity;
            if (!requestSecurity.IsGranted(new ExportPermissionRequest())) {
                throw new UserFriendlyException("Export operation is prohibited.");
            }
        }
    }
}
