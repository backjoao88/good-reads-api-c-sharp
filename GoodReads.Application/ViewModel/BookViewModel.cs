using GoodReads.Core.Entities;

namespace GoodReads.Application.ViewModel;

/// <summary>
/// Represents a <see cref="Book"/> view model.
/// </summary>
public class BookViewModel
{
    public BookViewModel(int id, string title, string description, List<RatingSimpleViewModel> ratings, double averageRate)
    {
        Id = id;
        Title = title;
        Description = description;
        Ratings = ratings;
        AverageRate = averageRate;
    }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double AverageRate { get; set; }
    public List<RatingSimpleViewModel> Ratings { get; set; }
}