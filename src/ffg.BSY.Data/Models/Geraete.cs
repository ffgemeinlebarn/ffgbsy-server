using System;
using System.Collections.Generic;

namespace ffg.BSY.Data
{
    public partial class Geraete
    {
        public Geraete()
        {
            Bestellungens = new HashSet<Bestellungen>();
        }

        public int Id { get; set; }
        public string? Hersteller { get; set; }
        public string? Type { get; set; }
        public string Ip { get; set; } = null!;
        public string? Mac { get; set; }

        public virtual ICollection<Bestellungen> Bestellungens { get; set; }
    }
}
