using BookStore.InternalContracts.BooksCommands;
using BookStore.InternalContracts.Models;
using BookStore.Services.BooksService;
using MediatR;

namespace BookStore.Handlers.Books
{
    public class SortBooksHandler : IRequestHandler<SortBooksCommand, List<BookModel>>
    {
        private readonly IBooksService _booksService;
        public SortBooksHandler(IBooksService booksService)
        {
            _booksService = booksService;
        }

        public async Task<List<BookModel>> Handle(SortBooksCommand request, CancellationToken cancellationToken)
        {
            return await _booksService.SortBooks(request);
        }
    }
}
