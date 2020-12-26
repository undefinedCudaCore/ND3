using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomeWorkThreeDotOne
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var items = new List<SellableItem>();

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            var responseObject = JsonConvert.DeserializeObject<List<User>>(responseBody);

            int countId = 0;

            for (int i = 0; i < responseObject.Count; i++)
            {
                countId++;

                if (responseObject[i].Name == "Mrs. Dennis Schulist")
                {
                    break;
                }
            }

            items = new List<SellableItem>();

            httpClient = new HttpClient();

            response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/photos");
            response.EnsureSuccessStatusCode();

            responseBody = await response.Content.ReadAsStringAsync();

            var responseObjectTwo = JsonConvert.DeserializeObject<List<Photo>>(responseBody);

            var linqIds = responseObjectTwo.Where(item => item.albumId == countId).Select(item => item.Url).ToList();

            for (int i = 0; i < linqIds.Count(); i++)
            {
                Console.WriteLine(linqIds[i]);
            }


            Console.ReadLine();

                
        }
    }
}
