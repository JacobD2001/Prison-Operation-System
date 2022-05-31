using System;
using System.Collections.Generic;

namespace Prison_Operation_System.Models
{
    public partial class Wiezniowie
    {
        public int Id { get; set; }
        public string Imie { get; set; } = null!;
        public string Nazwisko { get; set; } = null!;
        public string Pesel { get; set; } = null!;
        public DateTime RozpoczecieWyroku { get; set; }
        public DateTime PlanowaneZakonczenieWyroku { get; set; }
        public int? SkrytkaId { get; set; }
        public int? WidzeniaId { get; set; }
        public int? NagrodyId { get; set; }
        public int? WykroczeniaId { get; set; }
        public int? PracaWiezniowId { get; set; }
        public int PrzestepstwaId { get; set; }
        public int StopienZagrozeniaWiezniaId { get; set; }
        public int CeleId { get; set; }

        public virtual Cele Cele { get; set; } = null!;
        public virtual Nagrody? Nagrody { get; set; }
        public virtual PracaWiezniow? PracaWiezniow { get; set; }
        public virtual Przestepstwa Przestepstwa { get; set; } = null!;
        public virtual Skrytka? Skrytka { get; set; }
        public virtual StopienZagrozeniaWieznium StopienZagrozeniaWieznia { get; set; } = null!;
        public virtual Widzenium? Widzenia { get; set; }
        public virtual Wykroczenium? Wykroczenia { get; set; }
    }
}
