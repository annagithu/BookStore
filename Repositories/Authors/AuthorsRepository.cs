using BookStore.InternalContracts.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories.Authors
{
    public class AuthorsRepository : IAuthorsRepository
    {
        public async Task<AuthorModel> CreateAuthor(AuthorModel author)
        {
            using var context = new Context(); //хуйня переделывай
            await context.AddAsync(author);
            await context.SaveChangesAsync();
            return author;
        }


        public async Task<AuthorModel> GetAuthorById(int id)
        {
            using var context = new Context();
            return await context.Authors.Where(author => author.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<AuthorModel>> GetAllAuthors()
        {
            using var context = new Context();
            return await context.Authors.ToListAsync();
        }

        public async Task<string> DeleteAuthor(int id)
        {
            using var context = new Context();
            var deletedAuthor = new AuthorModel { Id = id };
            context.Remove(deletedAuthor);
            context.SaveChanges();
            var responce = "successfully";
            return responce;
        }

        public async Task<List<AuthorModel>> SortAuthors(string parameter, string value)
        {
            using var context = new Context();
            return await context.Authors.FromSqlRaw($"SELECT * FROM public.\"Authors\" ORDER BY \"{parameter}\" {value}").ToListAsync();
        }
    }
}
