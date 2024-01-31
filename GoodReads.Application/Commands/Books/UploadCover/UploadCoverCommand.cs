using GoodReads.Core.Primitives.Result;
using MediatR;

namespace GoodReads.Application.Commands.Books.UpdateCover;

/// <summary>
/// Represents a command to upload the book cover.
/// </summary>
public class UploadCoverCommand : IRequest<Result>
{
    public UploadCoverCommand(int idBook, Stream stream)
    {
        IdBook = idBook;
        Stream = stream;
    }
    public int IdBook { get; set; }
    public Stream Stream{ get; set; }
}