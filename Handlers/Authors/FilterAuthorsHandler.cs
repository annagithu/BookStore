using BookStore.InternalContracts.AuthorQueries;
using BookStore.InternalContracts.Models;
using BookStore.Services.Authors;
using MediatR;

namespace BookStore.Handlers.Authors
{
    public class FilterAuthorsHandler : IRequestHandler<FilterAuthorsQuery, List<AuthorModel>>
    {
        private readonly IAuthorsService _authorsService;
        public FilterAuthorsHandler(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        public async Task<List<AuthorModel>> Handle(FilterAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await _authorsService.FilterAuthors(request);
        }
    }
}
