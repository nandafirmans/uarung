using System.Collections.Generic;
using Newtonsoft.Json;

namespace Uarung.Model
{
    public class FileResponse : BaseResponse
    {
        public FileResponse()
        {
            ListPath = new List<string>();
        }

        [JsonProperty("listpath")]
        public List<string> ListPath { get; set; }
    }
}