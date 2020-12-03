﻿using System.Collections.Generic;
using System.IO;

namespace Bussines
{
    public static class Reader
    {
        public static int[,] Lector(string file)
        {
            var buffer = new List<string>();
            using var reader = File.OpenText(".\\datos.txt");
            {
                while (!reader.EndOfStream)
                {
                    buffer.Add(reader.ReadLine());
                }
            }

            int largo = buffer.Count;
            int ancho = buffer[0].Length;
            int veces = ((largo * 7) / ancho) + 1;
            
            var result = new int[largo, ancho * veces];
            int i = 0;
            foreach(var item in buffer)
            {
                var temp = new int[ancho];
                int itemp = 0;
                foreach(var c in item)
                {
                    temp[itemp++] = c == '.' ? 0 : 1;
                }
                int j = 0;
                for(int jtemp=0;jtemp<veces;jtemp++)
                {
                    for(int k=0;k<ancho;k++)
                    {
                        result[i, j++] = temp[k];
                    }
                }
                i++;
            }
            return result;
        }
    }
}
