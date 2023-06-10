﻿using Hospital_System_Management.Data;
using Hospital_System_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Hospital_System_Management.Controllers
{
    [Authorize(Roles = "receptionist, Patient")]
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


        public IActionResult Rooms()
        {
            return View();
        }
        public IActionResult Reservations()
        {
            return View();
        }
        public IActionResult Raports()
        {
            return View();
        }
        // Contact CRUD
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
    }  

}


