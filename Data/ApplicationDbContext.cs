using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public DbSet<RegisterModel> MakeReservation { get; set; }
    }
}
