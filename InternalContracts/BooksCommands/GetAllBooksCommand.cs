using MediatR;
using BookStore.InternalContracts.Models;

namespace BookStore.InternalContracts.BooksCommands
{
    public class GetAllBooksCommand : IRequest<List<BookModel>>
    {
    }
}
