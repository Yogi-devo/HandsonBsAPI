using AutoMapper;
using HandsonBsAPI.Data;
using HandsonBsAPI.Models;

namespace HandsonBsAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BookModel>().ReverseMap();
        }
    }
}
