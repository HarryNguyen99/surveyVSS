using surveyVSS.Infrastructure.Rest;
using surveyVSS.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace surveyVSS.service
{
    public  class HttpHelpers : CustomHttpClient
    {
        //static HttpClient client = new HttpClient();
        //static String urlResponse = "http://localhost:8089";
        //private const string URL = "https://jsonplaceholder.typicode.com/posts/1/comments";
        private const string urlParameters = "";

        public  async Task PostAsync(string URL, object t)
        {
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, URL)
            //{
            //    Version = new Version("6.0")
            //};
            //request.Content = new StringContent(NewtonJson.Serialize(t), Encoding.UTF8, "application/json");

            //var res = await PostAsync<dynamic>(URL, null, t);
            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                var response = client.PostAsJsonAsync("posts", t).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                }
                else
                    Console.Write("Error");
            }


        }
        

        public static async Task RunAsync(string URL)
        {
           

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(URL)
            };

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects =  response.Content.ReadAsAsync<dynamic>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                foreach (var d in dataObjects)
                {
                    //Console.WriteLine("{0}", d.Name);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
        }




        //static async Task<Uri> CreateSurveyAsync(Survey survey)
        //{
        //    //HttpResponseMessage response = await client.PostAsJsonAsync(
        //    //    "api/products", survey);
        //    //response.EnsureSuccessStatusCode();

        //    //// return URI of the created resource.
        //    //return response.Headers.Location;

        //}
    }
}
