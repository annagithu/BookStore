using MediatR;
using BookStore.InternalContracts.Models;

namespace BookStore.InternalContracts.BooksCommands
{
    public class GetAllBooksCommand : IRequest<List<BookModel>>
    {
        public int Take { get; set; }

        public int Skip { get; set; }
    }
}
