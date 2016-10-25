using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using EnterpriseIntegration.Ediweb.Filters;
using EnterpriseIntegration.Ediweb.Models;
using Swashbuckle.Swagger.Annotations;

namespace EnterpriseIntegration.Ediweb.Controllers
{
    [PassthroughBasicAuthentication]
    [Authorize]
    public class EdiController : ApiController
    {
        [HttpGet]
        [SwaggerOperation("Get All Interchanges")]
        public async Task<IEnumerable<InterchangeMessage>> GetAsync()
        {
            CheckAuthentication();

            var messages = await GetMessages();

            return messages.Select(p => new InterchangeMessage { InterchangeId = p.InterchangeId, RecipientId = p.RecipientId, SenderId = p.SenderId, SendTime = p.SendTime });
        }

        [HttpGet]
        [SwaggerOperation("Get Interchange")]
        public async Task<InterchangeMessagePayload> GetAsync(string id)
        {
            CheckAuthentication();

            var messages = await GetMessages();

            return messages.FirstOrDefault(p => p.InterchangeId == id);
        }

        private static async Task<IEnumerable<InterchangeMessagePayload>> GetMessages()
        {
            var result = new List<InterchangeMessagePayload>();

            result.Add(new InterchangeMessagePayload { InterchangeId = "160713875197", SendTime = new System.DateTime(2016, 7, 14, 16, 30, 00), RecipientId = "1000000000002", SenderId = "1000000000001", Payload = await GetPayload("160713875197") });
            result.Add(new InterchangeMessagePayload { InterchangeId = "160713882088", SendTime = new System.DateTime(2016, 7, 13, 15, 21, 00), RecipientId = "1000000000002", SenderId = "1000000000001", Payload = await GetPayload("160713882088") });
            result.Add(new InterchangeMessagePayload { InterchangeId = "160801078907", SendTime = new System.DateTime(2016, 8, 1, 9, 12, 00), RecipientId = "1000000000002", SenderId = "1000000000001", Payload = await GetPayload("160801078907") });
            result.Add(new InterchangeMessagePayload { InterchangeId = "160811349110", SendTime = new System.DateTime(2016, 8, 11, 8, 30, 00), RecipientId = "1000000000002", SenderId = "1000000000001", Payload = await GetPayload("160811349110") });

            return result;
        }

        private static async Task<string> GetPayload(string file)
        {
            using (var stream = typeof(EdiController).Assembly.GetManifestResourceStream($"EnterpriseIntegration.Ediweb.Edi.{file}.edi"))
            {
                using (var sr = new StreamReader(stream))
                {
                    return await sr.ReadToEndAsync();
                }
            }
        }

        private void CheckAuthentication()
        {
            var userName = ((ClaimsIdentity)User.Identity).Claims.First(p => p.Type == ClaimTypes.Name).Value;
            var password = ((ClaimsIdentity)User.Identity).Claims.First(p => p.Type == ClaimTypes.UserData).Value;

            if (userName != "test" || password != "test")
            {
                var error = this.Request.CreateErrorResponse(HttpStatusCode.Forbidden, "Invalid username or password");
                throw new HttpResponseException(error);
            }
        }
    }
}