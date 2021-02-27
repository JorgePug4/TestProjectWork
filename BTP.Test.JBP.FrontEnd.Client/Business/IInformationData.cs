using BTP.Test.JBP.FrontEnd.Client.Entities;
using System.Collections.Generic;

namespace BTP.Test.JBP.FrontEnd.Client.Business
{
    public interface IInformationData
    {
        public Dictionary<string, object> Get(int Id);
        public Dictionary<string, object> GetAll();
        public Dictionary<string, object> Insert(object data);
        public Dictionary<string, object> Update(object data);

        public Dictionary<string, object> Delete(int Id);

    }
}