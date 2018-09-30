using System.Collections.Generic;
using Newtonsoft.Json;

namespace Uarung.Model
{
    public class CollectionResponse<T> : BaseReponse
    {
        [JsonProperty("collection")]
        public List<T> Collection { get; set; }
    }
}