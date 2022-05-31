using System;
using System.Collections.Generic;

namespace Prison_Operation_System.Models
{
    public partial class Cele
    {
        public Cele()
        {
            Wiezniowies = new HashSet<Wiezniowie>();
        }

        public int Id { get; set; }
        public string TypCeli { get; set; } = null!;
        public string? Opis { get; set; }

        public virtual ICollection<Wiezniowie> Wiezniowies { get; set; }
    }
}
