using System;
using System.Collections.Generic;
using System.Text;

namespace BTP.Test.JBP.BackEnd.Entities.DTO
{
    public class ResponseData
    {
        public string IdRequest { get; set; }
        public DateTime DateTimeResponse { get; set; }
        public Dictionary<string, object> Response { get; set; }
        public Dictionary<string, string> Error { get; set; }

    }
}
