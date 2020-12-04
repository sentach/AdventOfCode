using System.Collections.Generic;
using System.IO;

namespace Bussines
{
    public class Reader
    {
        public static List<string> Lector(string file)
        {
            var result = new List<string>();
            string buffer = string.Empty;
            using var reader = File.OpenText(file);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if(string.IsNullOrEmpty(line))
                {
                    result.Add(buffer.Trim());
                    buffer = string.Empty;
                }
                else
                {
                    buffer += " " + line;
                }
            }
            result.Add(buffer.Trim());
            return result;
        }
    }
}
