namespace GapTest.Models.Entities
{
    using System.Collections.Generic;

    public class Specialty: EntityBase
    {
        public string Name { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
