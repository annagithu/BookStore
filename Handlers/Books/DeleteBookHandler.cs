using BookStore.Services.BooksService;
using MediatR;
using BookStore.InternalContracts.BooksQueries;

namespace BookStore.Handlers.Books
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookQuery, string>
    {
        private readonly IBooksService _booksService;
        public DeleteBookHandler(IBooksService booksService)
        {
            _booksService = booksService;
        }

        public async Task<string> Handle(DeleteBookQuery request, CancellationToken cancellationToken)
        {
            return await _booksService.DeleteBook(request.Id);
        }
    }
}
