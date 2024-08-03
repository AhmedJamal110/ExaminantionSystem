using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExaminantionSystem.API.Contracts.Course;
using ExaminantionSystem.API.Entities;
using ExaminantionSystem.API.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ExaminantionSystem.API.Services
{
    public class CourseService : ICourseService
    {
        private readonly IGenericRepository<Course> _courseRepo;
        private readonly IGenericRepository<StudentCourse> _studentCourseRepo;
        private readonly IMapper _mapper;

        public CourseService(IGenericRepository<Course> courseRepo, IGenericRepository<StudentCourse> studentCourseRepo  , IMapper mapper)
        {
            _courseRepo = courseRepo;
            _studentCourseRepo = studentCourseRepo;
            _mapper = mapper;
        }

        public async Task<CourseResponse> AddCourseAsync(CourseRequest request)
        {
            var courseInDb = _mapper.Map<Course>(request);
            

            await _courseRepo.AddAsync(courseInDb);


            return _mapper.Map<CourseResponse>(courseInDb);
        }

        public async Task DeleteCourse(int Id)
        {
            await _courseRepo.DeleteAsync(Id);
        }

        public async Task<IEnumerable<CourseResponse>> GetAllCoursesAsync()
        {
            var coursesInDb = await _courseRepo.GetAllAsync() ;

            return   await coursesInDb.ProjectTo<CourseResponse>(_mapper.ConfigurationProvider).ToListAsync();
             
            ////_mapper.Map<IEnumerable<CourseResponse>>(coursesInDb);
        }


        public async Task<CourseResponse> GetCourseAsync(int id)
        {
            var course = await _courseRepo.GetAsync(id);
            if (course is null)
                return null;

            return _mapper.Map<CourseResponse>(course);
        }


        public async Task<bool> UpdateCourse(int id, CourseRequest request)
        {
            var isCourseExsit = await _courseRepo.IsTEntityExist(x => x.Title == request.Title && x.Id != id);
            if (isCourseExsit)
                return false;

            var courseInDb = await _courseRepo.GetAsync(id);
            if (courseInDb is null)
                return false;

            courseInDb.Title = request.Title;
            courseInDb.Description = request.Description;
            courseInDb.Language = request.Language;
            courseInDb.Rating = request.Rating;
            //courseInDb.UpdatedOn = DateTime.UtcNow;
            await _courseRepo.UpdateAsync(courseInDb);
            return true;
        }


        public async Task<CourseResponse> GetAvaiableCourses(string userId)
        {
            var rseult =  await _studentCourseRepo.GetWithCriteriaAsync(x => x.AppUserId == userId);
            if (rseult is null)
                return null;

            var course = await _courseRepo.GetWithCriteriaAsync(x => x.Id == rseult.CourseId);
            if (course is null)
                return null;


            var response = _mapper.Map<CourseResponse>(course);
            return response;
        }



    }

}
