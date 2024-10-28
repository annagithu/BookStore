using BookStore.InternalContracts.Models;
using MediatR;

namespace BookStore.InternalContracts.AuthorQueries
{
    public class FilterAuthorsQuery : IRequest<List<AuthorModel>>
    {
        public References.References.AuthorParameters Parameters { get; set; }

        public string? Value { get; set; }
    }
}
