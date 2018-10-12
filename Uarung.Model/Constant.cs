
namespace Uarung.Model
{
    public static class Constant
    {
        public static class SessionKey
        {
            public const string RedisNamespace = "session";
            public const string SessionId = "sessionId";
            public const string UserId = "userId";
            public const string JsonUser = "jsonUser";
        }

        public static class Status
        {
            public const string TypeSuccess = "Success";
            public const string TypeError = "Error";
        }

        public static class ConfigKey
        {
            public const string ApiHost = "API.Host";
            public const string ApiUrlLogin = "API.Url.Login";
            public const string ApiUrlProduct = "API.Url.Product";
            public const string ApiUrlProductCategory = "API.Url.ProductCategory";
            public const string ApiUrlTransaction = "API.Url.Transaction";
            public const string ApiUrlTransactionGetHold = "API.Url.Transaction.GetHold";
            public const string ApiUrlTransactionReport = "API.Url.Transaction.Report";
            public const string ApiUrlDiscount = "API.Url.Discount";
            public const string ApiUrlUser = "API.Url.User";
            public const string ApiUrlFileUpload = "API.Url.FileUpload";

            public const string RouteDefaultController = "Route.Default.Controller";
            public const string RouteDefaultAction = "Route.Default.Action";

            public const string RedisOption = "Redis.Option";
            public const string SessionIdLifeTime = "Session.LifeTime";

            public const string BrandAddress = "Brand.Address";
            public const string BrandName = "Brand.Name";
        }

        public static class ViewDataKey
        {
            public const string ErrorMessage = "ErrorMessage";
            public const string Title = "Title";
            public const string UserName = "UserName";
            public const string UserId = "UserId";
        }

        public static class PaymentType
        {
            public const string Cash = "Cash";
            public const string Card = "Card";
            public const string Other = "Other";
        }

        public static class PaymentStatus
        {
            public const string Hold = "Hold";
            public const string Paid = "Paid";
        }

        public static class DiscountType
        {
            public const string Percentage = "Percentage";
            public const string Amount = "Amount"; 
        }

        public static class UserRole
        {
            public const string Admin = "admin";
            public const string Cashier = "cashier";
        }

        public static class UserGender
        {
            public const string MaleKey = "Male";
            public const string FemaleKey = "Female";
            public const char MaleValue = 'L';
            public const char FemaleValue = 'P';
        }
    }
}
