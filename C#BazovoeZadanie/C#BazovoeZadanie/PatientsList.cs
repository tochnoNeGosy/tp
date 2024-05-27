using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace C_BazovoeZadanie
{
    public class PatientsList
    {
        public int Id { get; set; }
        public BindingList<Patient> patients  { get; set; }

        public PatientsList()
        {
            patients = new BindingList<Patient>();
        }

        public void add(Patient patient)
        {
            patients.Add(patient);
        }

        public List<String> olderThan(int age)
        {
            var ret = from patient in patients
                      where patient.age > age
                      select patient.fcs;
            return ret.ToList();
        }

        public int mostPopularRoom()
        {
            return patients.GroupBy(p => p.roomNumber).OrderBy(gr => gr.Count()).Select(gr => gr.Key).LastOrDefault();
        }

    }
}
