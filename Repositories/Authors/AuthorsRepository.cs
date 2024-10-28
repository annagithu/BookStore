using BookStore.InternalContracts.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories.Authors
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly Context _context;
        public AuthorsRepository(Context context)
        {
            _context = context;
        }

        public async Task<AuthorModel> CreateAuthor(AuthorModel author) //решить проблему с айди
        {
            await _context.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<string> UpdateAuthor(AuthorModel model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
            return "1 row has been updated";
        }

        public async Task<AuthorModel?> GetAuthorById(int id)
        {
                 
            return await _context.Authors.FirstOrDefaultAsync(author => author.Id == id);
        }

        public async Task<List<AuthorModel>> GetAllAuthors(int? take, int? skip)
        {

            return await _context.Authors.Skip((int)skip).Take((int)take).ToListAsync();
        }

        public async Task<string> DeleteAuthor(int id)
        {
                 
            var deletedAuthor = new AuthorModel { Id = id };
            _context.Remove(deletedAuthor);
            await _context.SaveChangesAsync();
            var responce = "successfully"; //веррнуть кол-во удаленных элементов
            return responce;
        }

        public async Task<List<AuthorModel>> SortAuthors(string parameter, string value)
        {
                 
            return await _context.Authors.FromSqlRaw($"SELECT * FROM public.\"Authors\" ORDER BY \"{parameter}\" {value}").ToListAsync();
        }

        public async Task<List<AuthorModel>> FilterAuthors(string parameter, string value)
        {
                 
            return await _context.Authors.FromSqlRaw($"SELECT * FROM public.\"Authors\" WHERE \"{parameter}\" = \'{value}\'").ToListAsync();
        }
    }
}
