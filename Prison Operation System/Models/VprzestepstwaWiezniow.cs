using System;
using System.Collections.Generic;

namespace Prison_Operation_System.Models
{
    public partial class VprzestepstwaWiezniow
    {
        public string Imie { get; set; } = null!;
        public string Nazwisko { get; set; } = null!;
        public string Pesel { get; set; } = null!;
        public string RodzajPrzestepstwa { get; set; } = null!;
        public string Wyrok { get; set; } = null!;
    }
}
