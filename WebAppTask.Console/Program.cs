using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WebAppTask.Console
{
    internal class Program
    {
         static async Task Main(string[] args)
        {
            do
            {
                AddLog("App is running... ");

                System.Console.WriteLine("Request Type (Sync = 0, Async =1 ): ");

                int requestType = int.Parse(System.Console.ReadLine());

                System.Console.WriteLine("How mant request : ");

                int requestcount=int.Parse(System.Console.ReadLine());

                var tasks=requestType==0 ? GetSyncTasks(requestcount) : GetAsyncTasks(requestcount);

                var sw = Stopwatch .StartNew();

                await Task.WhenAll(tasks);

                sw.Stop();
                AddLog($"Total Time : {sw.ElapsedMilliseconds} MS");


            } while (System.Console.ReadKey().Key== System.ConsoleKey.R);

        }

        public static IEnumerable<Task> GetSyncTasks(int howMany)
        {
            var result = new List<Task>();
            var clinet = new WebApiClient();
            for (int i = 0; i < howMany; i++)
            {
                result.Add(clinet.CallSync());
            }
            return result;
        }


        public static IEnumerable<Task> GetAsyncTasks(int howMany)
        {
            var result = new List<Task>();
            var clinet = new WebApiClient();
            for (int i = 0; i < howMany; i++)
            {
                result.Add(clinet.CallAsync());
            }
            return result;
        }

        private static void AddLog(string logStr)
        {
            logStr = $"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}] - {logStr}";
            System.Console.WriteLine (logStr);
        }
    }
}
