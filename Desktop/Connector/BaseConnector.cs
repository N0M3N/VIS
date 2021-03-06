﻿using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Connector
{
    internal abstract class BaseConnector
    {
        protected readonly string WebApiUrl = ConfigurationManager.AppSettings["webApiAddress"];

        protected async Task<T> TryHttpGetAs<T>(string uri)
        {
            using (var client = new HttpClient())
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
        }

        protected async Task<TResponse> TryHttpPostAs<TContent, TResponse>(string uri, TContent content)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var jsonContent = new StringContent(ToJsonFrom(content), Encoding.UTF8, "application/json");

                var result = await client.PostAsync(uri, jsonContent);
                if (result.IsSuccessStatusCode)
                {
                    return DeserializeAs<TResponse>(await result.Content.ReadAsStringAsync());
                }
                throw new ConnectionFailedException($"{uri} : {result.StatusCode}");
            }

        }

        protected async Task<TResponse> TryHttpPutAs<TContent, TResponse>(string uri, TContent content)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var jsonContent = new StringContent(ToJsonFrom(content), Encoding.UTF8, "application/json");

                var result = await client.PutAsync(uri, jsonContent);
                if (result.IsSuccessStatusCode)
                {
                    return DeserializeAs<TResponse>(await result.Content.ReadAsStringAsync());
                }
                throw new ConnectionFailedException($"{uri} : {result.StatusCode} - {result.RequestMessage}");
            }
        }

        protected string ToJsonFrom<T>(T obj)
        {
            using (var stream = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                serializer.WriteObject(stream, obj);
                var reader = new StreamReader(stream);
                stream.Position = 0;
                return reader.ReadToEnd();
            }
        }

        protected T DeserializeAs<T>(string json)
        {
            using (var stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(stream);
            }
        }
    }
}
