using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AsyncAwaitCompareWithContinueWith
{
    public class AsyncClass
    {
        public async Task<int> HandleFileAsync(string file)
        {
            var count = 0;

            using (var reader = new StreamReader(file))
            {
                string data = await reader.ReadToEndAsync();
                count += data.Length;

                for (var value = 0; value< 10000; value++)
                {
                    int getHashCoed = data.GetHashCode();
                    if (getHashCoed == 0)
                    {
                        count--;
                    }
                }
            }
            return count;
        }
    }
}
