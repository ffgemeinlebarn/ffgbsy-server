using ffg.BSY.Dtos;

namespace ffg.BSY.Data.Contracts;

public interface IAufnehmerRepository : IRepositoryBase<AufnehmerDto>
{
    AufnehmerDto? Read(int id);
    IQueryable<AufnehmerDto> Read();
}