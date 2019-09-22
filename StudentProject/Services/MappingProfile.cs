using System.Linq;
using AutoMapper;
using StudentProject.DataAccess.Models;
using StudentProject.Dtos;

namespace StudentProject.Services
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.StudentId));

            CreateMap<Student, StudentGroupsDto>()
                .IncludeBase<Student, StudentDto>()
                .ForMember(d => d.StudentGroups, opt => opt.MapFrom(src => src.StudentGroups.Select(sg => sg.Group)));

            CreateMap<Group, GroupDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.GroupId))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.GroupName));

            CreateMap<Group, GroupStudentsDto>()
                .IncludeBase<Group, GroupDto>()
                .ForMember(d => d.Students, opt => opt.MapFrom(src => src.StudentGroups.Select(sg => sg.Student)));

            CreateMap<Project, ProjectGroupsStudentsDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.ProjectId))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.ProjectName))
                .ForMember(d => d.Groups, opt => opt.MapFrom(src => src.Groups));
        }
    }
}
