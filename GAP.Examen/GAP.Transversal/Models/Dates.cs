using System;

namespace GAP.Transversal.Models
{
    public class Dates
    {
        public Guid Id { get; set; }
        public Guid IdPatient { get; set; }
        public Guid IdService { get; set; }
        public DateTime DateService { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        //To Mapping
        public string IdPatientJs { get; set; }
        public string IdServiceJs { get; set; }
        public string Dni {get;set;}
        public string FirstName {get;set;}
        public string LastName { get;set;}
        public string Service { get;set;}
        public string StatusM { get;set;}
    }
}
