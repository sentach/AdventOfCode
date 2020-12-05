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
                if (string.IsNullOrEmpty(line))
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

        public static List<Dictionary<string, string>> Lector1(string file)
        {
            var result = new List<Dictionary<string, string>>();

            string buffer = string.Empty;
            using var reader = File.OpenText(file);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if(string.IsNullOrEmpty(line))
                {
                    result.Add(CreaDic(buffer));
                    buffer = string.Empty;
                }
                else
                {
                    buffer += " " + line;
                }
            }
            result.Add(CreaDic(buffer));
            return result;
        }

        private static Dictionary<string,string> CreaDic(string buff)
        {
            var dic = new Dictionary<string, string>();
            foreach(var item in buff.Trim().Split(" "))
            {
                var dato = item.Split(":");
                dic[dato[0]] = dato[1];
            }
            return dic;
        }
        
        public static List<Passport2> Lector2(string file)
        {
            var result = new List<Passport2>();
            string buffer = string.Empty;
            using var reader = File.OpenText(file);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if(string.IsNullOrEmpty(line))
                {
                    result.Add(new Passport2(buffer));
                    buffer = string.Empty;
                }
                else
                {
                    buffer += " " + line;
                }
            }
            result.Add(new Passport2(buffer));
            return result;
        }
    }
}
