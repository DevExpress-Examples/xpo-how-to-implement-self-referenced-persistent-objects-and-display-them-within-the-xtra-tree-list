namespace SelfReferenced {
    using System;
    using DevExpress.Xpo;
    
	public class Employee : XPObject {
        public Employee(Session session) : base(session) { }

        string _FullName;
        public string FullName {
            get { return _FullName; }
            set { SetPropertyValue("FullName", ref _FullName, value); }
        }

        private string _Title;
        public string Title {
            get { return _Title; }
            set { SetPropertyValue("Title", ref _Title, value); }
        }

        Employee _Manager;
        [Association("ManagerSubordinates")]
        public Employee Manager {
            get { return _Manager; }
            set { SetPropertyValue("Manager", ref _Manager, value); }
        }

        [Association("ManagerSubordinates")]
        public XPCollection<Employee> Subordinates {
            get { return GetCollection<Employee>("Subordinates"); }
		}
	}
}
