using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitCompareWithContinueWith
{
    public class ContinueWithClass
    {
        public Task<int> HandleFileContinueWith(string file)
        {
            Task<int> task;
            using (var reader = new StreamReader(file))
            {
                int count = 0;
                task = reader
                    .ReadToEndAsync()
                    .ContinueWith(x =>
                    {
                            string data = x.Result;
                            count += data.Length;
                            for (var value = 0; value < 10000; value++)
                            {
                                int getHashCoed = data.GetHashCode();
                                if (getHashCoed == 0)
                                {
                                    count--;
                                }
                            }
                       
                        return count;
                    });
                task.Wait(1000);
            }

            return task;
        }

    }
}
