using ffg.BSY.Contracts;
using ffg.BSY.Dtos;

namespace ffg.BSY.Data.Repositories;

public class TischeRepository : ITischeRepository
{
    private readonly DataContext context;

    public TischeRepository(DataContext context)
    {
        if (context is null)
            throw new ArgumentNullException(nameof(context));

        this.context = context;
    }

    public TischDto? Read(int id)
    {
        return
            this.context.Tische
            .Where(entity => entity.Id == id)
            .Select(entity => new TischDto
            {
                Id = entity.Id,
                Reihe = entity.Reihe,
                Nummer = entity.Nummer,
                Sortierindex = entity.Sortierindex,
                Tischkategorie = null
            })
            .FirstOrDefault();
    }

    public TischDto? ReadWithKategorie(int id)
    {
        return this.context.Tische
            .Join(
                this.context.Tischkategorien,
                tisch => tisch.TischkategorienId,
                kategorie => kategorie.Id,
                (tisch, kategorie) => new { tisch, kategorie }
            )
            .Where(entity => entity.tisch.Id == id)
            .Select(entity => new TischDto
            {
                Id = entity.tisch.Id,
                Reihe = entity.tisch.Reihe,
                Nummer = entity.tisch.Nummer,
                Sortierindex = entity.tisch.Sortierindex,
                Tischkategorie = new TischkategorieDto
                {
                    Id = entity.kategorie.Id,
                    Name = entity.kategorie.Name,
                    Sortierindex = entity.kategorie.Sortierindex
                }
            })
            .SingleOrDefault();
    }

    public IQueryable<TischDto> Read()
    {
        return
            this.context.Tische
            .Select(entity => new TischDto
            {
                Id = entity.Id,
                Reihe = entity.Reihe,
                Nummer = entity.Nummer,
                Sortierindex = entity.Sortierindex,
                Tischkategorie = null
            })
            .AsQueryable();
    }

    public TischDto Create(TischDto entity)
    {
        if (entity.Tischkategorie is null)
            throw new ArgumentNullException(nameof(entity.Tischkategorie));

        var tisch = new Tisch
        {
            Id = entity.Id,
            Reihe = entity.Reihe,
            Nummer = entity.Nummer,
            Sortierindex = entity.Sortierindex,
            TischkategorienId = entity.Tischkategorie.Id
        };
        this.context.Tische.Add(tisch);
        this.context.SaveChanges();

        return this.Read(tisch.Id)!;
    }

    public TischDto Update(TischDto entity)
    {
        if (entity.Tischkategorie is null)
            throw new ArgumentNullException(nameof(entity.Tischkategorie));

        this.context.Tische.Update(new Tisch
        {
            Id = entity.Id,
            Reihe = entity.Reihe,
            Nummer = entity.Nummer,
            Sortierindex = entity.Sortierindex,
            TischkategorienId = entity.Tischkategorie.Id
        });

        this.context.SaveChanges();

        return this.Read(entity.Id)!;
    }

    public bool Delete(int id)
    {
        this.context.Tische.Remove(new Tisch { Id = id });
        return this.context.SaveChanges() > 0;
    }
}
