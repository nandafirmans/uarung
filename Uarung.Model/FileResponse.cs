using System.Collections.Generic;
using Newtonsoft.Json;

namespace Uarung.Model
{
    public class FileResponse : BaseReponse
    {
        public FileResponse()
        {
            ListPath = new List<string>();
        }

        [JsonProperty("listpath")]
        public List<string> ListPath { get; set; }
    }
}