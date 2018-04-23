using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Security;

namespace SecuredExportExample.Module.BusinessObjects {
    [DefaultClassOptions, ImageName("BO_Employee")]
    public class Employee : PermissionPolicyUser {
        public Employee(Session session)
            : base(session) { }
        [Association("Employee-Task")]
        public XPCollection<Task> Tasks {
            get { return GetCollection<Task>("Tasks");  }
        }
        
    }
    [DefaultClassOptions]
    [ImageName("BO_Task")]
    public class Task : BaseObject {
        public Task(Session session)
            : base(session) { }
        private string subject;
        public string Subject {
            get { return subject; }
            set { SetPropertyValue("Subject", ref subject, value); }
        }
        private DateTime dueDate;
        public DateTime DueDate {
            get { return dueDate; }
            set { SetPropertyValue("DueDate", ref dueDate, value); }
        }
        private Employee assignedTo;
        [Association("Employee-Task")]
        public Employee AssignedTo {
            get { return assignedTo; }
            set { SetPropertyValue("AssignedTo", ref assignedTo, value); }
        }
    }
}
