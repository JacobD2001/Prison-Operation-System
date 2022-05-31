using System;
using System.Collections.Generic;

namespace Prison_Operation_System.Models
{
    public partial class Widzenium
    {
        public Widzenium()
        {
            Wiezniowies = new HashSet<Wiezniowie>();
        }

        public int Id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Godzina { get; set; }
        public int TypWidzeniaId { get; set; }
        public int LiczbaOdwiedzających { get; set; }

        public virtual TypWidzenium TypWidzenia { get; set; } = null!;
        public virtual ICollection<Wiezniowie> Wiezniowies { get; set; }
    }
}
