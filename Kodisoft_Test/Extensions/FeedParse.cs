using Kodisoft_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kodisoft_Test.Extensions
{
    public class FeedParse
    {
        public IList<ItemModel> Parse(string url, FeedType feedType)
        {
            switch(feedType)
            {
                case FeedType.RSS: return ParseRss(url);
                case FeedType.Atom: return ParseAtom(url);
                default: throw new NotSupportedException("Error");
            }
        }

        public virtual IList<ItemModel> ParseRss(string url)
        {
            try
            {
                XDocument doc = XDocument.Load(url);
                var entries = from item in doc.Root.Descendants().First(i => i.Name.LocalName == "channel").Elements().Where(i => i.Name.LocalName == "item")
                              select new ItemModel
                              {
                                  FeedType = FeedType.RSS,
                                  Content = item.Elements().First(i => i.Name.LocalName == "description").Value,
                                  Link = item.Elements().First(i => i.Name.LocalName == "link").Value,
                                  PublishDate = ParseDate(item.Elements().First(i => i.Name.LocalName == "pubDate").Value),
                                  Title = item.Elements().First(i => i.Name.LocalName == "title").Value
                              };

                return entries.ToList();
            }
            catch
            {
                return new List<ItemModel>();
            }
        }

        public virtual IList<ItemModel> ParseAtom(string url)
        {
            try
            {
                XDocument doc = XDocument.Load(url);
                var entries = from item in doc.Root.Elements().Where(i => i.Name.LocalName == "entry")
                              select new ItemModel
                              {
                                  FeedType = FeedType.Atom,
                                  Content = item.Elements().First(i => i.Name.LocalName == "feedEntryContent").Value,
                                  Link = item.Elements().First(i => i.Name.LocalName == "link").Attribute("href").Value,
                                  PublishDate = ParseDate(item.Elements().First(i => i.Name.LocalName == "lastUpdated").Value),
                                  Title = item.Elements().First(i => i.Name.LocalName == "title").Value
                              };
                return entries.ToList();
            }
            catch
            {
                return new List<ItemModel>();
            }
        }

        private DateTime ParseDate(string value)
        {
            DateTime result;
            if (DateTime.TryParse(value, out result))
                return result;
            else
                return DateTime.MinValue;
        }
        
    }
}
