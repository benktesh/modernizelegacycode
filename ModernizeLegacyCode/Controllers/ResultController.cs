using System;
using System.Web.Hosting;
using System.Web.Http;
using ModernizeLegacyCode.Manager;
using ModernizeLegacyCode.Models;

namespace ModernizeLegacyCode.Controllers
{
    public class ResultController : ApiController
    {
        private readonly IManager _manager;

        public ResultController()
        {
            _manager = new Manager.Manager();
        }

        public ResultController(IManager manager )
        {
            _manager = manager;
        }
        
        [HttpPost]
        public string GetResults(RequestData requestData)
        {
            DateTime requestDateTime = DateTime.Now;
            string jsonData = _manager.GetResultList(requestData, requestDateTime);
            return jsonData;
        }

        [HttpGet]
        public string Ping()
        {
            return "OK";
        }
    }
}
