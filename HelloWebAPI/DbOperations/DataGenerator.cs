using System;
using System.Linq;
using HelloWebAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace HelloWebAPI.DbOperations
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
                context.Books.AddRange
                    (
                        new Book
                        {
                            Id = 1,
                            Title = "BookName1",
                            GenreId = 1,
                            PageCount = 100,
                            PublishDate = new DateTime(2001, 12, 12)
                        },
                        new Book
                        {
                            Id = 2,
                            Title = "BookName2",
                            GenreId = 2,
                            PageCount = 200,
                            PublishDate = new DateTime(2005, 3, 2)
                        },
                        new Book
                        {
                            Id = 3,
                            Title = "BookName3",
                            GenreId = 2,
                            PageCount = 150,
                            PublishDate = new DateTime(1997, 11, 20)
                        }
                    );
                context.SaveChanges();
                Console.WriteLine(context.Books);
            }
        }
    }
}
