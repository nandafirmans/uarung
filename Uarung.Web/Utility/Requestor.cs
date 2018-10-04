using System;
using System.Collections.Generic;
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
        private readonly Dictionary<string, string> _httpHeaders;

        public Requestor()
        {
            _client = new HttpClient();
        }

        private string GetExec(HttpType type, string url, object payload)
        {
            if (payload != null)
                url += ToQueryString(payload);

            return Exec(type, url).Result;
        }

        private static async Task<string> ReadResponse(HttpResponseMessage response)
        {
            using (var reader = new StreamReader(await response.Content.ReadAsStreamAsync()))
            {
                return reader.ReadToEnd();
            }
        }

        private void IncludeHeader()
        {
            if (_httpHeaders == null) return;

            foreach (var header in _httpHeaders)
                _client.DefaultRequestHeaders.Add(header.Key, header.Value);
        }

        private async Task<string> Exec(HttpType type, string url, object payload = null)
        {
            HttpResponseMessage response;
            
            var content = payload != null
                ? new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json")
                : null;

            IncludeHeader();

            switch (type)
            {
                case HttpType.Post:
                    response = await _client.PostAsync(url, content);
                    break;

                case HttpType.Get:
                    response = await _client.GetAsync(url);
                    break;

                case HttpType.Put:
                    response = await _client.PutAsync(url, content);
                    break;

                case HttpType.Delete:
                    response = await _client.DeleteAsync(url);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return await ReadResponse(response);
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

        public Requestor(Dictionary<string, string> httpHeaders) : this()
        {
            _httpHeaders = httpHeaders;
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

        public T Get<T>(string url, object payload = null) where T : class
        {
            return JsonConvert.DeserializeObject<T>(Get(url, payload));
        }

        public string Delete(string url, object payload = null)
        {
            return GetExec(HttpType.Delete, url, payload);
        }

        public T Delete<T>(string url, object payload = null) where T : class
        {
            return JsonConvert.DeserializeObject<T>(Delete(url, payload));
        }

        public async Task<string> PostContent(string url, MultipartFormDataContent content)
        {
            IncludeHeader();

            var response = await _client.PostAsync(url, content);

            return await ReadResponse(response);
        }

        public T PostContent<T>(string url, MultipartFormDataContent content) where T : class
        {
            var jsonReponse = PostContent(url, content).Result;

            return JsonConvert.DeserializeObject<T>(jsonReponse);
        }
    }
}