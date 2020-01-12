namespace GapTest.Services.Clinic
{
    using System.Collections.Generic;
    using GapTest.Models.Entities;

    public interface ISpecialtyService
    {
        IEnumerable<Specialty> GetAll();
        Specialty GetById(int specialtyId);

    }
}