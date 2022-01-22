using AutoMapper;
using BookApp.Data.Entities;
using BookApp.Models;

namespace BookApp.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.IsCheap, e => e.MapFrom(src => src.Price < 1000));
            CreateMap<BookViewModel, Book>();
        }
    }
}
