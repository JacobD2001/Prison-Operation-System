using System;
using System.Collections.Generic;

namespace Prison_Operation_System.Models
{
    public partial class TypWidzenium
    {
        public TypWidzenium()
        {
            Widzenia = new HashSet<Widzenium>();
        }

        public int Id { get; set; }
        public string Typ { get; set; } = null!;

        public virtual ICollection<Widzenium> Widzenia { get; set; }
    }
}
