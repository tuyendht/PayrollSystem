using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models
{
    public partial class PaySlip
    {
        public PaySlip()
        {
            FeedBacks = new HashSet<FeedBack>();
        }

        public int Id { get; set; }
        public DateTime PayDate { get; set; }
        public DateTime PayPeriodBeginDate { get; set; }
        public DateTime PayPeriodEndDate { get; set; }
        public int PayStatusId { get; set; }
        public double TotalPayrollCost { get; set; }
        public double TotalNetPayroll { get; set; }
        public double Totaltax { get; set; }
        public int? EmployeeId { get; set; }
        public int? PaySlipDetailId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual PaySlipDetail PaySlipDetail { get; set; }
        public virtual PayStatus PayStatus { get; set; }
        public virtual ICollection<FeedBack> FeedBacks { get; set; }
    }
}
