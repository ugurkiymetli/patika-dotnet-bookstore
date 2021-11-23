using AutoMapper;
using BookStoreWebAPI.BookOperations.CreateBook;
using BookStoreWebAPI.BookOperations.GetBookDetail;
using BookStoreWebAPI.BookOperations.GetBooks;
using BookStoreWebAPI.Controllers;

namespace BookStoreWebAPI.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, GetBookDetailModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ( ( GenreEnum )src.GenreId ).ToString()));
            CreateMap<Book, GetBookModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ( ( GenreEnum )src.GenreId ).ToString()));
        }
    }
}