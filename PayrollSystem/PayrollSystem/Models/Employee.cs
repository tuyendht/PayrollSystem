using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models
{
    public partial class Employee
    {
        public Employee()
        {
            FeedBacks = new HashSet<FeedBack>();
            PaySlipDetails = new HashSet<PaySlipDetail>();
            PaySlips = new HashSet<PaySlip>();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }
        public string Fullname { get; set; }
        public bool? Gender { get; set; }
        public DateTime FirstDayAtWork { get; set; }
        public string WorkEmailAddress { get; set; }
        public int SalaryId { get; set; }
        public int CitizenIdentification { get; set; }
        public string Address { get; set; }
        public int? PhoneNumber { get; set; }
        public int? TaxCode { get; set; }
        public int? BankNumber { get; set; }
        public bool PaymentType { get; set; }

        public virtual Company Company { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<FeedBack> FeedBacks { get; set; }
        public virtual ICollection<PaySlipDetail> PaySlipDetails { get; set; }
        public virtual ICollection<PaySlip> PaySlips { get; set; }
    }
}
