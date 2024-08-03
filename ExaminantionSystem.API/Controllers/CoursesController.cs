using ExaminantionSystem.API.Contracts.Course;
using ExaminantionSystem.API.Entities;
using ExaminantionSystem.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExaminantionSystem.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService )
        {
            _courseService = courseService;
        }


        [HttpPost]
        [Authorize(Roles ="Instructor")]
        public async Task<ActionResult> CreateCourse(CourseRequest request)
        {
            var insId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var response = await _courseService.AddCourseAsync(request);
            return Ok(response);
         }


        [HttpGet("Courses")]
        public async Task<ActionResult> GetAllCourses()
        {
            return Ok(await _courseService.GetAllCoursesAsync());
        }


        [HttpGet("Course{id}")]
        public async Task<ActionResult> GetAllCourses([FromRoute] int id)
        {
            var response = await _courseService.GetCourseAsync(id);

            return response is null ? NotFound() : Ok(response);
        }


        [Authorize(Roles = "Instructor")]

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourse([FromRoute] int id)
        {
            await _courseService.DeleteCourse(id);
            return NoContent();
        }



        [Authorize(Roles = "Instructor")]

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCourse([FromRoute] int id , CourseRequest request)
        {
            var response = await _courseService.UpdateCourse(id, request);

            if (response)
                return Ok(response);

            return BadRequest("Course Title is Already Exsit Or Course Not Found");

        }

 
  
    
    }
}
