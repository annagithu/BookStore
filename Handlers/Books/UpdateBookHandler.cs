using BookStore.InternalContracts.BooksQueries;
using BookStore.Services.BooksService;
using MediatR;

namespace BookStore.Handlers.Books
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IBooksService _booksService;
        public UpdateBookHandler(IBooksService booksService)
        {
            _booksService = booksService;
        }

        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            await _booksService.UpdateBook(request);
        }
    }
}
