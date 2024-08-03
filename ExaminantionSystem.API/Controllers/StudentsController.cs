using ExaminantionSystem.API.Contracts.StudentQuize;
using ExaminantionSystem.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExaminantionSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentCourseService _studentCourse;
        private readonly ICourseService _courseService;
        private readonly IStudentQuizService _studentQuizService;

        public StudentsController( IStudentCourseService studentCourse , ICourseService courseService ,  IStudentQuizService studentQuizService)
        {
            _studentCourse = studentCourse;
            _courseService = courseService;
            _studentQuizService = studentQuizService;
        }



        [HttpPost("student-enroll-course{id}")]
        [Authorize(Roles = "Student")]
        public async Task<ActionResult> EnrollToCourse([FromRoute] int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _studentCourse.EnrollCourse(userId, id);
            if (result)
                return Ok();

            return BadRequest();
        }


        [HttpGet("current-courses")]
        [Authorize(Roles = "Student")]
        public async Task<ActionResult> GetCurrentCourse()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _courseService.GetAvaiableCourses(userId);

            if (result is not null)
                return Ok(result);

            return BadRequest();
        }





        [HttpPost("student-participate-quiz")]
        [Authorize(Roles ="Student")]
        public async Task<ActionResult> ParticipateQuizzes(StudentQuizeRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
           var result =await _studentQuizService.ParticipateQuizzesAsync(userId! , request) ;

            return result ? NoContent() : BadRequest();       
        }

    }
}
