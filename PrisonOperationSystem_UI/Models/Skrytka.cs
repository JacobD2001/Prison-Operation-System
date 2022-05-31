using System;
using System.Collections.Generic;

namespace PrisonOperationSystem_UI.Models
{
    public partial class Skrytka
    {
        public Skrytka()
        {
            Wiezniowies = new HashSet<Wiezniowie>();
        }

        public int Id { get; set; }
        public int? RzeczyOsobisteWiezniowId { get; set; }

        public virtual RzeczyOsobisteWiezniow? RzeczyOsobisteWiezniow { get; set; }
        public virtual ICollection<Wiezniowie> Wiezniowies { get; set; }
    }
}
