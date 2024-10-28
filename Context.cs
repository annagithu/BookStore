using BookStore.Helpers;
using BookStore.InternalContracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BookStore
{

    public class Context : DbContext
    {
        private readonly DbSettings _dbSettings;
        public Context(DbContextOptions<Context> options, IOptions<DbSettings> dbSettings)
        : base(options)
        {
            _dbSettings = dbSettings.Value;
            Database.EnsureCreated();
        }

        public DbSet<BookModel> Books { get; set; }
        public DbSet<AuthorModel> Authors { get; set; }

        [Obsolete]
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"host={_dbSettings.Server};port={_dbSettings.Port};database={_dbSettings.Database};username={_dbSettings.UserId};password={_dbSettings.Password}").LogTo(Console.WriteLine);
        }
    }
}
