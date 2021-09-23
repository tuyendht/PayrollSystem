using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models.DB
{
    public partial class Atribute
    {
        public Atribute()
        {
            EmployeeAtributes = new HashSet<EmployeeAtribute>();
            PeroidAtributes = new HashSet<PeroidAtribute>();
        }

        public string AtrId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string Id { get; set; }

        public virtual AtributeGroup IdNavigation { get; set; }
        public virtual ICollection<EmployeeAtribute> EmployeeAtributes { get; set; }
        public virtual ICollection<PeroidAtribute> PeroidAtributes { get; set; }
    }
}
