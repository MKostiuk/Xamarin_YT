using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public RestConsumer()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 2560000;
        }

        public async Task<List<Post>> Request()
        {
            var uri = new Uri(String.Format("https://jsonplaceholder.typicode.com/posts", String.Empty));

            var response = await client.GetAsync(uri).ConfigureAwait(false);
            
           if (response.StatusCode != HttpStatusCode.OK)
           {
                Console.Write("Erreur récupération données. Code statuts retourné par le serveur : {0}", response.StatusCode);
                throw new IOException();
           }

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Post>>(content);
        }
        

    }
}
