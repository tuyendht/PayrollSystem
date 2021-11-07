using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models
{
    public partial class Company
    {
        public Company()
        {
            Employees = new HashSet<Employee>();
            Industries = new HashSet<Industry>();
            LegalStructures = new HashSet<LegalStructure>();
            ManagePayrolls = new HashSet<ManagePayroll>();
            PaySchedules = new HashSet<PaySchedule>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TaxCode { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Industry> Industries { get; set; }
        public virtual ICollection<LegalStructure> LegalStructures { get; set; }
        public virtual ICollection<ManagePayroll> ManagePayrolls { get; set; }
        public virtual ICollection<PaySchedule> PaySchedules { get; set; }
    }
}
