using GoodReads.Core.Contracts;
using GoodReads.Core.Entities;

namespace GoodReads.Core.Repositories;

/// <summary>
/// Represents a contract of a book repository.
/// </summary>
public interface IBookRepository : IRepository<Book>
{
    public Task SaveRating(Rating rating);
    public Task<bool> IsIsbnUnique(string isbn);
}