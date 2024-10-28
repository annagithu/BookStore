using MediatR;
using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.References;

namespace BookStore.InternalContracts.BooksQueries
{
    public class SortBooksQuery : IRequest<List<BookModel>>
    {
        public BooksParameters Parameter { get; set; }

        public OrderKind Value { get; set; }
    }
}
