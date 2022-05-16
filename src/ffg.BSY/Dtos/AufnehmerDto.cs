namespace ffg.BSY.Dtos;

public class AufnehmerDto
{
    public int Id { get; set; }
    public string Vorname { get; set; } = String.Empty;
    public string Nachname { get; set; } = String.Empty;
    public bool Aktiv { get; set; }
    public int ZoomLevel { get; set; }
}