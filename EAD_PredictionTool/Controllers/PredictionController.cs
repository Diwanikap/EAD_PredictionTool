using EAD_PredictionTool.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EAD_PredictionTool.Controllers
{
    public class PredictionController : Controller
    {
        private readonly HttpClient _client;

        public PredictionController(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://localhost:5132");
        }

        public IActionResult Index()
        {
            return View("Prediction");
        }

        [HttpPost]
        public async Task<IActionResult> SubmitStudySession(StudySession studySession)
        {
            if (studySession == null)
            {
                return BadRequest("Study session data is null.");
            }

            try
            {

                string jsonContent = JsonConvert.SerializeObject(studySession);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync("/api/Session/GetStudySession", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Prediction");
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"Error: {response.StatusCode}, {error}");
                    return View("Prediction", studySession);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Exception: {ex.Message}");
                return View("Prediction", studySession);
            }
        }
    }
}
