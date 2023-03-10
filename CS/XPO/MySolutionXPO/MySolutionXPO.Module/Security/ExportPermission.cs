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
}
