using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_System_Management.Controllers
{
    [Authorize(Roles ="Patient")]
    public class PatientController : Controller
    {
        public IActionResult Index()

        {

            return View();
        }
        public IActionResult Rezervimi()
        {
            return View();
        }
        public IActionResult Kontakt()
        {
            return View();
        }
        public IActionResult Raporti()
        {
            return View();
        }

        public IActionResult YourAppointment()
        {
            return View();
        }
    }
}
