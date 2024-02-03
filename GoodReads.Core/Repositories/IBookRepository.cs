using GoodReads.Core.Contracts;
using GoodReads.Core.Entities;

namespace GoodReads.Core.Repositories;

/// <summary>
/// Represents a contract of a book repository.
/// </summary>
public interface IBookRepository : IRepository<Book>
{
    /// <summary>
    /// Save a rating.
    /// </summary>
    /// <param name="rating"></param>
    /// <returns></returns>
    public Task SaveRating(Rating rating);
    
    /// <summary>
    /// Checks if ISBN is unique.
    /// </summary>
    /// <param name="isbn"></param>
    /// <returns></returns>
    public Task<bool> IsIsbnUnique(string isbn);
}