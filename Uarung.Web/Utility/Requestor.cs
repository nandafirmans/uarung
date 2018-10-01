using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Uarung.Web.Utility
{
    public class Requestor
    {
        private readonly HttpClient _client;

        public Requestor()
        {
            _client = new HttpClient();
        }

        public string Post(string url, object payload)
        {
            return Exec(HttpType.Post, url, payload).Result;
        }

        public T Post<T>(string url, object payload) where T : class
        {
            return JsonConvert.DeserializeObject<T>(Post(url, payload));
        }

        public string Put(string url, object payload)
        {
            return Exec(HttpType.Put, url, payload).Result;
        }

        public T Put<T>(string url, object payload) where T : class
        {
            return JsonConvert.DeserializeObject<T>(Put(url, payload));
        }

        public string Get(string url, object payload = null)
        {
            return GetExec(HttpType.Get, url, payload);
        }

        public T Get<T>(string url, object payload) where T : class
        {
            return JsonConvert.DeserializeObject<T>(Get(url, payload));
        }

        public string Delete(string url, object payload = null)
        {
            return GetExec(HttpType.Delete, url, payload);
        }

        public T Delete<T>(string url, object payload) where T : class
        {
            return JsonConvert.DeserializeObject<T>(Delete(url, payload));
        }

        private string GetExec(HttpType type, string url, object payload)
        {
            if (payload != null)
                url += ToQueryString(payload);

            return Exec(type, url).Result;
        }

        private async Task<string> Exec(HttpType type, string url, object payload = null)
        {
            HttpResponseMessage request;
            var content = payload != null
                ? new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json")
                : null;

            switch (type)
            {
                case HttpType.Post:
                    request = await _client.PostAsync(url, content);
                    break;

                case HttpType.Get:
                    request = await _client.GetAsync(url);
                    break;

                case HttpType.Put:
                    request = await _client.PutAsync(url, content);
                    break;

                case HttpType.Delete:
                    request = await _client.DeleteAsync(url);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            using (var reader = new StreamReader(await request.Content.ReadAsStreamAsync()))
            {
                return reader.ReadToEnd();
            }
        }

        private static string ToQueryString(object payload)
        {
            if (payload == null)
                return string.Empty;

            var strPayload = payload.GetType().GetProperties()
                .Where(p => p.GetValue(payload, null) != null)
                .Select(p => $"{Uri.EscapeDataString(p.Name)}={Uri.EscapeDataString(p.GetValue(payload).ToString())}");
            
            return $"?{string.Join("&", strPayload)}";
        }

        private enum HttpType
        {
            Post,
            Get,
            Put,
            Delete
        }
    }
}