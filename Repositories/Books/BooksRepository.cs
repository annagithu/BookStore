using BookStore.Helpers;
using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.References;
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

        public async Task UpdateBook(BookModel model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task<BookModel?> GetBookById(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
        }


        public async Task<List<BookModel>> GetAllBooks(int take, int skip)
        {
            return await _context.Books.Skip((int)skip).Take((int)take).ToListAsync();
        }

        public async Task DeleteBook(BookModel model)
        {
            _context.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BookModel>> SortBooks(string parameter, OrderKind value)
        {
            return await _context.Books.FromSqlRaw($"SELECT * FROM public.\"Books\" ORDER BY \"{parameter}\" {ToSQL(value)}").ToListAsync();
        }

        public async Task<List<BookModel>> FilterBooks(string parameter, string value)
        {
            return await _context.Books.FromSqlRaw($"SELECT * FROM public.\"Books\" WHERE \"{parameter}\" = \'{value}\'").ToListAsync();
        }

        private string ToSQL(OrderKind orderKind)
        {
            switch (orderKind)
            {
                case OrderKind.ASC: return "ASC";
                case OrderKind.DESC: return "DESC";
                default: throw new AppException($"Not implemented for {orderKind}");
            }
        }
    }
}
