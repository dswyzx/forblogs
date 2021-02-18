using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        static ManualResetEvent manualResetEvent = new ManualResetEvent(false);

        static async Task Main(string[] args)
        {
            string url = "https://localhost:44343/home/GetUserInfo";

            string tes = "k=1%2b1";

            //string oth = HttpUtility.UrlEncode(tes);
            //string oth1 = HttpUtility.UrlDecode(oth);
            //string oth2 = HttpUtility.UrlDecode(tes);

            HttpClient client = new HttpClient();
            var hc = new StringContent(tes, Encoding.UTF8, "application/x-www-form-urlencoded");
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = hc;

            HttpResponseMessage response = await client.PostAsync(url, hc);
            string ret = await response.Content.ReadAsStringAsync();
            Console.WriteLine(ret);

        }
    }
}
