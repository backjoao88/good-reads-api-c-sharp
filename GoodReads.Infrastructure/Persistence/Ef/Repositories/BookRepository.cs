using GoodReads.Core.Entities;
using GoodReads.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GoodReads.Infrastructure.Persistence.Ef.Repositories;

/// <summary>
/// Represents a concrete repository implementation for <see cref="Book"/> entity.
/// </summary>
public class BookRepository : IBookRepository
{
    private readonly EfDbContext _dbContext;

    public BookRepository(EfDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    /// <inheritdoc />
    public async Task Save(Book entity)
    {
        await _dbContext.Books.AddAsync(entity);
    }
    
    /// <inheritdoc />
    public async Task<List<Book>> GetAllAsync()
    {
        return await _dbContext.Books.Include(o => o.Ratings).ToListAsync();
    }

    /// <inheritdoc />
    public List<Book> GetAll()
    {
        return _dbContext.Books.Include(o => o.Ratings).ToList();
    }

    /// <inheritdoc />
    public async Task<Book?> GetById(int id)
    {
        return await _dbContext.Books.Include(o => o.Ratings).SingleOrDefaultAsync(o => o.Id == id);
    }

    /// <inheritdoc />
    public async Task SaveRating(Rating entity)
    {
        await _dbContext.Ratings.AddAsync(entity);
    }

    /// <inheritdoc />
    public async Task<bool> IsIsbnUnique(string isbn)
    {
        return !await _dbContext.Books.AnyAsync(o => o.Isbn == isbn);
    }
}