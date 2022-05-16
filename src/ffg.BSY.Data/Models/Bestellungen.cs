using System;
using System.Collections.Generic;

namespace ffg.BSY.Data
{
    public partial class Bestellungen
    {
        public int Id { get; set; }
        public int TischeId { get; set; }
        public DateTime TimestampBegonnen { get; set; }
        public DateTime TimestampBeendet { get; set; }
        public DateTime? TimestampGedruckt { get; set; }
        public int AufnehmerId { get; set; }
        public int GeraeteId { get; set; }

        public virtual Aufnehmer Aufnehmer { get; set; } = null!;
        public virtual Geraete Geraete { get; set; } = null!;
        public virtual Tische Tische { get; set; } = null!;
    }
}
