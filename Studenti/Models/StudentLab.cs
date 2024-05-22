using System.ComponentModel.DataAnnotations;

namespace Studenti.Models
{
    public class StudentLab
    {
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int LabVezbaId { get; set; }
        public LabVezba? LabVezba { get; set; }
        [StringLength(2)]
        [Display(Name = "Zavrsena")]
        public string? Zavrsena { get; set; }
        [Display(Name = "Poeni")]
        public int? Poeni { get; set; }
        [Display(Name = "Data na Zavrsuvanje")]
        [DataType(DataType.Date)]
        public DateOnly? DataZavrsuvanje { get; set; }

    }
}
