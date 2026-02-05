using AutoMapper;
using LeaveMangementSystem.Web.Data;
using LeaveMangementSystem.Web.Models.LeaveType;

namespace LeaveMangementSystem.Web.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LeaveType, IndexVM>();
            CreateMap<LeaveType, DetailsVM>();
            CreateMap<CreateVM, LeaveType>();
            CreateMap<EditVM, LeaveType>().ReverseMap();
            CreateMap<DeleteVM, LeaveType>().ReverseMap();
        }
    }
}
