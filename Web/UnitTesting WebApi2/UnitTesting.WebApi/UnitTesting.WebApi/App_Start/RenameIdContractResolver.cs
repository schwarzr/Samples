using Newtonsoft.Json.Serialization;

namespace UnitTesting.WebApi
{
    public class RenameIdContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            if (propertyName == "Id")
            {
                return "Key";
            }

            return base.ResolvePropertyName(propertyName);
        }
    }
}