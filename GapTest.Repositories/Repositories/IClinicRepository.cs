

namespace GapTest.Repositories.Repositories
{
    using System.Collections.Generic;
    using GapTest.Models.Entities;
    public interface IClinicRepository<T> where T : EntityBase
    {
        T GetById(int id);
        IEnumerable<T> List();
        bool Add(T entity);
        bool Delete(T entity);
        bool Edit(T entity);
    }
}