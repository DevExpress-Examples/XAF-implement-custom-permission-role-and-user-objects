using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.ExpressApp.Security;

namespace SecuredExportExample.Win {
    public partial class SecuredExportExampleWindowsFormsApplication : WinApplication {
        public SecuredExportExampleWindowsFormsApplication() {
            InitializeComponent();
            DelayedViewItemsInitialization = true;
        }
        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args) {
            args.ObjectSpaceProvider =
                new SecuredObjectSpaceProvider(
                    (SecurityStrategy)Security, ConnectionString, Connection);
        }
        private void SecuredExportExampleWindowsFormsApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
            throw new InvalidOperationException(
            "The application cannot connect to the specified database " +
            "because the latter does not exist or its version is older " +
            "than that of the application.");
        }
    }
}
