using Hospital_System_Management.Data;
using Hospital_System_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Hospital_System_Management.Controllers
{
    [Authorize(Roles = "receptionist")]
    public class ReceptionistController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceptionistController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reservations()
        {
            return View();
        }
        public IActionResult ReserveARoom()
        {
            return View();
        }
        public IActionResult Raports()
        {
            return View();
        }
        public IActionResult Payment()
        {
            return View();
        }
        
        // REGISTER CRUD
        public ActionResult Register()
        {
            var submissions = _context.RegisterForm.ToList();
            return View(submissions);
        }
        [HttpGet]
        public IActionResult EditRegistration(int id)
        {
            var register = _context.RegisterForm.FirstOrDefault(c => c.Id == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        [HttpPost]
        public IActionResult EditRegistration(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var register = _context.RegisterForm.FirstOrDefault(c => c.Id == model.Id);
                if (register == null)
                {
                    return NotFound();
                }
                register.Name = model.Name;
                register.Surname = model.Surname;
                register.Age = model.Age;
                register.BirthPlace = model.BirthPlace;
                register.DateSubmitted = model.DateSubmitted;
                register.IDCard = model.IDCard;

                _context.SaveChanges();
                return RedirectToAction("Register");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteRegistration(int id)
        {
            var register = _context.RegisterForm.FirstOrDefault(c => c.Id == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var register = _context.RegisterForm.FirstOrDefault(c => c.Id == id);
            if (register == null)
            {
                return NotFound();
            }

            _context.RegisterForm.Remove(register);
            _context.SaveChanges();
            return RedirectToAction("Register");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                model.DateSubmitted = DateTime.Now;
                _context.RegisterForm.Add(model);
                _context.SaveChanges();
                return RedirectToAction("CreateSuccessR");
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Success()
        {
            var register = _context.RegisterForm.ToList();
            return View(register);
        }
        [HttpGet]

        public IActionResult CreateSuccessR()
        {
            return View();
        }

        // ROOM RESERVATION CRUD

        public ActionResult Rooms()
        {
            var room = _context.RoomReservation.ToList();
            return View(room);
        }

        [HttpGet]
        public IActionResult EditRoom(int id)
        {
            var room = _context.RoomReservation.FirstOrDefault(d => d.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        [HttpPost]
        public IActionResult EditRoom(RoomReservationModel model)
        {
            if (ModelState.IsValid)
            {
                var room = _context.RoomReservation.FirstOrDefault(d => d.Id == model.Id);
                if (room == null)
                {
                    return NotFound();
                }
                room.RoomNumber = model.RoomNumber;
                room.Name = model.Name;
                room.Surname = model.Surname;
                room.BirthPlace = model.BirthPlace;
                room.DateSubmitted = model.DateSubmitted;
                room.IDCard = model.IDCard;

                _context.SaveChanges();
                return RedirectToAction("Rooms");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteRoom(int id)
        {
            var room = _context.RoomReservation.FirstOrDefault(c => c.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        [HttpPost]
        public IActionResult DeleteConfirmedRoom(int id)
        {
            var room = _context.RoomReservation.FirstOrDefault(d => d.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            _context.RoomReservation.Remove(room);
            _context.SaveChanges();
            return RedirectToAction("Rooms");
        }
        [HttpPost]
        public IActionResult CreateRoom(RoomReservationModel model)
        {
            if (ModelState.IsValid)
            {

                var room = new RoomReservationModel
                {
                    RoomNumber = model.RoomNumber,
                    Name = model.Name,
                    Surname = model.Surname,
                    BirthPlace = model.BirthPlace,
                    DateSubmitted = model.DateSubmitted,
                    IDCard = model.IDCard
                };



                _context.RoomReservation.Add(room);
                _context.SaveChanges();

                return RedirectToAction("Rooms");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateRoom()
        {
            return View();
        }

        // Payment Crud 

        public ActionResult Checks()
        {
            var submissions = _context.Payment.ToList();
            return View(submissions);
        }
        [HttpGet]
        public IActionResult EditPayment(int id)
        {
            var pay = _context.Payment.FirstOrDefault(c => c.Id == id);
            if (pay == null)
            {
                return NotFound();
            }

            return View(pay);
        }

        [HttpPost]
        public IActionResult EditPayment(PaymentModel model)
        {
            if (ModelState.IsValid)
            {
                var pay = _context.Payment.FirstOrDefault(c => c.Id == model.Id);
                if (pay == null)
                {
                    return NotFound();
                }
                pay.Name = model.Name;
                pay.Surname = model.Surname;
                pay.DeptName = model.DeptName;
                pay.DoctorName = model.DoctorName;
                pay.Kontrolla = model.Kontrolla;
                pay.DateSubmitted = model.DateSubmitted;
                pay.PaymentTotal = model.PaymentTotal;

                _context.SaveChanges();
                return RedirectToAction("Checks");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult DeletePayment(int id)
        {
            var pay = _context.Payment.FirstOrDefault(c => c.Id == id);
            if (pay == null)
            {
                return NotFound();
            }

            return View(pay);
        }

        [HttpPost]
        public IActionResult DeleteConfirmedP(int id)
        {
            var pay = _context.Payment.FirstOrDefault(c => c.Id == id);
            if (pay == null)
            {
                return NotFound();
            }

            _context.Payment.Remove(pay);
            _context.SaveChanges();
            return RedirectToAction("Checks");
        }
        [HttpGet]
        public IActionResult CreatePayment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePayment(PaymentModel model)
        {
            if (ModelState.IsValid)
            {
                model.DateSubmitted = DateTime.Now;
                _context.Payment.Add(model);
                _context.SaveChanges();
                return RedirectToAction("CreateSuccessP");
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult SuccessP()
        {
            var pay = _context.Payment.ToList();
            return View(pay);
        }
        [HttpGet]

        public IActionResult CreateSuccessP()
        {
            return View();
        }
        // Terminet
        public ActionResult Appointments()
        {
            var appointments = _context.OnlineReservation.ToList();
            return View(appointments);

        }

    }

}


