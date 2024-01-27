using GoodReads.Core.Primitives;

namespace GoodReads.Core.Contracts;

/// <summary>
/// Represent a generic repository contract.
/// </summary>
public interface IRepository<T> where T: Entity
{
    public Task Save(T entity);
    public Task<List<T>> GetAllAsync();
    public List<T> GetAll();
    public Task<T?> GetById(int id);
}