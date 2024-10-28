using BookStore.InternalContracts.BooksQueries;
using BookStore.InternalContracts.Models;

namespace BookStore.Services.BooksService
{
    public interface IBooksService
    {
        Task<BookModel> CreateBook(BookModel model);

        Task<string> UpdateBook(UpdateBookQuery model);

        Task<BookModel> GetBookById(int id);

        Task<List<BookModel>> GetAllBooks(GetAllBooksQuery getAllBooksCommand);

        Task<string> DeleteBook(int id);

        Task<List<BookModel>> SortBooks(SortBooksQuery sortBooksCommand);

        Task<List<BookModel>> FilterBooks(FilterBooksQuery filterBooksCommand);

    }
}
