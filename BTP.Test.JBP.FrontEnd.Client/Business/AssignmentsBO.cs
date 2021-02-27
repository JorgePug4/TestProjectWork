using BTP.Test.JBP.FrontEnd.Client.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTP.Test.JBP.FrontEnd.Client.Business
{
    public class AssignmentsBO : IInformationData
    {
        public Dictionary<string,object> Get(int Id)
        {
            Services services = new Services();
            ResponseData resp = services.Get(Id, @"Assignments/Get");
            ValidateError(resp.Error);

            return resp.Response;
        }
        public Dictionary<string, object> GetAll()
        {
            Services services = new Services();
            ResponseData resp = services.GetAll(@"Assignments/GetAll");
            ValidateError(resp.Error);

            return resp.Response;
        }

        public Dictionary<string, object> Insert(object data)
        {
            Services services = new Services();
            ResponseData resp = services.Insert(data, "Assignments/Insert");
            ValidateError(resp.Error);
            return resp.Response;
        }

        public Dictionary<string, object> Update(object data)
        {
            Services services = new Services();
            ResponseData resp = services.Update(data, "Assignments/Update");
            ValidateError(resp.Error);
            return resp.Response;
        }

        public Dictionary<string, object> Delete(int Id)
        {
            Services services = new Services();
            ResponseData resp = services.Delete(Id, "Assignments/Delete");
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
