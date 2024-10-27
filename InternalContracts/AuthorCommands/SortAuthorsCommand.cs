using BookStore.InternalContracts.Models;
using MediatR;

namespace BookStore.InternalContracts.AuthorCommands
{
    public class SortAuthorsCommand : IRequest<List<AuthorModel>>
    {
        public AuthorParameters Parameter { get; set; }

        public OrderKindA Value { get; set; }  
    }
    public enum AuthorParameters
    {
        Surname,
        Name,
        Patronymic,
        BirthYear
    }

    public enum OrderKindA
    {
        ASC,
        DESC
    }
}
