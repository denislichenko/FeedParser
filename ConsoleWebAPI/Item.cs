using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleWebAPI
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Item
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        [JsonProperty(PropertyName = "publishDate")]
        public DateTime PublishDate { get; set; }

        [JsonProperty(PropertyName = "feedType")]
        public string FeedType { get; set; }
    }
}
