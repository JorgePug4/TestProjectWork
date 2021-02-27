using BTP.Test.JBP.BackEnd.DataAccess.Interfaces;
using BTP.Test.JBP.BackEnd.Entities.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTP.Test.JBP.BackEnd.DataAccess
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(DataContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public T Add(T entity)
        {
            var resp = entities.Add(entity);
            if (resp.State == EntityState.Added)
            {
                context.SaveChanges();
            }
            return entity;
        }

        public T Delete(T Student)
        {

            var resp = entities.Remove(Student);
            if (resp.State == EntityState.Deleted)
            {
                context.SaveChanges();

            }

            return Student;
        }

        public T Get(int id)
        {
            return entities.SingleOrDefault(x => x.ID == id);
        }

        public List<T> GetAll()
        {
            return entities.ToList();
        }

        public T Update(T entity)
        {
            var resp  =entities.Update(entity);
            if (resp.State == EntityState.Modified)
            {
                context.SaveChanges();

            }
            return entity;
        }
    }
}
