using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutorialsAPI.Data;
using TutorialsAPI.Models;

namespace TutorialsAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : Controller
    {
        private readonly CourseContext _context;

        public TeacherController(CourseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher([FromBody] Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(AddTeacher), new { id = teacher.TeacherId }, teacher);
        }

        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            var teachers = await _context.Teachers.ToListAsync();
            return Ok(teachers);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Teacher teacher)
        {
            var teacherData = _context.Teachers.SingleOrDefault(x =>x.TeacherId == teacher.TeacherId);
            if (teacherData == null)
                return NotFound();

            teacherData.TeacherId = teacher.TeacherId;
            teacherData.TeacherName = teacher.TeacherName;
            teacherData.Age = teacher.Age;
            teacherData.Experience = teacher.Experience;
            teacherData.Address = teacher.Address;
            teacherData.SkillSet = teacher.SkillSet;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
                return NotFound();

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
