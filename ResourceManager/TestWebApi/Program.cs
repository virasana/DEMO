using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using ResourcesWebApiHost;

namespace TestWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            const string baseAddress = "http://localhost:5000/";

            using (WebApp.Start<Startup>(baseAddress))
            {
                var client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/Resuorces/GetAllResources").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }

            Console.ReadLine(); 
        }
    }
}
