using BookStore.InternalContracts.AuthorCommands;
using BookStore.InternalContracts.BooksCommands;
using BookStore.InternalContracts.Models;
using BookStore.Services.Authors;
using MediatR;

namespace BookStore.Handlers.Authors
{
    public class GetAllAuthorsHandler : IRequestHandler <GetAllAuthorsCommand, List<AuthorModel>>
    {
        private readonly IAuthorsService _authorsService;
        public GetAllAuthorsHandler(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        public async Task<List<AuthorModel>> Handle(GetAllAuthorsCommand request, CancellationToken cancellationToken)
        {
            return await _authorsService.GetAllAuthors(request);
        }
    }
}
