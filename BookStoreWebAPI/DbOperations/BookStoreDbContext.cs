using BookStoreWebAPI.Controllers;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebAPI.DbOperations
{
    public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext( DbContextOptions<BookStoreDBContext> options ) : base(options) { }
        public DbSet<Book> Books { get; set; }
    }
}
