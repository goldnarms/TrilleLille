using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using TrilleLille.Web.Models;

namespace TrilleLille.Web.Services
{
    public class RssReader :IRssReader
    {
        public async Task<IEnumerable<RssFeed>> ReadFeed()
        {
            var client = new HttpClient();
            var stream = await client.GetStreamAsync("http://trillelilleblog.azurewebsites.net/feed/");
            XDocument feedXml = XDocument.Load(stream);
            var feeds = from feed in feedXml.Descendants("item").Take(6)
                        select new RssFeed
                        {
                            Title = feed.Element("title")?.Value,
                            Link = feed.Element("link")?.Value,
                            ImageUrl = feed.Element("image")?.Value,
                            Description = Regex.Match(feed.Element("description")?.Value, @"^.{1,580}\b(?<!\s)").Value //feed.Element("description").
                        };
            return feeds;
        }
    }
}
