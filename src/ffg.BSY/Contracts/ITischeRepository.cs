using ffg.BSY.Dtos;

namespace ffg.BSY.Contracts;

public interface ITischeRepository
{
    TischDto? Read(int id);
    TischDto? ReadWithKategorie(int id);
    IQueryable<TischDto> Read();
    TischDto Create(TischDto entity);
    TischDto Update(TischDto entity);
    bool Delete(int id);
}
