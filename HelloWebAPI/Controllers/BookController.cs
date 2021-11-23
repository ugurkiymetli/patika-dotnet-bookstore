using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static List<Book> BookList = new List<Book>()
        {
            //new Book
            //{
            //    Id = 1, Title = "BookName1", GenreId = 1, PageCount = 100, PublishDate=new DateTime(2001,12,12)
            //},
            //new Book
            //{
            //    Id = 2, Title = "BookName2", GenreId = 2, PageCount = 200, PublishDate=new DateTime(2005,3,2)
            //},
            //new Book
            //{
            //    Id = 3, Title = "BookName3", GenreId = 2, PageCount = 150, PublishDate=new DateTime(1997,11,20)
            //},
        };
        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(book => book.Id).ToList<Book>();
            return bookList;
        }

        [HttpGet("{id}")]
        public Book GetById( int id )
        {
            var book = BookList.Where(book => book.Id == id).SingleOrDefault();
            return book;
        }

        [HttpPost]
        public IActionResult AddBook( [FromBody] Book newBook )
        {
            var book = BookList.SingleOrDefault(book => book.Title == newBook.Title);
            if ( book is not null )
                return BadRequest();
            BookList.Add(newBook);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook( int id, [FromBody] Book updateBook )
        {
            var book = BookList.SingleOrDefault(book => book.Id == id);
            if ( book is null )
                return BadRequest();
            //Eğer bodyde data gelmezse (default ise) kendi datasını ekle.
            book.GenreId = updateBook.GenreId != default ? updateBook.GenreId : book.GenreId;
            book.PageCount = updateBook.PageCount != default ? updateBook.PageCount : book.PageCount;
            book.PublishDate = updateBook.PublishDate != default ? updateBook.PublishDate : book.PublishDate;
            book.Title = updateBook.Title != default ? updateBook.Title : book.Title;

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook( int id )
        {
            var book = BookList.SingleOrDefault(book => book.Id == id);
            if ( book is null )
                return BadRequest();
            BookList.Remove(book);
            return Ok();
        }

    }
}
