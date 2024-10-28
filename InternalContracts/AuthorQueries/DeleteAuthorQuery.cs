using MediatR;

namespace BookStore.InternalContracts.AuthorQueries
{
    public class DeleteAuthorQuery : IRequest<string>
    {
        public int Id { get; set; }
    }
}
