using AutoMapper;
using BookStoreWebAPI.BookOperations.CreateBook;
using BookStoreWebAPI.BookOperations.DeleteBook;
using BookStoreWebAPI.BookOperations.GetBookDetail;
using BookStoreWebAPI.BookOperations.GetBooks;
using BookStoreWebAPI.BookOperations.UpdateBook;
using BookStoreWebAPI.DbOperations;
using FluentValidation;
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
            GetBookDetailQueryModel result;
            try
            {
                GetBookDetailQuery query = new(_context, _mapper);
                query.BookId = id;
                GetBookDetailQueryValidator validator = new();
                validator.ValidateAndThrow(query);
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
        public IActionResult AddBook( [FromBody] CreateBookCommandModel newBook )
        {
            /*CreateBookCommand command = new(_context, _mapper);
            try
            {
                command.Model = newBook;
                CreateBookCommandValidator validator = new();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch ( Exception ex )
            {
                return BadRequest(ex.Message);
            }
            return Ok();*/

            CreateGenreCommand command = new(_context, _mapper);
            command.Model = newBook;
            CreateBookCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        //UpdateBook
        [HttpPut("{id}")]
        public IActionResult UpdateBook( int id, [FromBody] UpdateBookCommandModel updatedBook )
        {
            /*//Middleware eklenmeden önceki kod yapısı
            UpdateBookCommand command = new(_context);
            try
            {
                command.Model = updatedBook;
                command.BookId = id;
                UpdateBookCommandValidator validator = new();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch ( Exception ex )
            {
                return BadRequest(ex.Message);
            }
            return Ok();
*/
            //middleware eklediğimiz için yukarıdaki try catch yapısını kurmamıza gerek kalmıyor. 
            UpdateBookCommand command = new(_context);
            command.Model = updatedBook;
            command.BookId = id;
            UpdateBookCommandValidator validator = new();
            //eğer bi hata oluşursa validator hatayı fırlatıyor,
            //middleware yakalayıp gerekli hata mesajını, kodunu vs response içine yazıyor
            validator.ValidateAndThrow(command);
            command.Handle();
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
                DeleteBookCommandValidator validator = new();
                validator.ValidateAndThrow(command);
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
