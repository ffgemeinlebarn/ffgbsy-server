using System;
using System.Collections.Generic;

namespace ffg.BSY.Data
{
    public partial class AufnehmerSession
    {
        public int Id { get; set; }
        public int AufnehmerId { get; set; }
        public int GeraeteId { get; set; }
        public string Hash { get; set; } = null!;
        public DateTime? Start { get; set; }
        public DateTime? Ende { get; set; }
    }
}
