using System;
using System.Collections.Generic;

namespace ffg.BSY.Data
{
    public partial class Drucker
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Ip { get; set; } = null!;
        public int? Port { get; set; }
        public string? Mac { get; set; }
    }
}
