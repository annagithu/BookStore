using BookStore.InternalContracts.AuthorQueries;
using BookStore.InternalContracts.Models;
using BookStore.Services.Authors;
using MediatR;

namespace BookStore.Handlers.Authors
{
    public class GetAllAuthorsHandler : IRequestHandler <GetAllAuthorsQuery, List<AuthorModel>>
    {
        private readonly IAuthorsService _authorsService;
        public GetAllAuthorsHandler(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        public async Task<List<AuthorModel>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await _authorsService.GetAllAuthors(request);
        }
    }
}
