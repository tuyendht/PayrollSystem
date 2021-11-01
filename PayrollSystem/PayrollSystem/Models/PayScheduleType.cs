using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models
{
    public partial class PayScheduleType
    {
        public PayScheduleType()
        {
            PaySchedules = new HashSet<PaySchedule>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PaySchedule> PaySchedules { get; set; }
    }
}
