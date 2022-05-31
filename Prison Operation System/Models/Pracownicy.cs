using System;
using System.Collections.Generic;

namespace Prison_Operation_System.Models
{
    public partial class Pracownicy
    {
        public int Id { get; set; }
        public string Imie { get; set; } = null!;
        public string Nazwisko { get; set; } = null!;
        public string Pesel { get; set; } = null!;
        public string Funkcja { get; set; } = null!;
        public string? Stopien { get; set; }
    }
}
