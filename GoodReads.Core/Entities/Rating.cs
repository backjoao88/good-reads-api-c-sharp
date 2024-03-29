﻿using GoodReads.Core.Primitives;
using GoodReads.Core.Primitives.Result;

namespace GoodReads.Core.Entities;

/// <summary>
/// Entity used to represent a rating.
/// </summary>
public class Rating : Entity
{
    public Rating(string description, int rate, int idBook, int idUser)
    {
        Rate = rate;
        Description = description;
        IdBook = idBook;
        IdUser = idUser;
        Registration = DateTime.Now;
    }
    
    public int Rate { get; set; }
    public string Description { get; private set; }
    public int IdBook { get; private set; }
    public int IdUser { get; private set; }
    public User User { get; private set; } = null!;
    public DateTime Registration { get; private set; }
    
    /// <summary>
    /// Checks if the current rate is within the correct range.
    /// </summary>
    /// <returns>A bool result.</returns>
    public Result IsInCorrectRange()
    {
        const int maxRateThresold = 5;
        const int minRateThresold = 1;
        if (Rate < minRateThresold || Rate > maxRateThresold)
        {
            return Result.Fail(DomainErrors.Book.RateNotInRangeError);
        }
        return Result.Ok();
    }
    
}