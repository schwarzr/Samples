using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionDiary
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class BodyMemberAttribute : Attribute
    {
    }
}