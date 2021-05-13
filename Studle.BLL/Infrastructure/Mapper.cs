using AutoMapper;
using Studle.BLL.Dto;
using Studle.DAL.Entities;

namespace Studle.BLL.Infrastructure
{
    public class MapperImpl : Profile
    {
        public MapperImpl()
        {
            CreateMap<Group, GroupDto>()
                .ReverseMap();

            CreateMap<Mark, MarkDto>()
                .ReverseMap();

            CreateMap<Student, StudentDto>()
                .ReverseMap();

            CreateMap<SubjectType, SubjectDto>()
                .ReverseMap();

            CreateMap<Role, RoleDto>()
                .ReverseMap();

            CreateMap<Teacher, TeacherDto>()
                .ReverseMap();

            CreateMap<User, UserDto>()
                .ReverseMap();

            CreateMap<Topic, TopicDto>()
                .ReverseMap();
        }
    }
}
