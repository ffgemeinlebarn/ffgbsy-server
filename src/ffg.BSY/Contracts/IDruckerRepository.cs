using ffg.BSY.Dtos;

namespace ffg.BSY.Contracts;

public interface IDruckerRepository
{
    DruckerDto? Read(int id);
    IQueryable<DruckerDto> Read();
    DruckerDto Create(DruckerDto entity);
    DruckerDto Update(DruckerDto entity);
    bool Delete(int id);
}
