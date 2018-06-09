using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kodisoft_Test.Extensions;
using Kodisoft_Test.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodisoft_Test.Controllers
{
    [Produces("application/json")]
    [Route("api/Feed")]
    public class FeedController : Controller
    {
        // GET: https://localhost/api/Feed/{type}
        // types: ukraina, world, politics, crime, health, sport, culture, stories, life-stories, money, society, style, all

        [HttpGet("{type}")]
        public IList<ItemModel> Get(string type)
        {
            FeedParse feedParse = new FeedParse();
            var items = feedParse.Parse("http://fakty.ua/rss_feed/" + type, FeedType.RSS);

            return items;
        }
    }
}