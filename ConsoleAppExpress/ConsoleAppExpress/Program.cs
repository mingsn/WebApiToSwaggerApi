using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppExpress
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static object onlock = new object();
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Parallel.For(1, 100, (p)=> {
                Console.WriteLine(HttpPostAsync(p));
            });
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        static void WriteLine(int index)
        {
            lock (onlock)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"这是第 {index} 个 write line");
            }
        }

        static string HttpPostAsync(int p)
        {
            //发送Get请求
            //var responseGetString = await client.get($"https://localhost:44312/api/ParallelTest/ParallelInvoke?p={p}");
            //发送Post请求
            //var values = new Dictionary<string, string>{
            //   { "thing1", "hello" },
            //   { "thing2", "world" }
            //};
            //var content = new FormUrlEncodedContent(values);
            //var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);
            //var responsePostString = await response.Content.ReadAsStringAsync();
            //$"https://easy-mock.com/mock/5bf75bdf5cfdd6564a60da2b/example/patest"
            var request = (HttpWebRequest)WebRequest.Create($"https://localhost:44312/api/ParallelTest/ParallelInvoke?p={p}");
            //request.Method = "POST";
            //request.ContentType = "application/x-www-form-urlencoded";
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }
    }
}
