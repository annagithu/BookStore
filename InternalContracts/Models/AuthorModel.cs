using MediatR;

namespace BookStore.InternalContracts.Models
{
    public class AuthorModel : IRequest<AuthorModel>
    {
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic  { get; set; }

        public int BirthYear { get; set; }
    }
}
