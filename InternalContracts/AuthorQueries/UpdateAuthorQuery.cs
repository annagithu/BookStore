﻿using MediatR;

namespace BookStore.InternalContracts.AuthorQueries
{
    public class UpdateAuthorQuery : IRequest<string>
    {
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public int BirthYear { get; set; }

    }
}
