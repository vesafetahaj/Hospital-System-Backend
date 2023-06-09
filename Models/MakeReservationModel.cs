using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_System_Management.Models
{
    [Table("MakeReservation")]

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