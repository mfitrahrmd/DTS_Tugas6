namespace DTS_Tugas6.Repositories;

public interface IBaseRepository<TPk, T> where T : class
{
    Task<T> InsertOne(T entity);
    Task<IEnumerable<T>> FindAll();
    Task<T?> FindOneByPk(TPk pk);
    Task<T?> DeleteOneByPk(TPk pk);
    Task<T?> UpdateOneByPk(TPk pk, T entity);
}