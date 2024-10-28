using MediatR;

namespace BookStore.InternalContracts.BooksQueries
{
    public class UpdateBookQuery : IRequest<string>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public int YearOfPublication { get; set; }

        public int Pages { get; set; }

        public References.References.Condition Condition { get; set; }
    }
}
