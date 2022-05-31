using System;
using System.Collections.Generic;

namespace PrisonOperationSystem_UI.Models
{
    public partial class VprzedmiotyWskrytce
    {
        public int NrSkrytki { get; set; }
        public string Przedmiot { get; set; } = null!;
        public int OszacowanaWartosc { get; set; }
    }
}
