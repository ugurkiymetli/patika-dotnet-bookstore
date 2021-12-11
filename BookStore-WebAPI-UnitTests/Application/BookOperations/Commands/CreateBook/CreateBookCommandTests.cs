using AutoMapper;
using BookStore_WebAPI_UnitTests.TestSetup;
using BookStoreWebAPI.BookOperations.CreateBook;
using BookStoreWebAPI.DbOperations;
using BookStoreWebAPI.Entities;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;
namespace BookStore_WebAPI_UnitTests.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDBContext context;
        private readonly IMapper mapper;

        public CreateBookCommandTests( CommonTestFixture testFixture )
        {
            context = testFixture.Context;
            mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistedBookTitleIsGiven_InvalidOperationException_ShouldBeReturned()
        {
            //arrange
            var book = new Book()
            {
                Title = "Test_WhenAlreadyExistedBookTitleIsGiven_InvalidOperationException_ShouldBeReturned",
                PageCount = 99,
                PublishDate = new System.DateTime(1990, 01, 01),
                GenreId = 1
            };
            context.Books.Add(book);
            context.SaveChanges();
            CreateBookCommand command = new(context, mapper);
            command.Model = new CreateBookCommandModel() { Title = book.Title };
            //act & assert
            FluentActions
                .Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("This book already exists!!");
        }
        [Fact]
        public void WhenValidInputsGiven_Book_ShouldBeCreated()
        {
            //arrange
            CreateBookCommand command = new(context, mapper);
            CreateBookCommandModel model = new CreateBookCommandModel()
            {
                Title = "Lotr",
                PageCount = 99,
                PublishDate = System.DateTime.Now.Date.AddYears(-10),
                GenreId = 1,
                AuthorId = 1,
            };
            command.Model = model;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var book = context.Books.SingleOrDefault(book => book.Title == model.Title);
            book.Should().NotBeNull();

            book.PageCount.Should().Be(model.PageCount);
            book.PublishDate.Should().Be(model.PublishDate);
            book.GenreId.Should().Be(model.GenreId);
            book.AuthorId.Should().Be(model.AuthorId);
        }
    }
}
