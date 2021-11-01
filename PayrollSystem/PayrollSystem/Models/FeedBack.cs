using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models
{
    public partial class FeedBack
    {
        public int Id { get; set; }
        public string Desciption { get; set; }
        public int? PaySlipId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual PaySlip PaySlip { get; set; }
    }
}
