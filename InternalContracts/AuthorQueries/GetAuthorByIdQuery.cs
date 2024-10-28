using MediatR;
using BookStore.InternalContracts.Models;

namespace BookStore.InternalContracts.AuthorQueries
{
    public class GetAuthorByIdQuery : IRequest<AuthorModel>
    {
        public int Id { get; set; }
    }
}
