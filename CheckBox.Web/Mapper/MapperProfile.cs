using AutoMapper;
using CheckBox.Core.Entities;
using CheckBox.Web.Models;

namespace CheckBox.Web.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserViewModel, User>().ReverseMap();
            CreateMap<NoteViewModel, Note>().ReverseMap();
        }
    }
}