﻿using System;

namespace ConstructionDiary
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RestPutAttribute : RestOperationAttribute
    {
        public RestPutAttribute(string template)
            : base(template)
        {
        }

        public RestPutAttribute() : base(null)
        {
        }

        public override string HttpMethod() => "PUT";
    }
}