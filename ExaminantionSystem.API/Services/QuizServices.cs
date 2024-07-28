 using AutoMapper;
using ExaminantionSystem.API.Contracts.Quiz;
using ExaminantionSystem.API.Entities;
using ExaminantionSystem.API.Repositories;

namespace ExaminantionSystem.API.Services
{
    public class QuizServices : IQuizServices
    {
        private readonly IGenericRepository<Quiz> _quizRepo;
        private readonly IGenericRepository<Course> _courseRepo;
        private readonly IMapper _mapper;

        public QuizServices( IGenericRepository<Quiz> quizRepo, IGenericRepository<Course> courseRepo ,IMapper mapper )
        {
            _quizRepo = quizRepo;
            _courseRepo = courseRepo;
            _mapper = mapper;
        }
        public async Task<QuizResponse> CreateQuizAsync( int courseId ,  QuizRequest request)
        {

            var courseExsit = await _courseRepo.IsTEntityExist(x => x.Id == courseId);
            if (!courseExsit)
                return null;

            var quizInDb =  _mapper.Map<Quiz>(request);
            quizInDb.CourseId = courseId;

            //request.Questions.ForEach(question => quizInDb.Questions.Add(new Question { Text = question }));

            await _quizRepo.AddAsync(quizInDb);

            var response = _mapper.Map<QuizResponse>(quizInDb);
            return response;

        }

        public async Task<IEnumerable<QuizResponse>> GetAllQuizAsync()
        {
            var quizzs = await _quizRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<QuizResponse>>(quizzs);
        
        }
    }
}
