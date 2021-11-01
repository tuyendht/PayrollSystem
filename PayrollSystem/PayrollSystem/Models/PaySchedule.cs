using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models
{
    public partial class PaySchedule
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int PayScheduleTypeId { get; set; }
        public string PayDay { get; set; }
        public string OtherPayDay { get; set; }

        public virtual Company Company { get; set; }
        public virtual PayScheduleType PayScheduleType { get; set; }
    }
}
