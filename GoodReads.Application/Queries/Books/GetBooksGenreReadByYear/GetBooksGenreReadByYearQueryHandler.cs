using GoodReads.Application.ViewModel;
using GoodReads.Core.Contracts;
using GoodReads.Core.Entities;
using GoodReads.Core.Enumerations;
using MediatR;

namespace GoodReads.Application.Queries.Books.GetBooksGenreReadByYear;

/// <summary>
/// Represents the <see cref="GetBooksGenreReadByYearQuery"/> handler.
/// </summary>
public class GetBooksGenreReadByYearQueryHandler : IRequestHandler<GetBooksGenreReadByYearQuery, List<BookGenreReadViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetBooksGenreReadByYearQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<BookGenreReadViewModel>> Handle(GetBooksGenreReadByYearQuery request, CancellationToken cancellationToken)
    {
        var reportYear = request.Year;
        var allBooks = await _unitOfWork
            .BookRepository.GetAllAsync();
        var allRatings = allBooks
            .SelectMany(o => o.Ratings);
        var allBooksWithRatingsInRequiredYearTasks = allRatings
            .Where(o => o.Registration.Year == reportYear)
            .Select(async o => await _unitOfWork.BookRepository.GetById(o.IdBook));

        // needs to run sequentially
        List<Book?> allBooksWithRatingsInRequiredYear = new List<Book?>();
        foreach (var task in allBooksWithRatingsInRequiredYearTasks)
        {
            var book = await task;
            allBooksWithRatingsInRequiredYear.Add(book);
        }
        
        var listBookGenreReadViewModel = allBooksWithRatingsInRequiredYear
            .GroupBy(o => o!.Genre)
            .Select(o => new BookGenreReadViewModel(
                reportYear,
                Enum.GetName(typeof(EBookGenre), o.Key)!
                , o.Count())
            )
            .ToList();
        
        return listBookGenreReadViewModel;
    }
}