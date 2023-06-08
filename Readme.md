<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128591442/22.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3794)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# XAF - How to Implement Custom Permission, Role and User Objects


This example illustrates how to create custom security objects, such as permissions, roles, and users. 

The example XAF application implements a custom permission that allows administrators to control whether a user is allowed to use the export feature. The complete description is available in the following documentation article:

* [How to: Implement Custom Permission, Role and User Objects](https://docs.devexpress.com/eXpressAppFramework/113384)

![](https://user-images.githubusercontent.com/37070809/227926495-330d0c76-f8f9-416c-ba83-223cda9919ab.png)


## Files to Review

### Main Module:

* [ExportPermission.cs](./CS/EFCore/MySolutionEF/MySolutionEF.Module/Security/ExportPermission.cs)
* [ExportPermissionRequest.cs](./CS/EFCore/MySolutionEF/MySolutionEF.Module/Security/ExportPermissionRequest.cs)
* [ExportPermissionRequestProcessor.cs](./CS/EFCore/MySolutionEF/MySolutionEF.Module/Security/ExportPermissionRequestProcessor.cs)
* [ExtendedSecurityRole.cs](./CS/EFCore/MySolutionEF/MySolutionEF.Module/Security/SecuredExportController.cs)
* [SecuredExportController.cs](./CS/EFCore/MySolutionEF/MySolutionEF.Module/Security/SecuredExportController.cs)
* [Updater.cs](./CS/EFCore/MySolutionEF/MySolutionEF.Module/DatabaseUpdate/Updater.cs)

### Blazor Application:

* [Startup.cs](./CS/EFCore/MySolutionEF/MySolutionEF.Blazor.Server/Startup.cs)

### WinForms Application:

* [Startup.cs](./CS/EFCore/MySolutionEF/MySolutionEF.Win/Startup.cs)
