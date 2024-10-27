using BookStore.Helpers;
using BookStore.InternalContracts.Models;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories.Books
{
    public class BooksRepository : IBooksRepository
    {
        private readonly Context _context;
        public BooksRepository(Context context)
        {
            _context = context;
        }

        public async Task<BookModel> CreateBook(BookModel book)
        {
            await _context.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<BookModel?> GetBookById(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
        }


        public async Task<List<BookModel>> GetAllBooks(int take, int skip)
        {
                 
            return await _context.Books.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<string> DeleteBook(int id)
        {
                 
            var deletedBook = new BookModel { Id = id };
            _context.Remove(deletedBook);
            await _context.SaveChangesAsync();
            var responce = "successfully";
            return responce;
        }

        public async Task<List<BookModel>> SortBooks(string parameter, string value)
        {
                 
            return await _context.Books.FromSqlRaw($"SELECT * FROM public.\"Books\" ORDER BY \"{parameter}\" {value}").ToListAsync();
        }

        public async Task<List<BookModel>> FilterBooks(string parameter, string value)
        {
            
            return await _context.Books.FromSqlRaw($"SELECT * FROM public.\"Books\" WHERE \"{parameter}\" = \'{value}\'").ToListAsync();
        }
    }
}
