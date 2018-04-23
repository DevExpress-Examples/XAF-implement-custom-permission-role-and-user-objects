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
using DevExpress.ExpressApp.Security.ClientServer.Wcf;
using DevExpress.ExpressApp.Security.ClientServer;
using System.ServiceModel;

namespace SecuredExportExample.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached;
            SecuredExportExampleWindowsFormsApplication winApplication = new SecuredExportExampleWindowsFormsApplication();
#if EASYTEST
            DevExpress.ExpressApp.Win.EasyTest.EasyTestRemotingRegistration.Register();
            var serverProcess = new System.Diagnostics.Process();
            serverProcess.StartInfo.FileName = @"..\..\..\SecuredExportExample.MiddleTierSecurityServer\bin\EasyTest\SecuredExportExample.MiddleTierSecurityServer.exe";
            serverProcess.Start();
            System.Threading.Thread.Sleep(5000);
#endif
            try
            {

                WcfDataServerHelper.AddKnownType(typeof(ExportPermissionRequest));
                winApplication.ConnectionString = "net.tcp://127.0.0.1:1451/DataServer";
                winApplication.DatabaseUpdateMode = DatabaseUpdateMode.Never;
                WcfSecuredClient wcfSecuredClient = new WcfSecuredClient(WcfDataServerHelper.CreateNetTcpBinding(), new EndpointAddress(winApplication.ConnectionString));
                MiddleTierClientSecurity securityClient = new MiddleTierClientSecurity(wcfSecuredClient);
                securityClient.IsSupportChangePassword = true;
                winApplication.ApplicationName = "SecuredExportExample";
                winApplication.Security = securityClient;
                winApplication.CreateCustomObjectSpaceProvider += (s, e) =>
                {
                    e.ObjectSpaceProvider = new MiddleTierServerObjectSpaceProvider(wcfSecuredClient);
                };
                winApplication.Setup();
                winApplication.Start();
                wcfSecuredClient.Dispose();
            }
            catch (Exception e)
            {
                winApplication.HandleException(e);
            }
        }

    }
}
