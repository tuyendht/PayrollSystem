using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models.DB
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public string DepId { get; set; }
        public string Name { get; set; }
        public string Office { get; set; }
        public string Phone { get; set; }
        public int? NumEmployee { get; set; }
        public int? MgrCode { get; set; }
        public string ComId { get; set; }

        public virtual Company Com { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
