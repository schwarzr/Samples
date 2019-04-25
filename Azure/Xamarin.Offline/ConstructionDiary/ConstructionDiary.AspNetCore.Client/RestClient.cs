using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ConstructionDiary.AspNetCore.Client
{
    public class RestClient<TContract>
    {
        private readonly RestOptions<TContract> _options;

        public RestClient(RestOptions<TContract> options)
        {
            this._options = options;
        }

        public Task CallAsync(Expression<Func<TContract, Task>> opeationSelector)
        {
            return Task.CompletedTask;
        }

        public async Task<TResult> CallAsync<TResult>(Expression<Func<TContract, Task<TResult>>> operationSelector)
        {
            var methodCall = operationSelector.Body as MethodCallExpression;

            var param = operationSelector.Parameters.First();

            if (param != methodCall?.Object)
            {
                throw new NotSupportedException();
            }

            var attribute = methodCall.Method.GetCustomAttributes().OfType<RestOperationAttribute>().FirstOrDefault();

            if (attribute == null)
            {
                throw new NotSupportedException();
            }

            var client = _options.GetHttpClient();

            string requestUrl = null;

            if (attribute.Template != null && new Uri(attribute.Template).IsAbsoluteUri)
            {
                requestUrl = attribute.Template;
            }
            else
            {
                requestUrl = $"{typeof(TContract).GetCustomAttribute<RestRouteAttribute>().RoutePrefix}/{attribute.Template}";
            }

            var httpMethod = attribute.HttpMethod();

            for (int i = 0; i > methodCall.Arguments.Count; i++)
            {
                var data = Expression.Lambda<Func<object>>(methodCall.Arguments[0]).Compile()();
                var stringValue = data.ToString();

                requestUrl = requestUrl.Replace($"{{{methodCall.Method.GetParameters()[i].Name}}}", stringValue);
            }

            var request = new HttpRequestMessage(new HttpMethod(httpMethod), requestUrl);
            request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var serializer = JsonSerializer.Create(new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var streamReader = new StreamReader(stream))
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    var result = serializer.Deserialize<TResult>(jsonReader);

                    return result;
                }
            }

            throw new InvalidOperationException("Unexpected http status code.");
        }
    }
}