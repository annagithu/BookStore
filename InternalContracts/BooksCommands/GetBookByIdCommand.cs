using MediatR;
using BookStore.InternalContracts.Models;

namespace BookStore.InternalContracts.Commands
{
    public class GetBookByIdCommand : IRequest<BookModel>
    {
        public int Id { get; set; } 
    }
}
