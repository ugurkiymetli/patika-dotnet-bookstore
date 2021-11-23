using BookStoreWebAPI.BookOperations.CreateBook;
using BookStoreWebAPI.BookOperations.DeleteBook;
using BookStoreWebAPI.BookOperations.GetBookDetail;
using BookStoreWebAPI.BookOperations.GetBooks;
using BookStoreWebAPI.BookOperations.UpdateBook;
using BookStoreWebAPI.DbOperations;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStoreWebAPI.Controllers
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
            GetBooksQuery query = new(_context);
            var result = query.Handle();
            return Ok(result);
        }
        //GetBookById
        [HttpGet("{id}")]
        public IActionResult GetById( int id )
        {
            GetBookDetailModel result;
            try
            {
                GetBookDetailQuery query = new(_context);
                query.BookId = id;
                result = query.Handle();
            }
            catch ( Exception ex )
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
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
        public IActionResult UpdateBook( int id, [FromBody] UpdateBookModel updatedBook )
        {

            UpdateBookCommand command = new(_context);
            try
            {
                command.Model = updatedBook;
                command.BookId = id;
                command.Handle();
            }
            catch ( Exception ex )
            {
                return BadRequest(ex.Message);
            }
            return Ok();

        }
        //DeleteBook
        [HttpDelete("{id}")]
        public IActionResult DeleteBook( int id )
        {
            DeleteBookCommand command = new(_context);
            try
            {
                command.BookId = id;
                command.Handle();
            }
            catch ( Exception ex )
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

    }
}
