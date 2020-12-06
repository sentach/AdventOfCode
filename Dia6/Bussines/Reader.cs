using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bussines
{
    public class Reader
    {
        public static List<string> Lector1(string file)
        {
            var result = new List<string>();
            var buffer = string.Empty;
            using var reader = File.OpenText(file);
            while(!reader.EndOfStream)
            {
                var temp = reader.ReadLine();
                if(string.IsNullOrEmpty(temp))
                {
                    buffer = string.Join(null, buffer.ToCharArray().Distinct());
                    result.Add(buffer);
                    buffer = string.Empty;
                }
                else
                {
                    buffer += temp;
                }
            }
            buffer = string.Join(null, buffer.ToCharArray().Distinct());
            result.Add(buffer);
            return result;
        }
        public static List<string> Lector2(string file)
        {
            var result = new List<string>();
            var buffer = string.Empty;
            using var reader = File.OpenText(file);
            while (!reader.EndOfStream)
            {
                var temp = reader.ReadLine();
                if (string.IsNullOrEmpty(temp))
                {
                    result.Add(Procesa(buffer.Trim()));
                    buffer = string.Empty;
                }
                else
                {
                    buffer += " " + temp;
                }
            }
            result.Add(Procesa(buffer.Trim()));
            return result;
        }

        private static string Procesa(string buffer)
        {
            var result = string.Empty;
            var datos = buffer.Split(" ");
            for (int i=0; i<datos[0].Length;i++)
            {
                var esta = true;
                var current = datos[0][i];
                for(int j=1;j<datos.Length;j++)
                {
                    if(!datos[j].Contains(current))
                    {
                        esta = false;
                        break;
                    }
                }
                if(esta)
                {
                    result += current;
                }
            }
            return result;
        }
    }
}
