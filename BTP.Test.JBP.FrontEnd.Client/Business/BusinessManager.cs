using BTP.Test.JBP.FrontEnd.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTP.Test.JBP.FrontEnd.Client.Business
{
    public class BusinessManager
    {
        IInformationData _informationData;
        public BusinessManager(IInformationData informationData)
        {
            _informationData = informationData;
        }

        public Dictionary<string, object> Get(int Id) => _informationData.Get(Id);

        public Dictionary<string, object> GetAll() => _informationData.GetAll();

        public Dictionary<string, object> Insert(object data) => _informationData.Insert(data);
        public Dictionary<string, object> Update(object data) => _informationData.Update(data);

        public Dictionary<string, object> Delete(int Id) => _informationData.Delete(Id);



    }
}
