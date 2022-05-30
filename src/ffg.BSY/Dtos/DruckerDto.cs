using System.ComponentModel.DataAnnotations;

namespace ffg.BSY.Dtos;

public class DruckerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string? Standort { get; set; }

    [RegularExpression("^((25[0-5]|(2[0-4]|1\\d|[1-9]|)\\d)(\\.(?!$)|$)){4}$")]
    public string Ip { get; set; } = String.Empty;

    public int Port { get; set; }
}