using BookStore.InternalContracts.BooksQueries;
using BookStore.Services.BooksService;
using MediatR;

namespace BookStore.Handlers.Books
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookQuery, string>
    {
        private readonly IBooksService _booksService;
        public UpdateBookHandler(IBooksService booksService)
        {
            _booksService = booksService;
        }

        public async Task<string> Handle(UpdateBookQuery request, CancellationToken cancellationToken)
        {
            return await _booksService.UpdateBook(request);
        }
    }
}
