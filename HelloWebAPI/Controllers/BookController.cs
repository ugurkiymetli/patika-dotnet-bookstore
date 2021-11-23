using HelloWebAPI.BookOperations.CreateBook;
using HelloWebAPI.BookOperations.GetBooks;
using HelloWebAPI.DbOperations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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
        //GetBooks
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }
        //GetBookById
        [HttpGet("{id}")]
        public Book GetById( int id )
        {
            var book = _context.Books.Where(book => book.Id == id).SingleOrDefault();
            return book;
        }
        //CreateBook
        [HttpPost]
        public IActionResult AddBook( [FromBody] CreateBookModel newBook )
        {
            CreateBookCommand command = new(_context);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch ( Exception ex )
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        //UpdateBook
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
        //DeleteBook
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
