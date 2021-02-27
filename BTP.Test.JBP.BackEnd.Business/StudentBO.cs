using System;
using System.Collections.Generic;
using System.Text;
using BTP.Test.JBP.BackEnd.Business.Bases;
using BTP.Test.JBP.BackEnd.DataAccess;
using BTP.Test.JBP.BackEnd.DataAccess.Interfaces;
using BTP.Test.JBP.BackEnd.Entities;

namespace BTP.Test.JBP.BackEnd.Business
{
    public class StudentBO<T>
    {
        private IRepository<Students> _repository;
        public StudentBO(IRepository<Students> studentRepository)
        {
            this._repository = studentRepository;
        }

        public Students Get(int id)
        {
            Students resp = _repository.Get(id);
            if (resp is null)
            {
                throw new ExceptionApi("La consulta no regresó datos", 1);
            }
            return resp;
        }

        public List<Students> GetAll()
        {
            List<Students> resp = _repository.GetAll();
            if (resp is null)
            {
                throw new ExceptionApi("La consulta no regresó datos", 1);
            }
            return resp;
        }

        public Students Detete(int id)
        {
            var student = _repository.Get(id);
            if (student is null)
            {
                throw new ExceptionApi("No existe el estudiante a eliminar", 250);
            }
            else
            {
                _repository.Delete(student);
            }
            return student;
        }

        public Students Insert(Students entity)
        {
            return _repository.Add(entity);

        }

        public Students Update(Students entity)
        {
            return _repository.Update(entity);

        }

    }
}
