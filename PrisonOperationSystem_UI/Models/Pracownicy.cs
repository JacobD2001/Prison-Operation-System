using System;
using System.Collections.Generic;

namespace PrisonOperationSystem_UI.Models
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
