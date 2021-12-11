using BookStoreWebAPI.DbOperations;
using BookStoreWebAPI.Entities;

namespace BookStore_WebAPI_UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres( this BookStoreDBContext context )
        {
            context.Genres.AddRange(
                new Genre { Name = "Science Fiction" },
                new Genre { Name = "Horror" },
                new Genre { Name = "Classics" },
                new Genre { Name = "Comic" },
                new Genre { Name = "History" }
            );
        }
    }
}
