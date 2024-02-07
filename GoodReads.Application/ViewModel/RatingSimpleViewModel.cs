namespace GoodReads.Application.ViewModel;

/// <summary>
/// Represents a simple rating view model.
/// </summary>
public class RatingSimpleViewModel
{
    public RatingSimpleViewModel(int rate, string description, int idUser)
    {
        Rate = rate;
        Description = description;
        IdUser = idUser;
    }
    public int Rate { get; set; }
    public string Description { get; set; }
    public int IdUser { get; set; }
}