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

        [HttpGet]
        public async Task<ActionResult> GetALl()
        {
            return Ok( await _quizServices.GetAllQuizAsync());
        }


        [HttpPost("{courseId}")]
        public async Task<ActionResult> CreateQuiz([FromRoute] int courseId ,  QuizRequest request)
        {
            var result = await _quizServices.CreateQuizAsync(courseId  , request);

            return result is null ? BadRequest() : Ok(result) ;
        }
        
    
    
    
    }
}
