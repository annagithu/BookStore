using MediatR;
using BookStore.InternalContracts.Models;

namespace BookStore.InternalContracts.BooksQueries
{
    public class GetAllBooksQuery : IRequest<List<BookModel>>
    {
        public int? Take { get; set; }

        public int? Skip { get; set; }
    }
}
