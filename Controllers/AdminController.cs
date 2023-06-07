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

        public IActionResult Doctors()
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
        // GET: /Admin/Contact
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

    }

}
