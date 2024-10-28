using AutoMapper;
using BookStore.Helpers;
using BookStore.InternalContracts.BooksQueries;
using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.References;
using BookStore.Repositories.Books;

namespace BookStore.Services.BooksService
{
    public class BooksService(IBooksRepository bookStoreRepository, IMapper mapper) : IBooksService
    {
        private readonly IBooksRepository _booksRepository = bookStoreRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<BookModel> CreateBook(BookModel model)
        {
             return await _booksRepository.CreateBook(model); 
        }

        public async Task<string> UpdateBook(UpdateBookCommand updateBookCommand)
        {
            var book = await _booksRepository.GetBookById(updateBookCommand.Id) ?? throw new AppException($"Book with the ID {updateBookCommand.Id} doesn't exist");
            book = _mapper.Map<BookModel>(book);    
            return await _booksRepository.UpdateBook(book);
        }

        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _booksRepository.GetBookById(id);
            if (book == null) { throw new AppException($"Book with the ID {id} doesn't exist"); }
            return book; 
        }

        public async Task<List<BookModel>> GetAllBooks(GetAllBooksQuery getAllBooksQuery)
        {
            if (getAllBooksQuery.Take < 0 || getAllBooksQuery.Skip < 0)
            {
                getAllBooksQuery.Take = 0;
                getAllBooksQuery.Skip = 0;
            }
            return await _booksRepository.GetAllBooks(getAllBooksQuery.Take, getAllBooksQuery.Skip);
        }

        public async Task<string> DeleteBook(int id)
        {
            var book = await _booksRepository.GetBookById(id);
            if (book == null) { throw new AppException($"Book with the ID {id} doesn't exist"); }
            else { return await _booksRepository.DeleteBook(id); }
        }

        public async Task<List<BookModel>> SortBooks(SortBooksQuery sortBooksQuery)
        {
            return await _booksRepository.SortBooks(sortBooksQuery.Parameter.ToString(), sortBooksQuery.Value);
        }

        public async Task<List<BookModel>> FilterBooks(FilterBooksQuery filterBooksQuery)
        {
            return await _booksRepository.FilterBooks(filterBooksQuery.Parameter.ToString(), filterBooksQuery.Value.ToString());
        }


    }

}
