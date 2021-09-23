using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models.DB
{
    public partial class PeroidAtribute
    {
        public string Id { get; set; }
        public string AtributeName { get; set; }
        public string AtrId { get; set; }
        public string PayPeriodId { get; set; }
        public string EmpId { get; set; }

        public virtual Atribute Atr { get; set; }
        public virtual Employee Emp { get; set; }
        public virtual PayPeroid PayPeriod { get; set; }
    }
}
