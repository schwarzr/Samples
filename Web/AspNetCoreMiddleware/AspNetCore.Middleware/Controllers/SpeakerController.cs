using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ef.DeepDive.Database.Model;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Middleware.Controllers
{
    [Route("api/[controller]")]
    public class SpeakerController
    {
        [HttpGet]
        public async Task<IEnumerable<Speaker>> GetAllSpeakersAsync()
        {
            return null;
        }

        [HttpGet("status")]
        public async Task<string> GetDbStatus()
        {
            return new Random().Next(0, 100) % 2 == 0 ? $"online {DateTime.Now}" : $"offline {DateTime.Now}";
        }
    }
}
