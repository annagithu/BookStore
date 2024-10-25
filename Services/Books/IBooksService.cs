using BookStore.InternalContracts.BooksCommands;
using BookStore.InternalContracts.Models;

namespace BookStore.Services.BooksService
{
    //можед быдь обновление запихнуть (если будет настроение)
    public interface IBooksService
    {
        Task<BookModel> CreateBook(BookModel model);



        Task<BookModel> GetBookById(int id);



        Task<List<BookModel>> GetAllBooks();



        Task<string> DeleteBook(int id);


        Task<List<BookModel>> SortBooks(SortBooksCommand sortBooksCommand);



        //Task<List<BookModel>> FilterBooks(Enum parameter, string value);

    }
}
