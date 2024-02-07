using GoodReads.Application.ViewModel;
using GoodReads.Core.Contracts;
using MediatR;

namespace GoodReads.Application.Queries.Books.GetBooksGenreReadByYear;

/// <summary>
/// Represents a query to retrieve the books read by genre and by user.
/// </summary>
public class GetBooksGenreReadByYearQuery : IRequest<List<BookGenreReadViewModel>>
{
    public int IdUser { get; set; }
    public int Year { get; set; }

    public GetBooksGenreReadByYearQuery(int year, int idUser)
    {
        Year = year;
        IdUser = idUser;
    }
}