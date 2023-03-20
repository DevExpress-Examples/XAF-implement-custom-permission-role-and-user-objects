<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128591442/20.1.7%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3794)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# How to: Implement Custom Permission, Role and User Objects
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e3794/)**
<!-- run online end -->

This example illustrates how to create custom security objects, such as permissions, roles and users. 

The example XAF application implements a custom permission that allows administrators to control whether or not a user is allowed to use the export feature. The complete description is available in the following documentation article:

* [How to: Implement Custom Permission, Role and User Objects](http://documentation.devexpress.com/#Xaf/CustomDocument3384)

![](https://raw.githubusercontent.com/DevExpress-Examples/how-to-implement-custom-permission-role-and-user-objects-e3794/17.2.3+/media/00ffc31d-8a0d-47e5-a763-d7f07e79e52d.png)

## Files to Review:

* [Program.cs](./CS/SecuredExportExample.MiddleTierSecurityServer/Program.cs) (VB: [Program.vb](./VB/SecuredExportExample.MiddleTierSecurityServer/Program.vb))
* [Employee.cs](./CS/SecuredExportExample.Module/BusinessObjects/Employee.cs) (VB: [Employee.vb](./VB/SecuredExportExample.Module/BusinessObjects/Employee.vb))
* [SecuredExportController.cs](./CS/SecuredExportExample.Module/Controllers/SecuredExportController.cs) (VB: [SecuredExportController.vb](./VB/SecuredExportExample.Module/Controllers/SecuredExportController.vb))
* [Updater.cs](./CS/SecuredExportExample.Module/DatabaseUpdate/Updater.cs) (VB: [Updater.vb](./VB/SecuredExportExample.Module/DatabaseUpdate/Updater.vb))
* [ExportPermission.cs](./CS/SecuredExportExample.Module/SecurityObjects/ExportPermission.cs) (VB: [ExportPermission.vb](./VB/SecuredExportExample.Module/SecurityObjects/ExportPermission.vb))
* [ExtendedSecurityRole.cs](./CS/SecuredExportExample.Module/SecurityObjects/ExtendedSecurityRole.cs) (VB: [ExtendedSecurityRole.vb](./VB/SecuredExportExample.Module/SecurityObjects/ExtendedSecurityRole.vb))
* [Global.asax.cs](./CS/SecuredExportExample.Web/Global.asax.cs)
* [WebApplication.cs](./CS/SecuredExportExample.Web/WebApplication.cs) (VB: [WebApplication.vb](./VB/SecuredExportExample.Web/WebApplication.vb))
* [Program.cs](./CS/SecuredExportExample.Win.MiddleTierSecurityClient/Program.cs) (VB: [Program.vb](./VB/SecuredExportExample.Win.MiddleTierSecurityClient/Program.vb))
* [WinApplication.Designer.cs](./CS/SecuredExportExample.Win.MiddleTierSecurityClient/WinApplication.Designer.cs)
* [Program.cs](./CS/SecuredExportExample.Win/Program.cs) (VB: [Program.vb](./VB/SecuredExportExample.Win/Program.vb))
* [WinApplication.Designer.cs](./CS/SecuredExportExample.Win/WinApplication.Designer.cs)