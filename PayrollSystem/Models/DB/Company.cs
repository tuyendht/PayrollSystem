using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models.DB
{
    public partial class Company
    {
        public Company()
        {
            AtributeGroups = new HashSet<AtributeGroup>();
            Departments = new HashSet<Department>();
            PayPeroids = new HashSet<PayPeroid>();
            SalaryComponents = new HashSet<SalaryComponent>();
        }

        public string ComId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public virtual ICollection<AtributeGroup> AtributeGroups { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<PayPeroid> PayPeroids { get; set; }
        public virtual ICollection<SalaryComponent> SalaryComponents { get; set; }
    }
}
