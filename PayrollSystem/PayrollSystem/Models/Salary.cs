using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models
{
    public partial class Salary
    {
        public int? Id { get; set; }
        public string Type { get; set; }

        public virtual Employee IdNavigation { get; set; }
    }
}
