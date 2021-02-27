using BTP.Test.JBP.BackEnd.Business;
using BTP.Test.JBP.BackEnd.Business.Bases;
using BTP.Test.JBP.BackEnd.DataAccess;
using BTP.Test.JBP.BackEnd.Entities;
using BTP.Test.JBP.BackEnd.Entities.DTO;
using Microsoft.AspNetCore.Authorization;
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

    public class AssignmentsController : Controller
    {
        Repository<Assignments> _repository;

        public AssignmentsController()
        {
            _repository = new Repository<Assignments>(new DataContext());
        }

        // GET: StudentController
        [Route("[action]")]
        [HttpGet()]
        [Authorize]
        public ResponseData Get(int id)
        {
            string idRequest = Guid.NewGuid().ToString();
            try
            {
                AssignmentsBO<Assignments> AssignmentsBO = new AssignmentsBO<Assignments>(_repository);
                var resp = AssignmentsBO.Get(id);
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
        [Authorize]
        public ResponseData GetAll()
        {
            string idRequest = Guid.NewGuid().ToString();
            try
            {
                AssignmentsBO<Assignments> AssignmentsBO = new AssignmentsBO<Assignments>(_repository);
                var resp = AssignmentsBO.GetAll();
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
        [Authorize]
        public ResponseData Delete(int id)
        {
            string idRequest = Guid.NewGuid().ToString();
            try
            {
                AssignmentsBO<Assignments> AssignmentsBO = new AssignmentsBO<Assignments>(_repository);
                var resp = AssignmentsBO.Detete(id);
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
        [Authorize]
        public ResponseData Insert(Assignments entity)
        {
            string idRequest = Guid.NewGuid().ToString();
            try
            {
                AssignmentsBO<Assignments> AssignmentsBO = new AssignmentsBO<Assignments>(_repository);
                var resp = AssignmentsBO.Insert(entity);
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
        [Authorize]
        public ResponseData Update(Assignments entity)
        {
            string idRequest = Guid.NewGuid().ToString();
            try
            {
                AssignmentsBO<Assignments> AssignmentsBO = new AssignmentsBO<Assignments>(_repository);
                var resp = AssignmentsBO.Update(entity);
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
