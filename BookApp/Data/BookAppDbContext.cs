using Microsoft.EntityFrameworkCore;
using BookApp.Data.Entities;

namespace BookApp.Data
{
    public class BookAppDbContext : DbContext
    {
        public BookAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
    }
}
