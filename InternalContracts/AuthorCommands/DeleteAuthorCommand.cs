using MediatR;

namespace BookStore.InternalContracts.AuthorQueries
{
    public class DeleteAuthorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
