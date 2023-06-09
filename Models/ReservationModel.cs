using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_System_Management.Models
{

    public class ReservationModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Mosha { get; set; }
        public string IDCard { get; set; }

        public string Sherbimi { get; set; }
        public DateTime DateSubmitted { get; set; }
    }
}