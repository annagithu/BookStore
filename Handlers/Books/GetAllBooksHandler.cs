using BookStore.InternalContracts.BooksCommands;
using BookStore.InternalContracts.Models;
using BookStore.Services.BooksService;
using MediatR;

namespace BookStore.Handlers.Books
{
    public class GetAllBooksHandler : IRequestHandler <GetAllBooksCommand, List<BookModel>>
    {
        private readonly IBooksService _booksService;
        public GetAllBooksHandler(IBooksService booksService)
        {
            _booksService = booksService;
        }

        public async Task <List<BookModel>> Handle(GetAllBooksCommand request, CancellationToken cancellationToken)
        {
            return await _booksService.GetAllBooks();
        }
    }
}
