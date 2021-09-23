using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models.DB
{
    public partial class ComponentItem
    {
        public ComponentItem()
        {
            PaySlipItems = new HashSet<PaySlipItem>();
        }

        public string ComponentItemId { get; set; }
        public string Name { get; set; }
        public string Formula { get; set; }
        public string Id { get; set; }

        public virtual SalaryComponent IdNavigation { get; set; }
        public virtual ICollection<PaySlipItem> PaySlipItems { get; set; }
    }
}
