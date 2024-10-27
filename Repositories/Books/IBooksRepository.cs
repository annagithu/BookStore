using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.Commands;

namespace BookStore.Repositories.Books
{
    public interface IBooksRepository
    {
        Task<BookModel> CreateBook(BookModel model);

        Task<BookModel> GetBookById(int id);

        Task<List<BookModel>> GetAllBooks(int take, int skip);

        Task<string> DeleteBook(int id);

        Task<List<BookModel>> SortBooks(string parameter, string value);

        Task<List<BookModel>> FilterBooks(string parameter, string value);


    }
}
