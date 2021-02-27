using BTP.Test.JBP.FrontEnd.Client.Bases;
using BTP.Test.JBP.FrontEnd.Client.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BTP.Test.JBP.FrontEnd.Client
{
    public class Services: ServiceBase
    {
        public Services()
        {
            LoginJWT user = new LoginJWT();
            user.Username = "Jorge";
            user.Password = "PASSWORDJWT";
            LoginJWT(user, "apijwt");
        }

        public ResponseData Get(int Id, string Metodo)
        {
            var Resp =serviceGet(Id, Metodo);
            validateResponse(Resp.StatusCode);
            return  DeserializeData(Resp.Content);
        }
        public ResponseData GetAll( string Metodo)
        {
            var Resp = serviceGetAll( Metodo);
            validateResponse(Resp.StatusCode);
            return DeserializeData(Resp.Content);
        }

        public ResponseData Insert<T>(T data, string Metodo)
        {
            var Resp = servicePost(data, Metodo);
            validateResponse(Resp.StatusCode);
            return DeserializeData(Resp.Content);
        }

        public ResponseData Update<T>(T data, string Metodo)
        {
            var Resp = servicePut(data, Metodo);
            validateResponse(Resp.StatusCode);
            return DeserializeData(Resp.Content);
        }

        public ResponseData Delete(int Id, string Metodo)
        {
            var Resp = serviceDelete(Id, Metodo);
            validateResponse(Resp.StatusCode);
            return DeserializeData(Resp.Content);
        }

        public void LoginJWT(object user, string Metodo)
        {
            var Resp = servicePostJWT(user, Metodo);
            validateResponse(Resp.StatusCode);
            ResponseJWTService response = JsonConvert.DeserializeObject<ResponseJWTService>(Resp.Content);
            this.Token = response.token;

        }

        private ResponseData DeserializeData(string content)
        {
            return JsonConvert.DeserializeObject<ResponseData>(content);
        }

        private void validateResponse(HttpStatusCode statusCode)
        {
            if (!(statusCode == HttpStatusCode.OK))
            {
                throw new Exception($"Error de comunicación al servicio statusCode {statusCode}");
            }
        }
    }
}
