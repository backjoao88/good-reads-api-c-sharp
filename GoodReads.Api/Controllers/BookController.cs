using GoodReads.Api.Abstractions;
using GoodReads.Api.Attributes;
using GoodReads.Application.Commands.Books.Create;
using GoodReads.Application.Commands.Books.CreateRating;
using GoodReads.Application.Commands.Books.UpdateCover;
using GoodReads.Application.Queries.Books.DownloadCover;
using GoodReads.Application.Queries.Books.GetAll;
using GoodReads.Application.Queries.Books.GetBooksFromExternalSource;
using GoodReads.Application.Queries.Books.GetBooksGenreReadByYear;
using GoodReads.Core.Enumerations;
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
    /// Endpoint used to save a new book.
    /// </summary>
    /// <param name="createBookCommand"></param>
    /// <returns>A status 204 NO CONTENT</returns>
    [HttpPost]
    [HasPermission(ERole.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Post([FromBody] CreateBookCommand createBookCommand)
    {
        var result = await _mediator.Send(createBookCommand);
        return result.IsSuccess ? Created() : BadRequest(result.Error);
    }

    /// <summary>
    /// Endpoint used to save a new book rating.
    /// </summary>
    /// <param name="idBook"></param>
    /// <param name="createRatingCommand"></param>
    /// <returns>A status 204 NO CONTENT</returns>
    [HttpPost("{idBook}/ratings")]
    [HasPermission(ERole.Admin, ERole.Reader)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> PostRate(int idBook, [FromBody] CreateRatingCommand createRatingCommand)
    {
        createRatingCommand.IdBook = idBook;
        createRatingCommand.IdUser = GetAuthenticatedUserId();
        var result = await _mediator.Send(createRatingCommand);
        return result.IsSuccess ? Created() : BadRequest(result.Error);
    }
    
    /// <summary>
    /// Endpoint used to retrieve all books stored.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var getAllBooksQuery = new GetAllBooksQuery();
        var booksSimpleViewModel = await _mediator.Send(getAllBooksQuery);
        return Ok(booksSimpleViewModel);
    }
    
    /// <summary>
    /// Endpoint used for retrieving the report of books genre read by year and by user.
    /// </summary>
    /// <param name="year"></param>
    /// <returns></returns>
    [HttpGet("{year}/year")]
    [HasPermission(ERole.Admin, ERole.Reader)]
    public async Task<IActionResult> GetBooksGenreReadByYear(int year)
    {
        int idUser = GetAuthenticatedUserId();
        var getBooksGenreReadByYear = new GetBooksGenreReadByYearQuery(year, idUser);
        var booksGenreReadByYear = await _mediator.Send(getBooksGenreReadByYear);
        return Ok(booksGenreReadByYear);
    }
    
    /// <summary>
    /// Endpoint used to upload a new book cover.
    /// </summary>
    /// <param name="idBook"></param>
    /// <param name="formFileCollection"></param>
    /// <returns></returns>
    [HttpPut("{idBook}/cover/upload")]
    [HasPermission(ERole.Admin)]
    public async Task<IActionResult> UploadCover(int idBook, IFormCollection formFileCollection)
    {
        var file = formFileCollection.Files[0];
        var updateCoverCommand = new UploadCoverCommand(idBook, file.OpenReadStream());
        var result = await _mediator.Send(updateCoverCommand);
        return result.IsSuccess ? NoContent() : BadRequest(result.Error);
    }

    /// <summary>
    /// Endpoint used to download a book cover.
    /// </summary>
    /// <param name="idBook"></param>
    /// <returns></returns>
    [HttpGet("{idBook}/cover/download")]
    [HasPermission(ERole.Admin)]
    public async Task<IActionResult> DownloadCover(int idBook)
    {
        var downloadCoverQuery = new DownloadCoverQuery(idBook);
        var result = await _mediator.Send(downloadCoverQuery);
        return result.IsSuccess ? File(result.Data.CoverStream, "image/jpg") : BadRequest(result.Error);
    }

    /// <summary>
    /// Endpoint used to get books from an external source.
    /// </summary>
    /// <param name="query"></param>
    /// <param name="offset"></param>
    /// <param name="limit"></param>
    /// <returns></returns>
    [HttpGet("external")]
    [HasPermission(ERole.Admin, ERole.Reader)]
    public async Task<IActionResult> GetBooksFromExternalDataSource([FromQuery] string query, [FromQuery] int offset, [FromQuery] int limit)
    {
        var getBooksFromExternalSourceQuery = new GetBooksFromExternalSourceQuery(query, offset, limit);
        var result = await _mediator.Send(getBooksFromExternalSourceQuery);
        return Ok(result);
    }
    
}