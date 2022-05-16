using System.Linq.Expressions;

namespace ffg.BSY.Data.Contracts;

public interface IRepositoryBase<T>
{
    // IQueryable<T> FindAll();
    // IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    T Create(T entity);
    T Update(T entity);
    bool Delete(int id);
}