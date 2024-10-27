using BookStore.InternalContracts.BooksCommands;
using BookStore.InternalContracts.Models;
using BookStore.Repositories.Books;

namespace BookStore.Services.BooksService
{
    public class BooksService : IBooksService
    {
        private IBooksRepository _booksRepository;

        //праверке
        public BooksService(IBooksRepository bookStoreRepository)
        {
            _booksRepository = bookStoreRepository;
        }

        public async Task<BookModel> CreateBook(BookModel model)
        {
            return await _booksRepository.CreateBook(model);
        }

        public async Task<BookModel> GetBookById(int id)
        {
            return await _booksRepository.GetBookById(id);
        }

        public async Task<List<BookModel>> GetAllBooks(GetAllBooksCommand getAllBooksCommand)
        {
            return await _booksRepository.GetAllBooks(getAllBooksCommand.Take, getAllBooksCommand.Skip);
        }

        public async Task<string> DeleteBook(int id)
        {
           return await _booksRepository.DeleteBook(id);
        }

        public async Task<List<BookModel>> SortBooks(SortBooksCommand sortBooksCommand)
        {
            return await _booksRepository.SortBooks(sortBooksCommand.Parameter.ToString(), sortBooksCommand.Value.ToString());
        }

        public async Task<List<BookModel>> FilterBooks(FilterBooksCommand filterBooksCommand)
        {
            return await _booksRepository.FilterBooks(filterBooksCommand.Parameter.ToString(), filterBooksCommand.Value.ToString());
        }
    }

}
