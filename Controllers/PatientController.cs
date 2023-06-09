using Hospital_System_Management.Data;
using Hospital_System_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Hospital_System_Management.Controllers
{
    [Authorize(Roles = "Patient")]
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }
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

   
        // Reservation CRUD
        public ActionResult YourAppointment()
        {
            var submissions = _context.OnlineReservation.ToList();
            return View(submissions);
        }
        [HttpGet]
        public IActionResult EditReservation(int id)
        {
            var reserve = _context.OnlineReservation.FirstOrDefault(c => c.Id == id);
            if (reserve == null)
            {
                return NotFound();
            }

            return View(reserve);
        }

        [HttpPost]
        public IActionResult EditReservation(ReservationModel model)
        {
            if (ModelState.IsValid)
            {
                var reserve = _context.OnlineReservation.FirstOrDefault(c => c.Id == model.Id);
                if (reserve == null)
                {
                    return NotFound();
                }
                reserve.Name = model.Name;
                reserve.Surname = model.Surname;
                reserve.Mosha = model.Mosha;
                reserve.IDCard = model.IDCard;
                reserve.Sherbimi = model.Sherbimi;
                reserve.DateSubmitted = model.DateSubmitted;

                _context.SaveChanges();
                return RedirectToAction("YourAppointment");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteReservation(int id)
        {
            var reserve = _context.OnlineReservation.FirstOrDefault(c => c.Id == id);
            if (reserve == null)
            {
                return NotFound();
            }

            return View(reserve);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var reserve = _context.OnlineReservation.FirstOrDefault(c => c.Id == id);
            if (reserve == null)
            {
                return NotFound();
            }

            _context.OnlineReservation.Remove(reserve);
            _context.SaveChanges();
            return RedirectToAction("YourAppointment");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ReservationModel model)
        {
            if (ModelState.IsValid)
            {
                model.DateSubmitted = DateTime.Now;
                _context.OnlineReservation.Add(model);
                _context.SaveChanges();
                return RedirectToAction("CreateSuccessO");
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Success()
        {
            var reserve = _context.OnlineReservation.ToList();
            return View(reserve);
        }
        [HttpGet]

        public IActionResult CreateSuccessO()
        {
            return View();
        }
    }

}


