using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models.DB
{
    public partial class SalaryComponent
    {
        public SalaryComponent()
        {
            ComponentItems = new HashSet<ComponentItem>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string ComId { get; set; }

        public virtual Company Com { get; set; }
        public virtual ICollection<ComponentItem> ComponentItems { get; set; }
    }
}
