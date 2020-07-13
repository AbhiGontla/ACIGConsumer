using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ACIGConsumer.Areas.Medical.Api.Policy
{
    [Route("api")]
    [ApiController]
    public class PolicyApiController : ControllerBase
    {
        [HttpGet]
        [Route("Get")]
        public List<string> Get()
        {
            return new List<string> { "Hello", "World" };
        }

        [HttpGet]
        [Route("values/{valueName}")]
        public string Get(string valueName)
        {
            return valueName;
        }
    }
}
