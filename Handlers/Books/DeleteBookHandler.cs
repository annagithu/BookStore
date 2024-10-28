using BookStore.Services.BooksService;
using MediatR;
using BookStore.InternalContracts.BooksQueries;

namespace BookStore.Handlers.Books
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, string>
    {
        private readonly IBooksService _booksService;
        public DeleteBookHandler(IBooksService booksService)
        {
            _booksService = booksService;
        }

        public async Task<string> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            return await _booksService.DeleteBook(request.Id);
        }
    }
}
