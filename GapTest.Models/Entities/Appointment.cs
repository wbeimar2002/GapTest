
namespace GapTest.Models.Entities
{
    using System;

    public class Appointment : EntityBase
    {
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }
    }
}
