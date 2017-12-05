using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Calculator
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public int Add()
        {
            return FirstNumber + SecondNumber;
        }
        //public async void RetrievePage(string url)
        //{
        //    Task<string> getPageTask = GetPage(url);
        //    Console.WriteLine("Point 1");
        //    string page = await getPageTask;
        //    int length = page.Length;
        //    Console.WriteLine("Point 2");
        //}
        //private async Task<string> GetPage(string url)
        //{
        //    //Task<string> getString = (new HttpClient()).GetStringAsync(url);
        //    Console.WriteLine("Point 3");
        //   // string webText = await getString;
        //    Console.WriteLine("Point 4");
        //    return webText;
        //}
    }
}
