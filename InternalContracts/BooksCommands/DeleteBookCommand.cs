using MediatR;

namespace BookStore.InternalContracts.BooksQueries
{
    public class DeleteBookCommand : IRequest
    {
        public int Id { get; set; }
    }
}
