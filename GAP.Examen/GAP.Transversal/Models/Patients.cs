
using System;

namespace GAP.Transversal.Models
{
    public class Patients
    {
        public Guid Id { get; set; }
        public string Dni { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }
    }
}
