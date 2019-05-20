using System;
using System.Collections.Generic;

namespace FillingStation
{
    public partial class User
    {
        public User()
        {
            Customer = new HashSet<Customer>();
            Employee = new HashSet<Employee>();
        }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserRoleId { get; set; }

        public virtual UserRole UserRole { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
