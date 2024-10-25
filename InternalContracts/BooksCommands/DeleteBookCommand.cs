using MediatR;

namespace BookStore.InternalContracts.BooksCommands
{
    public class DeleteBookCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
