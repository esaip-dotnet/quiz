using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebClientCore.Extensions
{
    //Classe permettant de gérer la méthode HTTP PATCH ainsi que d'avoir accès aux autres méthodes
    public static class HttpClientEx
    {
        public const string MimeJson = "application/json";

        //La méthode PatchAsync n'éxistant pas de base dans visual studio,
        //Il faut la rajouter
        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                RequestUri = new Uri(client.BaseAddress + requestUri),
                Content = content,
            };

            return client.SendAsync(request);
        }

        //Permet d'éxecuter une méthode POST sur une uri
        public static Task<HttpResponseMessage> PostJsonAsync(this HttpClient client, string requestUri, object value)
        {
            return client.PostAsync(requestUri, new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, MimeJson));
        }

        //Permet d'éxecuter une méthode PUT sur une uri
        public static Task<HttpResponseMessage> PutJsonAsync(this HttpClient client, string requestUri, object value)
        {
            return client.PutAsync(requestUri, new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, MimeJson));
        }

        //Permet d'éxecuter une méthode PATCH sur une uri
        public static Task<HttpResponseMessage> PatchJsonAsync(this HttpClient client, string requestUri, object value)
        {
            return client.PatchAsync(requestUri, new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, MimeJson));
        }
    }
}
