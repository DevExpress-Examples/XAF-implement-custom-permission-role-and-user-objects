using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.SystemModule;
using SecuredExportExample.Module.SecurityObjects;

namespace SecuredExportExample.Module.Controllers {
    public class SecuredExportController : ViewController {
        protected override void OnActivated() {
            base.OnActivated();
            ExportController controller = Frame.GetController<ExportController>();
            if (controller != null) {
                controller.ExportAction.Executing += ExportAction_Executing;
                if(SecuritySystem.Instance is IRequestSecurity) {
                    controller.Active.SetItemValue("Security", 
                        SecuritySystem.IsGranted(new ExportPermissionRequest()));
                }
            }
        }
        void ExportAction_Executing(object sender, System.ComponentModel.CancelEventArgs e) {
            SecuritySystem.Demand(new ExportPermissionRequest());
        }
    }
}
