using MediatR;

namespace BookStore.InternalContracts.BooksQueries
{
    public class DeleteBookQuery : IRequest<string>
    {
        public int Id { get; set; }
    }
}
