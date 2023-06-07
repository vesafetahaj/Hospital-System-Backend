using System.ComponentModel.DataAnnotations;

namespace Hospital_System_Management.Models
{
    public class MakeReservationModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string IDCard { get; set; }
        public DateTime DateSubmitted { get; set; }
    }
}