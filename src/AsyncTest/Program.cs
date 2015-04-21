using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace AsyncTest
{
    public class Program
    {
        //////static void Main(string[] args)
        //////{
        //////    Task<string> task = MyDownloadPageAsync("http://huan-lin.blogspot.com");

        //////    string content = task.Result; // 取得非同步工作的結果。

        //////    Console.WriteLine("網頁內容總共為 {0} 個字元。", content.Length);
        //////    Console.ReadKey();
        //////}

        //////static async Task<string> MyDownloadPageAsync(string url)
        //////{
        //////    var webClient = new WebClient();  // 須引用 System.Net 命名空間。
        //////    Task<string> task = webClient.DownloadStringTaskAsync(url); 
        //////    Console.WriteLine("=== 1 ===");
        //////    string content = await task;
        //////    return content;
        //////}

        static void Main(string[] args)
        {
            ////Console.WriteLine("=== Do Something {0} ===", DateTime.Now);
            Console.WriteLine("=== first === {0}", Getint());

            Task<string> task = doSomething();


            Console.WriteLine("=== 5 === 等 doSomething {0}", Getint());

            string sum = task.Result;

            Console.WriteLine("=== final === {0}", Getint());
            Console.WriteLine("=== Result {0} ===", sum);
            Console.Read();
        }

        static async Task<string> doSomething()
        {
            Console.WriteLine("=== 1 === 開始 doSomething {0}", Getint());

            ////Task<string> sum = GetSum();

            Console.WriteLine("=== 2 === 開始 sum {0}", Getint());

            Console.WriteLine("=== 3 === 等 doSomething {0}", GetStr());

            string content = await Task.Run(() => { return GetSum(); });

            Console.WriteLine("=== 4 === 取得 sum {0}", Getint());
            return content;
        }

        static string GetSum()
        { 
            int sum1 = 0;
            for (int i = 0; i < int.MaxValue; i++)
            {
                sum1 += i + 1;
            } 
            return sum1.ToString(); 
        }

        static int Getint()
        {
            Random rint = new Random(Guid.NewGuid().GetHashCode());
            return rint.Next(1, 100);
        }

        static string GetStr()
        {
            return "Get a string ";
        }
    }
}
