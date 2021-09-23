using System;
using System.Collections.Generic;

#nullable disable

namespace PayrollSystem.Models.DB
{
    public partial class AtributeGroup
    {
        public AtributeGroup()
        {
            Atributes = new HashSet<Atribute>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string ComId { get; set; }

        public virtual Company Com { get; set; }
        public virtual ICollection<Atribute> Atributes { get; set; }
    }
}
