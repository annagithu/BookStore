using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.AuthorCommands;
using BookStore.Services.Authors;
using MediatR;

namespace BookStore.Handlers.Books
{
    
    public class GetAuthorByIdHandler : IRequestHandler<GetAuthorByIdCommand, AuthorModel>
    {
        private readonly IAuthorsService _authorsService;
        public GetAuthorByIdHandler(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        public async Task<AuthorModel> Handle(GetAuthorByIdCommand request, CancellationToken cancellationToken)
        {
            return await _authorsService.GetAuthorById(request.Id);
        }
    }
}
