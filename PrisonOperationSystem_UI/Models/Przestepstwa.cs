using System;
using System.Collections.Generic;

namespace PrisonOperationSystem_UI.Models
{
    public partial class Przestepstwa
    {
        public Przestepstwa()
        {
            Wiezniowies = new HashSet<Wiezniowie>();
        }

        public int Id { get; set; }
        public string RodzajPrzestepstwa { get; set; } = null!;
        public string Wyrok { get; set; } = null!;
        public DateTime DataPopelnienia { get; set; }
        public DateTime DataWyroku { get; set; }
        public string? Opis { get; set; }

        public virtual ICollection<Wiezniowie> Wiezniowies { get; set; }
    }
}
