using System;

namespace Bussines
{
    public class Reto1
    {
        public static int Calcular(int[,] datos)
        {
            int result = 0;
            int j = 3;
            for(int i=1; i < datos.GetLength(0); i++)
            {
                if (datos[i, j] == 1) { result++; }
                j += 3;
            }
            return result;
        }
    }
}
