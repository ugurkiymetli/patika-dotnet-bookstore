using HelloWebAPI.Controllers;
using Microsoft.EntityFrameworkCore;

namespace HelloWebAPI.DbOperations
{
    public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext( DbContextOptions<BookStoreDBContext> options ) : base(options) { }
        public DbSet<Book> Books { get; set; }
    }
}
