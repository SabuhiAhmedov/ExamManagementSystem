using ExamManagementSystem.Application.Abstractions;
using ExamManagementSystem.Application.Abstractions.Services;
using ExamManagementSystem.Domain.Entities;
using ExamManagementSystem.Domain.ViewModels;
using ExamManagementSystem.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Logic.ServiceImplementations
{
    public class LessonService : ILessonService
    {
        IUnitOfWork _unitOfWork;
        public LessonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<LessonViewModel>> GetLessons()
        {

            var lessons = await _unitOfWork.Repository<Lesson>().GetAllAsync();

            List<LessonViewModel> lessonsViewModel = new List<LessonViewModel>();

            foreach (var lesson in lessons)
            {
                lessonsViewModel.Add(new LessonViewModel()
                {
                    Name = lesson.Name,
                    Class = lesson.Class,
                    Code = lesson.Code,
                    TeacherName = lesson.TeacherName,
                    TeacherSurname = lesson.TeacherSurname
                });
            }

            return lessonsViewModel;
        }

        public void Add(LessonViewModel lesson)
        {

            var isExistCode = _unitOfWork.Repository<Lesson>().AsQueryable().Any(x=>x.Code == lesson.Code);

            if (isExistCode)
                return;

            _unitOfWork.Repository<Lesson>().Add(new Lesson()
            {
                Name = lesson.Name,
                Class = lesson.Class,
                Code = lesson.Code,
                TeacherName = lesson.TeacherName,
                TeacherSurname = lesson.TeacherSurname
            });

            _unitOfWork.Commit();
        }
    }
}
