namespace GoodReads.Application.ViewModel;

/// <summary>
/// Represents a simple rating view model.
/// </summary>
public class RatingSimpleViewModel
{
    public RatingSimpleViewModel(int rate, string description)
    {
        Rate = rate;
        Description = description;
    }
    public int Rate { get; set; }
    public string Description { get; set; }
}