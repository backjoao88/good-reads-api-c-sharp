using GoodReads.Application.ViewModel;
using MediatR;

namespace GoodReads.Application.Queries.Books.GetAll;

/// <summary>
/// Represents a command to retrieve all books.
/// </summary>
public class GetAllBooksQuery : IRequest<List<BookSimpleViewModel>>;