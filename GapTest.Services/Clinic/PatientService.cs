namespace GapTest.Services.Clinic
{
    using System;
    using System.Collections.Generic;
    using GapTest.Models.Entities;
    using GapTest.Repositories.Repositories;

    public class PatientService : IPatientService
    {
        private readonly IClinicRepository<Patient> _patientRepository;

        public PatientService(IClinicRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public IEnumerable<Patient> GetAll()
        {
            var result = _patientRepository.List();

            return result;
        }

        public Patient GetById(int patientId)
        {
            var result = _patientRepository.GetById(patientId);

            return result;
        }

        public bool Create(Patient patient)
        {
            try
            {
                var result = _patientRepository.Add(patient);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Remove(int patientId)
        {
            try
            {
                var patient = _patientRepository.GetById(patientId);

                var result = _patientRepository.Delete(patient);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
