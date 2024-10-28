using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.BooksQueries;
using BookStore.Services.BooksService;
using MediatR;

namespace BookStore.Handlers.Books
{
    
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, BookModel>
    {
        private readonly IBooksService _booksService;
        public GetBookByIdHandler(IBooksService booksService)
        {
            _booksService = booksService;
        }

        public async Task<BookModel> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _booksService.GetBookById(request.Id);
        }
    }
}
