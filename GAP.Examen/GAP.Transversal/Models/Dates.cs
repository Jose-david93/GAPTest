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
    }
}
