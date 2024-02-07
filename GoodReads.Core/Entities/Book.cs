using GoodReads.Core.Enumerations;
using GoodReads.Core.Primitives;

namespace GoodReads.Core.Entities;

/// <summary>
/// Entity used to represent a book.
/// </summary>
public class Book : Entity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Isbn { get; private set; }
    public EBookGenre Genre { get; private set; }
    public DateTime Registration { get; private set; }
    public double AverageRate { get; private set; }
    public byte[]? Cover { get; private set; } = null!;
    public List<Rating> Ratings { get; set; } = null!;

    /// <summary>
    /// Book base constructor.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="description"></param>
    /// <param name="isbn"></param>
    /// <param name="genre"></param>
    public Book(string title, string description, string isbn, EBookGenre genre) 
    {
        Title = title;
        Description = description;
        Isbn = isbn;
        Genre = genre;
    }

    /// <summary>
    /// Responsible for updating the book basic information.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="description"></param>
    /// <param name="isbn"></param>
    public void Update(string title, string description, string isbn)
    {
        Title = title;
        Description = description;
        Isbn = isbn;
    }

    /// <summary>
    /// Responsible for updating the current book cover.
    /// </summary>
    /// <param name="newCover"></param>
    public void UpdateCover(byte[] newCover)
    {
        Cover = newCover;
    }

    /// <summary>
    /// Recalculates the average rating based in the current ratings.
    /// </summary>
    public void RecalculateRate()
    {
        if (!Ratings.Any())
        {
            return;
        }
        AverageRate = Ratings.Average(o => o.Rate);
    }
}