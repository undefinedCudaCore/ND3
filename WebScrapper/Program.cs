using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebScrapper
{
    class Program
    {

        static async Task Main(string[] args)
        {
            //var items = new List<SellableItem>();

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos");
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            //var responseObject = JsonConvert.DeserializeObject<List<Job>>(responseBody);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(responseBody);

            var links = htmlDoc.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "")
                .Contains("offer_primary_info")).ToList();

            var child = links.Select(l => l.FirstChild.FirstChild.InnerHtml).ToList();

            
            for (int i = 0; i < child.Count(); i++)
            {
                if(child[i] == "NET DEVELOPER")
                {
                    Console.WriteLine(child[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
