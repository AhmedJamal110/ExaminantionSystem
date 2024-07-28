using AutoMapper;
using ExaminantionSystem.API.Contracts.Course;
using ExaminantionSystem.API.Contracts.Question;
using ExaminantionSystem.API.Contracts.Quiz;
using ExaminantionSystem.API.Entities;

namespace ExaminantionSystem.API.Mapping
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<CourseRequest, Course>();

            CreateMap<Course, CourseResponse>();


            CreateMap<QuizRequest, Quiz>();
            CreateMap<Quiz, QuizResponse>();

            CreateMap<QuestionRequest, Question>();
            CreateMap<Question, QuestionResponse>();
        }

    }
}
