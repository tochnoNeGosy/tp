using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_BazovoeZadanie
{
    public class Patient
    {
        public int PatientId { get; set; }
        public int age { get; set; }

        public int roomNumber { get; set; }
        public string fcs { get; set; }
        public string sick { get; set; }

        public Patient() { }

        public Patient(int age, int roomNumber, string fcs, string sick)
        {
            this.age = age;
            this.roomNumber = roomNumber;
            this.fcs = fcs;
            this.sick = sick;
        }

        override
        public string ToString()
        {
            return string.Format("ФИО: {0}, болезнь: {1}, возраст:{2}, палата:{3}", fcs, sick, age, roomNumber);
        }
    }
}


//сначала качаем через nuGet пакеты Microsoft.EntityFrameworkCore   EntityFrameworkCore.tools   EntityFrameworkCore.sqlServer 
//Класс Context  : DbContext
//public DbSet<Patient> Patients { get; set; }    dbSet каждому компоненту
//всем полям {get; set;] даже списку, так получится связь как раз
//Add-Migrations Name
//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//{
//    optionsBuilder.UseSqlServer("serverSayHi");
//    base.OnConfiguring(optionsBuilder);
//}
//
//