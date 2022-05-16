using System;
using System.Collections.Generic;

namespace ffg.BSY.Data
{
    public partial class BonsDruck
    {
        public int Id { get; set; }
        public int BestellungenId { get; set; }
        public int DruckerId { get; set; }
        public int? StornoId { get; set; }
        public DateOnly Datum { get; set; }
        public int Laufnummer { get; set; }
        public DateTime TimestampGedruckt { get; set; }
        public bool? Result { get; set; }
        public string? ResultMessage { get; set; }
    }
}
