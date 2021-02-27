using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BTP.Test.JBP.FrontEnd.Client.Bases
{
    public class ServiceBase
    {
        RestClient _client;
        IRestRequest _request;

        IConfiguration Configuration;

        public string Token { get; set; }
        public ServiceBase()
        {
            string path = Directory.GetCurrentDirectory();
            path = path.Replace(@"\bin\Debug\netcoreapp3.1","");
            Configuration = new ConfigurationBuilder()
            .AddJsonFile($"{path}/appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
        }


        public IRestResponse servicePost(object data, string method)
        {
            _client = new RestClient(Configuration["BaseHostWebApi"]);
            _request = new RestRequest(method, Method.POST);
            _request.AddHeader("Authorization", $"Bearer {Token}");
            _request.AddJsonBody(data);

            IRestResponse resp = _client.Execute(_request);
            return resp;
        }

        public IRestResponse servicePostJWT(object data, string method)
        {
            _client = new RestClient(Configuration["BaseHostJWT"]);
            _request = new RestRequest(method, Method.POST);
            _request.AddJsonBody(data);

            IRestResponse resp = _client.Execute(_request);
            return resp;
        }

        public IRestResponse servicePut(object obj, string method)
        {
            _client = new RestClient(Configuration["BaseHostWebApi"]);
            _request = new RestRequest(method, Method.PUT);
            _request.AddJsonBody(obj);
            _request.AddHeader("Authorization", $"Bearer {Token}");
            IRestResponse resp = _client.Execute(_request);
            return resp;
        }

        public IRestResponse serviceGet(int Id, string method)
        {
            _client = new RestClient(Configuration["BaseHostWebApi"]);
            _request = new RestRequest(method, Method.GET);
            _request.AddParameter("id", Id);
            _request.AddHeader("Authorization", $"Bearer {Token}");
            IRestResponse resp = _client.Execute(_request);

            return resp;
        }
        public IRestResponse serviceGetAll(string method)
        {
            _client = new RestClient(Configuration["BaseHostWebApi"]);
            _request = new RestRequest(method, Method.GET);
            _request.AddHeader("Authorization", $"Bearer {Token}");
            IRestResponse resp = _client.Execute(_request);

            return resp;
        }

        public IRestResponse serviceDelete(int Id, string method)
        {
            _client = new RestClient(Configuration["BaseHostWebApi"]);
            _request = new RestRequest(method, Method.DELETE);
            _request.AddHeader("Authorization", $"Bearer {Token}");
            _request.AddParameter("id", Id);
            IRestResponse resp = _client.Execute(_request);

            return resp;
        }
    }
}
