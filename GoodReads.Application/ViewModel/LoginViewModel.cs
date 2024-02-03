namespace GoodReads.Application.ViewModel;

/// <summary>
/// Represents a successful login.
/// </summary>
/// <param name="UserId"></param>
/// <param name="Token"></param>
public record LoginViewModel(string UserId, string Token);