using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_BazovoeZadanie
{
    public class PlanesContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientsList> PatientsLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("serverSayHi");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
