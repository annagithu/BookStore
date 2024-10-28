using AutoMapper;
using BookStore.InternalContracts.AuthorQueries;
using BookStore.InternalContracts.BooksQueries;
using BookStore.InternalContracts.Models;
using Microsoft.Azure.Cosmos;

namespace BookStore.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UpdateAuthorCommand, AuthorModel>();
            CreateMap<UpdateBookCommand, BookModel>();
        }
    }
}
