using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using HelloWebAPI.DbOperations;

namespace HelloWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDBContext _context;
        public BookController( BookStoreDBContext context )
        {
            _context = context;
        }

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = _context.Books.OrderBy(book => book.Id).ToList<Book>();
            return bookList;
        }

        [HttpGet("{id}")]
        public Book GetById( int id )
        {
            var book = _context.Books.Where(book => book.Id == id).SingleOrDefault();
            return book;
        }

        [HttpPost]
        public IActionResult AddBook( [FromBody] Book newBook )
        {
            var book = _context.Books.SingleOrDefault(book => book.Title == newBook.Title);
            if ( book is not null )
                return BadRequest();
            _context.Books.Add(newBook);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook( int id, [FromBody] Book updateBook )
        {
            var book = _context.Books.SingleOrDefault(book => book.Id == id);
            if ( book is null )
                return BadRequest();
            //Eğer bodyde data gelmezse (default ise) kendi datasını ekle.
            book.GenreId = updateBook.GenreId != default ? updateBook.GenreId : book.GenreId;
            book.PageCount = updateBook.PageCount != default ? updateBook.PageCount : book.PageCount;
            book.PublishDate = updateBook.PublishDate != default ? updateBook.PublishDate : book.PublishDate;
            book.Title = updateBook.Title != default ? updateBook.Title : book.Title;

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook( int id )
        {
            var book = _context.Books.SingleOrDefault(book => book.Id == id);
            if ( book is null )
                return BadRequest();
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }

    }
}
