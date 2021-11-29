using AutoMapper;
using BookStoreWebAPI.Application.AuthorOperations.Commands.CreateAuthorCommand;
using BookStoreWebAPI.Application.AuthorOperations.Queries.GetAuthorDetailQuery;
using BookStoreWebAPI.Application.AuthorOperations.Queries.GetAuthorsQuery;
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
            CreateMap<CreateBookCommandModel, Book>();
            //mapping genre id to genre name using enum
            //CreateMap<Book, GetBookModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ( ( GenreEnum )src.GenreId ).ToString()));
            //CreateMap<Book, GetBookDetailModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ( ( GenreEnum )src.GenreId ).ToString()));
            CreateMap<Book, GetBooksQueryModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => ( src.Author.Name + " " + src.Author.Surname )));
            CreateMap<Book, GetBookDetailQueryModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => ( src.Author.Name + " " + src.Author.Surname )));
            CreateMap<Genre, GetGenreModel>();
            CreateMap<Genre, GetGenreDetailModel>();
            CreateMap<Author, GetAuthorsQueryModel>();
            CreateMap<Author, GetAuthorDetailQueryModel>();
            CreateMap<CreateAuthorCommandModel, Author>();
        }
    }
}