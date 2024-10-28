using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.AuthorQueries;
using BookStore.Services.Authors;
using MediatR;

namespace BookStore.Handlers.Authors
{
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorQuery, string>
    {
        private readonly IAuthorsService _authorsService;
        public DeleteAuthorHandler(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        public async Task<string> Handle(DeleteAuthorQuery request, CancellationToken cancellationToken)
        {
            return await _authorsService.DeleteAuthor(request.Id);
        }
    }
}
