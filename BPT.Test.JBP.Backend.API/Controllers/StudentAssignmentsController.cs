using BTP.Test.JBP.BackEnd.Business;
using BTP.Test.JBP.BackEnd.Business.Bases;
using BTP.Test.JBP.BackEnd.DataAccess;
using BTP.Test.JBP.BackEnd.Entities;
using BTP.Test.JBP.BackEnd.Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace BPT.Test.JBP.Backend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentAssignmentsController : Controller
    {
        Repository<StudentAssignments> _repository;

        public StudentAssignmentsController()
        {
            _repository = new Repository<StudentAssignments>(new DataContext());
        }

        // GET: StudentController
        [Route("[action]")]
        [HttpGet()]
        public ResponseData Get(int id)
        {
            string idRequest = Guid.NewGuid().ToString();
            try
            {
                StudentAssignmentsBO<StudentAssignments> StudentAssignmentsBO = new StudentAssignmentsBO<StudentAssignments>(_repository);
                var resp = StudentAssignmentsBO.Get(id);
                DateTime timeResponse = DateTime.Now;
                return buildResponseOk(idRequest, resp, timeResponse);
            }
            catch (ExceptionApi exc)
            {
                DateTime timeResponse = DateTime.Now;
                return buildResponseError(exc.MessageClient, exc.NoError, timeResponse, idRequest);
            }

        }


        [Route("[action]")]
        [HttpGet()]
        public ResponseData GetAll()
        {
            string idRequest = Guid.NewGuid().ToString();
            try
            {
                StudentAssignmentsBO<StudentAssignments> StudentAssignmentsBO = new StudentAssignmentsBO<StudentAssignments>(_repository);
                var resp = StudentAssignmentsBO.GetAll();
                DateTime timeResponse = DateTime.Now;
                return buildResponseOk(idRequest, resp, timeResponse);
            }
            catch (ExceptionApi exc)
            {
                DateTime timeResponse = DateTime.Now;
                return buildResponseError(exc.MessageClient, exc.NoError, timeResponse, idRequest);
            }
        }

        [Route("[action]")]
        [HttpDelete()]
        public ResponseData Delete(int id)
        {
            string idRequest = Guid.NewGuid().ToString();
            try
            {
                StudentAssignmentsBO<StudentAssignments> StudentAssignmentsBO = new StudentAssignmentsBO<StudentAssignments>(_repository);
                var resp = StudentAssignmentsBO.Detete(id);
                DateTime timeResponse = DateTime.Now;
                return buildResponseOk(idRequest, resp, timeResponse);
            }
            catch (ExceptionApi exc)
            {
                DateTime timeResponse = DateTime.Now;
                return buildResponseError(exc.MessageClient, exc.NoError, timeResponse, idRequest);
            }
        }

        [Route("[action]")]
        [HttpPost()]
        public ResponseData Insert(StudentAssignments entity)
        {
            string idRequest = Guid.NewGuid().ToString();
            try
            {
                StudentAssignmentsBO<StudentAssignments> StudentAssignmentsBO = new StudentAssignmentsBO<StudentAssignments>(_repository);
                var resp = StudentAssignmentsBO.Insert(entity);
                DateTime timeResponse = DateTime.Now;
                return buildResponseOk(idRequest, resp, timeResponse);
            }
            catch (ExceptionApi exc)
            {
                DateTime timeResponse = DateTime.Now;
                return buildResponseError(exc.MessageClient, exc.NoError, timeResponse, idRequest);
            }
        }

        [Route("[action]")]
        [HttpPut()]
        public ResponseData Update(StudentAssignments entity)
        {
            string idRequest = Guid.NewGuid().ToString();
            try
            {
                StudentAssignmentsBO<StudentAssignments> StudentAssignmentsBO = new StudentAssignmentsBO<StudentAssignments>(_repository);
                var resp = StudentAssignmentsBO.Update(entity);
                DateTime timeResponse = DateTime.Now;
                return buildResponseOk(idRequest, resp, timeResponse);
            }
            catch (ExceptionApi exc)
            {
                DateTime timeResponse = DateTime.Now;
                return buildResponseError(exc.MessageClient, exc.NoError, timeResponse, idRequest);
            }
        }

        #region BuidResponse
        private ResponseData buildResponseError(string messageClient, int noError, DateTime timeResponse, string idRequest)
        {
            Dictionary<string, string> _errorMessage = new Dictionary<string, string>();
            Dictionary<string, object> _data = new Dictionary<string, object>();

            _errorMessage.Add("Mesaage", messageClient);
            _errorMessage.Add("NoError", noError.ToString());

            _data.Add("data", null);

            return new ResponseData()
            {
                Error = _errorMessage,
                Response = _data,
                DateTimeResponse = timeResponse,
                IdRequest = idRequest
            };
        }

        private ResponseData buildResponseOk(string idRequest, object resp, DateTime timeResponse)
        {
            Dictionary<string, string> _errorMessage = new Dictionary<string, string>();
            Dictionary<string, object> _data = new Dictionary<string, object>();

            _errorMessage.Add("mesaage", "");
            _data.Add("data", resp);

            return new ResponseData()
            {
                Error = _errorMessage,
                Response = _data,
                DateTimeResponse = timeResponse,
                IdRequest = idRequest
            };
        }
        #endregion
    }
}