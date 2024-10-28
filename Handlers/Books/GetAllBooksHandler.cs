using BookStore.InternalContracts.BooksQueries;
using BookStore.InternalContracts.Models;
using BookStore.Services.BooksService;
using MediatR;

namespace BookStore.Handlers.Books
{
    public class GetAllBooksHandler : IRequestHandler <GetAllBooksQuery, List<BookModel>>
    {
        private readonly IBooksService _booksService;
        public GetAllBooksHandler(IBooksService booksService)
        {
            _booksService = booksService;
        }

        public async Task <List<BookModel>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            return await _booksService.GetAllBooks(request);
        }
    }
}
