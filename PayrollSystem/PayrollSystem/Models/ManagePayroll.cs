using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models
{
    public partial class ManagePayroll
    {
        public int Id { get; set; }
        public int HrId { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Hraccount Hr { get; set; }
    }
}
