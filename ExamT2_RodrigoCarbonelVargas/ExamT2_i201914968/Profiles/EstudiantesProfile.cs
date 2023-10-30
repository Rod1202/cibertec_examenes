using AutoMapper;
using ExamT2_i201914968.DataAccess;
using ExamT2_i201914968.Models;

namespace ExamT2_i201914968.Profiles
{
    public class EstudiantesProfile : Profile
    {
        public EstudiantesProfile()
        {
            CreateMap<EstudiantesEntity, EstudiantesViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ReverseMap();
        }
    }
}
