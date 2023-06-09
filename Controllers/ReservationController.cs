using Microsoft.AspNetCore.Mvc;
using Hospital_System_Management.Models;
using System;
using System.Linq;
using Hospital_System_Management.Data;

namespace Hospital_System_Management.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var reservation = _context.MakeReservation.ToList();
            return View(reservation);
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
        public IActionResult Create(MakeReservationModel model)
        {
            if (ModelState.IsValid)
            {
                model.DateSubmitted = DateTime.Now;
                _context.MakeReservation.Add(model);
                _context.SaveChanges();
                return RedirectToAction("CreateSuccess");
            }

            return View(model);
        }

    }

}
