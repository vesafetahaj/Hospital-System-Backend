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
        public IActionResult CreateSuccess()
        {
            return View();
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
                return RedirectToAction("CreateSuccess");
            }

            return View(model);
        }

    }

}
