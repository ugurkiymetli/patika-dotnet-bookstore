using BookStoreWebAPI.Controllers;
using BookStoreWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebAPI.DbOperations
{
    public interface IBookStoreDBContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<Genre> Genres { get; set; }
        int SaveChanges();
        //void Remove();
    }
}