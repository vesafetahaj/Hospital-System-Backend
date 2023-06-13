using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace Hospital_System_Management.Models
{

    public class PaymentModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DeptName{ get; set; }
        public string DoctorName { get; set; }
        public string Kontrolla { get; set; }
        public int PaymentTotal { get; set; }
        public DateTime DateSubmitted { get; set; }
    }
}