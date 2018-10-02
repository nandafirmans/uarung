
namespace Uarung.Model
{
    public static class Constant
    {
        public static class SessionKey
        {
            public const string RedisNamespace = "session";
            public const string Id = "sessionId";
        }

        public static class Status
        {
            public const string TypeSuccess = "Success";
            public const string TypeError = "Error";
        }

        public static class ConfigKey
        {
            public const string ApiHost = "ApiHost";
            public const string ApiLogin = "ApiLogin";
            public const string ApiProduct = "ApiProduct";
            public const string SessionIdLifeTime = "SessionIdLifeTime";
        }

        public static class ViewDataKey
        {
            public const string ErrorMessage = "ErrorMessage";
        }
    }
}
