using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppGateway.Api.Controllers
{
    [Route("/Hello")]
    [Authorize(Policy = "default")]
    public class HelloController
    {
        [HttpGet]
        public Task<string> HelloAsync()
        {
            return Task.FromResult("World !!!");
        }
    }
}
