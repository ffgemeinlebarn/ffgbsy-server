using ffg.BSY.Attributes;

namespace ffg.BSY.Dtos;

public class TischkategorieDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int Sortierindex { get; set; }
}
