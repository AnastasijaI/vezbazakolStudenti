using System.ComponentModel.DataAnnotations;

namespace Studenti.Models
{
    public class LabVezba
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Naslov")]
        public string Naslov { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Opis")]
        public string Opis { get; set; }
        public ICollection<StudentLab>? Students { get; set; } = new List<StudentLab>();
    }
}
