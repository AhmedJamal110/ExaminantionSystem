using ExaminantionSystem.API.Contracts.Quiz;
using ExaminantionSystem.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminantionSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly IQuizServices _quizServices;

        public QuizzesController( IQuizServices quizServices)
        {
            _quizServices = quizServices;
        }

        [HttpGet("with-question{courseId}")]
        public async Task<ActionResult> GetAllQuizzessWithQuestion(int courseId )
        {
            return Ok( await _quizServices.GetQuizWithQuestionAsync(courseId));
        }

        [HttpGet("All{courseId}")]
        public async Task<ActionResult> GetAllQuizzes(int courseId)
        {
            return Ok(await _quizServices.GetAllQuizAsync(courseId));
        }


        [HttpPost("{courseId}")]
        public async Task<ActionResult> CreateQuiz([FromRoute] int courseId ,  QuizRequest request)
        {
            var result = await _quizServices.CreateQuizAsync(courseId  , request);

            return result is null ? BadRequest() : Ok(result) ;
        }



        [HttpGet("{id}")]
        public async Task<ActionResult> GetQuiz( int courseId, [FromRoute] int id)
        {
            var result = await _quizServices.GetByIdAsync(courseId , id);

            return result is null ? BadRequest() : Ok(result);
        }



    }
}
