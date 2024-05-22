using Microsoft.EntityFrameworkCore;
using Studenti.Models;
using System.IO;

namespace Studenti.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StudentiContext(serviceProvider.GetRequiredService<DbContextOptions<StudentiContext>>()))
            {
                if (context.Student.Any() || context.StudentLab.Any() || context.LabVezba.Any())
                {
                    return;
                }
                context.LabVezba.AddRange
                (
                    new LabVezba
                    {
                        Naslov = "Vezba br 1",
                        Opis = "Vo ovaa vezba ke se pravi.."
                    },
                    new LabVezba
                    {
                        Naslov = "Vezba br 2",
                        Opis = "Vo ovaa vezba ke se pravi istrazuvanje za.."
                    },
                    new LabVezba
                    {
                        Naslov = "Vezba br 3",
                        Opis = "Vo ovaa vezba ke se proveruva.."
                    }
                );
                context.SaveChanges();

                context.Student.AddRange(
                        new Student { /*Id = 1, */Indeks = "12/345", ImePrezime = "Anastasija Ilievska", Potpis = "da" },
                        new Student { /*Id = 2, */Indeks = "6/789", ImePrezime = "Anabela Ilievska", Potpis = "da" },
                        new Student { /*Id = 3, */Indeks = "11/2233", ImePrezime = "Aleksandar Dimcevski", Potpis = "ne" },
                        new Student { /*Id = 4, */Indeks = "122/112", ImePrezime = "Ilaria Ilievska", Potpis = "da" }
                );
                context.SaveChanges();

                context.StudentLab.AddRange(
                    new StudentLab
                    {
                        //Id = 1,
                       StudentId=1,
                       LabVezbaId=1,
                       Zavrsena="da",
                       Poeni = 10,
                       DataZavrsuvanje = new DateOnly(2024, 5, 30)
                    },
                    new StudentLab
                    {
                        //Id = 2,
                        StudentId = 2,
                        LabVezbaId = 1,
                        Zavrsena = "da",
                        Poeni = 9,
                        DataZavrsuvanje = new DateOnly(2024, 5, 30)
                    },
                    new StudentLab
                    {
                        //Id = 3,
                        StudentId = 3,
                        LabVezbaId = 2,
                        Zavrsena = "ne",
                        Poeni = 10,
                        DataZavrsuvanje = new DateOnly(2024, 6, 30)
                    },
                    new StudentLab
                    {
                        //Id = 4,
                        StudentId = 4,
                        LabVezbaId = 3,
                        Zavrsena = "da",
                        Poeni = 10,
                        DataZavrsuvanje = new DateOnly(2024, 5, 30)
                    }
                );
                context.SaveChanges();
                
            }
        }
    }
}
