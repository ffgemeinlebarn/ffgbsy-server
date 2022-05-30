namespace ffg.BSY.Dtos;

public class TischDto
{
    public int Id { get; set; }
    public string Reihe { get; set; } = String.Empty;
    public int? Nummer { get; set; }
    public int Sortierindex { get; set; }

    public TischkategorieDto? Tischkategorie { get; set; } = null;
}
