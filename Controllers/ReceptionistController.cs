using Hospital_System_Management.Data;
using Hospital_System_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_System_Management.Controllers
{
    [Authorize(Roles ="receptionist")]
    public class ReceptionistController : Controller
    {
        private readonly ApplicationDbContext _context1;
        public ReceptionistController(ApplicationDbContext context1)
        {
            _context1 = context1;
        }
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
        // GET: /Receptionist/Reservation
        public ActionResult Reservation()
        {
            var submissions = _context1.MakeReservation.ToList();
            return View(submissions);
        }
        [HttpGet]
        public IActionResult EditReservation(int id)
        {
            var reservation = _context1.MakeReservation.FirstOrDefault(c => c.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        [HttpPost]
        public IActionResult EditReservation(MakeReservationModel model)
        {
            if (ModelState.IsValid)
            {
                var reservation = _context1.MakeReservation.FirstOrDefault(c => c.Id == model.Id);
                if (reservation == null)
                {
                    return NotFound();
                }

                reservation.Name = model.Name;
                reservation.Surname= model.Surname;
                reservation.Age = model.Age;
                reservation.IDCard = model.IDCard;

                _context1.SaveChanges();
                return RedirectToAction("Reserve");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteReservation(int id)
        {
            var reservation = _context1.MakeReservation.FirstOrDefault(c => c.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var reservation = _context1.MakeReservation.FirstOrDefault(c => c.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            _context1.MakeReservation.Remove(reservation);
            _context1.SaveChanges();
            return RedirectToAction("Reserve");
        }

    }


}


