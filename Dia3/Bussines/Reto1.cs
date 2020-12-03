using System;

namespace Bussines
{
    public class Reto1
    {
        public static int Calcular1(int[,] datos)
        {
            int result = 0;
            int j = 3;
            for(int i=1; i < datos.GetLength(0); i++)
            {
                result += datos[i, j];
                j += 3;
            }
            return result;
        }

        public static long Calcular2(int[,] datos, int rigth, int down)
        {
            long result = 0;
            int j = rigth;
            for(int i=down; i<datos.GetLength(0); i+=down)
            {
                result += datos[i, j];
                j += rigth;
            }
            return result;
        }
    }
}
