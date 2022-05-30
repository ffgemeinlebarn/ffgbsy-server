using System.ComponentModel.DataAnnotations;
using ffg.BSY.Attributes;

namespace ffg.BSY.Data;

public class Drucker : AuditBase
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string? Standort { get; set; }

    [StringLength(100)]
    [IpAddressFormat]
    public string Ip { get; set; } = null!;

    [Range(0, 65535, ErrorMessage = "Der Port zwischen 0 und 65535 liegen!")]
    public int Port { get; set; } = 9100;
}
