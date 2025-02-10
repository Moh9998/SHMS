using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using SHMS.Models;
using SHMS.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SHMS.Controllers
{
    public class TestResultsController : Controller
    {
        private readonly TestResultService _testResultService;
        private readonly UserService _userService;

        public TestResultsController(TestResultService testResultService, UserService userService)
        {
            _testResultService = testResultService;
            _userService = userService;
        }

        // GET: TestResults/Patient (Patient views test results)
        public async Task<IActionResult> Patient()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized( );
            }

            var results = await _testResultService.GetPatientTestResultsAsync(int.Parse(userId));
            return View(results);
        }

        // GET: TestResults/Upload (Doctor Upload Page)
        public async Task<IActionResult> Upload()
        {
            var patients = await _userService.GetPatientsAsync( );
            ViewBag.Patients = new SelectList(patients, "Id", "Name");
            return View( );
        }

        // POST: TestResults/Upload (Doctor uploads test result)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(TestResult testResult)
        {
            if (!ModelState.IsValid)
            {
                var patients = await _userService.GetPatientsAsync( );
                ViewBag.Patients = new SelectList(patients, "Id", "Name");
                return View(testResult);
            }

            await _testResultService.AddTestResultAsync(testResult);
            return RedirectToAction("Upload");
        }
    }
}
