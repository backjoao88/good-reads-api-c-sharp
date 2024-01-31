using GoodReads.Core.Entities;

namespace GoodReads.Application.ViewModel;

/// <summary>
/// Represents a simple <see cref="Book"/> view model.
/// </summary>
public class BookSimpleViewModel
{
    public BookSimpleViewModel(string title, string publisher)
    {
        Title = title;
        Publisher = publisher;
    }
    public string Title { get; set; }
    public string Publisher { get; set; }
}