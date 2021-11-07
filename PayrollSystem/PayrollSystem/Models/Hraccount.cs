using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models
{
    public partial class Hraccount
    {
        public Hraccount()
        {
            ManagePayrolls = new HashSet<ManagePayroll>();
        }

        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string Fullname { get; set; }
        public bool? Gender { get; set; }
        public int? PhoneNumber { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<ManagePayroll> ManagePayrolls { get; set; }
    }
}
