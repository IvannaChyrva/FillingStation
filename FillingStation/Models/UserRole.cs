﻿using System;
using System.Collections.Generic;

namespace FillingStation
{
    public partial class UserRole
    {
        public UserRole()
        {
            User = new HashSet<User>();
        }

        public string UserRoleId { get; set; }
        public string UserRole1 { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
