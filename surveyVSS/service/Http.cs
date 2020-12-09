using surveyVSS.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace surveyVSS.service
{
    class Http
    {
        static HttpClient client = new HttpClient();
        static String urlResponse = "http://localhost:8089";


        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri(urlResponse);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


        }

        static async Task<Uri> CreateSurveyAsync(Survey survey)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/products", survey);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }
    }
}
