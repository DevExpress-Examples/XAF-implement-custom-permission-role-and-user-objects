using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.Security.ClientServer;
using System.Configuration;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp.MiddleTier;
using SecuredExportExample.Module.BusinessObjects;
using SecuredExportExample.Module.SecurityObjects;
using System.ServiceModel;
using DevExpress.ExpressApp.Security.ClientServer.Wcf;

namespace SecuredExportExample.MiddleTierSecurityServer {
    class Program {
        private static void serverApplication_DatabaseVersionMismatch(object sender, DatabaseVersionMismatchEventArgs e) {
            e.Updater.Update();
            e.Handled = true;
        }
        private static void serverApplication_CreateCustomObjectSpaceProvider(object sender, CreateCustomObjectSpaceProviderEventArgs e) {
            e.ObjectSpaceProvider = new XPObjectSpaceProvider(e.ConnectionString, e.Connection);
        }
        static void Main(string[] args) {
            try {
                
                ValueManager.ValueManagerType = typeof(MultiThreadValueManager<>).GetGenericTypeDefinition();
                InMemoryDataStoreProvider.Register();
                string connectionString = InMemoryDataStoreProvider.ConnectionString;

                Console.WriteLine("Starting...");

                ServerApplication serverApplication = new ServerApplication();
                // Change the ServerApplication.ApplicationName property value. It should be the same as your client application name. 
                serverApplication.ApplicationName = "SecuredExportExample";

                // Add your client application's modules to the ServerApplication.Modules collection here. 
                serverApplication.Modules.BeginInit();
                serverApplication.Modules.Add(new DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule());
                serverApplication.Modules.Add(new DevExpress.ExpressApp.Security.SecurityModule());
                serverApplication.Modules.Add(new SecuredExportExample.Module.SecuredExportExampleModule());
                serverApplication.Modules.EndInit();

                serverApplication.DatabaseVersionMismatch += new EventHandler<DatabaseVersionMismatchEventArgs>(serverApplication_DatabaseVersionMismatch);
                serverApplication.CreateCustomObjectSpaceProvider += new EventHandler<CreateCustomObjectSpaceProviderEventArgs>(serverApplication_CreateCustomObjectSpaceProvider);

                serverApplication.ConnectionString = connectionString;

                Console.WriteLine("Setup...");
                serverApplication.Setup();
                Console.WriteLine("CheckCompatibility...");
                serverApplication.CheckCompatibility();
                serverApplication.Dispose();

                Console.WriteLine("Starting server...");
                Func<IDataServerSecurity> dataServerSecurityProvider = () => {
                    SecurityStrategyComplex security = new SecurityStrategyComplex(
                        typeof(Employee), typeof(ExtendedSecurityRole), new AuthenticationStandard());                  
                    security.CustomizeRequestProcessors +=
                        delegate(object sender, CustomizeRequestProcessorsEventArgs e) {
                            List<IOperationPermission> result = new List<IOperationPermission>();
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
                    return security;
                };

                WcfDataServerHelper.AddKnownType(typeof(ExportPermissionRequest));
                WcfXafServiceHost serviceHost = new WcfXafServiceHost(connectionString, dataServerSecurityProvider);
                serviceHost.AddServiceEndpoint(typeof(IWcfXafDataServer), WcfDataServerHelper.CreateNetTcpBinding(), "net.tcp://127.0.0.1:1451/DataServer");
                serviceHost.Open();
                Console.WriteLine("Server is started. Press Enter to stop.");
#if !EASYTEST
                Console.ReadLine();
#else
                // 20 seconds is enough to pass all tests:
                System.Threading.Thread.Sleep(20000);
#endif
                Console.WriteLine("Stopping...");
                serviceHost.Close();
                Console.WriteLine("Server is stopped.");
            }
            catch (Exception e) {
                Console.WriteLine("Exception occurs: " + e.Message);
                Console.WriteLine("Press Enter to close.");
                Console.ReadLine();
            }
        }
    }
}
