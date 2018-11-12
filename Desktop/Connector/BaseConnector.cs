using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Connector
{
    internal abstract class BaseConnector
    {
        protected readonly string WebApiUrl = ConfigurationManager.AppSettings["webApiAddress"];

        protected async Task<T> TryHttpGetAs<T>(HttpClient client, string uri)
        {
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var result = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead);
            if (result.IsSuccessStatusCode)
            {
                return DeserializeAs<T>(await result.Content.ReadAsStringAsync());
            }
            else
            {
                throw new ConnectionFailedException($"Failed to connect to {uri}");
            }
        }

        protected async Task<TResponse> TryHttpPostAs<TContent, TResponse>(HttpClient client, string uri, TContent content)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var byteContent = new StringContent(ToJsonFrom(content));
                try
                {
                    var result = await client.PostAsync(uri, byteContent);
                    if (result.IsSuccessStatusCode)
                    {
                        return DeserializeAs<TResponse>(await result.Content.ReadAsStringAsync());
                    }
                    throw new ConnectionFailedException(uri);
                }
                catch(TaskCanceledException e)
                {
                    throw e;
                }

            }
            catch(Exception e)
            {
                throw e;
            }
        }

        protected string ToJsonFrom<T>(T obj)
        {
            using (var objectStream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(objectStream, obj);
                using (var jsonStream = new MemoryStream(objectStream.GetBuffer()))
                {
                    var serializer = new DataContractJsonSerializer(typeof(T));
                    serializer.WriteObject(jsonStream, obj);
                    var jsonBytes = jsonStream.ToArray();
                    return Encoding.UTF8.GetString(jsonBytes, 0, jsonBytes.Length);
                }
            }
        }

        protected T DeserializeAs<T>(string json)
        {
            using(var stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(stream);
            }
        }
    }
}
