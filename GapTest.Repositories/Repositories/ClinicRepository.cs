namespace GapTest.Repositories.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ClinicRepository<T> : IClinicRepository<T> where T : EntityBase
    {
        private readonly ClinicContext _dbContext;

        public ClinicRepository()
        {
            _dbContext = new ClinicContext();
        }

        public bool Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            var changes = _dbContext.SaveChanges();

            return changes > 0;
        }

        public bool Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            var changes = _dbContext.SaveChanges();

            return changes > 0;
        }

        public bool Edit(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            var changes = _dbContext.SaveChanges();

            return changes > 0;
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> List()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }
    }
}
