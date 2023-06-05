using Microsoft.AspNetCore.Mvc;
using Hospital_System_Management.Models;
using System;
using System.Linq;
using Hospital_System_Management.Data;

namespace Hospital_System_Management.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contactForms = _context.ContactForms.ToList();
            return View(contactForms);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                model.DateSubmitted = DateTime.Now;
                _context.ContactForms.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var contactForm = _context.ContactForms.FirstOrDefault(c => c.Id == id);
            if (contactForm == null)
            {
                return NotFound();
            }

            return View(contactForm);
        }

        [HttpPost]
        public IActionResult Edit(ContactFormModel model)
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
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contactForm = _context.ContactForms.FirstOrDefault(c => c.Id == id);
            if (contactForm == null)
            {
                return NotFound();
            }

            return View(contactForm);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var contactForm = _context.ContactForms.FirstOrDefault(c => c.Id == id);
            if (contactForm == null)
            {
                return NotFound();
            }

            _context.ContactForms.Remove(contactForm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
