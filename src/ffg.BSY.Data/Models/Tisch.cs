using System;
using System.Collections.Generic;

namespace ffg.BSY.Data
{
    public partial class Tisch
    {
        public Tisch()
        {
            Bestellungens = new HashSet<Bestellung>();
        }

        public int Id { get; set; }
        public string Reihe { get; set; } = null!;
        public int? Nummer { get; set; }
        public int TischkategorienId { get; set; }
        public int? Sortierindex { get; set; }

        public virtual ICollection<Bestellung> Bestellungens { get; set; }
    }
}
