using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_System_Management.Controllers
{
    [Authorize(Roles ="Patient")]
    public class Patient : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
