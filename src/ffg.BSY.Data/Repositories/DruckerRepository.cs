using ffg.BSY.Contracts;
using ffg.BSY.Dtos;

namespace ffg.BSY.Data.Repositories;

public class DruckerRepository : IDruckerRepository
{
    private readonly DataContext context;

    public DruckerRepository(DataContext context)
    {
        this.context = context;
    }

    public DruckerDto? Read(int id)
    {
        Drucker? entity = this.context.Drucker.SingleOrDefault(a => a.Id == id);
        return entity is null ? null : Map(entity);
    }

    public IQueryable<DruckerDto> Read()
    {
        return this.context.Drucker.Select(entity => Map(entity)).AsQueryable();
    }

    public DruckerDto Create(DruckerDto entityDto)
    {
        Drucker entity = Map(entityDto);
        this.context.Drucker.Add(entity);
        this.context.SaveChanges();

        return Map(entity);
    }

    public DruckerDto Update(DruckerDto entityDto)
    {
        Drucker entity = Map(entityDto);
        this.context.Drucker.Update(entity);
        this.context.SaveChanges();

        return Map(entity);
    }

    public bool Delete(int id)
    {
        this.context.Drucker.Remove(new Drucker { Id = id });
        return this.context.SaveChanges() > 0;
    }

    #region Mapping

    private static DruckerDto Map(Drucker entity) => new DruckerDto
    {
        Id = entity.Id,
        Name = entity.Name ?? String.Empty,
        Standort = entity.Standort ?? String.Empty,
        Ip = entity.Ip,
        Port = entity.Port
    };

    private static Drucker Map(DruckerDto entity) => new Drucker
    {
        Id = entity.Id,
        Name = entity.Name ?? String.Empty,
        Standort = entity.Standort ?? String.Empty,
        Ip = entity.Ip,
        Port = entity.Port
    };

    #endregion
}
