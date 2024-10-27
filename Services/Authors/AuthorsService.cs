using BookStore.InternalContracts.AuthorCommands;
using BookStore.InternalContracts.Models;
using BookStore.Repositories.Authors;

namespace BookStore.Services.Authors
{
    public class AuthorsService : IAuthorsService
    {
        private IAuthorsRepository _authorsRepository;

        public AuthorsService(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        public async Task<AuthorModel> CreateAuthor(AuthorModel model)
        {
            return await _authorsRepository.CreateAuthor(model);
        }

        public async Task<AuthorModel> GetAuthorById(int id)
        {
            return await _authorsRepository.GetAuthorById(id);
        }

        public async Task<List<AuthorModel>> GetAllAuthors(GetAllAuthorsCommand getAllAuthorsCommand)
        {
            return await _authorsRepository.GetAllAuthors(getAllAuthorsCommand.Take, getAllAuthorsCommand.Skip);
        }

        public async Task<string> DeleteAuthor(int id)
        {
            return await _authorsRepository.DeleteAuthor(id);
        }

        public async Task<List<AuthorModel>> SortAuthors(SortAuthorsCommand sortAuthorsCommand)
        {
            return await _authorsRepository.SortAuthors(sortAuthorsCommand.Parameter.ToString(), sortAuthorsCommand.Value.ToString());
        }

        public async Task<List<AuthorModel>> FilterAuthors(FilterAuthorsCommand filterAuthorsCommand)
        {
            return await _authorsRepository.FilterAuthors(filterAuthorsCommand.Parameters.ToString(), filterAuthorsCommand.Value.ToString());
        }
    }
}
