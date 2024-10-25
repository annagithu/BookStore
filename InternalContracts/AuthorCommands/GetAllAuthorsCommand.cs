using MediatR;
using BookStore.InternalContracts.Models;

namespace BookStore.InternalContracts.AuthorCommands
{
    public class GetAllAuthorsCommand : IRequest<List<AuthorModel>>
    {
    }
}
