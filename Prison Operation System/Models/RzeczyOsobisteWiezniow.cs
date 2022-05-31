using System;
using System.Collections.Generic;

namespace Prison_Operation_System.Models
{
    public partial class RzeczyOsobisteWiezniow
    {
        public RzeczyOsobisteWiezniow()
        {
            Skrytkas = new HashSet<Skrytka>();
        }

        public int Id { get; set; }
        public string Przedmiot { get; set; } = null!;
        public int OszacowanaWartosc { get; set; }

        public virtual ICollection<Skrytka> Skrytkas { get; set; }
    }
}
