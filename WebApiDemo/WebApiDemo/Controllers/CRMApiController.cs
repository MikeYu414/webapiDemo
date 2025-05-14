using Ave.WebJob.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Xrm.Sdk;

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
            return new string[] { "value1", "value2" };
        }

        // POST api/<CRMApiController>
        [HttpPost]
        public void Post()
        {
            var client = new D365ConnectionService(_config).GetOrganizationService();
            Entity entity = new Entity("new_webjob");
            entity["new_name"] = DateTime.Now.ToString("s");
            client.Create(entity);
        }
    }
}
