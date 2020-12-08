using System;
using System.Collections.Generic;
using System.IO;

namespace Bussines
{
    public class Reader
    {
        public static List<string> Lector1(string file)
        {
            var result = new List<string>();
            using var reader = File.OpenText(file);
            while(!reader.EndOfStream)
            {
                result.Add(reader.ReadLine());
            }
            return result;
        }
    }
}
