using AutoMapper;
using PrenticeApi.Dtos;
using PrenticeApi.Models;

namespace PrenticeApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<UserDto, ApplicationUser>();

            CreateMap<Institution, InstitutionDto>();
            CreateMap<InstitutionDto, Institution>();

            CreateMap<AcademicType, AcademicTypeDto>();
            CreateMap<AcademicTypeDto, AcademicType>();

            CreateMap<ProgramType, ProgramTypeDto>();
            CreateMap<ProgramTypeDto, ProgramType>();

            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();

            CreateMap<TermType, TermTypeDto>();
            CreateMap<TermTypeDto, TermType>();

            CreateMap<Batch, BatchDto>();
            CreateMap<BatchDto, Batch>();

            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
        }
    }
}