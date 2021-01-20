using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Innoloft.Demo.Core.Entity.Common;
using Innoloft.Demo.Data;
using Innoloft.Demo.Service.Seed;
using Microsoft.AspNetCore.Mvc;

namespace Innoloft.Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private ISeedService _seedService;

        public SeedController(InnoloftDBContext context)
        {
            _seedService = new SeedService(context);
        }

        [HttpGet]
        [Route("/Initiate")]
        public IActionResult RunSeed()
        {
            _seedService.Install();
            return Ok(true);
        }
    }
}
