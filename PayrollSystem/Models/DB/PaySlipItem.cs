using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models.DB
{
    public partial class PaySlipItem
    {
        public string PaySlipItemId { get; set; }
        public string PaySlipItemName { get; set; }
        public decimal? Earning { get; set; }
        public decimal? Deduction { get; set; }
        public string ComponentItemId { get; set; }
        public string PaySlipId { get; set; }

        public virtual ComponentItem ComponentItem { get; set; }
        public virtual PaySlip PaySlip { get; set; }
    }
}
