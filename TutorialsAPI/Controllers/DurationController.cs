using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutorialsAPI.Data;
using TutorialsAPI.Models;

namespace TutorialsAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DurationController : Controller
    {

        private readonly CourseContext _context;

        public DurationController(CourseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddDuration([FromBody] Duration duration)
        {
            _context.Durations.Add(duration);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(AddDuration), new { id = duration.DurationId }, duration);
        }

        [HttpGet]
        public async Task<IActionResult> GetDurations()
        {
            var durations = await _context.Durations.ToListAsync();
            return Ok(durations);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDuration([FromBody] Duration duration)
        {
            var durationData = _context.Durations.SingleOrDefault(x => x.DurationId == duration.DurationId);
            durationData.DurationId = duration.DurationId;
            durationData.Days = duration.Days;

            await _context.SaveChangesAsync();
            return Ok(duration);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveDuration(int id)
        {
            var durationData = await _context.Durations.FindAsync(id);

            _context.Durations.Remove(durationData);
            await _context.SaveChangesAsync();
            return Ok(durationData);

        }

    }
}
