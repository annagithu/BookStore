
using System.Collections.Generic;
using BookStore.InternalContracts.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore
{
    public class Context : DbContext
    {
        public DbSet<BookModel> Books { get; set; }
        public DbSet<AuthorModel> Authors { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }

        [Obsolete]
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=bookstore;username=postgres;password=1234").LogTo(Console.WriteLine);
            ReloadTypesAsync();
        }

        public Task ReloadTypesAsync()
        {
            return Task.CompletedTask;
        }
    }
}
