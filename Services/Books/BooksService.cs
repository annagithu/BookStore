using AutoMapper;
using BookStore.Helpers;
using BookStore.InternalContracts.BooksQueries;
using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.References;
using BookStore.Repositories.Books;
using static BookStore.InternalContracts.References.References;

namespace BookStore.Services.BooksService
{
    public class BooksService(IBooksRepository bookStoreRepository) : IBooksService
    {
        private IBooksRepository _booksRepository = bookStoreRepository;

        public async Task<BookModel> CreateBook(BookModel model)
        {
            if (!Enum.IsDefined(typeof(References.Condition), model.Condition)) {

                throw new AppException($"Type of condition {model.Condition} doesn't exist. Please, enter one of these: {string.Join(", ", Enum.GetNames(typeof(Condition)))}");
            }

            else { return await _booksRepository.CreateBook(model); };
        }

        public async Task<string> UpdateBook(UpdateBookQuery updateBookQuery)
        {
            var book = await _booksRepository.GetBookById(updateBookQuery.Id);
            if (book == null) { throw new AppException($"Book with the ID {updateBookQuery.Id} doesn't exist"); }
            return await _booksRepository.UpdateBook(ParseModels(updateBookQuery));
        }

        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _booksRepository.GetBookById(id);
            if (book == null) { throw new AppException($"Book with the ID {id} doesn't exist"); }
             return book; 
        }

        public async Task<List<BookModel>> GetAllBooks(GetAllBooksQuery getAllBooksQuery)
        {
            if (getAllBooksQuery.Take < 0|| getAllBooksQuery.Skip < 0) { throw new AppException("Значения Skip и Take должны быть больше или равны нулю"); }
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
            if (!Enum.IsDefined(typeof(BooksParameters), sortBooksQuery.Parameter))
            {

                throw new AppException($"Parameter {sortBooksQuery.Parameter} doesn't exist. Please, enter one of these: {string.Join(", ", Enum.GetNames(typeof(BooksParameters)))}");
            }

            if (!Enum.IsDefined(typeof(OrderKind), sortBooksQuery.Value))
            {

                throw new AppException($"Value {sortBooksQuery.Value} doesn't exist. Please, enter one of these: {string.Join(", ", Enum.GetNames(typeof(OrderKind)))}");
            }

            return await _booksRepository.SortBooks(sortBooksQuery.Parameter.ToString(), sortBooksQuery.Value.ToString());
        }

        public async Task<List<BookModel>> FilterBooks(FilterBooksQuery filterBooksQuery)
        {
            if (!Enum.IsDefined(typeof(BooksParameters), filterBooksQuery.Parameter))
            {

                throw new AppException($"Parameter {filterBooksQuery.Parameter} doesn't exist. Please, enter one of these: {string.Join(", ", Enum.GetNames(typeof(BooksParameters)))}");
            }

            return await _booksRepository.FilterBooks(filterBooksQuery.Parameter.ToString(), filterBooksQuery.Value.ToString());
        }

        public BookModel ParseModels(UpdateBookQuery updateBookQuery)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<UpdateBookQuery, BookModel>()));
            return mapper.Map<UpdateBookQuery, BookModel>(updateBookQuery);
        }
    }

}
