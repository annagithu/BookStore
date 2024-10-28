using MediatR;
using BookStore.InternalContracts.Models;

namespace BookStore.InternalContracts.BooksQueries
{
    public class GetBookByIdQuery : IRequest<BookModel>
    {
        public int Id { get; set; } 
    }
}
