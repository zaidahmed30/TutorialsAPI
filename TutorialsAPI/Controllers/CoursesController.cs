using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutorialsAPI.Data;
using TutorialsAPI.Models;

namespace CoursesController.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class CoursesController : ControllerBase
        {
            private readonly CourseContext _context;

            public CoursesController(CourseContext context)
            {
                _context = context;
            }


            [HttpPost]
            public async Task<IActionResult> AddCourse([FromBody] Course course)
            {
                if (string.IsNullOrWhiteSpace(course.CourseName))
                {
                    return BadRequest("Course name is required.");
                }

                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(AddCourse), new { id = course.Id }, course);
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
            {
                var courses = await _context.Courses.ToListAsync();
                return Ok(courses);
            }

            [HttpPut]
            public async Task<IActionResult> UpdateCourse([FromBody] Course course)
            {
                if (string.IsNullOrWhiteSpace(course.CourseName))
                {
                return BadRequest("Course name is required.");
                }

                var courseData = _context.Courses.SingleOrDefault(x => x.Id == course.Id); // id 2 - c++
                courseData.Id = course.Id;
                courseData.CourseName = course.CourseName;
    
                await _context.SaveChangesAsync();
                return Ok(course);
        
            }

            [HttpDelete]
            public async Task<IActionResult> RemoveCourse(int id)
            {
                var courseData = await _context.Courses.FindAsync(id); 

                _context.Courses.Remove(courseData);
                await _context.SaveChangesAsync();
                return Ok(courseData);

            }

        }
}
