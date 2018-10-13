using System;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Uarung.Web.Utility
{
    public static class SessionExtension
    {
        public static string GetValue(this ISession session, string key)
        {
            var sessionValueBytes = session.Get(key);

            return sessionValueBytes != null
                ? Encoding.Default.GetString(sessionValueBytes)
                : string.Empty;
        }

        public static T GetValue<T>(this ISession session, string key) where T : class
        {
            try
            {
                var jsonValue = GetValue(session, key);

                return JsonConvert.DeserializeObject<T>(jsonValue);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return default(T);
            }
        }

        public static void SetValue(this ISession session, string key, string value)
        {
            session.Set(key, Encoding.Default.GetBytes(value));
        }
    }
} 