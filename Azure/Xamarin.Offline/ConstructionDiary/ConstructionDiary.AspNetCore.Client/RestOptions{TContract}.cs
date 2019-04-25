using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ConstructionDiary.AspNetCore.Client
{
    public class RestOptions<TContract> : RestOptions
    {
        public RestOptions(string baseUrl)
            : base(baseUrl)
        {
        }
    }
}