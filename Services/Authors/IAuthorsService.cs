using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.AuthorQueries;

namespace BookStore.Services.Authors
{
    public interface IAuthorsService
    {
        Task<AuthorModel> CreateAuthor(AuthorModel model);

        Task<string> UpdateAuthor(UpdateAuthorQuery model);

        Task<AuthorModel> GetAuthorById(int id);

        Task<List<AuthorModel>> GetAllAuthors(GetAllAuthorsQuery getAllAuthorsCommand);

        Task<string> DeleteAuthor(int id);

        Task<List<AuthorModel>> SortAuthors(SortAuthorsQuery sortAuthorsCommand);

        Task<List<AuthorModel>> FilterAuthors(FilterAuthorsQuery filterAuthorsCommand);
    }
}
