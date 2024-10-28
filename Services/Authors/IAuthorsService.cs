using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.AuthorQueries;

namespace BookStore.Services.Authors
{
    public interface IAuthorsService
    {
        Task<AuthorModel> CreateAuthor(AuthorModel model);

        Task<string> UpdateAuthor(UpdateAuthorCommand model);

        Task<AuthorModel> GetAuthorById(int id);

        Task<List<AuthorModel>> GetAllAuthors(GetAllAuthorsQuery getAllAuthorsQuery);

        Task<string> DeleteAuthor(int id);

        Task<List<AuthorModel>> SortAuthors(SortAuthorsQuery sortAuthorsQuery);

        Task<List<AuthorModel>> FilterAuthors(FilterAuthorsQuery filterAuthorsQuery);
    }
}
