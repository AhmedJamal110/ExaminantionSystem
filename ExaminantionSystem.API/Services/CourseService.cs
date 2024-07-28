using AutoMapper;
using ExaminantionSystem.API.Contracts.Course;
using ExaminantionSystem.API.Entities;
using ExaminantionSystem.API.Repositories;
using Microsoft.AspNetCore.Identity;

namespace ExaminantionSystem.API.Services
{
    public class CourseService : ICourseService
    {
        private readonly IGenericRepository<Course> _courseRepo;
        private readonly IMapper _mapper;

        public CourseService(IGenericRepository<Course> courseRepo, IMapper mapper)
        {
            _courseRepo = courseRepo;
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
            var coursesInDb = await _courseRepo.GetAllAsync();

            return _mapper.Map<IEnumerable<CourseResponse>>(coursesInDb);
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






    }

}
