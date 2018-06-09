using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kodisoft_Test.Models
{
    public enum FeedType { RSS, Atom }

    public class ItemModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public DateTime PublishDate { get; set; }
        public FeedType FeedType { get; set; }
    }
}
