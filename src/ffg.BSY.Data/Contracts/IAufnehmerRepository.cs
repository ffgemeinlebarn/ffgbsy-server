using ffg.BSY.Dtos;

namespace ffg.BSY.Data.Contracts;

public interface IAufnehmerRepository
{
    AufnehmerDto? Read(int id);
    IQueryable<AufnehmerDto> Read();
    AufnehmerDto Create(AufnehmerDto entity);
    AufnehmerDto Update(AufnehmerDto entity);
    bool Activate(int id);
    bool Deactivate(int id);
    bool Delete(int id);
}