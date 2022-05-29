using System;
using System.Collections.Generic;

namespace ffg.BSY.Data
{
    public partial class Bestellposition
    {
        public int Id { get; set; }
        public int Anzahl { get; set; }
        public int ProdukteId { get; set; }
        public string? Notiz { get; set; }
        public int BestellungenId { get; set; }
    }
}
