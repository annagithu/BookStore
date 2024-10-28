using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.AuthorQueries;
using BookStore.Services.Authors;
using MediatR;

namespace BookStore.Handlers.Authors
{
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorCommand, string>
    {
        private readonly IAuthorsService _authorsService;
        public DeleteAuthorHandler(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        public async Task<string> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            return await _authorsService.DeleteAuthor(request.Id);
        }
    }
}
