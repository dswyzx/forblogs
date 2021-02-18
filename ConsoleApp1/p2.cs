using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class Program
    {
        static async Task Main(string[] args)
        {

            Dictionary<string, string> formData = new Dictionary<string, string>();
            var ms = new MemoryStream();
            formData.FillFormDataStream(ms); //填充formData
            HttpContent hcDic = new StreamContent(ms);

            //string oth = HttpUtility.UrlEncode(tes);
            //string oth1 = HttpUtility.UrlDecode(oth);
            //string oth2 = HttpUtility.UrlDecode(tes);


            string url = "https://localhost:44343/home/GetUserInfo";
            string tes = "k=1%2b1";
            HttpClient client = new HttpClient();
            var hc = new StringContent(tes, Encoding.UTF8, "application/x-www-form-urlencoded");
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = hc;

            HttpResponseMessage response = await client.PostAsync(url, hc);
            string ret = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"post:({tes}),return:({ret})");
            Console.ReadKey();

        }

        public static void FillFormDataStream(this Dictionary<string, string> formData, Stream stream)
        {
            string dataString = GetQueryString(formData);
            byte[] formDataBytes = formData == null ? new byte[0] : Encoding.UTF8.GetBytes(dataString);
            stream.Write(formDataBytes, 0, formDataBytes.Length);
            stream.Seek(0, SeekOrigin.Begin); //设置指针读取位置
        }

        public static string GetQueryString(this Dictionary<string, string> formData)
        {
            if (formData == null || formData.Count == 0) return "";
            var sb = new StringBuilder();
            var i = 0;
            foreach (KeyValuePair<string, string> kv in formData)
            {
                i++;
                sb.AppendFormat("{0}={1}", kv.Key, kv.Value);
                if (i < formData.Count) sb.Append("&");
            }
            return sb.ToString();
        }
    }
}
