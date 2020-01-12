namespace GapTest.Services.Clinic
{
    using System.Collections.Generic;
    using GapTest.Models.Entities;
    public interface IPatientService
    {
        IEnumerable<Patient> GetAll();
        Patient GetById(int patientId);
        bool Create(Patient patient);
        bool Remove(int patientId);
    }
}