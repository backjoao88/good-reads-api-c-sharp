namespace GoodReads.Core.Primitives;

/// <summary>
/// Represents a generic API error.
/// </summary>
public class Error
{
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }
    
    /// <summary>
    /// Represents an empty error.
    /// </summary>
    public static Error None => new Error(string.Empty, String.Empty);    
    public string Code { get; set; }
    public string Message { get; set; }
}

public static class DomainErrors
{
    public static class Book
    {
        public static Error RateNotInRangeError =
            new("Rate.NotInRangeError", "The book rate is not within the correct range.");
        public static Error BookNotFoundError => new("Book.NotFoundError", "The book was not found.");
        public static Error IsbnNotUniqueError =>
            new("Book.IsbnNotUniqueError", "The ISBN informed is not unique in the database.");
    }
}