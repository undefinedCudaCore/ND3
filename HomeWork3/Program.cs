using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            var responseObject = JsonConvert.DeserializeObject<List<Post>>(responseBody);

            Console.ReadLine();
        }
    }
}
