
namespace Uarung.Model
{
    public static class Constant
    {
        public static class Session
        {
            public const string RedisNamespace = "session";
        }

        public static class Status
        {
            public const string TypeSuccess = "Success";
            public const string TypeError = "Error";
        }

        public  static class RequestKey
        {
            public const string SessionId = "sessionId";
            public const string UnAuth = "unAuth";
        }

        public static class ConfigKey
        {
            public const string ApiHost = "ApiHost";
            public const string ApiLogin = "ApiLogin";
        }

        public static class ViewDataKey
        {
            public const string ErrorMessage = "ErrorMessage";
        }
    }
}
