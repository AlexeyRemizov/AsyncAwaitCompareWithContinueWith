using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitCompareWithContinueWith
{
    class Program
    {
        public static void Main(string[] args)
        {
            string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            string file = filePath + @"\1.txt";


            var asyncClassInstance = new AsyncClass();
            var task = asyncClassInstance.HandleFileAsync(file);
            task.Wait();
            var count = task.Result;
            Console.WriteLine("Count = {0}, with using Async/Await", count);


            var continueWithClassInstance = new ContinueWithClass();
            var taskContinueWith = continueWithClassInstance.HandleFileContinueWith(file);
            taskContinueWith.Wait();
            var countContinueWith = taskContinueWith.Result;
            Console.WriteLine("Count = {0}, with using ContinueWith",countContinueWith);


            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}
