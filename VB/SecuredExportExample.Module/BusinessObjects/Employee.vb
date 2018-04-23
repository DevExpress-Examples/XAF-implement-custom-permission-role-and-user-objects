Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.BaseImpl.PermissionPolicy
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.Security

Namespace SecuredExportExample.Module.BusinessObjects
    <DefaultClassOptions, ImageName("BO_Employee")> _
    Public Class Employee
        Inherits PermissionPolicyUser

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        <Association("Employee-Task")> _
        Public ReadOnly Property Tasks() As XPCollection(Of Task)
            Get
                Return GetCollection(Of Task)("Tasks")
            End Get
        End Property

    End Class
    <DefaultClassOptions, ImageName("BO_Task")> _
    Public Class Task
        Inherits BaseObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Private subject_Renamed As String
        Public Property Subject() As String
            Get
                Return subject_Renamed
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Subject", subject_Renamed, value)
            End Set
        End Property

        Private dueDate_Renamed As Date
        Public Property DueDate() As Date
            Get
                Return dueDate_Renamed
            End Get
            Set(ByVal value As Date)
                SetPropertyValue("DueDate", dueDate_Renamed, value)
            End Set
        End Property

        Private assignedTo_Renamed As Employee
        <Association("Employee-Task")> _
        Public Property AssignedTo() As Employee
            Get
                Return assignedTo_Renamed
            End Get
            Set(ByVal value As Employee)
                SetPropertyValue("AssignedTo", assignedTo_Renamed, value)
            End Set
        End Property
    End Class
End Namespace
