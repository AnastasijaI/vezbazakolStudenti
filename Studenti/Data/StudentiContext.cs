using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Studenti.Models;

namespace Studenti.Data
{
    public class StudentiContext : DbContext
    {
        public StudentiContext (DbContextOptions<StudentiContext> options)
            : base(options)
        {
        }

        public DbSet<Studenti.Models.Student> Student { get; set; } = default!;
        public DbSet<Studenti.Models.LabVezba> LabVezba { get; set; } = default!;
        public DbSet<Studenti.Models.StudentLab> StudentLab { get; set; } = default!;
    }
}
