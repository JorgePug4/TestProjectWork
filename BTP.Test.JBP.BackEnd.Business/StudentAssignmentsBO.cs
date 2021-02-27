using BTP.Test.JBP.BackEnd.Business.Bases;
using BTP.Test.JBP.BackEnd.DataAccess.Interfaces;
using BTP.Test.JBP.BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTP.Test.JBP.BackEnd.Business
{
    public class StudentAssignmentsBO<T>
    {
        private IRepository<StudentAssignments> _repository;
        public StudentAssignmentsBO(IRepository<StudentAssignments> studentRepository)
        {
            this._repository = studentRepository;
        }

        public StudentAssignments Get(int id)
        {
            StudentAssignments resp = _repository.Get(id);
            if (resp is null)
            {
                throw new ExceptionApi("La consulta no regresó datos", 1);
            }
            return resp;
        }

        public List<StudentAssignments> GetAll()
        {
            List<StudentAssignments> resp = _repository.GetAll();
            if (resp is null)
            {
                throw new ExceptionApi("La consulta no regresó datos", 1);
            }
            return resp;
        }

        public StudentAssignments Detete(int id)
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

        public StudentAssignments Insert(StudentAssignments entity)
        {
            return _repository.Add(entity);

        }

        public StudentAssignments Update(StudentAssignments entity)
        {
            return _repository.Update(entity);

        }

    }
}