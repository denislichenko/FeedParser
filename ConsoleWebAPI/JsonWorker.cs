using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ConsoleWebAPI
{
    public static class JsonWorker
    {
        public static IList<Item> DeserializeJson(string type)
        {
            string StreamStr = GetJson(type);
            var stuff = JsonConvert.DeserializeObject<IList<Item>>(StreamStr);

            return stuff;
        }

        public static string GetJson(string type)
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.Accept] = "application/json";
                string result = client.DownloadString("https://localhost:44361/api/Feed/" + type);

                return result;
            }
        }
    }
}
