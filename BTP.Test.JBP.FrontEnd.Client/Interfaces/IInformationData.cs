using System;
using System.Collections.Generic;
using System.Text;

namespace BTP.Test.JBP.FrontEnd.Client.Interfaces
{
    public interface IInformationData<T>
    {
        public void Get(int Id);

        public void GetAll();

        public void Insert(T Entity);

        public void Delete(int Id);
        public void Update(T Entity);


    }
}
