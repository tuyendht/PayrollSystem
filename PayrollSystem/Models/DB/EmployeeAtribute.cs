using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models.DB
{
    public partial class EmployeeAtribute
    {
        public string Id { get; set; }
        public int? QuantityValue { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public string EmpId { get; set; }
        public string AtrId { get; set; }

        public virtual Atribute Atr { get; set; }
        public virtual Employee Emp { get; set; }
    }
}
