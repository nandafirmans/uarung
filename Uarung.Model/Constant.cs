
namespace Uarung.Model
{
    public static class Constant
    {
        public static class SessionKey
        {
            public const string RedisNamespace = "session";
            public const string SessionId = "sessionId";
            public const string UserId = "userId";
        }

        public static class Status
        {
            public const string TypeSuccess = "Success";
            public const string TypeError = "Error";
        }

        public static class ConfigKey
        {
            public const string ApiHost = "ApiHost";
            public const string ApiUrlLogin = "ApiUrlLogin";
            public const string ApiUrlProduct = "ApiUrlProduct";
            public const string ApiUrlProductCategory = "ApiUrlProductCategory";
            public const string ApiUrlFileUpload = "ApiUrlFileUpload";
            public const string SessionIdLifeTime = "SessionIdLifeTime";
        }

        public static class ViewDataKey
        {
            public const string ErrorMessage = "ErrorMessage";
            public const string Title = "Title";
        }
    }
}
