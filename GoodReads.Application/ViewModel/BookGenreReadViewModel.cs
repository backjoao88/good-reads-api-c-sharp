namespace GoodReads.Application.ViewModel;

/// <summary>
/// Represents the report of books read in the current year.
/// </summary>
public class BookGenreReadViewModel
{
    public int Year { get; set; }
    public string Genre { get; set; }
    public int Count { get; set; }

    public BookGenreReadViewModel(int year, string genre, int count)
    {
        Year = year;
        Genre = genre;
        Count = count;
    }
}