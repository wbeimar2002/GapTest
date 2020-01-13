
namespace GapTest.Tests.DataMocks
{
    using System;
    using GapTest.Models.Entities;
    using GapTest.Repositories.Repositories;
    using Moq;

    public class MockData
    {
        internal static readonly Appointment Appointment1 = new Appointment()
        {
            Id = 1,
            Date = DateTime.Now.AddDays(2),
            SpecialtyId = 1,
            PatientId = 1
        };
        internal static readonly Appointment Appointment2 = new Appointment()
        {
            Id = 2,
            Date = DateTime.Now.AddDays(2),
            SpecialtyId = 2,
            PatientId = 2
        };
        internal static readonly Appointment Appointment3 = new Appointment()
        {
            Id = 3,
            Date = DateTime.Now.AddHours(12),
            SpecialtyId = 1,
            PatientId = 2
        };

        internal static readonly Specialty Specialty1 = new Specialty()
        {
            Id = 1,
            Name = "Specialty 1"
        };
        internal static readonly Specialty Specialty2 = new Specialty()
        {
            Id = 2,
            Name = "Specialty 2"
        };

        internal static readonly Patient Patient1 = new Patient()
        {
            Id = 1,
            Name = "Patient 1",
            IdentificationNumber = "IN1",
            PhoneNumber = "PN1",
            Email = "patient1@mail.com"
        };
        internal static readonly Patient Patient2 = new Patient()
        {
            Id = 2,
            Name = "Patient 2",
            IdentificationNumber = "IN2",
            PhoneNumber = "PN2",
            Email = "patient2@mail.com"
        };

        internal static IClinicRepository<Patient> GetPatientRepository()
        {
            var patientRepositoryMock = new Mock<IClinicRepository<Patient>>();
            patientRepositoryMock.Setup(x => x.List()).Returns(new[] { Patient1, Patient2 });
            patientRepositoryMock.Setup(x => x.GetById(1)).Returns(Patient1);
            patientRepositoryMock.Setup(x => x.GetById(2)).Returns(Patient2);
            return patientRepositoryMock.Object;
        }

        internal static IClinicRepository<Specialty> GetSpecialtyRepository()
        {
            var specialtyRepositoryMock = new Mock<IClinicRepository<Specialty>>();
            specialtyRepositoryMock.Setup(x => x.List()).Returns(new[] { Specialty1, Specialty2 });
            specialtyRepositoryMock.Setup(x => x.GetById(1)).Returns(Specialty1);
            specialtyRepositoryMock.Setup(x => x.GetById(2)).Returns(Specialty2);
            return specialtyRepositoryMock.Object;
        }

        internal static IClinicRepository<Appointment> GetAppointmentRepository()
        {
            var appointmentRepositoryMock = new Mock<IClinicRepository<Appointment>>();
            appointmentRepositoryMock.Setup(x => x.List()).Returns(new[] { Appointment1, Appointment2 });
            appointmentRepositoryMock.Setup(x => x.GetById(1)).Returns(Appointment1);
            appointmentRepositoryMock.Setup(x => x.GetById(2)).Returns(Appointment2);
            appointmentRepositoryMock.Setup(x => x.GetById(3)).Returns(Appointment3);
            appointmentRepositoryMock.Setup(x => x.Add(It.IsAny<Appointment>())).Returns(true);
            appointmentRepositoryMock.Setup(x => x.Delete(It.IsAny<Appointment>())).Returns(true);
            return appointmentRepositoryMock.Object;
        }
    }
}
