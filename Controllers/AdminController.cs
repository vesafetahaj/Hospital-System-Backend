using Hospital_System_Management.Data;
using Hospital_System_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_System_Management.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        
       
        public IActionResult Patients()
        {
            return View();
        }
        public ActionResult Appointments()
        {
            var appointments = _context.OnlineReservation.ToList();
            return View(appointments);
            
        }
        // Contact CRUD
        public ActionResult Contact()
        {
            var submissions = _context.ContactForms.ToList();
            return View(submissions);
        }
        [HttpGet]
        public IActionResult EditContact(int id)
        {
            var contactForm = _context.ContactForms.FirstOrDefault(c => c.Id == id);
            if (contactForm == null)
            {
                return NotFound();
            }

            return View(contactForm);
        }

        [HttpPost]
        public IActionResult EditContact(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                var contactForm = _context.ContactForms.FirstOrDefault(c => c.Id == model.Id);
                if (contactForm == null)
                {
                    return NotFound();
                }

                contactForm.FirstName = model.FirstName;
                contactForm.LastName = model.LastName;
                contactForm.Email = model.Email;
                contactForm.Phone = model.Phone;
                contactForm.Message = model.Message;

                _context.SaveChanges();
                return RedirectToAction("Contact");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteContact(int id)
        {
            var contactForm = _context.ContactForms.FirstOrDefault(c => c.Id == id);
            if (contactForm == null)
            {
                return NotFound();
            }

            return View(contactForm);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var contactForm = _context.ContactForms.FirstOrDefault(c => c.Id == id);
            if (contactForm == null)
            {
                return NotFound();
            }

            _context.ContactForms.Remove(contactForm);
            _context.SaveChanges();
            return RedirectToAction("Contact");
        }
        //Doctors CRUD
        public ActionResult Doctors()
        {
            var doctors = _context.Doctor.ToList();
            return View(doctors);
        }

        [HttpGet]
        public IActionResult EditDoctor(int id)
        {
            var doctor = _context.Doctor.FirstOrDefault(d => d.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        [HttpPost]
        public IActionResult EditDoctor(DoctorModel model)
        {
            if (ModelState.IsValid)
            {
                var doctor = _context.Doctor.FirstOrDefault(d => d.Id == model.Id);
                if (doctor == null)
                {
                    return NotFound();
                }

                doctor.Name = model.Name;
                doctor.Specialization = model.Specialization;
                doctor.Email = model.Email;
                doctor.PhoneNumber = model.PhoneNumber;
                doctor.Address = model.Address;
                doctor.PhotoUrl = model.PhotoUrl;

                _context.SaveChanges();
                return RedirectToAction("Doctors");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteDoctor(int id)
        {
            var doctor = _context.Doctor.FirstOrDefault(c => c.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        [HttpPost]
        public IActionResult DeleteConfirmedDoctor(int id)
        {
            var doctor = _context.Doctor.FirstOrDefault(d => d.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctor.Remove(doctor);
            _context.SaveChanges();
            return RedirectToAction("Doctors");
        }
        [HttpPost]
        public IActionResult CreateDoctor(DoctorModel model)
        {
            if (ModelState.IsValid)
            {
              
                var doctor = new DoctorModel
                {
                   
                    Name = model.Name,
                    Specialization = model.Specialization,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    PhotoUrl = model.PhotoUrl
                };

               
                _context.Doctor.Add(doctor);
                _context.SaveChanges();

                return RedirectToAction("Doctors");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateDoctor()
        {
            return View();
        }

    }

}



