using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace KanyeSwanson
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = InitializeHttpClient();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(GetKanyeQuote(client));
                Console.WriteLine(GetSwansonQuote(client));            
            }

            


        }

        private static string GetSwansonQuote(HttpClient client)
        {
            var jtext = client
                .GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;

            var quote = JArray.Parse(jtext).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

            return quote;
        }

        private static string GetKanyeQuote(HttpClient client)
        {
            var jtext = client.GetStringAsync("https://api.kanye.rest/").Result;

            var quote = JObject.Parse(jtext).GetValue("quote").ToString();
            return quote;
        }

        private static HttpClient InitializeHttpClient()
        {
            return new HttpClient();
        }
    }
}
