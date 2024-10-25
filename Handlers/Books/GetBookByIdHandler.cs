using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.Commands;
using BookStore.Services.BooksService;
using MediatR;

namespace BookStore.Handlers.Books
{
    
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdCommand, BookModel>
    {
        private readonly IBooksService _booksService;
        public GetBookByIdHandler(IBooksService booksService)
        {
            _booksService = booksService;
        }

        public async Task<BookModel> Handle(GetBookByIdCommand request, CancellationToken cancellationToken)
        {
            return await _booksService.GetBookById(request.Id);
        }
    }
}
