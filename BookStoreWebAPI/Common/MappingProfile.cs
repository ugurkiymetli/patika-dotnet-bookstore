using AutoMapper;
using BookStoreWebAPI.Application.GenreOperations.Queries.GetGenres;
using BookStoreWebAPI.BookOperations.CreateBook;
using BookStoreWebAPI.BookOperations.GetBookDetail;
using BookStoreWebAPI.BookOperations.GetBooks;
using BookStoreWebAPI.Controllers;
using BookStoreWebAPI.Entities;

namespace BookStoreWebAPI.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, GetBookDetailModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ( ( GenreEnum )src.GenreId ).ToString()));
            CreateMap<Book, GetBookModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ( ( GenreEnum )src.GenreId ).ToString()));
            CreateMap<Genre, GetGenreModel>();
            CreateMap<Genre, GetGenreDetailModel>();
        }
    }
}