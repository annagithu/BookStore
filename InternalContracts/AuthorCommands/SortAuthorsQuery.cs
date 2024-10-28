using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.References;
using MediatR;

namespace BookStore.InternalContracts.AuthorQueries
{
    public class SortAuthorsQuery : IRequest<List<AuthorModel>>
    {
        public AuthorParameters Parameter { get; set; }

        public OrderKind Value { get; set; }  
    }
   
}
