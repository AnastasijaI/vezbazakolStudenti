using System.ComponentModel.DataAnnotations;

namespace Studenti.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name ="Indeks")]
        public string Indeks { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Ime i Prezime")]
        public string ImePrezime { get; set; }
        [Required]
        [StringLength(2)]
        [Display(Name = "Potpis")]
        public string Potpis { get; set; }  

        public ICollection<StudentLab>? Labs { get; set; } = new List<StudentLab>();

    }
}
