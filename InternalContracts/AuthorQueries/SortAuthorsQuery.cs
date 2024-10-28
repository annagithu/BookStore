using BookStore.InternalContracts.Models;
using MediatR;

namespace BookStore.InternalContracts.AuthorQueries
{
    public class SortAuthorsQuery : IRequest<List<AuthorModel>>
    {
        public References.References.AuthorParameters Parameter { get; set; }

        public References.References.OrderKind Value { get; set; }  
    }
   
}
