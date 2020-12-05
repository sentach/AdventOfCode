using System;
using System.Collections.Generic;

namespace Bussines
{
    public class Reto5
    {
        public static int Resuelve1(List<string> datos)
        {
            var result = 0;
            foreach(var dato in datos)
            {
                var id = CalculaId(dato);
                result = Math.Max(id, result);
            }
            return result;
        }

        public static int CalculaId(string dato)
        {
            int row = 0;
            for (int i = 0; i < 7; i++)
            {
                if (dato[i] == 'B') 
                {
                    row += 1 << (6 - i);                    
                }
            }
            int col = 0;
            for (int j = 7; j < 10; j++)
            {
                if (dato[j] == 'R')
                {
                    col += 1 << (9 - j);
                }
            }
            
            return row * 8 + col;
        }

        public static int Resuelve2(List<string> datos)
        {
            return 0;
            /*var result = 7;
            foreach(dato in datos.OrderByDescending(x=>x.Replace("L","S"))
            */
        }
    }
}
