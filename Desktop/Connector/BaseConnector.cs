using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace Desktop.Connector
{
    internal abstract class BaseConnector
    {
        protected readonly string WebApiUrl = ConfigurationManager.AppSettings["webApiAddress"];

        protected async Task<T> TryHttpRequestAs<T>(HttpClient client, string uri)
        {
            var result = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead);
            if (result.IsSuccessStatusCode)
            {
                return DeserializeAs<T>(await result.Content.ReadAsByteArrayAsync());
            }
            else
            {
                throw new ConnectionFailedException($"Failed to connect to {uri}");
            }
        }

        protected T DeserializeAs<T>(byte[] obj)
        {
            using (var stream = new MemoryStream(obj))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                return (T) serializer.ReadObject(stream);
            }
        }
    }
}
