using EAD_PredictionTool.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Prediction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictionController : ControllerBase
    {
        private readonly StudySession_Context _dbContext;

        public PredictionController(StudySession_Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("predict")]
        public async Task<IActionResult> PredictGrade()
        {
            var sessions = await _dbContext.StudySessions.ToListAsync();
            int sum = sessions.Sum(s => s.NumberofUnits);

            string grade;
            if (sum >= 9)
            {
                grade = "Distinction";
            }
            else if (sum >= 7)
            {
                grade = "Merit";
            }
            else if (sum >= 5)
            {
                grade = "Pass";
            }
            else if (sum >= 3)
            {
                grade = "Simple Pass";
            }
            else
            {
                grade = "Fail";
            }

            return Ok(new { TotalUnits = sum, Grade = grade });
        }
    }
}
