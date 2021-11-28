using BookStoreWebAPI.Controllers;
using BookStoreWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
namespace BookStoreWebAPI.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize( IServiceProvider serviceProvider )
        {
            using ( var context = new BookStoreDBContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDBContext>>()) )
            {
                // Look for any book.
                if ( context.Books.Any() )
                    return;// Data was already seeded
                context.Genres.AddRange(
                         new Genre
                         {
                             Name = "Science Fiction",
                         },
                         new Genre
                         {
                             Name = "Horror",
                         },
                         new Genre
                         {
                             Name = "Classics",
                         },
                         new Genre
                         {
                             Name = "Comic",
                         },
                         new Genre
                         {
                             Name = "History",
                         }

                 );
                context.Books.AddRange
                    (
                        new Book
                        {
                            Title = "Lord of the Rings",
                            GenreId = 1,
                            PageCount = 1178,
                            PublishDate = new DateTime(1954, 07, 29)
                        },
                        new Book
                        {
                            Title = "It",
                            GenreId = 2,
                            PageCount = 1138,
                            PublishDate = new DateTime(1986, 09, 13)
                        },
                        new Book
                        {
                            Title = "1984",
                            GenreId = 3,
                            PageCount = 328,
                            PublishDate = new DateTime(1949, 06, 08)
                        },
                        new Book
                        {
                            Title = "Batman",
                            GenreId = 4,
                            PageCount = 150,
                            PublishDate = new DateTime(1939, 05, 01)
                        },

                        new Book
                        {
                            Title = "SPQR: A History of Ancient Rome",
                            GenreId = 4,
                            PageCount = 608,
                            PublishDate = new DateTime(2016, 09, 06)
                        }
                    );
                context.SaveChanges();
                Console.WriteLine(context.Books);
            }
        }
    }
}
