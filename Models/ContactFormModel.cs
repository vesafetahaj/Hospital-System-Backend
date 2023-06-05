using System.ComponentModel.DataAnnotations;

namespace Hospital_System_Management.Models
{
    public class ContactFormModel
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public DateTime DateSubmitted { get; set; }
    }
}
