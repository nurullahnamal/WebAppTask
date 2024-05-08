using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTask.Console
{
    public class WebApiClient
    {
        private const string url = "https://localhost:5001/api/test/";

        public async Task CallAsync()
        {
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri(url)
            };
            await httpClient.GetAsync("Async");
        }


        public async Task CallSync()
        {
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri(url)
            };
            await httpClient.GetAsync("Sync");
        }
    }
}
