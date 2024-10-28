using BookStore.InternalContracts.BooksQueries;
using BookStore.InternalContracts.Models;
using BookStore.Services.BooksService;
using MediatR;

namespace BookStore.Handlers.Books
{
    public class FilterBooksHandler : IRequestHandler<FilterBooksQuery, List<BookModel>>
    {
        private readonly IBooksService _booksService;
        public FilterBooksHandler(IBooksService booksService)
        {
            _booksService = booksService;
        }

        public async Task<List<BookModel>> Handle(FilterBooksQuery request, CancellationToken cancellationToken)
        {
            return await _booksService.FilterBooks(request);
        }
    }
}
