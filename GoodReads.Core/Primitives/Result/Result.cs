namespace GoodReads.Core.Primitives.Result;

/// <summary>
/// Represents a bool result.
/// </summary>
public class Result
{
    public Result(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }
    public Error Error { get; set; }
    public bool IsSuccess { get; set; }

    public bool IsFailure => !IsSuccess;
    
    /// <summary>
    /// Creates a successfull bool result.
    /// </summary>
    /// <returns>A bool result</returns>
    public static Result Ok() => new(true, Error.None);
    
    /// <summary>
    /// Creates a successful generic result.
    /// </summary>
    /// <param name="data"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns>A generic result</returns>
    public static Result<TValue> Ok<TValue>(TValue data) => new (data, true, Error.None);
    
    /// <summary>
    /// Creates a failled bool result.
    /// </summary>
    /// <param name="error"></param>
    /// <returns>A bool result</returns>
    public static Result Fail(Error error) => new(false, error);
    
    /// <summary>
    /// Creates a failed generic result.
    /// </summary>
    /// <param name="error"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns>A generic result</returns>
    public static Result<TValue> Fail<TValue>(Error error) => new(default!, false, error);
}

/// <summary>
/// Represents a generic result.
/// </summary>
/// <typeparam name="TValue"></typeparam>
public class Result<TValue> : Result
{
    public TValue Data { get; set; }
    public Result(TValue data, bool isSuccess, Error error) : base(isSuccess, error)
    {
        Data = data;
    }
}