using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutorialsAPI.Data;
using TutorialsAPI.Migrations;
using TutorialsAPI.Models;

namespace TutorialsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseDetailController : Controller
    {
        

        private readonly CourseContext _context;

        public CourseDetailController(CourseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddDetail([FromBody] CourseDetail courseDetail)
        {
            _context.CourseDetails.Add(courseDetail);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(AddDetail), new { id = courseDetail.CourseDetailId }, courseDetail);
        }

        [HttpGet]
        public async Task<IActionResult> GetDetails()
        {
            var details = await (from cd in _context.CourseDetails
                                 join c in _context.Courses on cd.CourseId equals c.Id
                                 join d in _context.Durations on cd.DurationId equals d.DurationId
                                 join t in _context.Teachers on cd.TeacherId equals t.TeacherId
                                 select new
                                 {
                                     CourseDetailId = cd.CourseDetailId,
                                     CourseName = c.CourseName,
                                     CourseId = c.Id,
                                     Days = d.Days,
                                     DurationId = d.DurationId,
                                     Fee = cd.Fee,
                                     BatchTime = cd.BatchTime,
                                     TopicCover = cd.TopicCover,
                                     TeacherName = t.TeacherName,
                                     TeacherId = t.TeacherId,
                                     ShortDiscription = cd.ShortDiscription,
                                     LongDiscription = cd.LongDiscription,
                                     IsPublish = cd.IsPublish
                                 }).ToListAsync();

            return Ok(details);
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CourseDetail courseDetail)
        {
            var detailData = _context.CourseDetails.SingleOrDefault(x => x.CourseDetailId == courseDetail.CourseDetailId);
            if (detailData == null)
                return NotFound();

            detailData.CourseDetailId = courseDetail.CourseDetailId;
            detailData.CourseId = courseDetail.CourseId;
            detailData.DurationId = courseDetail.DurationId;
            detailData.Fee = courseDetail.Fee;
            detailData.BatchTime = courseDetail.BatchTime;
            detailData.TopicCover = courseDetail.TopicCover;
            detailData.TeacherId = courseDetail.TeacherId;
            detailData.ShortDiscription = courseDetail.ShortDiscription;
            detailData.LongDiscription = courseDetail.LongDiscription;
            detailData.IsPublish = courseDetail.IsPublish;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var courseDetail = await _context.CourseDetails.FindAsync(id);
            if (courseDetail == null)
                return NotFound();

            _context.CourseDetails.Remove(courseDetail);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
