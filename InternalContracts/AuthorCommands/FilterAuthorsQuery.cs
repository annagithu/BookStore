using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.References;
using MediatR;

namespace BookStore.InternalContracts.AuthorQueries
{
    public class FilterAuthorsQuery : IRequest<List<AuthorModel>>
    {
        public AuthorParameters Parameters { get; set; }

        public string Value { get; set; }
    }
}
