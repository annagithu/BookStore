using BookStore.InternalContracts.BooksQueries;
using BookStore.InternalContracts.Models;

namespace BookStore.Services.BooksService
{
    public interface IBooksService
    {
        Task<BookModel> CreateBook(BookModel model);

        Task UpdateBook(UpdateBookCommand model);

        Task DeleteBook(int id);

        Task<BookModel> GetBookById(int id);

        Task<List<BookModel>> GetAllBooks(GetAllBooksQuery getAllBooksQuery);

        Task<List<BookModel>> SortBooks(SortBooksQuery sortBooksQuery);

        Task<List<BookModel>> FilterBooks(FilterBooksQuery filterBooksQuery);

    }
}
