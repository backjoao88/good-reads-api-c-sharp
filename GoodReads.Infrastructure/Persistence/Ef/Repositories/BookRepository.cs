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
    
    /// <summary>
    /// Save a new book.
    /// </summary>
    /// <param name="entity"></param>
    public async Task Save(Book entity)
    {
        await _dbContext.Books.AddAsync(entity);
    }
    
    /// <summary>
    /// Retrieve all books saved.
    /// </summary>
    /// <returns>A list of books</returns>
    public async Task<List<Book>> GetAllAsync()
    {
        return await _dbContext.Books.Include(o => o.Ratings).ToListAsync();
    }

    public List<Book> GetAll()
    {
        return _dbContext.Books.Include(o => o.Ratings).ToList();
    }

    /// <summary>
    /// Retrieve the requested book.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>A book entity</returns>
    public async Task<Book?> GetById(int id)
    {
        return await _dbContext.Books.Include(o => o.Ratings).SingleOrDefaultAsync(o => o.Id == id);
    }

    /// <summary>
    /// Save a new rating.
    /// </summary>
    /// <param name="entity"></param>
    public async Task SaveRating(Rating entity)
    {
        await _dbContext.Ratings.AddAsync(entity);
    }

    /// <summary>
    /// Checks if the ISBN required is unique in this repository.
    /// </summary>
    /// <param name="isbn"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<bool> IsIsbnUnique(string isbn)
    {
        return !await _dbContext.Books.AnyAsync(o => o.Isbn == isbn);
    }
}