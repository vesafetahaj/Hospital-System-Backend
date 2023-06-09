﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Hospital_System_Management.Models;

namespace Hospital_System_Management.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<ContactFormModel> ContactForms { get; set; }
        public DbSet<DoctorModel> Doctor { get; set; }
        public DbSet<RegisterModel> RegisterForm { get; set; }
        public DbSet<ReservationModel> OnlineReservation { get; set; }
        public DbSet<ServiceModel> Sherbimi { get; set; }
        public DbSet<RoomReservationModel> RoomReservation { get; set; }
        public DbSet<ComplaintModel> Complaints { get; set; }
        public DbSet<PaymentModel> Payment { get; set; }
        public DbSet<RaportModel> Raport { get; set; }
    }
}
