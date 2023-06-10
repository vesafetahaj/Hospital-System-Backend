using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_System_Management.Models
{
    [Table("Sherbimi")] 
    
    public class ServiceModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pershkrimi { get; set; }
        public string PhotoUrl { get; set; }
    }
}