using MediatR;
using BookStore.InternalContracts.Models;

namespace BookStore.InternalContracts.BooksQueries
{
    public class SortBooksQuery : IRequest<List<BookModel>>
    {
        public References.References.BooksParameters Parameter { get; set; }

        public References.References.OrderKind Value { get; set; }
    }
}
