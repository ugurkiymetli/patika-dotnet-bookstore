using BookStoreWebAPI.DbOperations;
using BookStoreWebAPI.Entities;
using System;

namespace BookStore_WebAPI_UnitTests.TestSetup
{
    public static class Books
    {
        public static void AddBooks( this BookStoreDBContext context )
        {
            context.Books.AddRange(
                new Book { Title = "Lord of the Rings", GenreId = 1, AuthorId = 1, PageCount = 1178, PublishDate = new DateTime(1954, 07, 29) },
                new Book { Title = "It", GenreId = 2, AuthorId = 2, PageCount = 1138, PublishDate = new DateTime(1986, 09, 13) },
                new Book { Title = "1984", GenreId = 3, AuthorId = 3, PageCount = 328, PublishDate = new DateTime(1949, 06, 08) },
                new Book { Title = "Batman", GenreId = 4, AuthorId = 4, PageCount = 150, PublishDate = new DateTime(1939, 05, 01) },
                new Book { Title = "SPQR: A History of Ancient Rome", GenreId = 5, AuthorId = 5, PageCount = 608, PublishDate = new DateTime(2016, 09, 06) }
            );
        }
    }
}
