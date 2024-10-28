using MediatR;
using BookStore.InternalContracts.Models;

namespace BookStore.InternalContracts.AuthorQueries
{
    public class GetAllAuthorsQuery : IRequest<List<AuthorModel>>
    {
        public int Take { get; set; }

        public int Skip { get; set; }
    }
}
