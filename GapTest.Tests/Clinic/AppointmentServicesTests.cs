namespace GapTest.Tests.Clinic
{
    using System;
    using GapTest.Models.Entities;
    using GapTest.Services.Clinic;
    using GapTest.Tests.DataMocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AppointmentServicesTests
    {
        private IPatientService _patientService;
        private ISpecialtyService _specialtyService;
        private IAppointmentService _appointmentService;

        [TestInitialize]
        public void TestInitialize()
        {
            _patientService = new PatientService(MockData.GetPatientRepository());
            _specialtyService = new SpecialtyService(MockData.GetSpecialtyRepository());
            _appointmentService = new AppointmentService(MockData.GetAppointmentRepository(), _patientService, _specialtyService);
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void Create_ValidAppointment_True()
        {
            // there is an appointment for patient 1 in +2 days
            var appointment4 = new Appointment()
            {
                PatientId = 1,
                Date = DateTime.Now.AddDays(3),
                SpecialtyId = 1
            };

            var result = _appointmentService.Create(appointment4);

            // can be created, because there is no appointment in +3 days
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Create_InvalidAppointment_False()
        {
            // there is an appointment for patient 1 in +2 days
            var appointment4 = new Appointment()
            {
                PatientId = 1,
                Date = DateTime.Now.AddDays(2),
                SpecialtyId = 1
            };

            var result = _appointmentService.Create(appointment4);

            // can't be created, because already an appointment exists in +2 days
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Remove_CancelableAppointment_True()
        {
            // appointment 2 is in +2 days
            var result = _appointmentService.Remove(2);

            // can be removed, because appointment is in more than 24 hours
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Remove_NonCancelableAppointment_False()
        {
            // appointment 3 is in +12 hours
            var result = _appointmentService.Remove(3);

            // can't be removed, because appointment is in less than 24 hours
            Assert.IsFalse(result);
        }
    }
}
