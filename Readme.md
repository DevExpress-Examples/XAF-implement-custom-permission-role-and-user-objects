<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128591442/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3794)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
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
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=XAF-implement-custom-permission-role-and-user-objects&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=XAF-implement-custom-permission-role-and-user-objects&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
