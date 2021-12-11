using AutoMapper;
using BookStoreWebAPI.Common;
using BookStoreWebAPI.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStore_WebAPI_UnitTests.TestSetup
{
    public class CommonTestFixture
    {

        public BookStoreDBContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<BookStoreDBContext>().UseInMemoryDatabase(databaseName: "BookStoreTestDB").Options;
            Context = new BookStoreDBContext(options);

            Context.Database.EnsureCreated();
            Context.AddBooks();
            Context.AddGenres();
            Context.AddAuthors();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            }).CreateMapper();
        }
    }
}
