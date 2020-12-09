using System;
using System.Collections.Generic;
using System.IO;

namespace Bussines
{
    public class Reader
    {
        public static List<long> Lector1(string filename)
        {
            var result = new List<long>();
            using var reader = File.OpenText(filename);
            while (!reader.EndOfStream)
            {
                result.Add(Convert.ToInt64(reader.ReadLine()));
            }
            return result;
        }
    }
}
