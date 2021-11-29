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
                context.Authors.AddRange(
                        new Author
                        {
                            Name = "J. R. R.",
                            Surname = "Tolkien",
                            BirthDate = new DateTime(1892, 01, 03)
                        },
                        new Author
                        {
                            Name = "Stephen",
                            Surname = "King",
                            BirthDate = new DateTime(1947, 09, 21)
                        },
                        new Author
                        {
                            Name = "George",
                            Surname = "Orwell",
                            BirthDate = new DateTime(1943, 06, 25)
                        },
                        new Author
                        {
                            Name = "Robert",
                            Surname = "Kahn",
                            BirthDate = new DateTime(1915, 10, 24)
                        },
                        new Author
                        {
                            Name = "Mary",
                            Surname = "Beard",
                            BirthDate = new DateTime(1955, 01, 01)
                        }
                    );
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
                            AuthorId = 1,
                            PageCount = 1178,
                            PublishDate = new DateTime(1954, 07, 29)
                        },
                        new Book
                        {
                            Title = "It",
                            GenreId = 2,
                            AuthorId = 2,
                            PageCount = 1138,
                            PublishDate = new DateTime(1986, 09, 13)
                        },
                        new Book
                        {
                            Title = "1984",
                            GenreId = 3,
                            AuthorId = 3,
                            PageCount = 328,
                            PublishDate = new DateTime(1949, 06, 08)
                        },
                        new Book
                        {
                            Title = "Batman",
                            GenreId = 4,
                            AuthorId = 4,
                            PageCount = 150,
                            PublishDate = new DateTime(1939, 05, 01)
                        },

                        new Book
                        {
                            Title = "SPQR: A History of Ancient Rome",
                            GenreId = 4,
                            AuthorId = 5,
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
