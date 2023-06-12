using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_System_Management.Models
{

    public class ComplaintModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    

   
        public DateTime DateSubmitted { get; set; }

        public string Explanation { get; set; }
    }
}