using ffg.BSY.Dtos;

namespace ffg.BSY.Contracts;

public interface ITischkategorienRepository
{
    TischkategorieDto? Read(int id);
    IQueryable<TischkategorieDto> Read();
    TischkategorieDto Create(TischkategorieDto entity);
    TischkategorieDto Update(TischkategorieDto entity);
    bool Delete(int id);
}
