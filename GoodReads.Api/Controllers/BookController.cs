using GoodReads.Api.Abstractions;
using GoodReads.Application.Commands.Books.Create;
using GoodReads.Application.Commands.Books.CreateRating;
using GoodReads.Application.Queries.Books.GetAll;
using GoodReads.Application.Queries.Books.GetBooksGenreReadByYear;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoodReads.Api.Controllers;

[ApiController]
[Route("/api/books")]
public class BookController : ApiController
{
    private readonly IMediator _mediator;

    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Post a new book.
    /// </summary>
    /// <param name="createBookCommand"></param>
    /// <returns>A status 204 NO CONTENT</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Post([FromBody] CreateBookCommand createBookCommand)
    {
        var result = await _mediator.Send(createBookCommand);
        return result.IsSuccess ? Created() : BadRequest(result.Error);
    }

    /// <summary>
    /// Post a new book rating.
    /// </summary>
    /// <param name="idBook"></param>
    /// <param name="createRatingCommand"></param>
    /// <returns>A status 204 NO CONTENT</returns>
    [HttpPost("{idBook}/ratings")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> PostRate(int idBook, [FromBody] CreateRatingCommand createRatingCommand)
    {
        createRatingCommand.IdBook = idBook;
        var result = await _mediator.Send(createRatingCommand);
        return result.IsSuccess ? Created() : BadRequest(result.Error);
    }
    
    /// <summary>
    /// Retrieve all books saved.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var getAllBooksQuery = new GetAllBooksQuery();
        var booksSimpleViewModel = await _mediator.Send(getAllBooksQuery);
        return Ok(booksSimpleViewModel);
    }
    
    /// <summary>
    /// Represents the endpoint for retrieving the report of books genre read by year.
    /// </summary>
    /// <param name="year"></param>
    /// <returns></returns>
    [HttpGet("{year}/year")]
    public async Task<IActionResult> GetBooksGenreReadByYear(int year)
    {
        var getBooksGenreReadByYear = new GetBooksGenreReadByYearQuery(year);
        var booksGenreReadByYear = await _mediator.Send(getBooksGenreReadByYear);
        return Ok(booksGenreReadByYear);
    }
}