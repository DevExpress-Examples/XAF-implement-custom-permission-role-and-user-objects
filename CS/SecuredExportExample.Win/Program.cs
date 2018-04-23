using System;
using System.Configuration;
using System.Windows.Forms;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Win;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using SecuredExportExample.Module.SecurityObjects;
using DevExpress.ExpressApp.Xpo;
using System.Collections.Generic;
using SecuredExportExample.Module.BusinessObjects;

namespace SecuredExportExample.Win {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached;
            SecuredExportExampleWindowsFormsApplication winApplication = new SecuredExportExampleWindowsFormsApplication();
#if EASYTEST
            DevExpress.ExpressApp.Win.EasyTest.EasyTestRemotingRegistration.Register();
#endif
            try {
                InMemoryDataStoreProvider.Register();
                winApplication.ConnectionString = InMemoryDataStoreProvider.ConnectionString;
                ((SecurityStrategy)winApplication.Security).CustomizeRequestProcessors +=
                    delegate(object sender, CustomizeRequestProcessorsEventArgs e) {
                        List<IOperationPermission> result = new List<IOperationPermission>();
                        SecurityStrategyComplex security = sender as SecurityStrategyComplex;
                        if (security != null) {
                            Employee user = security.User as Employee;
                            if (user != null) {
                                foreach (ExtendedSecurityRole role in user.Roles) {
                                    if (role.CanExport) {
                                        result.Add(new ExportPermission());
                                    }
                                }
                            }
                        }
                        IPermissionDictionary permissionDictionary = new PermissionDictionary((IEnumerable<IOperationPermission>)result);
                        e.Processors.Add(typeof(ExportPermissionRequest), new ExportPermissionRequestProcessor(permissionDictionary));
                    }; 
                winApplication.Setup();
                winApplication.Start();
            }
            catch (Exception e) {
                winApplication.HandleException(e);
            }
        }

    }
}
