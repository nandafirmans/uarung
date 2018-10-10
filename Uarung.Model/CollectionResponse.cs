using System.Collections.Generic;
using Newtonsoft.Json;

namespace Uarung.Model
{
    public class CollectionResponse<T> : BaseReponse
    {
        [JsonProperty("collections")]
        public List<T> Collections { get; set; }
    }
}