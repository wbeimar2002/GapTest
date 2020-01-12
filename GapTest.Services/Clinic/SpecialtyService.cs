namespace GapTest.Services.Clinic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GapTest.Models.Entities;
    using GapTest.Repositories.Repositories;

    public class SpecialtyService : ISpecialtyService
    {
        private readonly IClinicRepository<Specialty> _specialtyRepository;

        public SpecialtyService(IClinicRepository<Specialty> specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }

        public IEnumerable<Specialty> GetAll()
        {
            try
            {
                var result = _specialtyRepository.List();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Specialty GetById(int specialtyId)
        {
            try
            {
                var result = _specialtyRepository.GetById(specialtyId);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
