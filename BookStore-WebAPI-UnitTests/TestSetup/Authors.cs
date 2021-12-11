using BookStoreWebAPI.DbOperations;
using BookStoreWebAPI.Entities;
using System;

namespace BookStore_WebAPI_UnitTests.TestSetup
{
    public static class Authors
    {
        public static void AddAuthors( this BookStoreDBContext context )
        {
            context.Authors.AddRange(
                new Author { Name = "J. R. R.", Surname = "Tolkien", BirthDate = new DateTime(1892, 01, 03) },
                new Author { Name = "Stephen", Surname = "King", BirthDate = new DateTime(1947, 09, 21) },
                new Author { Name = "George", Surname = "Orwell", BirthDate = new DateTime(1943, 06, 25) },
                new Author { Name = "Robert", Surname = "Kahn", BirthDate = new DateTime(1915, 10, 24) },
                new Author { Name = "Mary", Surname = "Beard", BirthDate = new DateTime(1955, 01, 01) }
            );
        }
    }
}
