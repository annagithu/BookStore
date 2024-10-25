using MediatR;

namespace BookStore.InternalContracts.AuthorCommands
{
    public class DeleteAuthorCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
