using ffg.BSY.Dtos;

namespace ffg.BSY.Data.Contracts;

public interface IDruckerRepository
{
    DruckerDto? Read(int id);
    IQueryable<DruckerDto> Read();
    DruckerDto Create(DruckerDto entity);
    DruckerDto Update(DruckerDto entity);
    bool Delete(int id);
}