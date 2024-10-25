using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.Commands;
using BookStore.InternalContracts.AuthorCommands;

namespace BookStore.Services.Authors
{
    public interface IAuthorsService
    {
        Task<AuthorModel> CreateAuthor(AuthorModel model);

        Task<AuthorModel> GetAuthorById(int id);

        Task<List<AuthorModel>> GetAllAuthors();

        Task<string> DeleteAuthor(int id);

        Task<List<AuthorModel>> SortAuthors(SortAuthorsCommand sortAuthorsCommand);

        //Task<List<AuthorModel>> FilterAuthors(string parameter, string value);
    }
}
