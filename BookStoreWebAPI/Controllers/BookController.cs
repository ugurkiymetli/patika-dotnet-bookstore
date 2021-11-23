using AutoMapper;
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
        private readonly IMapper _mapper;
        public BookController( BookStoreDBContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
        //GetBooks
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new(_context, _mapper);
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
                GetBookDetailQuery query = new(_context, _mapper);
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
            CreateBookCommand command = new(_context, _mapper);
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
