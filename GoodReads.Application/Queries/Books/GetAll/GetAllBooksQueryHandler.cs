﻿using GoodReads.Application.ViewModel;
using GoodReads.Core.Contracts;
using MediatR;

namespace GoodReads.Application.Queries.Books.GetAll;

/// <summary>
/// Represents the <see cref="GetAllBooksQuery"/> handler.
/// </summary>
public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookSimpleViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllBooksQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<BookSimpleViewModel>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _unitOfWork.BookRepository.GetAllAsync();
        var booksSimpleViewModel = books.Select(
            o => 
                new BookSimpleViewModel(
                    o.Id, 
                    o.Title, 
                    o.Description, 
                    o.Ratings.Select(r => new RatingSimpleViewModel(r.Rate, r.Description)).ToList(),
                    o.AverageRate
                )
        ).ToList();
        return booksSimpleViewModel;
    }
}