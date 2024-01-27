using GoodReads.Core.Contracts;
using GoodReads.Core.Repositories;

namespace GoodReads.Infrastructure.Persistence.Ef;

/// <summary>
/// Represents a concrete implementation of a EF unit of work.
/// </summary>
public class EfUnitOfWork : IUnitOfWork
{
    public EfUnitOfWork(IBookRepository bookRepository, EfDbContext dbContext)
    {
        BookRepository = bookRepository;
        _dbContext = dbContext;
    }

    private readonly EfDbContext _dbContext;
    public IBookRepository BookRepository { get; set; }
    
    /// <summary>
    /// Commit all changes made to the database. 
    /// </summary>
    /// <returns></returns>
    public async Task<int> Complete()
    {
        return await _dbContext.SaveChangesAsync();
    }
}