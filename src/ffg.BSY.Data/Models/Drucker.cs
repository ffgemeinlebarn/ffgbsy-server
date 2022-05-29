using System.ComponentModel.DataAnnotations;

namespace ffg.BSY.Data;

public class Drucker
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string? Standort { get; set; }

    [StringLength(100)]
    [RegularExpression("^((25[0-5]|(2[0-4]|1\\d|[1-9]|)\\d)(\\.(?!$)|$)){4}$")]
    public string Ip { get; set; } = null!;

    [Range(0, 65535)]
    public int Port { get; set; } = 9100;
}
