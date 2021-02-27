using System;
using System.Collections.Generic;
using System.Text;

namespace BTP.Test.JBP.BackEnd.Business.Bases
{
    public class ExceptionApi : Exception
    {
        public int NoError { get; set; }
        public string MessageClient { get; set; }
        public ExceptionApi(string  messageClient, int noError)
        {
            this.MessageClient = messageClient;
            this.NoError = noError;
        }
    }


}

