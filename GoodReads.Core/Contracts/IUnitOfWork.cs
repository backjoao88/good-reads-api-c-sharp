using GoodReads.Core.Repositories;

namespace GoodReads.Core.Contracts;

/// <summary>
/// Represents a generic unit of work.
/// </summary>
public interface IUnitOfWork
{
    public IBookRepository BookRepository { get; set; }
    public Task<int> Complete();
}