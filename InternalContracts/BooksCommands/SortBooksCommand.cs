using MediatR;
using BookStore.InternalContracts.Models;

namespace BookStore.InternalContracts.BooksCommands
{
    public class SortBooksCommand : IRequest<List<BookModel>>
    {
        public BooksParameters Parameter { get; set; }

        public OrderKindB Value { get; set; }

       
    }
    public enum BooksParameters
    {
        Name,
        Author,
        Pages,
        YearOfPublication,
        Condition
    }

    public enum OrderKindB
    {
        ASC,
        DESC
    }

}
