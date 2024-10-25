using BookStore.InternalContracts.AuthorCommands;
using BookStore.InternalContracts.Models;
using BookStore.Services.Authors;
using MediatR;

namespace BookStore.Handlers.Authors
{
    public class SortAuthorsHandler : IRequestHandler<SortAuthorsCommand, List<AuthorModel>>
    {
        private readonly IAuthorsService _authorsService;
        public SortAuthorsHandler(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        public async Task<List<AuthorModel>> Handle(SortAuthorsCommand request, CancellationToken cancellationToken)
        {
            return await _authorsService.SortAuthors(request);
        }
    }
}
