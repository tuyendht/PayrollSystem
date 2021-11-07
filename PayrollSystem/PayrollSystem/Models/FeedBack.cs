using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models
{
    public partial class FeedBack
    {
        public string Desciption { get; set; }
        public int? PaySlipId { get; set; }
        public int? EmployeeId { get; set; }
        public string CreateDate { get; set; }
        public string Image { get; set; }
        public int Id { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual PaySlip PaySlip { get; set; }
    }
}
