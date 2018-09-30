using Newtonsoft.Json;

namespace Uarung.Model
{
    public class Status
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        public void SetSuccess(string message = "OK")
        {
            Code = "200";
            Message = message;
            Type = Constant.Status.TypeSuccess;
        }
        
        public void SetError(string message = "Unknown Error Occured")
        {
            Code = "999";
            Message = message;
            Type = Constant.Status.TypeError;
        }

        public void SetError(System.Exception e) 
        {
            SetError($"{e.Message} | {e.InnerException?.Message} | {e.StackTrace}");
        }
    }
}