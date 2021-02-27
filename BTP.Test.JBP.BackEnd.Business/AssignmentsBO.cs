using System;
using System.Collections.Generic;
using System.Text;
using BTP.Test.JBP.BackEnd.Business.Bases;
using BTP.Test.JBP.BackEnd.DataAccess;
using BTP.Test.JBP.BackEnd.DataAccess.Interfaces;
using BTP.Test.JBP.BackEnd.Entities;

namespace BTP.Test.JBP.BackEnd.Business
{
    public class AssignmentsBO<T>
    {
        private IRepository<Assignments> _repository;
        public AssignmentsBO(IRepository<Assignments> studentRepository)
        {
            this._repository = studentRepository;
        }

        public Assignments Get(int id)
        {
            Assignments resp = _repository.Get(id);
            if (resp is null)
            {
                throw new ExceptionApi("La consulta no regresó datos", 1);
            }
            return resp;
        }

        public List<Assignments> GetAll()
        {
            List<Assignments> resp = _repository.GetAll();
            if (resp is null)
            {
                throw new ExceptionApi("La consulta no regresó datos", 1);
            }
            return resp;
        }

        public Assignments Detete(int id)
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

        public Assignments Insert(Assignments entity)
        {
            return _repository.Add(entity);

        }

        public Assignments Update(Assignments entity)
        {
            return _repository.Update(entity);

        }

    }
}
