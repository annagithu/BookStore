using BookStore.Helpers;
using BookStore.InternalContracts.Models;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories.Books
{
    public class BooksRepository : IBooksRepository
    {

        public async Task<BookModel> CreateBook(BookModel book)
        {
            using var context = new Context(); //хуйня переделывай
            await context.AddAsync(book);
            await context.SaveChangesAsync();
            return book;
        }



        public async Task<BookModel> GetBookById(int id)
        {
            using var context = new Context();
            return await context.Books.Where(book => book.Id == id).FirstOrDefaultAsync();
        }


        public async Task<List<BookModel>> GetAllBooks()
        {
            using var context = new Context();
            return await context.Books.ToListAsync();
        }

        public async Task<string> DeleteBook(int id)
        {
            using var context = new Context();
            var deletedBook = new BookModel { Id = id };
            context.Remove(deletedBook);
            context.SaveChanges();
            var responce = "successfully";
            return responce;
        }

        public async Task<List<BookModel>> SortBooks(string parameter, string value)
        {
            using var context = new Context();
            return await context.Books.FromSqlRaw($"SELECT * FROM public.\"Books\" ORDER BY \"{parameter}\" {value}").ToListAsync();
        }
    }
}
