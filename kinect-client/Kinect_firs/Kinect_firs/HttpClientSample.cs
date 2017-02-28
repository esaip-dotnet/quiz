using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Kinect_firs
{
    public class HttpClientSample
    {
        static HttpClient client = new HttpClient();
        static async Task RunAsync()
            {
                String addressAPI = "localhost";
                client.BaseAddress = new Uri("http://"+addressAPI+":80/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Console.ReadLine();
            }
            static async Task<Quiz> GetProductAsync(string path)
            {
                Quiz quiz = null;
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    quiz = await response.Content.ReadAsAsync<Quiz>();
                }
                return quiz;
            }
    }
}
