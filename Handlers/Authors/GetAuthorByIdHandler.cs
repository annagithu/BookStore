using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.AuthorQueries;
using BookStore.Services.Authors;
using MediatR;

namespace BookStore.Handlers.Books
{
    
    public class GetAuthorByIdHandler : IRequestHandler<GetAuthorByIdQuery, AuthorModel>
    {
        private readonly IAuthorsService _authorsService;
        public GetAuthorByIdHandler(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        public async Task<AuthorModel> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _authorsService.GetAuthorById(request.Id);
        }
    }
}
