using AutoMapper;
using BookStoreWebAPI.Application.AuthorOperations.Queries.GetAuthorsQuery;
using BookStoreWebAPI.DbOperations;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public AuthorController( IMapper mapper, BookStoreDBContext context )
        {
            _mapper = mapper;
            _context = context;
        }

        //GetAuthors
        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }
    }
}
