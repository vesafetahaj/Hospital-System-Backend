using Hospital_System_Management.Data;
using Hospital_System_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_System_Management.Controllers
{
    [Authorize(Roles ="Doctor")]
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Patients()
        {
            return View();
        }
        public IActionResult Appointments()
        {
            return View();
        }
        public IActionResult Medications()
        {
            return View();
        }


        public ActionResult YourRaport()
        {
            var submissions = _context.Raport.ToList();
            return View(submissions);
        }


        [HttpGet]
        public IActionResult EditRaport(int id)
        {
            var reserve = _context.Raport.FirstOrDefault(c => c.Id == id);
            if (reserve == null)
            {
                return NotFound();
            }

            return View(reserve);
        }

        [HttpPost]
        public IActionResult EditRaport(RaportModel model)
        {
            if (ModelState.IsValid)
            {
                var reserve = _context.Raport.FirstOrDefault(c => c.Id == model.Id);
                if (reserve == null)
                {
                    return NotFound();
                }
                reserve.Name = model.Name;
                reserve.Surname = model.Surname;
                reserve.Birthday = model.Birthday;
                reserve.Birthplace = model.Birthplace;
                reserve.Raporti = model.Raporti;

                _context.SaveChanges();
                return RedirectToAction("YourRaport");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteRaport(int id)
        {
            var reserve = _context.Raport.FirstOrDefault(c => c.Id == id);
            if (reserve == null)
            {
                return NotFound();
            }

            return View(reserve);
        }

        [HttpPost]
        public IActionResult DeleteRaportConfirmed(int id)
        {
            var reserve = _context.Raport.FirstOrDefault(c => c.Id == id);
            if (reserve == null)
            {
                return NotFound();
            }

            _context.Raport.Remove(reserve);
            _context.SaveChanges();
            return RedirectToAction("YourRaport");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RaportModel model)
        {
            if (ModelState.IsValid)
            {
                model.Birthday = DateTime.Now;
                _context.Raport.Add(model);
                _context.SaveChanges();
                return RedirectToAction("CreateSuccessO");
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Success()
        {
            var reserve = _context.Raport.ToList();
            return View(reserve);
        }
        [HttpGet]

        public IActionResult CreateSuccessO()
        {
            return View();
        }


    }
}