using ffg.BSY.Dtos;

namespace ffg.BSY.Contracts;

public interface IAufnehmerRepository
{
    AufnehmerDto? Read(int id);
    IQueryable<AufnehmerDto> Read();
    AufnehmerDto Create(AufnehmerDto entity);
    AufnehmerDto Update(AufnehmerDto entity);
    bool Delete(int id);

    bool Activate(int id);
    bool Deactivate(int id);
}
