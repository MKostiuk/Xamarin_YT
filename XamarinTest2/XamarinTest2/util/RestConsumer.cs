using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using XamarinTest2.objects;

namespace XamarinTest2.util
{
    class RestConsumer
    {

        HttpClient client;
        public List<Post> Posts { get; set; }

        public RestConsumer()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 2560000;
            Posts = new List<Post>();
        }

        public async Task<List<Post>> Request()
        {
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

            try
            {
                var response = await client.GetAsync("posts/");

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    Console.Write("Erreur récupération données. Code statuts retourné par le serveur : {0}", response.StatusCode);
                    throw new IOException();
                }

                var content = await response.Content.ReadAsStringAsync();
                Posts = JsonConvert.DeserializeObject<List<Post>>(content);
            } catch (Exception ex)
            {
                Debug.WriteLine(@"              ERROR {0}", ex.Message);    
            }
            return Posts;
        }
        

    }
}
