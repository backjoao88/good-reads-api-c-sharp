using GoodReads.Core.Primitives;

namespace GoodReads.Core.Contracts;

/// <summary>
/// Represent a generic repository contract.
/// </summary>
public interface IRepository<T> where T: Entity
{
    /// <summary>
    /// Saves a new entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task Save(T entity);
    
    /// <summary>
    /// Retrieve all entities.
    /// </summary>
    /// <returns></returns>
    public Task<List<T>> GetAllAsync();
    
    /// <summary>
    /// Retrieve all entities.
    /// </summary>
    /// <returns></returns>
    public List<T> GetAll();
    
    /// <summary>
    /// Retrieve an entity by ID.
    /// </summary>
    /// <returns></returns>
    public Task<T?> GetById(int id);
}