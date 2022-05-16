using System;
using System.Collections.Generic;

namespace ffg.BSY.Data
{
    public partial class BestellpositionenStorno
    {
        public int Id { get; set; }
        public int? BestellpositionenId { get; set; }
        public int Anzahl { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
