using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_System_Management.Controllers
{
    [Authorize(Roles ="receptionist")]
    public class ReceptionistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Rezervimet()
        {
            return View();
        }
        public IActionResult Dhomat()
        {
            return View();
        }
        public IActionResult Raportet()
        {
            return View();
        }
    }
}

