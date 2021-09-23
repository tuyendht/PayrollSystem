using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models.DB
{
    public partial class EmployeeType
    {
        public EmployeeType()
        {
            Employees = new HashSet<Employee>();
        }

        public string Id { get; set; }
        public string TypeName { get; set; }
        public float? HoursPerDay { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
