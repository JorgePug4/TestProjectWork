using BTP.Test.JBP.FrontEnd.Client.Entities;
using BTP.Test.JBP.FrontEnd.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTP.Test.JBP.FrontEnd.Client.Business
{
    public class StudentsBO : IInformationData
    {
        public Dictionary<string, object> Get(int Id)
        {
            Services services = new Services();
            ResponseData resp = services.Get(Id, @"Student/Get");
            ValidateError(resp.Error);

            return resp.Response;
        }
        public Dictionary<string, object> GetAll()
        {
            Services services = new Services();
            ResponseData resp = services.GetAll(@"Student/GetAll");
            ValidateError(resp.Error);

            return resp.Response;
        }

        public Dictionary<string, object> Insert(object data)
        {
            Services services = new Services();
            ResponseData resp = services.Insert(data, "Student/Insert");
            ValidateError(resp.Error);
            return resp.Response;
        }

        public Dictionary<string, object> Update(object data)
        {
            Services services = new Services();
            ResponseData resp = services.Update(data, "Student/Update");
            ValidateError(resp.Error);
            return resp.Response;
        }

        public Dictionary<string, object> Delete(int Id)
        {
            Services services = new Services();
            ResponseData resp = services.Delete(Id, "Student/Delete");
            ValidateError(resp.Error);

            return resp.Response;
        }

        private void ValidateError(Dictionary<string, string> error)
        {
            if (!(error["mesaage"] == ""))
                throw new Exception(error["mesaage"]);

        }
    }
}
