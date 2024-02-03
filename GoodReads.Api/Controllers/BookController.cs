using GoodReads.Api.Abstractions;
using GoodReads.Application.Commands.Books.Create;
using GoodReads.Application.Commands.Books.CreateRating;
using GoodReads.Application.Commands.Books.UpdateCover;
using GoodReads.Application.Queries.Books.DownloadCover;
using GoodReads.Application.Queries.Books.GetAll;
using GoodReads.Application.Queries.Books.GetBooksFromExternalSource;
using GoodReads.Application.Queries.Books.GetBooksGenreReadByYear;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodReads.Api.Controllers;

/// <summary>
/// Handles books requests.
/// </summary>
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
    
    /// <summary>
    /// Represents the endpoint for updating a book cover.
    /// </summary>
    /// <param name="idBook"></param>
    /// <param name="formFileCollection"></param>
    /// <returns></returns>
    [HttpPut("{idBook}/cover/upload")]
    public async Task<IActionResult> UploadCover(int idBook, IFormCollection formFileCollection)
    {
        var file = formFileCollection.Files[0];
        var updateCoverCommand = new UploadCoverCommand(idBook, file.OpenReadStream());
        var result = await _mediator.Send(updateCoverCommand);
        return result.IsSuccess ? NoContent() : BadRequest(result.Error);
    }

    /// <summary>
    /// Represents the endpoint for downlaod a book cover.
    /// </summary>
    /// <param name="idBook"></param>
    /// <returns></returns>
    [HttpGet("{idBook}/cover/download")]
    public async Task<IActionResult> DownloadCover(int idBook)
    {
        var downloadCoverQuery = new DownloadCoverQuery(idBook);
        var result = await _mediator.Send(downloadCoverQuery);
        return result.IsSuccess ? File(result.Data.CoverStream, "image/jpg") : BadRequest(result.Error);
    }

    /// <summary>
    /// Represents the endpoint for retrieving a list of books from an external data source.
    /// </summary>
    /// <param name="query"></param>
    /// <param name="offset"></param>
    /// <param name="limit"></param>
    /// <returns></returns>
    [HttpGet("external")]
    [Authorize]
    public async Task<IActionResult> GetBooksFromExternalDataSource([FromQuery] string query, [FromQuery] int offset, [FromQuery] int limit)
    {
        var getBooksFromExternalSourceQuery = new GetBooksFromExternalSourceQuery(query, offset, limit);
        var result = await _mediator.Send(getBooksFromExternalSourceQuery);
        return Ok(result);
    }
    
}