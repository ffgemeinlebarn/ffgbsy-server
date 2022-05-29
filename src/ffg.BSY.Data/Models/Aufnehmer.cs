namespace ffg.BSY.Data;

public partial class Aufnehmer
{
    public Aufnehmer()
    {
        Bestellungens = new HashSet<Bestellung>();
    }

    public int Id { get; set; }
    public string? Vorname { get; set; }
    public string? Nachname { get; set; }
    public bool Aktiv { get; set; }
    public int ZoomLevel { get; set; }

    public virtual ICollection<Bestellung> Bestellungens { get; set; }
}
