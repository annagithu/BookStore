using BookStore.InternalContracts.Models;
using BookStore.Services.BooksService;
using MediatR;

namespace BookStore.Handlers.Books
{
    public class CreateBookHandler : IRequestHandler<BookModel, BookModel>
    {
        private readonly IBooksService _booksService;
        public CreateBookHandler(IBooksService booksService)
        {
            _booksService = booksService;
        }

        public async Task<BookModel> Handle(BookModel request, CancellationToken cancellationToken)
        {
            return await _booksService.CreateBook(request);
        }
    }
}
