using BookStoreWebAPI.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreWebAPI.Controllers
{

    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }

    }
    //public class Book : IBook
    //{
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //    public int GenreId { get; set; }
    //    public int PageCount { get; set; }
    //    public DateTime PublishDate { get; set; }
    //}
}
