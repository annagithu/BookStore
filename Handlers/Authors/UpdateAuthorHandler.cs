using BookStore.InternalContracts.AuthorQueries;
using BookStore.InternalContracts.Models;
using BookStore.Services.Authors;
using MediatR;

namespace BookStore.Handlers.Authors
{
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand, string>
    {
        private readonly IAuthorsService _authorsService;
        public UpdateAuthorHandler(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        public async Task<string> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            return await _authorsService.UpdateAuthor(request);
        }
    }
}
