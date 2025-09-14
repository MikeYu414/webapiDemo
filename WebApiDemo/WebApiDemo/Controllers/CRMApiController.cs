using Ave.WebJob.Common;
using Batchjob.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Xrm.Sdk;
using Newtonsoft.Json;
using NuGet.Configuration;
using SharePoint.Models;
using System.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRMApiController : ControllerBase
    {
        private readonly IConfiguration _config;

        public CRMApiController(IConfiguration config)
        {
            _config = config;
        }

        // GET: api/<CRMApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var certSetting = _config.GetSmartValue<SPCertificateSetting>("SharePointCertificate");
            var spSetting = _config.GetSmartValue<SharePointSettingsModel>("SharePointConnection");

            var va = _config.GetSection("JobSettings");
            var se = _config.GetValue<string>("JobSettings");
            var jobSetting = _config.GetSection("JobSettings").Get<JobSettingModel>();
            return new string[] {JsonConvert.SerializeObject(certSetting), JsonConvert.SerializeObject(spSetting), JsonConvert.SerializeObject(va), 
                JsonConvert.SerializeObject(jobSetting),
se };
        }

        //// POST api/<CRMApiController>
        //[HttpPost]
        //public void Post()
        //{
        //    var client = new D365ConnectionService(_config).GetOrganizationService();
        //    Entity entity = new Entity("new_webjob");
        //    entity["new_name"] = DateTime.Now.ToString("s");
        //    client.Create(entity);
        //}
    }
}
