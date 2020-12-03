using System.Collections.Generic;

namespace Bussines
{
    public class RetoOptimizado
    {
        public static int Calcular1(List<string> datos)
        {
            int result = 0;
            var ancho = datos[0].Length;
            int j = 3;
            for (int i = 1;  i < datos.Count; i++)
            {
                result += Cond(datos[i][j]);
                j += 3;
                j %= ancho;
            }
            return result;
        }

        public static long Calcular2(List<string> datos, int rigth, int down)
        {
            long result = 0;
            int j = rigth;
            int ancho = datos[0].Length;
            for (int i = down; i < datos.Count; i += down)
            {
                result += Cond(datos[i][j]);
                j += rigth;
                j %= ancho;
            }
            return result;
        }

        private static int Cond(char c) => c == '#' ? 1 : 0;
    }
}
