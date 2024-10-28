using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.References;

namespace BookStore.Repositories.Books
{
    public interface IBooksRepository
    {
        Task<BookModel> CreateBook(BookModel model);

        Task UpdateBook(BookModel model);

        Task<BookModel> GetBookById(int id);

        Task<List<BookModel>> GetAllBooks(int take, int skip);

        Task DeleteBook(BookModel model);

        Task<List<BookModel>> SortBooks(string parameter, OrderKind value);

        Task<List<BookModel>> FilterBooks(string parameter, string value);


    }
}
