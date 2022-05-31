using System;
using System.Collections.Generic;

namespace PrisonOperationSystem_UI.Models
{
    public partial class StopienZagrozeniaWieznium
    {
        public StopienZagrozeniaWieznium()
        {
            Wiezniowies = new HashSet<Wiezniowie>();
        }

        public int Id { get; set; }
        public string Opis { get; set; } = null!;

        public virtual ICollection<Wiezniowie> Wiezniowies { get; set; }
    }
}
