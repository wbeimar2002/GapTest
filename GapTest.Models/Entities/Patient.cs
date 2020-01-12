namespace GapTest.Models.Entities
{
    using System.Collections.Generic;
    public class Patient : EntityBase
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string IdentificationNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
