using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_System_Management.Models
{
    [Table("Doctor")] 
    
    public class DoctorModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }
    }
}