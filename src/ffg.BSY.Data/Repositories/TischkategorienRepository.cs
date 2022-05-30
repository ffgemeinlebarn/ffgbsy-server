using ffg.BSY.Contracts;
using ffg.BSY.Dtos;

namespace ffg.BSY.Data.Repositories;

public class TischkategorienRepository : ITischkategorienRepository
{
    private readonly DataContext context;

    public TischkategorienRepository(DataContext context)
    {
        if (context is null)
            throw new ArgumentNullException(nameof(context));

        this.context = context;
    }

    public TischkategorieDto? Read(int id)
    {
        Tischkategorie? entity = this.context.Tischkategorien.SingleOrDefault(a => a.Id == id);
        return entity is null ? null : Map(entity);
    }

    public IQueryable<TischkategorieDto> Read()
    {
        return this.context.Tischkategorien.Select(entity => Map(entity)).AsQueryable();
    }

    public TischkategorieDto Create(TischkategorieDto entityDto)
    {
        Tischkategorie entity = Map(entityDto);
        this.context.Tischkategorien.Add(entity);
        this.context.SaveChanges();

        return Map(entity);
    }

    public TischkategorieDto Update(TischkategorieDto entityDto)
    {
        Tischkategorie entity = Map(entityDto);
        this.context.Tischkategorien.Update(entity);
        this.context.SaveChanges();

        return Map(entity);
    }

    public bool Delete(int id)
    {
        this.context.Tischkategorien.Remove(new Tischkategorie { Id = id });
        return this.context.SaveChanges() > 0;
    }

    #region Mapping

    private static TischkategorieDto Map(Tischkategorie entity) => new TischkategorieDto
    {
        Id = entity.Id,
        Name = entity.Name ?? String.Empty,
        Sortierindex = entity.Sortierindex
    };

    private static Tischkategorie Map(TischkategorieDto entity) => new Tischkategorie
    {
        Id = entity.Id,
        Name = entity.Name ?? String.Empty,
        Sortierindex = entity.Sortierindex
    };

    #endregion
}
