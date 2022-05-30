using ffg.BSY.Attributes;

namespace ffg.BSY.Dtos;

public class DruckerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string? Standort { get; set; }

    [IpAddressFormat]
    public string Ip { get; set; } = String.Empty;

    public int Port { get; set; } = default;
}
