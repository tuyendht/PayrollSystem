using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models.DB
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeAtributes = new HashSet<EmployeeAtribute>();
            PaySlips = new HashSet<PaySlip>();
            PeroidAtributes = new HashSet<PeroidAtribute>();
        }

        public string EmpId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }
        public string Address { get; set; }
        public bool? Role { get; set; }
        public bool? StillWorking { get; set; }
        public string Id { get; set; }
        public string DepId { get; set; }

        public virtual Department Dep { get; set; }
        public virtual EmployeeType IdNavigation { get; set; }
        public virtual ICollection<EmployeeAtribute> EmployeeAtributes { get; set; }
        public virtual ICollection<PaySlip> PaySlips { get; set; }
        public virtual ICollection<PeroidAtribute> PeroidAtributes { get; set; }
    }
}
