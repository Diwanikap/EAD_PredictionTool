using EAD_PredictionTool.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StudySession.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ILogger<SessionController> _logger;
        private readonly StudySession_Context _dbContext;

        public SessionController(ILogger<SessionController> logger, StudySession_Context dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }


        [HttpGet("GetStudySessions")]
        public async Task<ActionResult<IEnumerable<EAD_PredictionTool.Models.StudySession>>> GetStudySessions()
        {
            if (_dbContext.StudySessions == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database context is not initialized.");
            }

            try
            {
                var studySessions = await _dbContext.StudySessions.ToListAsync();
                return Ok(studySessions);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving data.");
            }
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<EAD_PredictionTool.Models.StudySession>> GetStudySession(int id)
        {
            if (_dbContext.StudySessions == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database context is not initialized.");
            }

            try
            {
                var studySession = await _dbContext.StudySessions.FindAsync(id);
                if (studySession == null)
                {
                    return NotFound();
                }
                return Ok(studySession);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving data.");
            }
        }
        [HttpPost("PostStudySession")]
        public async Task<ActionResult<EAD_PredictionTool.Models.StudySession>> PostStudySession(EAD_PredictionTool.Models.StudySession studySession)
        {
            if (studySession == null)
            {
                return BadRequest("Study session data is null.");
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dbContext.StudySessions.Add(studySession);
                await _dbContext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetStudySession), new { id = studySession.ID }, studySession);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the study session.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudySession(int id)
        {
            if (_dbContext.StudySessions == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database context is not initialized.");
            }

            try
            {
                var studySession = await _dbContext.StudySessions.FindAsync(id);
                if (studySession == null)
                {
                    return NotFound($"Study session with ID {id} not found.");
                }

                _dbContext.StudySessions.Remove(studySession);
                await _dbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the study session.");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudySession(int id, EAD_PredictionTool.Models.StudySession updatedStudySession)
        {
            if (_dbContext.StudySessions == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database context is not initialized.");
            }

            if (id != updatedStudySession.ID)
            {
                return BadRequest("ID in URL does not match ID in the body.");
            }

            try
            {
                var existingStudySession = await _dbContext.StudySessions.FindAsync(id);
                if (existingStudySession == null)
                {
                    return NotFound($"Study session with ID {id} not found.");
                }
                existingStudySession.Session = updatedStudySession.Session;
                existingStudySession.Goalhours = updatedStudySession.Goalhours;
                existingStudySession.StartTime = updatedStudySession.StartTime;
                existingStudySession.EndTime = updatedStudySession.EndTime;
                existingStudySession.Day = updatedStudySession.Day;
                existingStudySession.TotalStudyhours = updatedStudySession.TotalStudyhours;
                existingStudySession.BreakID = updatedStudySession.BreakID;
                existingStudySession.Date = updatedStudySession.Date;
                existingStudySession.NumberofUnits = updatedStudySession.NumberofUnits;
                existingStudySession.EnrollmentDate = updatedStudySession.EnrollmentDate;

                _dbContext.Entry(existingStudySession).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the study session.");
            }
        }


    }
}
