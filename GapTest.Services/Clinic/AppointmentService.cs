
namespace GapTest.Services.Clinic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using GapTest.Models.Entities;
    using GapTest.Repositories.Repositories;

    public class AppointmentService : IAppointmentService
    {
        private readonly IClinicRepository<Appointment> _appointmentRepository;
        private readonly IPatientService _patientService;
        private readonly ISpecialtyService _specialtyService;

        public AppointmentService(
            IClinicRepository<Appointment> appointmentRepository,
            IPatientService patientService,
            ISpecialtyService specialtyService)
        {
            _appointmentRepository = appointmentRepository;
            _patientService = patientService;
            _specialtyService = specialtyService;
        }

        public Appointment GetById(int appointmentId)
        {
            var result = _appointmentRepository.GetById(appointmentId);

            if (result != null)
                return GetFullInformation(result);

            return null;
        }

        public IEnumerable<Appointment> GetAll()
        {
            var result = _appointmentRepository.List();

            if (result != null)
            {
                var appointments = new List<Appointment>();

                foreach (var item in result)
                {
                    appointments.Add(GetFullInformation(item));
                }

                return appointments;
            }

            return null;
        }


        public bool Create(Appointment appointment)
        {
            try
            {
                var result = ValidateCreation(appointment) ? _appointmentRepository.Add(appointment) : false;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Remove(int appointmentId)
        {
            try
            {
                var appointment = _appointmentRepository.GetById(appointmentId);

                var result = ValidateCancel(appointment) ? _appointmentRepository.Delete(appointment) : false;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidateCancel(Appointment appointment)
        {
            //Business rule, the Appointment only be canceled when don't pass 24 hours
            bool canBeCanceled = (appointment.Date - DateTime.Now).TotalHours > 24;

            return canBeCanceled;
        }

        private bool ValidateCreation(Appointment appointment)
        {
            // Appointment can be created if patient doesn't have appointments for the same day
            var patient = _patientService.GetById(appointment.PatientId);
            var patientAppointments = GetAll().Where(x => x.PatientId == patient.Id).ToList();

            var anotherAppointmentForSameDay =
                patientAppointments?.FirstOrDefault(x => x.Date.Date == appointment.Date.Date);

            var canBeCreated = anotherAppointmentForSameDay == null;

            return canBeCreated;
        }

        private Appointment GetFullInformation(Appointment appointment)
        {
            var fullAppointment = new Appointment()
            {
                Id = appointment.Id,
                Date = appointment.Date,
                Location = appointment.Location,
                PatientId = appointment.PatientId,
                SpecialtyId = appointment.SpecialtyId,
                Patient = _patientService.GetById(appointment.PatientId),
                Specialty = _specialtyService.GetById(appointment.SpecialtyId)
            };

            return fullAppointment;
        }
    }
}
