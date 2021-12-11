using BookStore_WebAPI_UnitTests.TestSetup;
using BookStoreWebAPI.BookOperations.CreateBook;
using FluentAssertions;
using Xunit;

namespace BookStore_WebAPI_UnitTests.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("", 0, 0, 0)]
        [InlineData("", 99, 0, 0)]
        [InlineData("", 99, 1, 0)]
        [InlineData("", 99, 0, 1)]
        [InlineData("LotR", 0, 0, 0)]
        [InlineData("LotR", 99, 0, 0)]
        [InlineData("LotR", 99, 1, 0)]
        [InlineData("LotR", 99, 0, 1)]
        [InlineData("Lo", 0, 0, 0)]
        [InlineData("Lo", 99, 0, 0)]
        [InlineData("Lo", 99, 1, 0)]
        [InlineData("Lo", 99, 0, 1)]
        [InlineData("Lo", 0, 1, 0)]
        [InlineData("Lo", 0, 0, 1)]
        [InlineData(" ", 0, 0, 0)]
        [InlineData(" ", 99, 0, 0)]
        [InlineData(" ", 99, 1, 0)]
        [InlineData(" ", 99, 0, 1)]
        [InlineData(" ", 0, 0, 1)]
        [InlineData(" ", 0, 1, 1)]

        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors( string title, int pageCount, int genreId, int authorId )
        {
            //arrange
            CreateBookCommand command = new(null, null);
            command.Model = new()
            {
                Title = title,
                PageCount = pageCount,
                PublishDate = System.DateTime.Now.Date.AddYears(-1),
                GenreId = genreId,
                AuthorId = authorId
            };
            //act
            CreateBookCommandValidator validator = new();
            var result = validator.Validate(command);
            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenDateTimeEqualNowInputsAreGiven_Validator_ShouldReturnErrors()
        {
            //arrange
            CreateBookCommand command = new(null, null);
            command.Model = new()
            {
                Title = "Lotr",
                PageCount = 99,
                PublishDate = System.DateTime.Now.Date,
                GenreId = 1,
            };
            //act
            CreateBookCommandValidator validator = new();
            var result = validator.Validate(command);
            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotReturnErrors()
        {
            //arrange
            CreateBookCommand command = new(null, null);
            command.Model = new()
            {
                Title = "Lotr",
                PageCount = 99,
                PublishDate = System.DateTime.Now.Date.AddYears(-10),
                GenreId = 1,
                AuthorId = 1,
            };
            //act
            CreateBookCommandValidator validator = new();
            var result = validator.Validate(command);
            //assert
            result.Errors.Count.Should().Be(0);
        }
    }

}
