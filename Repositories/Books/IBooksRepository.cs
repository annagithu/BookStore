using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.References;

namespace BookStore.Repositories.Books
{
    public interface IBooksRepository
    {
        Task<BookModel> CreateBook(BookModel model);

        Task<string> UpdateBook(BookModel model);

        Task<BookModel> GetBookById(int id);

        Task<List<BookModel>> GetAllBooks(int take, int skip);

        Task<string> DeleteBook(int id);

        Task<List<BookModel>> SortBooks(string parameter, OrderKind value);

        Task<List<BookModel>> FilterBooks(string parameter, string value);


    }
}
