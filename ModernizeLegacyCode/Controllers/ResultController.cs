using System;
using System.Web.Http;
using ModernizeLegacyCode.Models;

namespace ModernizeLegacyCode.Controllers
{
    public class ResultController : ApiController
    {
        
        [HttpPost]
        public string GetResults(RequestData requestData)
        {
            DateTime requestDateTime = DateTime.Now;
            var manager = new Manager.Manager(); //dependency in manager
            string jsonData = manager.GetResultList(requestData, requestDateTime);
            return jsonData;
        }

        [HttpGet]
        public string Ping()
        {
            return "OK";
        }
    }
}
