using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.References;
using BookStore.Helpers;
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

        public async Task<AuthorModel> CreateAuthor(AuthorModel author)
        {
            await _context.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task UpdateAuthor(AuthorModel model)
        {
            _context.Authors.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task<AuthorModel> GetAuthorById(int id)
        {
            return await _context.Authors.FirstOrDefaultAsync(author => author.Id == id);
        }

        public async Task<List<AuthorModel>> GetAllAuthors(int take, int skip)
        {

            return await _context.Authors.Skip(skip).Take(take).ToListAsync();
        }

        public async Task DeleteAuthor(AuthorModel model)
        {
         
            _context.Authors.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AuthorModel>> SortAuthors(string parameter, OrderKind value)
        {
                 
            return await _context.Authors.FromSqlRaw($"SELECT * FROM public.\"Authors\" ORDER BY \"{parameter}\" {ToSQL(value)}").ToListAsync();
        }

        public async Task<List<AuthorModel>> FilterAuthors(string parameter, string value)
        {
                 
            return await _context.Authors.FromSqlRaw($"SELECT * FROM public.\"Authors\" WHERE \"{parameter}\" = \'{value}\'").ToListAsync();
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
