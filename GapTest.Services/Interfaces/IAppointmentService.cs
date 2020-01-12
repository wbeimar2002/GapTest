using System.Collections.Generic;
using GapTest.Models.Entities;

namespace GapTest.Services.Clinic
{
    public interface IAppointmentService
    {
        Appointment GetById(int appointmentId);
        IEnumerable<Appointment> GetAll();
        bool Create(Appointment appointment);
        bool Remove(int appointmentId);
    }
}