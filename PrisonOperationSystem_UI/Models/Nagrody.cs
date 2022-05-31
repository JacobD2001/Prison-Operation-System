using System;
using System.Collections.Generic;

namespace PrisonOperationSystem_UI.Models
{
    public partial class Nagrody
    {
        public Nagrody()
        {
            Wiezniowies = new HashSet<Wiezniowie>();
        }

        public int Id { get; set; }
        public string RodzajNagrody { get; set; } = null!;
        public string ZaCoPrzyznana { get; set; } = null!;
        public string? Opis { get; set; }

        public virtual ICollection<Wiezniowie> Wiezniowies { get; set; }
    }
}
