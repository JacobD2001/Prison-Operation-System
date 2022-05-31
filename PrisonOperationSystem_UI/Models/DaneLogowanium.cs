using System;
using System.Collections.Generic;

namespace PrisonOperationSystem_UI.Models
{
    public partial class DaneLogowanium
    {
        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Haslo { get; set; } = null!;
    }
}
