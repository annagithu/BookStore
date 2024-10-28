using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.References;

namespace BookStore.Repositories.Authors
{
    public interface IAuthorsRepository
    {
        Task<AuthorModel> CreateAuthor(AuthorModel model);

        Task<string> UpdateAuthor(AuthorModel model);

        Task<AuthorModel> GetAuthorById(int id);

        Task<List<AuthorModel>> GetAllAuthors(int take, int skip);

        Task<string> DeleteAuthor(int id);

        Task<List<AuthorModel>> SortAuthors(string parameter, OrderKind value);

        Task<List<AuthorModel>> FilterAuthors(string parameter, string value);
    }
}
