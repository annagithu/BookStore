using BookStore.InternalContracts.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore
{

    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<BookModel> Books { get; set; }
        public DbSet<AuthorModel> Authors { get; set; }
    }
}
