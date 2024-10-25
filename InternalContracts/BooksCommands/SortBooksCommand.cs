using MediatR;
using BookStore.InternalContracts.Models;

namespace BookStore.InternalContracts.BooksCommands
{
    public class SortBooksCommand : IRequest<List<BookModel>>
    {
        public BooksParameters Parameter { get; set; }

        public BooksValues Value { get; set; }

        public enum BooksParameters
        {
            Name,
            Author,
            Pages,
            YearOfPublication,
            Condition
        }

        public enum BooksValues
        {
            ASC,
            DESC
        }
    }
}
