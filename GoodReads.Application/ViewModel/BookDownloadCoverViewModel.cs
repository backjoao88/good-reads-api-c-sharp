namespace GoodReads.Application.ViewModel;

/// <summary>
/// Represents a book download cover view model
/// </summary>
public class BookDownloadCoverViewModel
{
    public Stream CoverStream;

    public BookDownloadCoverViewModel(Stream coverStream)
    {
        CoverStream = coverStream;
    }
}