using System;
using System.Collections.Generic;

namespace ffg.BSY.Data
{
    public partial class Aufnehmer
    {
        public Aufnehmer()
        {
            Bestellungens = new HashSet<Bestellungen>();
        }

        public int Id { get; set; }
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }
        public bool Aktiv { get; set; }
        public int ZoomLevel { get; set; }

        public virtual ICollection<Bestellungen> Bestellungens { get; set; }
    }
}
