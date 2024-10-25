using BookStore.InternalContracts.Models;
using BookStore.Services.Authors;
using MediatR;

namespace BookStore.Handlers.Authors
{
    public class CreateAuthorHandler : IRequestHandler<AuthorModel, AuthorModel>
    {
        private readonly IAuthorsService _authorsService;
        public CreateAuthorHandler(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        public async Task<AuthorModel> Handle(AuthorModel request, CancellationToken cancellationToken)
        {
            return await _authorsService.CreateAuthor(request);
        }
    }
}
