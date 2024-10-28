using BookStore.Services.BooksService;
using MediatR;
using BookStore.InternalContracts.BooksQueries;

namespace BookStore.Handlers.Books
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBooksService _booksService;
        public DeleteBookHandler(IBooksService booksService)
        {
            _booksService = booksService;
        }

        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
             await _booksService.DeleteBook(request.Id);
        }
    }
}
