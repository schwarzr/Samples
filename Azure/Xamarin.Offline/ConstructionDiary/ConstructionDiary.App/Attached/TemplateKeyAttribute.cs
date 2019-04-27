using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionDiary.App.Attached
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TemplateKeyAttribute : Attribute
    {
        public TemplateKeyAttribute(string templateKey)
        {
            TemplateKey = templateKey;
        }

        public string TemplateKey { get; }
    }
}