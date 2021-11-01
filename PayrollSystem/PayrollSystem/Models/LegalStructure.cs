using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models
{
    public partial class LegalStructure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
