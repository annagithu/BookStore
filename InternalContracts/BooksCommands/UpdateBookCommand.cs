using BookStore.InternalContracts.References;
using MediatR;

namespace BookStore.InternalContracts.BooksQueries
{
    public class UpdateBookCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public int YearOfPublication { get; set; }

        public int Pages { get; set; }

        public Condition Condition { get; set; }
    }
}
