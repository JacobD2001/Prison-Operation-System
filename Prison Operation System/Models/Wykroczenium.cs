using System;
using System.Collections.Generic;

namespace Prison_Operation_System.Models
{
    public partial class Wykroczenium
    {
        public Wykroczenium()
        {
            Wiezniowies = new HashSet<Wiezniowie>();
        }

        public int Id { get; set; }
        public string RodzajWykroczenia { get; set; } = null!;
        public string Kara { get; set; } = null!;
        public string? Opis { get; set; }

        public virtual ICollection<Wiezniowie> Wiezniowies { get; set; }
    }
}
