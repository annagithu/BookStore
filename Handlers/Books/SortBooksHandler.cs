using BookStore.InternalContracts.BooksQueries;
using BookStore.InternalContracts.Models;
using BookStore.Services.BooksService;
using MediatR;

namespace BookStore.Handlers.Books
{
    public class SortBooksHandler : IRequestHandler<SortBooksQuery, List<BookModel>>
    {
        private readonly IBooksService _booksService;
        public SortBooksHandler(IBooksService booksService)
        {
            _booksService = booksService;
        }

        public async Task<List<BookModel>> Handle(SortBooksQuery request, CancellationToken cancellationToken)
        {
            return await _booksService.SortBooks(request);
        }
    }
}
