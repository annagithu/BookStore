using BookStore.InternalContracts.Models;

namespace BookStore.Repositories.Authors
{
    public interface IAuthorsRepository
    {
        Task<AuthorModel> CreateAuthor(AuthorModel model);

        Task<AuthorModel> GetAuthorById(int id);

        Task<List<AuthorModel>> GetAllAuthors();

        Task<string> DeleteAuthor(int id);

        Task<List<AuthorModel>> SortAuthors(string parameter, string value);

        //Task<List<AuthorModel>> FilterAuthors(string parameter, string value);
    }
}
