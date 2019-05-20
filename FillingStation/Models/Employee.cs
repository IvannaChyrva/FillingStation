using System;
using System.Collections.Generic;

namespace FillingStation
{
    public partial class Employee
    {
        public string EmployeeId { get; set; }
        public string UserId { get; set; }
        public string EmployeePasport { get; set; }
        public decimal? EmployeeSalery { get; set; }
        public string EmployeeAdress { get; set; }
        public decimal? EmployeePhone { get; set; }
        public string StationId { get; set; }

        public virtual Station Station { get; set; }
        public virtual User User { get; set; }
    }
}
