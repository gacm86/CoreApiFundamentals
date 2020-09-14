using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCodeCamp.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;

        public OperationsController(Microsoft.Extensions.Configuration.IConfiguration config)
        {
            _config = config;
        }

        [HttpOptions("reloadconfig")]
        public ActionResult<bool> ReloadConfig()
        {
            try
            {
                var root = (IConfigurationRoot)_config;
                root.Reload();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
