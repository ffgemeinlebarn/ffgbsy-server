using System;
using System.Collections.Generic;

namespace ffg.BSY.Data
{
    public partial class Tische
    {
        public Tische()
        {
            Bestellungens = new HashSet<Bestellungen>();
        }

        public int Id { get; set; }
        public string Reihe { get; set; } = null!;
        public int? Nummer { get; set; }
        public int TischkategorienId { get; set; }
        public int? Sortierindex { get; set; }

        public virtual ICollection<Bestellungen> Bestellungens { get; set; }
    }
}
