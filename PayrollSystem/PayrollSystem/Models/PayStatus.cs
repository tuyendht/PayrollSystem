using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models
{
    public partial class PayStatus
    {
        public PayStatus()
        {
            PaySlips = new HashSet<PaySlip>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PaySlip> PaySlips { get; set; }
    }
}
