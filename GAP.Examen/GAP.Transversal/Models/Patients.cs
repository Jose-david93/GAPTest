
using System;

namespace GAP.Transversal.Models
{
    public class Patients
    {
        public Patients()
        {

        }
        public Patients(string Dni)
        {
            this.Dni = Dni;
        }
        public Patients(string Dni, string FirstName, string LastName)
        {
            this.Dni = Dni;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
        public Guid Id { get; set; }
        public string Dni { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }
    }
}
