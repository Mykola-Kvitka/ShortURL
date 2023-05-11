using AutoMapper;
using ShortURL.Api.Models;
using ShortURL.BLL.Models;
using ShortURL.DAL.Models;

namespace ShortURL.Api.Mapping
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            AddBusinessMapping();
            AddWebMapping();
        }
        public void AddWebMapping()
        {
            CreateMap<URL, URLViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
        }

        public void AddBusinessMapping()
        {
            CreateMap<UserEntity, User>().ReverseMap();
            CreateMap<URLEntity, URL>().ReverseMap();
        }

    }
}
