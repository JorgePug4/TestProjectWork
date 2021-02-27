using BTP.Test.JBP.BackEnd.Business;
using BTP.Test.JBP.BackEnd.Business.Bases;
using BTP.Test.JBP.BackEnd.DataAccess;
using BTP.Test.JBP.BackEnd.DataAccess.Interfaces;
using BTP.Test.JBP.BackEnd.Entities;
using BTP.Test.JBP.BackEnd.Entities.DTO;
using BTP.Test.JBP.BackEnd.Entities.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPT.Test.JBP.Backend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {

        Repository<Students> _repository;

        public StudentController()
        {
            _repository = new Repository<Students>(new DataContext());
        }

        // GET: StudentController
        [Route("[action]")]
        [HttpGet()]
        public ResponseData Get(int id)
        {
            string idRequest = Guid.NewGuid().ToString();
            try
            {
                StudentBO<Students> studentBO = new StudentBO<Students>(_repository); 
                var resp = studentBO.Get(id);
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
                StudentBO<Students> studentBO = new StudentBO<Students>(_repository);
                var resp = studentBO.GetAll();
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
        public ResponseData DeleteStudent(int id)
        {
            string idRequest = Guid.NewGuid().ToString();
            try
            {
                StudentBO<Students> studentBO = new StudentBO<Students>(_repository);
                var resp = studentBO.Detete(id);
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
        public ResponseData InsertStudent(Students entity)
        {
            string idRequest = Guid.NewGuid().ToString();
            try
            {
                StudentBO<Students> studentBO = new StudentBO<Students>(_repository);
                var resp = studentBO.Insert(entity);
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
        public ResponseData UpdateStudent(Students entity)
        {
            string idRequest = Guid.NewGuid().ToString();
            try
            {
                StudentBO<Students> studentBO = new StudentBO<Students>(_repository);
                var resp = studentBO.Update(entity);
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
