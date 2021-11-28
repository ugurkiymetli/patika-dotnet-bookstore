using BookStoreWebAPI.Controllers;
using BookStoreWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebAPI.DbOperations
{
    public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext( DbContextOptions<BookStoreDBContext> options ) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
