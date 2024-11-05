using ExamManagementSystem.Domain.Entities;
using ExamManagementSystem.Domain.ViewModels;
using AutoMapper;
using System.Collections.Generic;

namespace ExamManagementSystem.Application.Mappings
{
    public class ViewModelsMappings : Profile
    {
        public ViewModelsMappings()
        {

            CreateMap<StudentViewModel, Student>().ReverseMap();
            CreateMap<LessonViewModel, Lesson>().ReverseMap();
            CreateMap<ExamViewModel, Exam>().ReverseMap();
           
        }
    }
}
