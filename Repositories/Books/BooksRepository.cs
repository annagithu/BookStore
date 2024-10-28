using BookStore.Helpers;
using BookStore.InternalContracts.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories.Books
{
    public class BooksRepository(Context context) : IBooksRepository
    {
        private readonly Context _context = context;

        public async Task<BookModel> CreateBook(BookModel book)
        {
            await _context.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<string> UpdateBook(BookModel model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
            return "1 row has been updated";
        }

        public async Task<BookModel?> GetBookById(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
        }


        public async Task<List<BookModel>> GetAllBooks(int? take, int? skip)
        {
            return await _context.Books.Skip((int)skip).Take((int)take).ToListAsync();
        }

        public async Task<string> DeleteBook(int id)
        {
            _context.Remove(new BookModel { Id = id });
            await _context.SaveChangesAsync();
            return "1 record has been deleted";
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
