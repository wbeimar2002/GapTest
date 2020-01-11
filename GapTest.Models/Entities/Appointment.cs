using System;
using System.Collections.Generic;
using System.Text;

namespace GapTest.Models.Entities
{
    public class Appointment : EntityBase
    {
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public Patient Patient { get; set; }
        public Speciality Speciality { get; set; }
    }
}
