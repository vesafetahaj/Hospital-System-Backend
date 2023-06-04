using Microsoft.AspNetCore.Mvc;

namespace Hospital_System_Management.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
