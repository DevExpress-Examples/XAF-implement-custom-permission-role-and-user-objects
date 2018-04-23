#Application SecuredExportExample.Win.MiddleTier
#Application SecuredExportExample.Win
#Application SecuredExportExample.Web

*FillForm
 User Name = Admin

*Action Log On

*Action Navigation(Extended Security Role)

*CheckTable
 Columns = Name, Can Export
 Row = Administrator, False
 Row = Exporter, True
 Row = Default, False
 
*ProcessRecord  
 Name = Default
 
*Action Type Permissions

*CheckTable Type Permissions
 Columns = Object, Read, Write, Create, Delete, Navigate
 Row = Employee, True, False, False, False, True
 Row = Task, True, True, True, True, True
 Row = User, False, False, False, False, False

*ProcessRecord Type Permissions
 Object = User

*Action Object Permissions

*CheckTable Object Permissions
 Columns = Criteria, Read, Write, Delete, Navigate
 Row = [Oid] = CurrentUserId(), True, False, False, True

*OptionalAction Close

*OptionalAction Close

*Action Log Off

*FillForm
 User Name = Sam
 
*Action Log On

*Action Navigation(Task)

*ActionAvailable Export to

*Action Log Off

*FillForm
 User Name = John
 
*Action Log On

*Action Navigation(Task)

!ActionAvailable Export to

