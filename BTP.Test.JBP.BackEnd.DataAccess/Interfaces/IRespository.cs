using BTP.Test.JBP.BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTP.Test.JBP.BackEnd.DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        public List<T> GetAll();
        public T Get(int id);
        public T Add(T entity);
        public T Update(T entity);
        public T Delete(T entity);

    }
}
