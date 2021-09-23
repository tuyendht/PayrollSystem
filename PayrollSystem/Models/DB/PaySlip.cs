using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models.DB
{
    public partial class PaySlip
    {
        public PaySlip()
        {
            PaySlipItems = new HashSet<PaySlipItem>();
        }

        public string PaySlipId { get; set; }
        public string Payment { get; set; }
        public string EmpId { get; set; }
        public string PayPeriodId { get; set; }

        public virtual Employee Emp { get; set; }
        public virtual PayPeroid PayPeriod { get; set; }
        public virtual ICollection<PaySlipItem> PaySlipItems { get; set; }
    }
}
