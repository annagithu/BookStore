using MediatR;
using BookStore.InternalContracts.Models;

namespace BookStore.InternalContracts.AuthorCommands
{
    public class GetAuthorByIdCommand : IRequest<AuthorModel>
    {
        public int Id { get; set; }
    }
}
