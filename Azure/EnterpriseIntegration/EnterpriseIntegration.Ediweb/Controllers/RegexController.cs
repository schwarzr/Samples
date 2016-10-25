using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using EnterpriseIntegration.Ediweb.Models;
using Swashbuckle.Swagger.Annotations;

namespace EnterpriseIntegration.Ediweb.Controllers
{
    public class RegexController : ApiController
    {
        [HttpPost()]
        [Route("Match/{group}")]
        [SwaggerOperation("Regex Match By Group")]
        public async Task<MatchResult> PostMatchAync(string group, [FromUri] string pattern, [FromBody] string content)
        {
            return DoMatch(group, pattern, content).FirstOrDefault();
        }

        [HttpPost()]
        [Route("Match")]
        [SwaggerOperation("Regex Match")]
        public async Task<MatchResult> PostMatchAync([FromUri] string pattern, [FromBody] string content)
        {
            return DoMatch(null, pattern, content).FirstOrDefault();
        }

        private IEnumerable<MatchResult> DoMatch(string group, [FromUri] string pattern, [FromBody] string content)
        {
            var regex = new Regex(pattern);

            var matches = regex.Matches(content);

            foreach (Match item in matches)
            {
                if (item.Success)
                {
                    if (group == null)
                    {
                        yield return new MatchResult { GroupName = "default", Value = item.Value };
                    }
                    else
                    {
                        for (int i = 0; i < item.Groups.Count; i++)
                        {
                            var grp = item.Groups[i];
                            if (grp.Success)
                            {
                                var name = regex.GroupNameFromNumber(i);

                                if (name == group || ($"group{name}").Equals(group, StringComparison.OrdinalIgnoreCase))
                                {
                                    yield return new MatchResult { GroupName = name, Value = grp.Value };
                                }
                            }
                        }
                    }
                }
            }
            yield break;
        }
    }
}