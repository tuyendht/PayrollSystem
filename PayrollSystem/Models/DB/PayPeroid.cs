using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models.DB
{
    public partial class PayPeroid
    {
        public PayPeroid()
        {
            PaySlips = new HashSet<PaySlip>();
            PeroidAtributes = new HashSet<PeroidAtribute>();
        }

        public string PayPeriodId { get; set; }
        public string PayPeriodName { get; set; }
        public string ComId { get; set; }

        public virtual Company Com { get; set; }
        public virtual ICollection<PaySlip> PaySlips { get; set; }
        public virtual ICollection<PeroidAtribute> PeroidAtributes { get; set; }
    }
}
