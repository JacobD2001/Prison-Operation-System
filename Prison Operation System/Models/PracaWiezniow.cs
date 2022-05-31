using System;
using System.Collections.Generic;

namespace Prison_Operation_System.Models
{
    public partial class PracaWiezniow
    {
        public PracaWiezniow()
        {
            Wiezniowies = new HashSet<Wiezniowie>();
        }

        public int Id { get; set; }
        public string RodzajPracy { get; set; } = null!;
        public int LiczbaGodzin { get; set; }

        public virtual ICollection<Wiezniowie> Wiezniowies { get; set; }
    }
}
