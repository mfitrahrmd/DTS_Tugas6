namespace DTS_Tugas6.Repositories;

public interface IBaseRepository<TPk, TEntity> where TEntity : class
{
    TEntity InsertOne(TEntity entity);
    IEnumerable<TEntity> FindAll();
    TEntity? FindOneByPk(TPk pk);
    TEntity? DeleteOneByPk(TPk pk);
    TEntity? UpdateOneByPk(TPk pk, TEntity entity);
}