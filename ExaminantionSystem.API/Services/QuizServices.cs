 using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExaminantionSystem.API.Contracts.Question;
using ExaminantionSystem.API.Contracts.Quiz;
using ExaminantionSystem.API.Entities;
using ExaminantionSystem.API.Repositories;
using Microsoft.EntityFrameworkCore;

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
        public async Task<QuizWithQuestionResponse> CreateQuizAsync( int courseId ,  QuizRequest request)
        {

            var courseExsit = await _courseRepo.IsTEntityExist(x => x.Id == courseId);
            if (!courseExsit)
                return null;

            var quizInDb =  _mapper.Map<Quiz>(request);
                 quizInDb.CourseId = courseId;

            //request.Questions.ForEach(question => quizInDb.Questions.Add(new Question { Text = question }));

            await _quizRepo.AddAsync(quizInDb);

            var response = _mapper.Map<QuizWithQuestionResponse>(quizInDb);
            return response;

        }

        public async Task<IEnumerable<QuizWithQuestionResponse>> GetQuizWithQuestionAsync(int courseId)
        {
            var IsExsit = await _courseRepo.IsTEntityExist(x => x.Id == courseId);
            if (!IsExsit)
                return null;

            var quizzs = await _quizRepo.GetAllAsync();

            //return await quizzs.Where(x => x.Id == courseId)
            //                            .Include(x => x.Questions)
            //                            .Select( Qz =>  new QuizResponse { Qz.Id , Qz.Title , Qz.Type ,
            //                               Qz.Questions.Select( q => new QuestionResponse{ q.Text , q.Level}).
            //                               }).ToListAsync();

                  return await quizzs.Where(Qz => Qz.CourseId == courseId)
                                        .Include(Qz => Qz.Questions)
                                        .Select(Qz => new QuizWithQuestionResponse
                                        {
                                            Id = Qz.Id,
                                            Title = Qz.Title,
                                            Type = Qz.Title,
                                            Question = Qz.Questions
                                        .Select(q => new QuestionResponse { Level = q.Level, Text = q.Text }).ToList()
                                        }).ToListAsync();


             
         
        }


        public async Task<IEnumerable<QuizResponse>> GetAllQuizAsync(int courseId)
        {
            var IsExsit = await _courseRepo.IsTEntityExist(x => x.Id == courseId);
            if (!IsExsit)
                return null;

            var quizzs = await _quizRepo.GetAllAsync();

                return await quizzs.Where(x => x.CourseId == courseId)
                                                       .ProjectTo<QuizResponse>(_mapper.ConfigurationProvider)
                                                       .ToListAsync();
        }

        public async Task<QuizWithQuestionResponse?> GetByIdAsync(int courseId, int id)
        {  
               var quizes = await _quizRepo.GetAllAsync();

            return await quizes.Where(Qz => Qz.CourseId == courseId)
                                  .Include(Qz => Qz.Questions)
                                  .Select(Qz => new QuizWithQuestionResponse
                                  {
                                      Id = Qz.Id,
                                      Title = Qz.Title,
                                      Type = Qz.Title,
                                      Question = Qz.Questions
                                  .Select(q => new QuestionResponse { Level = q.Level, Text = q.Text }).ToList()
                                  }).FirstOrDefaultAsync();


        }



    }
}
