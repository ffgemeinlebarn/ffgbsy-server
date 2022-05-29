using ffg.BSY.Data.Contracts;
using ffg.BSY.Dtos;

namespace ffg.BSY.Data.Repositories;

public class AufnehmerRepository : IAufnehmerRepository
{
    private readonly DataContext context;

    public AufnehmerRepository(DataContext context)
    {
        this.context = context;
    }

    public AufnehmerDto? Read(int id)
    {
        Aufnehmer? entity = this.context.Aufnehmer.SingleOrDefault(a => a.Id == id);
        return entity is null ? null : Map(entity);
    }

    public IQueryable<AufnehmerDto> Read()
    {
        return this.context.Aufnehmer.Select(entity => Map(entity)).AsQueryable();
    }

    public AufnehmerDto Create(AufnehmerDto entityDto)
    {
        Aufnehmer entity = Map(entityDto);
        this.context.Aufnehmer.Add(entity);
        this.context.SaveChanges();

        return Map(entity);
    }

    public AufnehmerDto Update(AufnehmerDto entityDto)
    {
        Aufnehmer entity = Map(entityDto);
        this.context.Aufnehmer.Update(entity);
        this.context.SaveChanges();

        return Map(entity);
    }

    public bool Delete(int id)
    {
        this.context.Aufnehmer.Remove(new Aufnehmer { Id = id });
        return this.context.SaveChanges() > 0;
    }

    #region Mapping

    private static AufnehmerDto Map(Aufnehmer entity) => new AufnehmerDto
    {
        Id = entity.Id,
        Vorname = entity.Vorname ?? String.Empty,
        Nachname = entity.Nachname ?? String.Empty,
        Aktiv = entity.Aktiv,
        ZoomLevel = entity.ZoomLevel
    };

    private static Aufnehmer Map(AufnehmerDto entity) => new Aufnehmer
    {
        Id = entity.Id,
        Vorname = entity.Vorname ?? String.Empty,
        Nachname = entity.Nachname ?? String.Empty,
        Aktiv = entity.Aktiv,
        ZoomLevel = entity.ZoomLevel
    };

    #endregion
}