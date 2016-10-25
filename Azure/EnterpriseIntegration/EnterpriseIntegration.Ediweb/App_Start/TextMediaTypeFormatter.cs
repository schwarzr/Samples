using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class TextMediaTypeFormatter : MediaTypeFormatter
{
    public TextMediaTypeFormatter()
    {
        SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
    }

    public override async Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
    {
        using (var memoryStream = new MemoryStream())
        {
            await readStream.CopyToAsync(memoryStream);
            var s = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
            return s;
        }
    }

    public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, System.Net.TransportContext transportContext, System.Threading.CancellationToken cancellationToken)
    {
        var buff = System.Text.Encoding.UTF8.GetBytes(value.ToString());
        return writeStream.WriteAsync(buff, 0, buff.Length, cancellationToken);
    }

    public override bool CanReadType(Type type)
    {
        return type == typeof(string);
    }

    public override bool CanWriteType(Type type)
    {
        return type == typeof(string);
    }
}