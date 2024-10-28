
using System.Collections.Generic;
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

        [Obsolete]
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=bookstore;username=postgres;password=1234").LogTo(Console.WriteLine);
        }
    }
}
