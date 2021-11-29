using System;

namespace BookStoreWebAPI.BookOperations.CreateBook
{
    public class CreateBookCommandModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
